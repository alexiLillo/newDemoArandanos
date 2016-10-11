using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QRCoder;
using System.IO;
using System.Drawing;
using DemoArandanos.Controlador;

namespace DemoArandanos
{
    public partial class Trabajadores2 : System.Web.UI.Page
    {
        Controler control = new Controler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 2)
                {
                    Server.Transfer("Login.aspx", true);
                }
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
        }

        public void generaQR(String rut)
        {
            string code = rut;
            if (validarRut(code))
            {
                plBarCode.Controls.Clear();
                lblQR.Text = "";

                String spaces = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                if (code.Length == 9)
                {
                    spaces = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                }

                for (int i = 0; i < 3; i++)
                {
                    Label label = new Label();
                    label.Text = code;
                    lblQR.Text = lblQR.Text + spaces + code;
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 100;
                    imgBarCode.Width = 100;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                    }
                    plBarCode.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                    plBarCode.Controls.Add(imgBarCode);

                    if (i < 2)
                    {
                        spaces = spaces + "&nbsp;&nbsp;";
                        if (code.Length == 9)
                            spaces = spaces + "&nbsp;";
                    }
                }
            }
            else
            {
                lblwarning.Text = "Rut Inválido!";
                divWarning.Visible = true;
            }
        }

        protected void btGenerarQR_Click(object sender, EventArgs e)
        {
            generaQR(txtRutTrabajador.Text);
        }

        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        protected void btGuardarTrabajador_Click(object sender, EventArgs e)
        {
            if (validarRut(txtRutTrabajador.Text))
            {
                //GUARDAR DATOS DE TRABAJADOR EN BD (VALIDAR RUT)
                try
                {
                    control.insertarTrabajador(txtRutTrabajador.Text, txtNombreTrabajador.Text, txtApellidoTrabajador.Text, txtRutTrabajador.Text, txtFechaNacimiento.Text, DateTime.Now.ToString("yyyy-MM-dd"), Int32.Parse(txtFicha.Text));
                    lblsuccess.Text = "Trabajador ingresado correctamente";
                    divSuccess.Visible = true;
                    generaQR(txtRutTrabajador.Text);
                    txtRutTrabajador.Text = "";
                    txtNombreTrabajador.Text = "";
                    txtApellidoTrabajador.Text = "";
                    txtFechaNacimiento.Text = "";
                    txtFicha.Text = "";
                    grillaTrabajadores.DataBind();                    
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo registrar al trabajador";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lblwarning.Text = "Rut Inválido!";
                divWarning.Visible = true;
            }
        }

        protected void grillaTrabajadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRutTrabajador.Text = grillaTrabajadores.Rows[grillaTrabajadores.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtNombreTrabajador.Text = grillaTrabajadores.Rows[grillaTrabajadores.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            txtApellidoTrabajador.Text = grillaTrabajadores.Rows[grillaTrabajadores.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            DateTime d = DateTime.Parse(grillaTrabajadores.Rows[grillaTrabajadores.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "").ToString());
            txtFechaNacimiento.Text = d.ToString("yyyy-MM-dd");
            txtFicha.Text = grillaTrabajadores.Rows[grillaTrabajadores.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");

        }

        protected void btActualizarTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                control.actualizarTrabajador(txtRutTrabajador.Text, txtNombreTrabajador.Text, txtApellidoTrabajador.Text, txtRutTrabajador.Text, txtFechaNacimiento.Text, DateTime.Now.ToString("yyyy-MM-dd"), Int32.Parse(txtFicha.Text));
                lblsuccess.Text = "Trabajador actualizado correctamente";
                divSuccess.Visible = true;
                txtRutTrabajador.Text = "";
                txtNombreTrabajador.Text = "";
                txtApellidoTrabajador.Text = "";
                txtFechaNacimiento.Text = "";
                txtFicha.Text = "";
                grillaTrabajadores.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldanger.Text = "No se pudo actualziar información del trabajador";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                control.eliminarTrabajador(txtRutTrabajador.Text);
                lblinfo.Text = "Trabajador eliminado correctamente";
                divInfo.Visible = true;
                txtRutTrabajador.Text = "";
                txtNombreTrabajador.Text = "";
                txtApellidoTrabajador.Text = "";
                txtFechaNacimiento.Text = "";
                txtFicha.Text = "";
                grillaTrabajadores.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldanger.Text = "No se pudo eliminar el trabajador";
                divDanger.Visible = true;
            }
        }

        protected void txtFiltroRut_TextChanged(object sender, EventArgs e)
        {
            grillaTrabajadores.DataBind();
        }
        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            grillaTrabajadores.DataBind();
        }
    }
}