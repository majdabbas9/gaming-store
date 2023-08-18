using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Classcontactus
/// </summary>
public class Classcontactus
{
    public string CommentName, CommentTitle, CommentBody, CommentDate,CommentID;
	public Classcontactus()
	{
        CommentDate = DateTime.Now.ToString();
	}
    //الدالة تقوم بانشاء كائن من نوع تعليق
    public static DataTable GetAll()
    {
        string str = "SELECT * FROM [Comments] ORDER BY UserID ASC";
        return Dbase.SelectFromTable(str,"DB.accdb");
    }
    //datatable الدلة تقوم بارجاع جميع التعليقات ك
    public  void Insert(string UserID)
    {
        string sql = "INSERT INTO [Comments] ([UserID],[CommentName],[CommentTitle],[CommentBody],[CommentDate])";
        sql += "VALUES({0},'{1}','{2}','{3}',#{4}#)";
        sql = string.Format(sql,UserID,CommentName,CommentTitle,CommentBody,CommentDate);
        Dbase.ChangeTable(sql,"DB.accdb");
    }
    //الدالة تستقبل رقم مستخدم وتقوم بادخال رسالة جديدة
    public void Delete()
    {
        string sql = "DELETE FROM [Comments] WHERE CommentID=" + CommentID;
        Dbase.ChangeTable(sql,"DB.accdb");
    }
    public static void DeleteByID(string CommentID)
    {
        string sql = "DELETE FROM [Comments] WHERE CommentID=" + CommentID;
        Dbase.ChangeTable(sql, "DB.accdb");
    }
    // الدالة تقوم بمحي رسالة
    public static DataTable getallcomments()
    {
        string sql = "SELECT User.UserName, Comments.CommentName, Comments.CommentTitle, Comments.CommentBody, Comments.CommentDate FROM [User] INNER JOIN Comments ON User.UserID = Comments.UserID;";
        return Dbase.SelectFromTable(sql,"DB.accdb");
    }
    public static DataTable GetAllCommentsByUserID(string UserID)
    {
        string sql = "SELECT User.UserName, Comments.CommentName, Comments.CommentTitle, Comments.CommentBody, Comments.CommentDate, Comments.CommentID FROM [User] INNER JOIN Comments ON User.UserID = Comments.UserID WHERE Comments.UserID=" + UserID;
        return Dbase.SelectFromTable(sql, "DB.accdb");
    }
    public static void Update(string CommentID,String Name,string Title,string Body)
    {
        string sql = "Update [Comments] SET CommentName='{0}', CommentTitle='{1}', CommentBody='{2}' WHERE CommentID={3}";
        sql = string.Format(sql,Name,Title,Body,CommentID);
        Dbase.ChangeTable(sql,"DB.accdb");
    }
}