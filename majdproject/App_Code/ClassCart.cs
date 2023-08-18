using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Cart
/// </summary>
public class ClassCart
{
    public ClassCart()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    // الدلة تقوم بانشاء كائن من نوع سلة
    public static void AddToCart(string ProductID, string UserID)
    {
        string str = "INSERT INTO [Cart] ([ProductID],[UserID]) VALUES({0},{1})";
        str = string.Format(str, ProductID, UserID);
        Dbase.ChangeTable(str, "DB.accdb");
    }
    //الدالة تستقبل رقم مستخدم و رقم منتج وتقوم بادخاله الى سلة المشتريات
    public static DataTable ShowMyProduct(string UserID)
    {
        string str = "SELECT Types.TypeName, Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Product.TypesID, Cart.CartID, Product.ProductName";
        str += " FROM Types INNER JOIN (Product INNER JOIN ([User] INNER JOIN Cart ON User.UserID = Cart.UserID) ON Product.ProductID = Cart.ProductID) ON Types.TypesID = Product.TypesID WHERE User.UserID=" + UserID;
        return Dbase.SelectFromTable(str, "DB.accdb");
    }
    //datatable الدلة تستقبل رقم مستخدم وتقوم بارجاع جميع منتجاته ك
    public static void Delete(string CartID)
    {
        string str = "DELETE  FROM [Cart] WHERE CartID=" + CartID;
        Dbase.ChangeTable(str, "DB.accdb");
    }
    //الدلة تستقبل رقم سلة وتقوم بحذفها
    public static void DeleteALL(string UserID)
    {
        string str = "DELETE * FROM [Cart] WHERE UserID=" + UserID;
        Dbase.ChangeTable(str, "DB.accdb");
    }
    //الدالة تستقبل رقم مستخدم وتقوم بحذف جميع منتجاته
    public static int SumUpTheProduct(string UserID)
    {
        string sql = "SELECT Cart.*, Product.* FROM Product INNER JOIN Cart ON Product.ProductID = Cart.ProductID WHERE UserID=" + UserID;
        DataTable dt = Dbase.SelectFromTable(sql, "DB.accdb");
        int sum = 0;
        if (dt.Rows.Count == 0)
            return 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sum += int.Parse(dt.Rows[i]["Price"].ToString());
        }
        return sum;

        //دالة تستقبل رقم مستخدم وترجع سعر جميع منتجاته
    }
    public static void UpdateQuntity(string UserID)
    {
        string str = "SELECT Types.TypeName,Product.ProductID ,Product.Price, Product.Warranty, Product.Photo, Product.Quantity, Product.TypesID, Cart.CartID, Product.ProductName";
        str += " FROM Types INNER JOIN (Product INNER JOIN ([User] INNER JOIN Cart ON User.UserID = Cart.UserID) ON Product.ProductID = Cart.ProductID) ON Types.TypesID = Product.TypesID WHERE User.UserID=" + UserID;
        DataTable dt = Dbase.SelectFromTable(str, "DB.accdb");
        string sql = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sql = "UPDATE [Product] SET [Quantity]=[Quantity]-1 WHERE ProductID={0}";
            sql = string.Format(sql, dt.Rows[i]["ProductID"].ToString());
            Dbase.ChangeTable(sql, "DB.accdb");
        }
    }
}