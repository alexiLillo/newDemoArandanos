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
    public partial class Produccion2 : System.Web.UI.Page
    {
        Controler control = new Controler();
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
        }

        protected void btGenerarQR_Click(object sender, EventArgs e)
        {
            string code = txtRutTrabajador.Text;
            if (validarRut(code))
            {
                //GUARDAR DATOS DE TRABAJADOR EN BD (VALIDAR RUT)
                try
                {
                    control.insertarTrabajador(code, txtNombreTrabajador.Text, txtApellidoTrabajador.Text, code, txtFechaNacimiento.Text);
                    lblsuccess.Text = "Trabajador ingresado correctamente";
                    divSuccess.Visible = true;
                    txtRutTrabajador.Text = "";
                    txtNombreTrabajador.Text = "";
                    txtApellidoTrabajador.Text = "";
                    txtFechaNacimiento.Text = "";
                }
                catch (Exception ex)
                {
                    lbldanger.Text = "No se pudo registrar al trabajador";
                    divDanger.Visible = true;
                }

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
    }
}