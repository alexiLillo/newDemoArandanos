using System;
using System.Web;
using DemoArandanos.Controlador;

namespace DemoArandanos
{
    public partial class Login : System.Web.UI.Page
    {
        Controler control = new Controler();

        protected void Page_Load(object sender, EventArgs e)
        {
            divBadLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            divBadLogin.Visible = false;
            try
            {
                if (control.login(txtUser.Text, txtPass.Text) == 1)
                {
                    Application["usuario"] = txtUser.Text;
                    HttpCookie cookie1 = new HttpCookie("login");
                    cookie1.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(cookie1);
                    Server.Transfer("InformePlantas.aspx", true);
                }
                else
                {
                    if (control.login(txtUser.Text, txtPass.Text) == 2)
                    {
                        //usuario de tipo normals
                        Application["usuario"] = txtUser.Text;
                        HttpCookie cookie1 = new HttpCookie("login");
                        cookie1.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Add(cookie1);
                        Server.Transfer("InformePlantas2.aspx", true);
                    }
                    else
                    {
                        if (control.login(txtUser.Text, txtPass.Text) == 3)
                        {
                            //usuario de tipo solo informes
                            Application["usuario"] = txtUser.Text;
                            HttpCookie cookie1 = new HttpCookie("login");
                            cookie1.Expires = DateTime.Now.AddMinutes(30);
                            Response.Cookies.Add(cookie1);
                            Server.Transfer("InformePlantas3.aspx", true);
                        }
                        else
                        {
                            if (control.login(txtUser.Text, txtPass.Text) == 0)
                            {
                                lblLogin.Text = "Datos de inicio de sesión incorrectos.";
                                divBadLogin.Visible = true;
                                txtUser.Text = "";
                                txtPass.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblLogin.Text = "No se puede establecer conexión con el servidor. "+ ex.ToString();
                divBadLogin.Visible = true;
            }
        }
    }
}