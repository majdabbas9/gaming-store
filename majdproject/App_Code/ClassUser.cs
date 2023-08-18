using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassUser
/// </summary>
public class ClassUser
{
    public string UserName, UserID, UserDateOfBirth, UserEmail, UserPassword, UserDateJoin, ISfemale;
	public ClassUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //دالة تفوم ببناء كائن من نوع مستخدم 
    public static  DataTable GetAll()
    {
        string strSQL = "SELECT * FROM [User] WHERE ISAdmin=False";
        return Dbase.SelectFromTable(strSQL, "Db.accdb");
    }
//datatabe دالة تقوم بارجاع جميع المتسخدمين ك 
    public void Insert()
    {
        // INSERT INTO
        string strSQL = "INSERT INTO [User] ([UserName],[UserDateOfBirth],[UserEmail],[UserPassword],[UserDateJoin],[ISfemale])";
        string str = "VALUES('{0}',#{1}#,'{2}','{3}',#{4}#,{5})";
        strSQL += str;
        strSQL = string.Format(strSQL,UserName,UserDateOfBirth,UserEmail,UserPassword,UserDateJoin,ISfemale);
        Dbase.ChangeTable(strSQL,"DB.accdb");
    }
    //الدالة تدخل الى جدول المستخدمين صفات الكائن الحالي
    public void Update()
    {
        string strSQL;
        strSQL = "UPDATE [User] SET UserName='{0}', UserPassword='{1}', UserEmail='{2}', UserDateOfBirth=#{3}# WHERE UserID={4}";
        strSQL = String.Format(strSQL,UserName,UserPassword,UserEmail,UserDateOfBirth,UserID); 
        Dbase.ChangeTable(strSQL, "DB.accdb");
    }
    // الدالة تقوم بتعديل صفات المستخدم حسب صفات الكائن الحالي ورقم المستخدم
    public void Delete()
    {
        string SQL = "DELETE FROM [User] WHERE UserID="+UserID;
        Dbase.ChangeTable(SQL, "DB.accdb");
    }
    //الدلة تقوم بتعديل صفات المستخدم حسب صفات الكائن الحالي ورقم المستخدم
    public DataTable GetByID()
    {
        string SQL = "SELECT * FROM [User] WHERE UserID=" + UserID;
       return Dbase.SelectFromTable(SQL, "DB.accdb");
    }
}
