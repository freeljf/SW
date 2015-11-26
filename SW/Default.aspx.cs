using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SW.BLL;
using SW.Model;
using Common;

public partial class _Default : System.Web.UI.Page
{
    SWBLL swb = new SWBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int num;
        List<Software> li= swb.GetPagedSW(1, 3, out num);
        TextBox1.Text = li[0].swName;
        TextBox2.Text = li[1].swName;
        TextBox3.Text = li[2].swName;
    }
}