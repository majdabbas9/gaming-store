using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddToMyCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false)
        {
            Response.Redirect("ViewProduct.aspx");
        }
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    public  void FillGrid()
    {
        if (Session["UserID"] != null)
        {
            string UserID =Session["UserID"].ToString();
            GridViewCart.DataSource = ClassCart.ShowMyProduct(UserID.ToString());
            GridViewCart.DataBind();
        }
        else
        {
            return;
        }
    }
    protected void GridViewCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lb = (Label)GridViewCart.Rows[e.RowIndex].FindControl("LabelC");
        ClassCart.Delete(lb.Text);
        FillGrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = ClassCart.ShowMyProduct(Session["UserID"].ToString());
        if (dt.Rows.Count > 0)
        {
            Response.Redirect("PayPage.aspx");
        }
    }
}