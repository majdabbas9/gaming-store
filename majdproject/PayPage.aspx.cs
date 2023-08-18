using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false)
        {
            Response.Redirect("ViewProduct.aspx");
        }
        if (!IsPostBack)
        {
            FillDDLMonth();
            FillDDLYear();
            FillDay();
        }

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
        for (int i = 2019; i <= 2050; i++)
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
    protected void ButtonPay_Click(object sender, EventArgs e)
    {
        string UserID = Session["UserID"].ToString();
        ClassCart.UpdateQuntity(UserID);
        int sum = ClassCart.SumUpTheProduct(UserID);
        localhost.WSMyVisa MyVisa = new localhost.WSMyVisa();
        int d=int.Parse(DropDownListDay.Text);
        int m=int.Parse(DropDownListmonth.Text);
        int y=int.Parse(DropDownListYear.Text);
        DateTime DT=new DateTime(y,m,d);
        string str = MyVisa.Pay(TextBoxvnr.Text, DT.ToString(), sum);
        LabelMSG.Text = str;
        if (str.Equals("Succeeded"))
        {
            ClassCart.DeleteALL(UserID);
            ClassCart.UpdateQuntity(UserID);
        }
        LabelMSG.Text = str;
    }
}