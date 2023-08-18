using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for ClassTypes
/// </summary>
public class ClassTypes
{
	public ClassTypes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //دالة تقوم بانشاء كائن من نوع نوع منتج
    public static DataTable GetAll()
    {
        string sql = "SELECT DISTINCT * FROM [Types]";
        return Dbase.SelectFromTable(sql,"DB.accdb");
    }
    //datatable دالة تقوم بارجاع جميع انوع المنتجات ك
    public static void Insert(string TypeName)
    {
        string sql = "INSERT INTO [Types] ([TypeName]) VALUES('" + TypeName + "')";
        Dbase.ChangeTable(sql, "DB.accdb");
    }
    //دالة تقوم بادخال نوع جديد الى جدول انواع المنتجات
    public static string GetID(string TypeName)
    {
        string sql = "SELECT * FROM [Types] WHERE TypeName='" + TypeName+"'";
        DataTable dt = Dbase.SelectFromTable(sql,"DB.accdb");
        return dt.Rows[0]["TypesID"].ToString();
    }
    //دالة تستقبل اسم نوع منتج وترجع رقمه
    public static bool IsExist(string Type)
    {
        int i;
        string sql = "SELECT [TypeName] FROM [Types]";
        DataTable dt = Dbase.SelectFromTable(sql, "DB.accdb");
        for (i = 0; i < dt.Rows.Count; i++)
        {
            string type2=dt.Rows[i]["TypeName"].ToString();
            if (Type.Equals(type2))
            {
                return true;
            }
        }
        return false;
    }
    public static void Update(string TypeName,string TypesID)
    {
        string sql = "UPDATE [Types] SET TypeName='{0}' WHERE TypesID={1}";
        sql = string.Format(sql,TypeName,TypesID);
        Dbase.ChangeTable(sql,"DB.accdb");
    }
    //الدالة تستقبل نوع منتج وتقوم بفحص ائا كان موجود
    public static void Delete(string TypesID)
    {
        String sql = "DELETE FROM [Types] WHERE TypesID=" + TypesID;
        Dbase.ChangeTable(sql,"DB.accdb");
    }
    public static DataTable GetAllTypesByID(string TypesID)
    {
        string str = "SELECT Types.TypesID, Product.Photo, Product.TypesID FROM Types INNER JOIN Product ON Types.TypesID = Product.TypesID WHERE Product.TypesID=" + TypesID;
        DataTable dt = Dbase.SelectFromTable(str, "DB.accdb");
        return dt;
    }
}