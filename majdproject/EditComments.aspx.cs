using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditComments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false || ((bool)Session["Admin1"] == false))
        {
            Response.Redirect("ViewProduct.aspx");
        }
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    public void FillGrid()
    {
        if (Session["UserID"] != null)
        {
            GridViewComments.DataSource = Classcontactus.GetAll();
            GridViewComments.DataBind();
        }
    }

    protected void GridViewComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label CID = (Label)GridViewComments.Rows[e.RowIndex].FindControl("LabelCID");
        Classcontactus cc = new Classcontactus();
        cc.CommentID = CID.Text;
        cc.Delete();
        FillGrid();
    }
}