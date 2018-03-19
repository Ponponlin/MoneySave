using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_User : System.Web.UI.Page
{
    String connString = ConfigurationManager.ConnectionStrings["WebConnection"].ConnectionString;
    Common cc = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserNo"] == null)
            Response.Redirect("~/Login.aspx");

        UserPassword.Attributes["type"] = "password";
        UserPasswordEdit.Attributes["type"] = "password";
        Int32 U_No = Convert.ToInt32(Session["UserNo"]);
        DataView UView = new DataView(new db_User().selectby_ID(this.Page, U_No));
        if (!IsPostBack) 
        {
            //取得User資料
            UserName.Text = UView[0]["U_Name"].ToString();
            UserEmail.Text = UView[0]["U_Email"].ToString();
            UserTitle.Text = UView[0]["U_Title"].ToString();
            UserPhone.Text = UView[0]["U_Phone"].ToString();
            UserGroup.Text = UView[0]["U_Group"].ToString();
            UserPassword.Text = UView[0]["U_Password"].ToString();
            UserPasswordEdit.Text = UView[0]["U_Password"].ToString();

            switch(UView[0]["U_Sex"].ToString())
            {
                case "0":
                    female.Checked = true;
                    break;
                case "1":
                    male.Checked = true;
                    break;
            }
        }
    }

    //儲存資料按鈕
    protected void commit_Click(object sender, EventArgs e)
    {
        bool result = false;
        String U_Name = UserName.Text.ToString();
        String U_UserEmail = UserEmail.Text.ToString();
        String U_UserTitle = UserTitle.Text.ToString();
        String U_UserPhone = UserPhone.Text.ToString();
        String U_Password = UserPassword.Text.ToString();
        String U_Sex = "";
        Int32 U_No = Convert.ToInt32(Session["UserNo"]);
        if(male.Checked)
            U_Sex = "1";
        else
            U_Sex = "2";

        result = UpdateUserData(U_Name,U_UserEmail,U_Password, U_Sex,U_UserTitle,U_UserPhone,U_No);
        if (result)
            cc.showMsg(this.Page, "修改成功");
        else
            cc.showMsg(this.Page, "修改失敗");

        UserName.Enabled = false;
        UserEmail.Enabled = false;
        UserTitle.Enabled = false;
        UserPhone.Enabled = false;
        UserGroup.Enabled = false;
        UserPassword.Enabled = false;
        UserPasswordEdit.Enabled = false;
        commit.Visible = false;
    }
    //修改資料按鈕
    protected void later_Click(object sender, EventArgs e)
    {
        UserName.Enabled = true;
        UserEmail.Enabled = true;
        UserTitle.Enabled = true;
        UserPhone.Enabled = true;
        UserGroup.Enabled = true;
        UserPassword.Enabled = true;
        UserPasswordEdit.Enabled = true;
        commit.Visible = true;
        alater.Visible = false;
    }

    //更新User資料表
    protected bool UpdateUserData(String username,String useremail, String userpassword,String sex, String usertitile, String userphone, Int32 userno)
    {
        bool result = true;

        String SQL_String = "UPDATE Users SET U_Name = @U_Name, U_Email = @U_Email, U_Password = @U_Password, U_Sex = @U_Sex, U_Title = @U_Title, U_Phone = @U_Phone, U_UpdateDate = GETDATE() "
                          + "WHERE U_No = @U_No";

        SqlConnection conn = new SqlConnection(connString);
        try
        {
            SqlCommand cmd = new SqlCommand(SQL_String, conn);
            cmd.Parameters.Add("@U_Name", SqlDbType.NVarChar, 50).Value = username;
            cmd.Parameters.Add("@U_Email", SqlDbType.VarChar, 255).Value = useremail;
            cmd.Parameters.Add("@U_Password", SqlDbType.VarChar, 255).Value = userpassword;
            cmd.Parameters.Add("@U_Sex", SqlDbType.Char, 1).Value = sex;
            cmd.Parameters.Add("@U_Title", SqlDbType.NVarChar, 20).Value = usertitile;
            cmd.Parameters.Add("@U_Phone", SqlDbType.VarChar, 10).Value = userphone;
            cmd.Parameters.Add("@U_No", SqlDbType.Int).Value = userno;

            conn.Open();
            cmd.ExecuteScalar();
        }
        catch(Exception e){
            cc.showMsg(this.Page,e.Message);
            result = false;
        }
        finally{
            conn.Close();
        }
        return result;
    }
}