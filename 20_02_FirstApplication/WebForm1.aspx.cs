using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _20_02_FirstApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Changed by server"+DateTime.Now.ToString();
            TestBox1.Text = "Changed by server"+DateTime.Now.ToString();
		}
    }
}