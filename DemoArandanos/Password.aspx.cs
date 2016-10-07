using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class Password : System.Web.UI.Page
    {
        Controler control = new Controler();
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            if (!IsPostBack)
            {
                txtUser.Text = Application["usuario"].ToString();
            }
        }

        protected void btCambiarPass_Click(object sender, EventArgs e)
        {
            if (control.login(Application["usuario"].ToString(), Encrypt.GetMD5(txtPassOld.Text)) == 1 || control.login(Application["usuario"].ToString(), Encrypt.GetMD5(txtPassOld.Text)) == 2 || control.login(Application["usuario"].ToString(), Encrypt.GetMD5(txtPassOld.Text)) == 3)
            {
                if (txtPass1.Text.Equals(txtPass2.Text))
                {
                    try
                    {
                        //eliminar usuario y generar nuevo (mantener tipo) o actualizar usuario (ver si se puede) (insertSyncUsuario)

                        //traer tipo
                        String tipo = control.getTipoUser(Application["usuario"].ToString(), Encrypt.GetMD5(txtPassOld.Text));

                        //eliminar antiguo
                        control.eliminarUsuario(Application["usuario"].ToString(), Encrypt.GetMD5(txtPassOld.Text));
                        control.insertarSyncUsuario(Application["usuario"].ToString(), Encrypt.GetMD5(txtPassOld.Text), tipo, 0, "delete");

                        //insertar nuevo
                        control.insertarUsuario(txtUser.Text, Encrypt.GetMD5(txtPass1.Text), tipo);
                        control.insertarSyncUsuario(txtUser.Text, Encrypt.GetMD5(txtPass1.Text), tipo, 0, "insert");

                        lblsuccess.Text = "Contraseña cambiada con exito, será redireccionado a la página de inicio...";
                        divSuccess.Visible = true;

                        salirOK();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        lbldanger.Text = "No se pudo cambiar la contraseña";
                        divDanger.Visible = true;
                    }

                }
                else
                {
                    lblwarning.Text = "Las contraseñas nuevas no coinciden";
                    divWarning.Visible = true;
                    clear();
                }
            }
            else
            {
                lblwarning.Text = "La contraseña antigua no es válida";
                divWarning.Visible = true;
                clear();
            }
        }

        private void clear()
        {
            //txtUser.Text = "";
            txtPassOld.Text = "";
            txtPass1.Text = "";
            txtPass2.Text = "";
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

        public void salirOK()
        {
            txtUser.Attributes.Add("disabled", "true");
            txtPassOld.Attributes.Add("disabled", "true");
            txtPass1.Attributes.Add("disabled", "true");
            txtPass2.Attributes.Add("disabled", "true");
            btCambiarPass.Attributes.Add("disabled", "true");

            if (Request.Cookies.Get("login") != null)
            {
                HttpCookie cookie1 = new HttpCookie("login");
                cookie1.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie1);

                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "5;url=Login.aspx";
                this.Page.Controls.Add(meta);
            }
            else
            {
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "5;url=Login.aspx";
                this.Page.Controls.Add(meta);
            }
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