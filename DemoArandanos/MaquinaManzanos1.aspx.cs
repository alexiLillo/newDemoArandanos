using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class MaquinaManzanos1 : System.Web.UI.Page
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

                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-01");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            lblid.Visible = false;
        }

        protected void ddVariedad_DataBound(object sender, EventArgs e)
        {
            if (ddVariedad.Items.Count > 1)
                ddVariedad.Items.Insert(0, new ListItem("Seleccione...", ""));
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            if (ddFundo.Items.Count > 1)
                ddFundo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            if (ddPotrero.Items.Count > 1)
                ddPotrero.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            if (ddSector.Items.Count > 1)
                ddSector.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddCuartel_DataBound(object sender, EventArgs e)
        {
            if (ddCuartel.Items.Count > 1)
                ddCuartel.Items.Insert(0, new ListItem("SIN CUARTEL", "0"));
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            grillaMaquina.DataBind();
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaMaquina.DataBind();
        }

        public void limpiarCampos()
        {
            grillaMaquina.DataBind();
            btGuardarCosechaMaquina.Attributes.Remove("disabled");

            txtDescripcion.Text = "";
            txtBandejas.Text = "";
            txtFechaCosecha.Text = "";
            txtGuia.Text = "";
            txtRecepcion.Text = "";
            txtKilos.Text = "";
            ddVariedad.SelectedIndex = 0;
            lblid.Text = "";
        }

        protected void btLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void grillaMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            ddVariedad.SelectedValue = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            ddFundo.DataBind();
            ddFundo.SelectedValue = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            ddPotrero.DataBind();
            ddPotrero.SelectedValue = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
            ddSector.DataBind();
            ddSector.SelectedValue = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");
            ddCuartel.DataBind();
            ddCuartel.SelectedValue = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[6].Text.Replace("&nbsp;", "");
            DateTime d = DateTime.Parse(grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[7].Text.Replace("&nbsp;", "").ToString());
            txtFechaCosecha.Text = d.ToString("yyyy-MM-dd");
            decimal pesoNeto = Decimal.Parse(grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[8].Text.Replace("&nbsp;", "").ToString().Replace(".", ""));
            decimal bandejas = Decimal.Parse(grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[9].Text.Replace("&nbsp;", "").ToString().Replace(".", ""));
            txtKilos.Text = pesoNeto.ToString().Replace(",", ".");
            txtBandejas.Text = bandejas.ToString().Replace(",", ".");
            txtGuia.Text = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[10].Text.Replace("&nbsp;", "");
            txtRecepcion.Text = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[11].Text.Replace("&nbsp;", "");
            lblid.Text = grillaMaquina.Rows[grillaMaquina.SelectedIndex].Cells[12].Text.Replace("&nbsp;", "");

            btGuardarCosechaMaquina.Attributes.Add("disabled", "true");
        }

        protected void btGuardarCosechaMaquina_Click(object sender, EventArgs e)
        {
            if (ddFundo.SelectedValue != "0" && ddPotrero.SelectedValue != "0" && ddSector.SelectedValue != "0" && ddVariedad.SelectedValue != "0")
            {
                try
                {
                    decimal pesoNeto = Decimal.Parse(txtKilos.Text.Replace(".", ","));
                    decimal bandejas = Decimal.Parse(txtBandejas.Text.Replace(".", ","));
                    control.insertarCosechaMaquina("25", ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddVariedad.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(txtFechaCosecha.Text), pesoNeto, bandejas, txtGuia.Text, txtRecepcion.Text, txtDescripcion.Text);
                    lblsuccess.Text = "Cosecha Contratista ingresada correctamente.";
                    divSuccess.Visible = true;
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar Cosecha Contratista";
                    divDanger.Visible = true;
                }

            }
            else
            {
                lblwarning.Text = "Seleccione todos los campos para poder registrar Cosecha Contratista";
                divWarning.Visible = true;
            }
        }

        protected void btActualizarCosechaMaquina_Click(object sender, EventArgs e)
        {
            if (ddFundo.SelectedValue != "0" && ddPotrero.SelectedValue != "0" && ddSector.SelectedValue != "0" && ddVariedad.SelectedValue != "0")
            {
                try
                {
                    decimal pesoNeto = Decimal.Parse(txtKilos.Text.Replace(".", ","));
                    decimal bandejas = Decimal.Parse(txtBandejas.Text.Replace(".", ","));
                    int id = int.Parse(lblid.Text);
                    control.actualizarCosechaMaquina(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddVariedad.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(txtFechaCosecha.Text), pesoNeto, bandejas, txtGuia.Text, txtRecepcion.Text, id, txtDescripcion.Text);
                    lblsuccess.Text = "Cosecha Contratista actualizada correctamente.";
                    divSuccess.Visible = true;
                    limpiarCampos();
                    btGuardarCosechaMaquina.Attributes.Remove("disabled");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo actualizar Cosecha Contratista ";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lblwarning.Text = "Seleccione todos los campos para poder actualizar Cosecha Contratista";
                divWarning.Visible = true;
            }
        }

        protected void btEliminarCosechaMaquina_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblid.Text);
                control.eliminarCosechaMaquina(id);
                lblinfo.Text = "Cosecha Contratista eliminada.";
                divInfo.Visible = true;
                limpiarCampos();
                btGuardarCosechaMaquina.Attributes.Remove("disabled");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldanger.Text = "No se pudo eliminar Cosecha Contratista";
                divDanger.Visible = true;
            }
        }
    }
}