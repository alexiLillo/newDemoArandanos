using System;
using System.Web;

namespace DemoArandanos
{
    public partial class Maestra : System.Web.UI.MasterPage
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