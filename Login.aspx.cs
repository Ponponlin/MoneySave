using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;

public partial class Login : System.Web.UI.Page
{
    Common cc = new Common();
    String connString = ConfigurationManager.ConnectionStrings["WebConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login_Click(object sender, EventArgs e)
    {
        String UserEmail = email.Text.ToString();
        String UserPass = password.Text.ToString();
        Int32 U_No = User_Login(UserEmail,UserPass);

        if (U_No <= 0)
            cc.showMsg(this.Page, "帳號或密碼錯誤");
        else 
        {
            String param = "U_No=" + U_No.ToString();
            Session["UserNo"] = U_No;
            Response.Redirect("~/Default.aspx");
            
        }
            
    }

    protected Int32 User_Login(String email, String password) 
    {
        Int32 U_No = 0;
        String SQLString = "SELECT U_No,U_Email,U_Password "
                         + "FROM Users "
                         + "WHERE U_Email = @U_Email AND U_Password = @U_Password";

        SqlConnection conn = new SqlConnection(connString);

        try 
        {
            SqlCommand cmd = new SqlCommand(SQLString, conn);
            cmd.Parameters.Add("@U_Email", SqlDbType.VarChar, 255).Value = email;
            cmd.Parameters.Add("@U_Password", SqlDbType.VarChar, 255).Value = password;

            conn.Open();
            U_No=Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception ex) 
        {
            cc.showMsg(this.Page, ex.Message);
            U_No = 0;
        }
        finally
        { 
            conn.Close();
        }
        return U_No;
    }
}