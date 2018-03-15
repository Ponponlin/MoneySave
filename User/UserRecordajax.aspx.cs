using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class User_UserRecordajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String No = Request.Form["No"].ToString();

        DataView ExpenditureDetail = new DataView(new Search().find_table("*", "RecordSub", "RS_Group = " + No));
        Response.Write(ExpenditureDetail);
    }
}