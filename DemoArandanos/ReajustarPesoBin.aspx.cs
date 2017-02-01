using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class ReajustarPesoBin : System.Web.UI.Page
    {
        Controler control = new Controler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 1)
                {
                    Server.Transfer("Login.aspx", true);
                }
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            lblpesodeldia.Text = control.pesoPorDiaManzanos(DateTime.Parse(txtFecha.Text)).ToString();
        }

        protected void btReajustarPeso_Click(object sender, EventArgs e)
        {
            int reajustados = control.reajustarPesosBins(DateTime.Parse(txtFecha.Text));
            int total = control.catidadRegistrosBinDia(DateTime.Parse(txtFecha.Text));
            if (reajustados == total)
            {
                lblsuccess.Text = "Se reajustó el peso de " + reajustados + " registros, de un total de " + total;
                divSuccess.Visible = true;
            }
            else
            {
                lblwarning.Text = "Se reajustó el peso de " + reajustados + " registros, de un total de " + total;
                divWarning.Visible = true;
            }
        }
    }
}