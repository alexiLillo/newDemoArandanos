using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class Taras : System.Web.UI.Page
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
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
        }

        protected void btGuardarTara_Click(object sender, EventArgs e)
        {
            try
            {
                control.insertarTara(txtCodTara.Text, Decimal.Parse(txtPesoTara.Text.Replace(".", ",")), txtDescripcion.Text, ddProducto.SelectedValue, txtFormato.Text);
                lblsuccess.Text = "Tara ingresada correctamente";
                divSuccess.Visible = true;
                txtCodTara.Text = "";
                txtPesoTara.Text = "";
                txtDescripcion.Text = "";
                txtFormato.Text = "";
                grillaTaras.DataBind();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldanger.Text = "No se pudo registrar Tara";
                divDanger.Visible = true;
            }
        }

        protected void btActualizarTara_Click(object sender, EventArgs e)
        {
            try
            {
                control.actualizarTara(txtCodTara.Text, Decimal.Parse(txtPesoTara.Text.Replace(".", ",")), txtDescripcion.Text, ddProducto.SelectedValue, txtFormato.Text);
                lblsuccess.Text = "Tara actualizada correctamente";
                divSuccess.Visible = true;
                txtCodTara.Text = "";
                txtPesoTara.Text = "";
                txtDescripcion.Text = "";
                txtFormato.Text = "";
                grillaTaras.DataBind();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldanger.Text = "No se pudo actualizar Tara";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarTara_Click(object sender, EventArgs e)
        {
            try
            {
                control.eliminarTara(txtCodTara.Text);
                lblinfo.Text = "Tara eliminada";
                divInfo.Visible = true;
                txtCodTara.Text = "";
                txtPesoTara.Text = "";
                txtDescripcion.Text = "";
                txtFormato.Text = "";
                grillaTaras.DataBind();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldanger.Text = "No se pudo eliminar Tara";
                divDanger.Visible = true;
            }
        }

        protected void grillaTaras_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodTara.Text = grillaTaras.Rows[grillaTaras.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtPesoTara.Text = grillaTaras.Rows[grillaTaras.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "").Replace(",", ".");
            ddProducto.SelectedValue = grillaTaras.Rows[grillaTaras.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            txtFormato.Text = grillaTaras.Rows[grillaTaras.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
            txtDescripcion.Text = grillaTaras.Rows[grillaTaras.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");
        }
    }
}