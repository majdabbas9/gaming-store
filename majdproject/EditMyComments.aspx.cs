using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditMyComments : System.Web.UI.Page
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
    public void FillGrid()
    {
        GridViewComments.DataSource = Classcontactus.GetAllCommentsByUserID(Session["UserID"].ToString());
        GridViewComments.DataBind();
    }
    protected void GridViewComments_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewComments.EditIndex = -1;
        FillGrid();
    }
    protected void GridViewComments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("RowDelete"))
        {
            Classcontactus.DeleteByID(e.CommandArgument.ToString());
            FillGrid();
        }
         
    }
    protected void GridViewComments_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewComments.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void GridViewComments_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Label lb = (Label)GridViewComments.Rows[e.RowIndex].FindControl("LabelCID");
        TextBox TN = (TextBox)GridViewComments.Rows[e.RowIndex].FindControl("TextBoxN");
        TextBox TT = (TextBox)GridViewComments.Rows[e.RowIndex].FindControl("TextBoxT");
        TextBox TB = (TextBox)GridViewComments.Rows[e.RowIndex].FindControl("TextBoxB");
        Classcontactus.Update(lb.Text,TN.Text,TT.Text,TB.Text);
        GridViewComments.EditIndex = -1;
        FillGrid();
    }
}