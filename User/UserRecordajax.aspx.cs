using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

public partial class User_UserRecordajax : System.Web.UI.Page
{
    List<itemGroup> IG = new List<itemGroup>();
    protected void Page_Load(object sender, EventArgs e)
    {
        String Value = Request.QueryString["Value"];
        //DataView ExpenditureDetail = new DataView(new Search().find_table("*", "RecordSub", "RS_Group = " + Value));

        DataView ExpenditureDetail = new DataView(new Search().find_table("*", "RecordSub", "RS_Group = " + "'"+"飲食"+"'"));
        
        foreach (DataRowView item in ExpenditureDetail)
        {
            itemGroup it = new itemGroup()
            {
                No = Convert.ToInt32(item["RS_No"]),
                Name = item["RS_Name"].ToString()
            };
            IG.Add(it);
        }
        //IG.Add(new itemGroup() { No = 1, Name = "ponpon" });
        PrintJSON(IG);
    }

    public void PrintJSON(object item)
    {
        string json = JsonConvert.SerializeObject(item);        
        Response.Write(json);
    }
    public class itemGroup
    {
        public Int32 No { get;set; }
        public String Name { get; set; }
    }
}