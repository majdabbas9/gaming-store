using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["LoggedIn"] != null)
            {
                bool LoggedIn = (bool)Session["LoggedIn"];
                if (LoggedIn)
                {
                    RenameMenuItem("loginout", "Logout");
                    RemoveMenuItem("signup");
                }
                else
                {
                    Session["Admin1"] = false;
                    Session["UserID"] = null;
                    RenameMenuItem("loginout", "Login");
                    RemoveMenuItem("contactus");
                    RemoveMenuItem("MyCart");
                    RemoveMenuItem("Profile");
                }
                

            }
            else
            {
                Session["LoggedIn"] = false;
                RemoveMenuItem("contactus");
                RemoveMenuItem("MyCart");
                RemoveMenuItem("Profile");
            }
            if (Session["Admin1"] != null)
            {
                bool ISAdmin1 = (bool)Session["Admin1"];
                if (ISAdmin1 == false)
                {
                    RemoveMenuItem("Admin");
                }
            }
            else
            {
                RemoveMenuItem("Admin");
            }
        }
    }
    protected void RemoveMenuItem(string Value)
    {
        MenuItem mi = Menu1.FindItem(Value);
        if (mi != null) // Found by Value
        {
            Menu1.Items.Remove(mi);
        }
    }
    protected void RenameMenuItem(string Value, string NewText)
    {
        MenuItem mi = Menu1.FindItem(Value);
        if (mi != null) // Found by Value
        {
            mi.Text = NewText;
        }
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Value.Equals("loginout"))
        {
            if (e.Item.Text.Equals("Login"))
            {
                Response.Redirect("loginpage.aspx");
            }
            else
            {
                Session["LoggedIn"] = false;
                Response.Redirect("ViewProduct.aspx");
                
            }
        }
    }
}
