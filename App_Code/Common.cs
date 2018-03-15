using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
	public Common()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //顯示JavaScript的Alert訊息
    public void showMsg(Page thisPage, String message) 
    {
        Literal txtMsg = new Literal();
        txtMsg.Text = "<script>alert('" + GetMsg(message) + "')</script>";
        thisPage.Controls.Add(txtMsg);
    }
    //將字串中的單引號改為雙引號
    public String GetMsg(String msg) 
    {
        msg = msg.Replace("\r\n", "");
        msg = msg.Replace("'", "");
        msg = "\"" + msg + "\"";
        return msg;
    }
}