using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class ClassProduct
{
    public string Photo,TypesID,ProductName;
     public int Quantity, Price, Warranty;
	public ClassProduct()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool DoesThisProductNameExist(String ProductName)
    {
        string str = "SELECT * FROM [Product] WHERE ProductName='{0}'";
        str = string.Format(str,ProductName);
        DataTable dt = Dbase.SelectFromTable(str,"DB.accdb");
        if (dt.Rows.Count == 0)
            return false;
        else
            return true;
    }
    //دالة تقوم بنشاء كائن من نوع منتج 
    public static DataTable GetAllByID( string ProductID)
    {
        string str = "SELECT Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Types.TypeName, Product.ProductName FROM Types INNER JOIN Product ON Types.TypesID = Product.TypesID WHERE ProductID=" + ProductID;
        return Dbase.SelectFromTable(str,"DB.accdb");
    }
    public static DataTable GetAll()
    {
        string str = "SELECT Types.TypeName, Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Product.TypesID, Product.ProductID, Product.Likes, Product.DisLikes, Product.ProductName";
        str += " FROM Types INNER JOIN Product ON Types.TypesID = Product.TypesID ";
        return Dbase.SelectFromTable(str, "DB.accdb");

    }
    public static string TheCarrentName(string ProductID)
    {
        string str= "SELECT * FROM [Product] WHERE ProductID="+ProductID;
        DataTable dt=Dbase.SelectFromTable(str,"DB.accdb");
        return dt.Rows[0]["ProductName"].ToString();
    }
    public static DataTable GetAllQuantity()
    {
        string str = "SELECT Types.TypeName, Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Product.TypesID, Product.ProductID, Product.Likes, Product.DisLikes, Product.ProductName";
        str += " FROM Types INNER JOIN Product ON Types.TypesID = Product.TypesID WHERE Product.Quantity>0";
        return Dbase.SelectFromTable(str, "DB.accdb");
    }
    //datatable دالة تقوم بارجاع جميع المنتجات ك
    public static DataTable GetALLbyType(string TypeID)
    {
        string str = "SELECT Types.TypeName, Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Product.TypesID, Product.ProductID, Product.Likes, Product.DisLikes, Product.ProductName";
        str += " FROM Types INNER JOIN Product ON Types.TypesID = Product.TypesID WHERE Product.TypesID={0}";
         str = string.Format(str,TypeID);
         return Dbase.SelectFromTable(str,"DB.accdb");
    }
    public static DataTable GetAllByTypeQuantity(String TypeID)
    {
        string str = "SELECT Types.TypeName, Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Product.TypesID, Product.ProductID, Product.Likes, Product.DisLikes, Product.ProductName";
        str += " FROM Types INNER JOIN Product ON Types.TypesID = Product.TypesID WHERE Product.TypesID={0} AND Product.Quantity>0;";
        str = string.Format(str, TypeID);
        return Dbase.SelectFromTable(str, "DB.accdb");
    }
    //datatable دالة تستقبل رقم منتج وتقوم بارجاع جميع المنتجات من نوع المدخل
    public void Insert()
    {
        string sql = "INSERT INTO [Product] ([TypesID],[Photo],[Warranty],[Quantity],[Price],[Likes],[DisLikes],[ProductName])";
        sql += "VALUES({0},'{1}',{2},{3},{4},{5},{5},'{6}')";
        sql = string.Format(sql,TypesID,Photo, Warranty, Quantity, Price,0,ProductName);
        Dbase.ChangeTable(sql, "DB.accdb");
    }
    //دالة تقوم بادخال صفات الكائن الى جدول المنتجات
    public void Update(string ProductID)
    {
        string sql = "UPDATE [Product] SET  Quantity={0}, Warranty={1}, price={2}, Photo='{3}', TypesID={4}, ProductName='{5}'  WHERE ProductID={6}";
        sql = string.Format(sql, Quantity, Warranty, Price, Photo,TypesID,ProductName,ProductID);
        Dbase.ChangeTable(sql, "DB.accdb");
    }
    //دالة تقوم باستقبال رقم منتح وتعديل المنتج في جدول المنتجات حسب صفات الكائن و رقم المنتج
    public static void Delete(String ProductID)
    {
        string sql = "DELETE FROM [Product] WHERE ProductID=" + ProductID;
        Dbase.ChangeTable(sql, "DB.accdb");
    }
    //دالة تستقبل رقم منتج وتقوم بحذفه من جدول المنتجات حسب رقم المنتج 
    public static void NewReview(string ProductID, bool flag)
    {
        if (flag)
        {
            string sql = "Update [Product] SET [Likes]=[Likes]+1 WHERE [ProductID]={0}";
            sql = string.Format(sql, ProductID);
            Dbase.ChangeTable(sql, "DB.accdb");
        }
        else
        {
            string sql = "Update [Product] SET [DisLikes]=[DisLikes]+1 WHERE [ProductID]={0}";
            sql = string.Format(sql, ProductID);
            Dbase.ChangeTable(sql, "DB.accdb");
        }
    }
    //دالة تستقبل رقم منتج واعجاب/عدم اعجاب وتقوم بانشاء نقد
    public static void UpdateReview(string ProductID, bool flag)
    {
        if (flag)
        {
            string sql = "Update [Product] SET [Likes]=[Likes]+1,[DisLikes]=[DisLikes]-1 WHERE [ProductID]={0}";
            sql = string.Format(sql, ProductID);
            Dbase.ChangeTable(sql, "DB.accdb");
        }
        else
        {
            string sql = "Update [Product] SET [Likes]=[Likes]-1,[DisLikes]=[DisLikes]+1 WHERE [ProductID]={0}";
            sql = string.Format(sql, ProductID);
            Dbase.ChangeTable(sql, "DB.accdb");
        }
    }
    public static DataTable GetByID(string ID)
    {
        string str = "SELECT * FROM [Product] WHERE ProductID={0}";
        str = string.Format(str,ID);
        return Dbase.SelectFromTable(str,"DB.accdb");
    }
    public static DataTable GetByProductName(String ProductName)
    {
        string str = "SELECT Types.TypeName, Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Product.ProductName, Product.ProductID, Product.Likes, Product.DisLikes FROM Types INNER JOIN Product ON Types.TypesID = Product.TypesID WHERE ProductName='{0}'";
        str = string.Format(str,ProductName);
        return Dbase.SelectFromTable(str,"DB.accdb");

    }
    }
//دالة تستقبل رقم منتج واعجاب/عدم اعجاب وتقوم بتعديل عدد الاعجابات 

