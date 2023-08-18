using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignupPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["LoggedIn"])
        {
            Response.Redirect("ViewProduct.aspx");
        }
        if (!IsPostBack)
        {
            FillDDLMonth();
            FillDDLYear();
            FillDay();
            TextBoxUserName.Text = "";
            TextBoxUserEmail.Text = "";
            TextBoxPassWord.Text = "";
        }
    }
    protected void Buttonsignup_Click(object sender, EventArgs e)
    {
        try
        {
            string UserID;
            ClassUser cu = new ClassUser();
            cu.UserName = TextBoxUserName.Text;
            cu.UserEmail = TextBoxUserEmail.Text;
            cu.UserPassword = TextBoxPassWord.Text;
            string dob = DropDownListDay.SelectedValue + "/" +DropDownListmonth.SelectedValue + "/" + DropDownListYear.SelectedValue;
            cu.UserDateOfBirth = dob;
            cu.ISfemale = (CheckBoxIsfemale.Checked).ToString();
            string date = DateTime.Now.ToString();
            cu.UserDateJoin = date;
            string SQL = "SELECT * FROM [User] WHERE UserName=";
            SQL += "'" + TextBoxUserName.Text + "'";
            SQL += "AND UserEmail='" + TextBoxUserEmail.Text + "'";
            DataTable dt = Dbase.SelectFromTable(SQL, "DB.accdb");
            if (dt.Rows.Count == 0)
            {
                if (DropDownListDay.SelectedValue.Equals(""))
                {
                    LabelMSG.Text="Day Is missing";
                    return;
                }
                if (DropDownListmonth.SelectedValue.Equals(""))
                {
                    LabelMSG.Text = "Day Is missing";
                    return;
                }
                if (DropDownListYear.SelectedValue.Equals(""))
                {
                    LabelMSG.Text = "Day Is missing";
                    return;
                }
                cu.Insert();
                dt = Dbase.SelectFromTable(SQL, "DB.accdb");
                UserID = dt.Rows[0]["UserID"].ToString();
                Session["UserID"] = UserID;
                Session["LoggedIn"] = true;
                Response.Redirect("ViewProduct.aspx");
            }
            else
            {
                LabelMSG.Text = "this email or username is taken!!";
            }
        }
        catch (Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBoxUserName.Text = "";
        TextBoxPassWord.Text = "";
        TextBoxUserEmail.Text = "";
    }
    private void FillDDLMonth()
    {
        DropDownListmonth.Items.Clear();
        for (int i = 1; i <= 12; i++)
        {
            DropDownListmonth.Items.Add(i.ToString());
        }
    }
    private void FillDDLYear()
    {
        DropDownListYear.Items.Clear();
        for (int i = 1948; i <= 2010; i++)
        {
            DropDownListYear.Items.Add(i.ToString());
        }
    }
    private void FillDay()
    {
        int month = int.Parse(DropDownListmonth.SelectedValue.ToString());
        int Year = int.Parse(DropDownListYear.SelectedValue.ToString());
        int day = getnumofdays(month, Year);
        for (int i = 1; i <= day; i++)
        {
            DropDownListDay.Items.Add(i.ToString());
        }
    }
    private int getnumofdays(int month, int year)
    {
        switch (month)
        {
            case 1: return 31;
            case 2:
            if(IsLeapYear(year)) return 29;
            else return 28;
            case 3: return 31;
            case 4: return 30;
            case 5: return 31;
            case 6: return 30;
            case 7: return 31;
            case 8: return 31;
            case 9: return 30;
            case 10: return 31;
            case 11: return 30;
            case 12: return 31;
        }
        return 0;
    }
    private bool IsLeapYear(int year)
    {
        return (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0));
    }
    protected void DropDownListDay_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void DropDownListmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDay();
    }
    protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDay();
    }
}