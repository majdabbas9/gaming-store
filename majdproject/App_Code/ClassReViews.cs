using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReViews
/// </summary>
public class ClassReViews
{
	public ClassReViews()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void Update(bool Isliked,string ReviewsID)
    {
        string sql = "UPDATE [Review] SET Liked={0} WHERE ReviewID={1}";
        sql = string.Format(sql,Isliked,ReviewsID);
        Dbase.SelectFromTable(sql,"DB.accdb");
    }
    /*دالة تقوم باستقبال رقم المنتج,رقم المستخدم,رقم النقد,هل اعجبه
     الدالة تقوم بتعديل النقد حسب الادخال*/
    public static void Insert(bool Isliked,string UserID,string ProductID)
    {
        string sql = "INSERT INTO [Review] ([UserID],[ProductID],[Liked]) Values({0},{1},{2})";
        sql = string.Format(sql,UserID,ProductID,Isliked);
        Dbase.ChangeTable(sql,"DB.accdb");
    }
    /*الدالة تستقبل رقم المنتج,رقم المستخدم,هل اعجبه 
     الدلة تقوم بادخال النقد الى جدول النقاد*/
    public static bool DidTheUserReviewed(string ProductID, string UserID)
    {
        string sql = "SELECT * FROM  [Review] WHERE [ProductID]={0} AND [UserID]={1};";
        sql = string.Format(sql,ProductID,UserID);
        DataTable dt = Dbase.SelectFromTable(sql,"DB.accdb");
        if (dt.Rows.Count == 0)
            return false;
        else return true;
    }
    /*الدالة تستقبل رقم منتج ,رقم مستخدم
      الدالة تقوم بارجاع اذا تم نقد المنتج عن طريق المستخدم المدخل*/
    public static string GiveMeID(string ProductID, string UserID)
    {
        string sql = "SELECT * FROM [Review] WHERE [ProductID]={0} AND [UserID]={1}";
        sql = string.Format(sql, ProductID, UserID);
        DataTable dt = Dbase.SelectFromTable(sql, "DB.accdb");
        return dt.Rows[0]["ReviewID"].ToString();
    }
    //الدالة تستقبل رقم المنتج ورقم المستخدم وترجع رقم النقد
    public static bool IsLiked(string ProductID, string UserID)
    {
        string sql = "SELECT * FROM [Review] WHERE [ProductID]={0} AND [UserID]={1}";
        sql = string.Format(sql, ProductID, UserID);
        DataTable dt = Dbase.SelectFromTable(sql, "DB.accdb");
        return (bool)(dt.Rows[0]["Liked"]);
    }
    //الدالة تستقبل رقم المنتج ورقم المستخدم وتفحص اذا اعجب بالمنتج
}