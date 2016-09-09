using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class MasterInformes : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void salir(object sender, EventArgs e)
        {
            if (Request.Cookies.Get("login") != null)
            {
                HttpCookie cookie1 = new HttpCookie("login");
                cookie1.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie1);
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}