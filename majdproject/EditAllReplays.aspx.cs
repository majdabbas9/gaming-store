using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditAllReplays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductID"] == null)
            Response.Redirect("ViewProduct.aspx");
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    public void FillGrid()
    {
        GridViewAR.DataSource = ClassReplays.ShowAllReplays(Request.QueryString["ProductID"].ToString());
        GridViewAR.DataBind();
    }
    protected void GridViewAR_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("RowDeleting"))
        {
            string ReplayID = e.CommandArgument.ToString();
            ClassReplays.Delete(ReplayID);
            FillGrid();
        }
    }
}