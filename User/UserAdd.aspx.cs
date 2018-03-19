using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class User_UserAdd : System.Web.UI.Page
{
    String connString = ConfigurationManager.ConnectionStrings["WebConnection"].ConnectionString;
    String UserGroup = "";
    Common cc = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserNo"] == null)
            Response.Redirect("~/Login.aspx");
    }
    //送出申請
    protected void submit_Click(object sender, EventArgs e)
    {
        String Email = UserEmail.Text.ToString();
        String Password = UserPassword.Text.ToString();
        String Name = UserName.Text.ToString();
        String Title = UserTitle.Text.ToString();
        String Phone = UserPhone.Text.ToString();
        String sex = "";

        if (male.Checked)
            sex = "1";
        else if (female.Checked)
            sex = "0";

        if (UserInsert(Name, Email, Password, sex, Title, Phone))
            cc.showMsg(this.Page, "建立成功!");
        else
            cc.showMsg(this.Page, "建立失敗!");
    }
    /*新增使用者
     Group變數尚未完成設定
     finally部分需再想想
     */
    protected bool UserInsert(String U_Name, String U_Email, String U_Password, String U_Sex, String U_Title, String U_Phone) 
    {
        bool result = true;

        String SQL_String = "INSERT INTO Users (U_Name,U_Email,U_Password,U_Sex,U_Title,U_Phone,U_Group,U_CreateDate,U_UpdateDate,U_LastTimeLogin) "
                          + "VALUES (@U_Name,@U_Email,@U_Password,@U_Sex,@U_Title,@U_Phone,1,GETDATE(),GETDATE(),null)";

        SqlConnection conn = new SqlConnection(connString);
        try 
        {
            SqlCommand cmd = new SqlCommand(SQL_String, conn);
            cmd.Parameters.Add("@U_Name", SqlDbType.VarChar, 50).Value = U_Name;
            cmd.Parameters.Add("@U_Email", SqlDbType.NVarChar, 255).Value = U_Email;
            cmd.Parameters.Add("@U_Password", SqlDbType.NVarChar, 255).Value = U_Password;
            cmd.Parameters.Add("@U_Sex", SqlDbType.Char, 1).Value = U_Sex;
            cmd.Parameters.Add("@U_Title", SqlDbType.NVarChar, 20).Value = U_Title;
            cmd.Parameters.Add("@U_Phone", SqlDbType.NVarChar, 10).Value = U_Phone;

            conn.Open();
            cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            result = false;
            cc.showMsg(this.Page, ex.Message);
        }
        finally 
        {
            conn.Close();
        }
        return result;
    }
}