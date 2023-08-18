using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class EditTypes : System.Web.UI.Page
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
        GridViewTypes.DataSource = ClassTypes.GetAll();
        GridViewTypes.DataBind();
    }
    protected void GridViewTypes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewTypes.EditIndex = -1;
        fillGrid();
    }
    protected void GridViewTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lb = (Label)GridViewTypes.Rows[e.RowIndex].FindControl("LabelTID");
        DataTable dt = ClassTypes.GetAllTypesByID(lb.Text);
        string strRealPath = Request.PhysicalApplicationPath;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            System.IO.File.Delete(strRealPath + dt.Rows[i]["Photo"].ToString());
        }
            ClassTypes.Delete(lb.Text);
        fillGrid();
    }
    protected void GridViewTypes_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox TB = (TextBox)GridViewTypes.Rows[e.RowIndex].FindControl("TextBoxEditTN");
        if (ClassTypes.IsExist(TB.Text))
        {
            LabelMSG.Text = "This Type esist";
            return;
        }
        Label L = (Label)GridViewTypes.Rows[e.RowIndex].FindControl("LabelTID");
        ClassTypes.Update(TB.Text,L.Text);
        GridViewTypes.EditIndex = -1;
        fillGrid();   
    }
    protected void GridViewTypes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Insert"))
        {
            TextBox TextBoxTN = (TextBox)GridViewTypes.FooterRow.FindControl("TextBoxFooterTN");
            if (ClassTypes.IsExist(TextBoxTN.Text))
            {
                LabelMSG.Text = "This Type esist";
                return;
            }
            ClassTypes.Insert(TextBoxTN.Text);
            fillGrid();
        }
    }
    protected void GridViewTypes_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewTypes.EditIndex = e.NewEditIndex;
        fillGrid();
    }
}