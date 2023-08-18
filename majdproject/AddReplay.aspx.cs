using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddReplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductID"] == null)
            Response.Redirect("ViewProduct");
    }
    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        string productID =Request.QueryString["productID"].ToString();
        ClassReplays.Insert(productID,TextBoxCommentName.Text,TextBoxCommentTitle.Text,TextBoxBody.Text);
        TextBoxBody.Text = "";
        TextBoxCommentName.Text = "";
        TextBoxCommentTitle.Text = "";
        LabelMSG.Text = "Your replay Sent successfully";
    }
}