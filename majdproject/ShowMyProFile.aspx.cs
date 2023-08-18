using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShowMyProFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false)
        {
            Response.Redirect("ViewProduct.aspx");
        }
        if (!IsPostBack)
        {
            string UID = Session["UserID"].ToString();
            ClassUser CU = new ClassUser();
            CU.UserID = UID;
            DataTable dt = CU.GetByID();
            string un = dt.Rows[0]["UserName"].ToString();
            string pw = dt.Rows[0]["UserPassword"].ToString();
            string E = dt.Rows[0]["UserEmail"].ToString();
            string str = dt.Rows[0]["UserDateOfBirth"].ToString();
            int day = getday(str);
            int month = getMonth(str);
            int year = getyear(str);
            TextBoxUN.Text = un;
            TextBoxUN2.Text = un;
            TextBoxPW.Text = pw;
            TextBoxPW2.Text = pw;
            TextBoxE.Text = E;
            TextBoxE2.Text = E;
            FillDDLMonth();
            FillDDLYear();
            FillDay();
            DropDownListDay.Text = day.ToString();
            DropDownListmonth.Text = month.ToString();
            DropDownListYear.Text = year.ToString();
        }

        

    }
    public static int getday(string date1)
    {
        string str = date1[0].ToString() + date1[1].ToString();
        return int.Parse(str);
    }
    public static int getMonth(string date1)
    {
        string str = date1[3].ToString() + date1[4].ToString();
        return int.Parse(str);
    }
    public static int getyear(string date1)
    {
        string str = date1[6].ToString() + date1[7].ToString()+date1[8].ToString() + date1[9].ToString();
        return int.Parse(str);
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
                if (IsLeapYear(year)) return 29;
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
    protected void DropDownListmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDay();
    }
    protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDay();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!(Session["UserID"] == null))
        {
            string UN = TextBoxUN.Text;
            string PW = TextBoxPW.Text;
            string E = TextBoxE.Text;
            string dob = DropDownListDay.SelectedValue + "/" + DropDownListmonth.SelectedValue + "/" + DropDownListYear.SelectedValue;
            string UID = Session["UserID"].ToString();
            ClassUser CU = new ClassUser();
            CU.UserID = UID;
            CU.UserName = UN;
            CU.UserDateOfBirth = dob;
            CU.UserEmail = E;
            CU.UserPassword = PW;
            CU.Update();
        }
        else
        {
            Response.Redirect("home.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewProduct.aspx");
    }
}