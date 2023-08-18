using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowAllReplays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductID"] == null)
        {
            Response.Redirect("ViewProduct");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    public void fillgrid()
    {
        string str = Request.QueryString["ProductID"].ToString();
        GridViewST.DataSource = ClassProduct.GetAllByID(str);
        GridViewST.DataBind();
        GridViewAR.DataSource = ClassReplays.ShowAllReplays(str);
        GridViewAR.DataBind();
    }
}