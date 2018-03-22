using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Search
/// </summary>
public class Search
{
    String connString = ConfigurationManager.ConnectionStrings["WebConnection"].ConnectionString;
    Common cc = new Common();
	public Search()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable find_table(String cellname,String tablename,String searchstring) 
    {
        String SQL_String = " SELECT " + cellname
                          + " FROM " + tablename
                          + " WHERE " + searchstring;

        SqlConnection conn = new SqlConnection(connString);
        DataTable UserTable = new DataTable();
        SqlDataReader reader = null;
        try 
        {
            SqlCommand cmd = new SqlCommand(SQL_String, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            UserTable.Load(reader);
        }
        catch(Exception e) 
        {
            
        }
        finally 
        {
            conn.Close();
        }
        return UserTable;
    }

    //供查詢起始和結束日期RecordUser資料
    public DataTable search_record(String startdate, String enddate) 
    {
        SqlConnection conn = new SqlConnection(connString);
        string SQL_String = "select RU_UserName,RU_Class,RS_Name,RU_Money,RU_CreateDate,RU_Type from RecordUser inner join RecordSub on RU_CreateDate >= " +"'"+startdate+"'" + " and RU_CreateDate <= DATEADD(day,1,"+"'"+enddate+"'"+") and RU_ClassSub = RS_No order by RU_CreateDate DESC";
        SqlDataReader reader = null;
        DataTable RecordTable = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand(SQL_String, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            RecordTable.Load(reader);
        }
        catch (Exception e) 
        { 
         
        }
        finally
        {
            conn.Close();
        }
        return RecordTable;
    }

    //供查詢當月的RecordUser資料
    public DataTable search_record(String startdate)
    {
        SqlConnection conn = new SqlConnection(connString);
        //string SQL_String = "select RU_UserName,RU_Class,RU_ClassSub,RU_Money,RU_CreateDate,RU_Type from RecordUser where RU_CreateDate >= " + "'" + startdate +"'" + "order by RU_CreateDate DESC";
        string SQL_String = "select RU_UserName,RU_Class,RecordSub.RS_Name,RU_Money,RU_CreateDate,RU_Type from RecordUser inner join RecordSub on RU_CreateDate >= " + "'" + startdate + "'" + " and RU_ClassSub = RS_No order by RU_CreateDate DESC";

        SqlDataReader reader = null;
        DataTable RecordTable = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand(SQL_String, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            RecordTable.Load(reader);
        }
        catch (Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
        return RecordTable;
    }
}