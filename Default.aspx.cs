using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    String U_No;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["U_No"] != null)
            U_No = Session["U_No"].ToString();
    }
}