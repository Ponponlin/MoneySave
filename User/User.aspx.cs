using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataView UView = new DataView(new db_User().selectby_ID(this.Page, 1));
        if (!IsPostBack) 
        {
            UserName.Text = UView[0]["U_Name"].ToString();
            UserEmail.Text = UView[0]["U_Email"].ToString();
            UserTitle.Text = UView[0]["U_Title"].ToString();
            UserPhone.Text = UView[0]["U_Phone"].ToString();
            UserGroup.Text = UView[0]["U_Group"].ToString();

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
    protected void commit_Click(object sender, EventArgs e)
    {

    }
}