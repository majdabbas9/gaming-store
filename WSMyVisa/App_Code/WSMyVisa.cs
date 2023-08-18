using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WSMyVisa
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSMyVisa : System.Web.Services.WebService
{

    public WSMyVisa()
    {
    }
    [WebMethod]
    public void AddVisa(string VisaNr, string ValidUntil, int Balance)
    {
        // Errors
        // Trying to add same visa more than once
        // Balance is < 0
        // Invalid ValidUntil

        string Query = "INSERT INTO [Accounts] ";
        Query += " ([VisaNr] ,[ValidUntil], [Balance]) ";
        Query += " VALUES ('{0}', #{1}#, {2})";
        Query = string.Format(Query, VisaNr, ValidUntil, Balance);
        Dbase.ChangeTable(Query, "WSDB.accdb");
    }
    //الدلة تستقبل رقم الفيزا وتاريخ الانتهاء وقيمة العددية للفيزا وتدخل الفيزا اللى الجدول
    [WebMethod]
    public DataTable GetReport(string VisaNr, string ValidUntil)
    {
        string Query = "SELECT * FROM [Accounts] ";
        Query += " WHERE VisaNr='{0}' AND ValidUntil=#{1}#";
        Query = string.Format(Query, VisaNr, ValidUntil);
        DataTable dt = Dbase.SelectFromTable(Query, "WSDB.accdb");
        return dt;

    }
    //الدالة تستقبل رقم الفيزا وتاريخ انتهائها وترجع تقرير عنها
    [WebMethod]
    public bool IsValid(string VisaNr, string ValidUntil)
    {
        string Now = DateTime.Now.ToString("dd/MM/yyyy");
        string Query = "SELECT * FROM [Accounts] ";
        Query += " WHERE VisaNr='{0}' AND ValidUntil=#{1}# AND ";
        Query += " ValidUntil>=#{2}#";
        Query = string.Format(Query, VisaNr, ValidUntil, Now);
        DataTable dt = Dbase.SelectFromTable(Query, "WSDB.accdb");
        return dt.Rows.Count == 1;
    }
    //الدالة تستقبل رقم الفيزا و تاريخ انتهائها وتفحص اذا انتهت صلاحية الفيزا
    [WebMethod]
    public string Pay(string visanr, string visaUntil, int amount)
    {
        if (!IsValid(visanr, visaUntil))
        {
            return "visa invalid";
        }
        string Query = "SELECT * FROM [Accounts] ";
        Query += " WHERE VisaNr='{0}' AND [Balance]>={1}";
        Query = string.Format(Query, visanr, amount);
        DataTable dt = Dbase.SelectFromTable(Query, "WSDB.accdb");
        if (dt.Rows.Count == 0)
            return "Insufficient Amount!";

        Query = "UPDATE [Accounts] SET [Balance] = [Balance] - {0} ";
        Query += " WHERE VisaNr ='{1}'";
        Query = string.Format(Query, amount, visanr);
        Dbase.ChangeTable(Query, "WSDB.accdb");
        return "Succeeded";
    }
    //الدالة تستقبل تواريخ والقيمة العددية للفيزا وتقوم بالدفع 

}
