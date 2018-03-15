using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class User_UserRecord : System.Web.UI.Page
{
    Common cc = new Common();
    String connString = ConfigurationManager.ConnectionStrings["WebConnection"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataView InComeData = new DataView(new Search().find_table("*", "Record", "R_Type = 'I'"));
        DataView ExpenditureData = new DataView(new Search().find_table("*", "Record", "R_Type = 'E'"));

        
        if (!IsPostBack)
        {
            //收入項目綁至Dropdownlist
            foreach (DataRowView item in InComeData) 
            {
                ListItem listitem = new ListItem();
                listitem.Text = item["R_Name"].ToString();
                listitem.Value = item["R_Name"].ToString();
                InComeClass.Items.Add(listitem);
            }
            //支出項目綁至Dropdownlist
            foreach (DataRowView item in ExpenditureData) 
            {
                ListItem listitem = new ListItem();
                listitem.Text = item["R_Name"].ToString();
                listitem.Value = item["R_Name"].ToString();
                ExpenditureClass.Items.Add(listitem);
            }

            UpdateGridview();
        }
    }

    //支出類別細項連結設定
    protected void ExpenditureClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        ExpenditureClassSub.Items.Clear();

        if (ExpenditureClass.SelectedValue == "7" || ExpenditureClass.SelectedValue == "8")
            ExpenditureDetail.Enabled = false;
        else
            ExpenditureDetail.Enabled = true;

        DataView ExpenditureSub = new DataView(new Search().find_table("*", "RecordSub", " RS_Group = " + "'"+ExpenditureClass.SelectedValue+"'"));
        foreach (DataRowView item in ExpenditureSub)
        {
            ListItem listitem = new ListItem();
            listitem.Text = item["RS_Name"].ToString();
            listitem.Value = item["RS_No"].ToString();
            ExpenditureClassSub.Items.Add(listitem);
        }
        ExpenditureClassSub.Items.Add("請選擇類別");
    }

    protected void AddButton_Click(object sender, EventArgs e) 
    {
        Int32 InsertSuccess = RecordInsert();
        if (InsertSuccess != 1)
            cc.showMsg(this.Page, "儲存失敗");
        else
            cc.showMsg(this.Page, "儲存成功");
    }




    //存入資料庫
    protected Int32 RecordInsert()
    {
        Int32 U_No = Convert.ToInt32(Session["UserNo"]);
        Int32 RU_No = 0;
        DataView UserData = new DataView(new Search().find_table("*", "Users", "U_No = " + U_No.ToString() ));      //抓取使用者的資訊

        String[] Data = RecordDateStream.Value.Split(',');      //將要存入的資料切割放入陣列
        String RU_UserName = UserData[0]["U_Name"].ToString();
        String SQL_String = "INSERT INTO RecordUser (RU_UserNo,RU_UserName,RU_Class,RU_ClassSub,RU_Money,RU_Remarks,RU_Type,RU_CreateDate)"
                          + "VALUES (@RU_UserNo,@RU_UserName,@RU_Class,@RU_ClassSub,@RU_Money,@RU_Remarks,@RU_Type,GETDATE())";

        SqlConnection conn = new SqlConnection(connString);
        try 
        {
            SqlCommand cmd = new SqlCommand(SQL_String, conn);
            cmd.Parameters.Add("@RU_UserNo", SqlDbType.Int).Value = U_No;
            cmd.Parameters.Add("@RU_UserName", SqlDbType.NVarChar, 20).Value = RU_UserName;
            cmd.Parameters.Add("@RU_Class", SqlDbType.NVarChar, 10).Value = Data[0].ToString();
            cmd.Parameters.Add("@RU_ClassSub", SqlDbType.NVarChar, 10).Value = Data[1].ToString();
            cmd.Parameters.Add("@RU_Money", SqlDbType.Int).Value = Convert.ToInt32(Data[2]);
            cmd.Parameters.Add("@RU_Remarks", SqlDbType.NVarChar, 50).Value = Data[3].ToString();
            cmd.Parameters.Add("@RU_Type", SqlDbType.Char, 20).Value = Data[4].ToString();

            conn.Open();
            RU_No = Convert.ToInt32(cmd.ExecuteNonQuery());
        }
        catch(Exception ex)
        {
            cc.showMsg(this.Page, ex.Message);
        }
        finally
        {
            conn.Close();
            UpdateGridview();
        }
        return RU_No;
    }

    //查詢日期
    protected void TimeSearch_Click(object sender, EventArgs e)
    {
        String starttime = StartDate.Text;
        String endtime = EndDate.Text;
        Record_GridView.DataSource = new Search().search_record(starttime, endtime);
        Record_GridView.DataBind();
        
    }

    //更新RecordGridView資料
    protected void UpdateGridview() 
    {
        StartDate.Text = DateTime.Today.ToString("yyyy/MM/01");
        Record_GridView.DataSource = new Search().search_record(StartDate.Text);
        Record_GridView.DataBind();
    }
}