using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class _Default : Page
{
    String U_No;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserNo"] != null)
        {
            U_No = Session["UserNo"].ToString();
            DataView User = new DataView(new db_User().selectby_ID(this.Page, Convert.ToInt32(U_No)));
            String U_Name = User[0]["U_Name"].ToString();

            wellcome.Text = "你好 " + U_Name;
        }
    }
}