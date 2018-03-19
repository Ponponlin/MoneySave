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
/// Summary description for db_User
/// </summary>
public class db_User
{
    String connString = ConfigurationManager.ConnectionStrings["WebConnection"].ConnectionString;
    Common cc = new Common();

	public db_User()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //用使用者ID來查詢
    public DataTable selectby_ID(Page thispage,Int32 U_No) 
    {
        String SQL_String = "SELECT TOP 1 * "
                          + "FROM Users "
                          + "WHERE U_No = @U_No";

        SqlConnection conn = new SqlConnection(connString);
        SqlDataReader reader = null;
        DataTable UsersTable = new DataTable();

        try 
        {
            SqlCommand cmd = new SqlCommand(SQL_String, conn);
            cmd.Parameters.Add("@U_No", SqlDbType.Int, 255).Value = U_No;
            conn.Open();
            reader = cmd.ExecuteReader();
            UsersTable.Load(reader);
        }
        catch (Exception ex) 
        {
            
        }
        finally 
        {
            conn.Close();
        }
        return UsersTable;
    }
}