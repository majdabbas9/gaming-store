using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditReplays : System.Web.UI.Page
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
        GridViewST.DataSource = ClassProduct.GetAll();
        GridViewST.DataBind();
    }
    protected void GridViewST_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("ShowAllReplays"))
        {
            string str = "EditAllReplays.aspx?ProductID=" + e.CommandArgument.ToString();
            Response.Redirect(str);
        }
    }
}