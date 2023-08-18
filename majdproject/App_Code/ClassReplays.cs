using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

/// <summary>
/// Summary description for ClassReplays
/// </summary>
public class ClassReplays
{
	public ClassReplays()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void Insert(string ProductID, String Name, String Title, String Body)
    {
        string Sql = "INSERT INTO [Replays] ([ProductID],[ReplayerName],[ReplayeTiltle],[ReplayBody]) ";
        Sql += "VALUES({0},'{1}','{2}','{3}')";
        Sql = string.Format(Sql,ProductID,Name,Title,Body);
        Dbase.ChangeTable(Sql,"DB.accdb");
    }
    public static DataTable ShowAllReplays(string ProductID)
    {
        string sql = "SELECT Replays.ReplayerName, Replays.ReplayeTiltle, Replays.ReplayBody, Replays.ReplayID FROM Product INNER JOIN Replays ON Product.ProductID = Replays.ProductID WHERE Replays.ProductID=" + ProductID;
        return Dbase.SelectFromTable(sql,"DB.accdb");
    }
    public static void Delete(string ReplayID)
    {
        string SQl = "DELETE FROM [Replays] WHERE ReplayID="+ReplayID;
        Dbase.ChangeTable(SQl,"DB.accdb");
    }
}