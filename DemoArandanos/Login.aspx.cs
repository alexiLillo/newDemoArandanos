using System;
using System.Web;
using DemoArandanos.Controlador;
using System.Security.Cryptography;
using System.Text;

namespace DemoArandanos
{
    public partial class Login : System.Web.UI.Page
    {
        Controler control = new Controler();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            //    Response.Cache.SetAllowResponseInBrowserHistory(false);
            //    Response.Cache.SetNoStore();
            //}

            divBadLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            divBadLogin.Visible = false;
            if (rbtArandanos.Checked == true)
            {
                rbtArandanos.Checked = false;
                //ARANDANOS
                try
                {
                    if (control.login(txtUser.Text, Encrypt.GetMD5(txtPass.Text)) == 1)
                    {
                        Session["log"] = 1;

                        Session["usuario"] = txtUser.Text;
                        HttpCookie cookie1 = new HttpCookie("login");
                        cookie1.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Add(cookie1);
                        Server.Transfer("InformePlantas.aspx", true);
                    }
                    else
                    {
                        //POR ENCRYP
                        if (control.login(txtUser.Text, Encrypt.GetMD5(txtPass.Text)) == 2)
                        {
                            Session["log"] = 2;

                            //usuario de tipo normals
                            Session["usuario"] = txtUser.Text;
                            HttpCookie cookie1 = new HttpCookie("login");
                            cookie1.Expires = DateTime.Now.AddMinutes(30);
                            Response.Cookies.Add(cookie1);
                            Server.Transfer("InformePlantas2.aspx", true);

                        }
                        else
                        {
                            if (control.login(txtUser.Text, Encrypt.GetMD5(txtPass.Text)) == 3)
                            {
                                Session["log"] = 3;

                                //usuario de tipo solo informes
                                Session["usuario"] = txtUser.Text;
                                HttpCookie cookie1 = new HttpCookie("login");
                                cookie1.Expires = DateTime.Now.AddMinutes(30);
                                Response.Cookies.Add(cookie1);
                                Server.Transfer("InformePlantas3.aspx", true);

                            }
                            else
                            {
                                if (control.login(txtUser.Text, txtPass.Text) == 0)
                                {
                                    Session["log"] = 0;

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
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblLogin.Text = "No se puede establecer conexión con el servidor.";
                    divBadLogin.Visible = true;
                }
            }
            else if (rbtManzanos.Checked == true)
            {
                rbtManzanos.Checked = false;
                //MANZANOS
                try
                {
                    if (control.login(txtUser.Text, Encrypt.GetMD5(txtPass.Text)) == 1)
                    {
                        Session["log"] = 1;

                        Session["usuario"] = txtUser.Text;
                        HttpCookie cookie1 = new HttpCookie("login");
                        cookie1.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Add(cookie1);
                        Server.Transfer("InformeProdManzanos1.aspx", true);
                    }
                    else
                    {
                        //POR ENCRYP
                        if (control.login(txtUser.Text, Encrypt.GetMD5(txtPass.Text)) == 2)
                        {
                            Session["log"] = 2;

                            //usuario de tipo normals
                            Session["usuario"] = txtUser.Text;
                            HttpCookie cookie1 = new HttpCookie("login");
                            cookie1.Expires = DateTime.Now.AddMinutes(30);
                            Response.Cookies.Add(cookie1);
                            Server.Transfer("InformeProdManzanos2.aspx", true);

                        }
                        else
                        {
                            if (control.login(txtUser.Text, Encrypt.GetMD5(txtPass.Text)) == 3)
                            {
                                Session["log"] = 3;

                                //usuario de tipo solo informes
                                Session["usuario"] = txtUser.Text;
                                HttpCookie cookie1 = new HttpCookie("login");
                                cookie1.Expires = DateTime.Now.AddMinutes(30);
                                Response.Cookies.Add(cookie1);
                                Server.Transfer("InformeProdManzanos3.aspx", true);
                            }
                            else
                            {
                                if (control.login(txtUser.Text, txtPass.Text) == 0)
                                {
                                    Session["log"] = 0;

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
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblLogin.Text = "No se puede establecer conexión con el servidor.";
                    divBadLogin.Visible = true;
                }

            }
            else
            {
                lblLogin.Text = "Seleccione un sitio para navegar";
                divBadLogin.Visible = true;
            }
        }

        public class Encrypt
        {
            public static string GetMD5(string str)
            {
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
        }
    }
}