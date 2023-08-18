using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["LoggedIn"])
        {
            Response.Redirect("ViewProduct.aspx");
        }
    }
    protected void Buttonlogin_Click(object sender, EventArgs e)
    {
        try
        {
            string un = TextBoxUserName.Text;
            string pw = TextBoxPassword.Text;
            string strSQL = "SELECT * FROM [User] WHERE UserName=";
            strSQL += "'" + TextBoxUserName.Text + "'";
            strSQL += " AND UserPassWord='" + TextBoxPassword.Text + "'";
            //if (!TextBoxUserName.Text.Equals("Me") ||
            //    !TextBoxPassword.Text.Equals("123"))
            DataTable dt = Dbase.SelectFromTable(strSQL, "DB.accdb");
            if (dt.Rows.Count == 0)
            {
                Session["LoggedIn"] = false;
                LabelMSG.Text = "you need to sgin up first your username doesnt exist!!";
            }
            else
            {
                Session["LoggedIn"] = true;
                Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                if (int.Parse(dt.Rows[0]["UserID"].ToString()) == 1)
                {
                    Session["Admin1"] = true;
                }
                else
                {
                    Session["Admin1"] = false;
                }
                Response.Redirect("ViewProduct.aspx");
            }
        }
        catch (Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }

               
     
    }
    protected void Buttoncancel_Click(object sender, EventArgs e)
    {
        TextBoxPassword.Text = "";
        TextBoxUserName.Text = "";
    }
}