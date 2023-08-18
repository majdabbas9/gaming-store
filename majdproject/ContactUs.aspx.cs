using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false)
        {
            Response.Redirect("ViewProduct.aspx");
        }
    }
    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        try
        {
            Classcontactus CS = new Classcontactus();
            CS.CommentTitle = TextBoxCommentTitle.Text;
            CS.CommentName = TextBoxCommentName.Text;
            CS.CommentBody = TextBoxBody.Text;
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                CS.Insert(UserID);
                Response.Redirect("home.aspx");
            }
            else
            {
                return;
            }
        }
        catch(Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }
        
    }
}