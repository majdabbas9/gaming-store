using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paytest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {  
        localhost.WSMyVisa myv = new localhost.WSMyVisa();
        Label1.Text = myv.Pay("123", "31/01/2021", int.Parse(TextBox1.Text));
    }
}