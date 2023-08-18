using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false || ((bool)Session["Admin1"] == false))
        {
            Response.Redirect("ViewProduct.aspx");
        }
        if (!IsPostBack)
        {
            fillGrid();
        }
    }
    public void fillGrid()
    {
        GridViewUsers.DataSource = ClassUser.GetAll();
        GridViewUsers.DataBind();
    }
    protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ClassUser cu = new ClassUser();
        Label CID = (Label)GridViewUsers.Rows[e.RowIndex].FindControl("LabelUID");
        cu.UserID = CID.Text;
        cu.Delete();
        fillGrid();
    }
}