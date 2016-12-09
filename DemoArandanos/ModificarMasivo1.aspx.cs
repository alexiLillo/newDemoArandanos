using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class ModificarMasivo1 : System.Web.UI.Page
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
                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-ddT23:59:00");
                txtCant.Text = "0";
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
        }

        protected void ddVariedad_DataBound(object sender, EventArgs e)
        {
            ddVariedad.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            ddFundo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            ddPotrero.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            ddSector.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddCuartel_DataBound(object sender, EventArgs e)
        {
            ddCuartel.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void txtFiltroRut_TextChanged(object sender, EventArgs e)
        {
            grillaPesajes.DataBind();
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            grillaPesajes.DataBind();
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaPesajes.DataBind();
        }

        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            grillaPesajes.DataBind();
        }

        protected void grillaPesajes_DataBound(object sender, EventArgs e)
        {
            lblcantidadbandejas.Text = grillaPesajes.Rows.Count.ToString();
        }

        //ddFiltros
        protected void ddVariedadFiltro_DataBound(object sender, EventArgs e)
        {
            ddVariedadFiltro.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddFundoFiltro_DataBound(object sender, EventArgs e)
        {
            ddFundoFiltro.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddPotreroFiltro_DataBound(object sender, EventArgs e)
        {
            ddPotreroFiltro.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddSectorFiltro_DataBound(object sender, EventArgs e)
        {
            ddSectorFiltro.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddCuartelFiltro_DataBound(object sender, EventArgs e)
        {
            ddCuartelFiltro.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void btModificarMasivo_Click(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text.Substring(0, 10).Equals(txtFechaTermino.Text.Substring(0, 10)))
            {
                if (ddVariedad.SelectedValue.Equals("0") || ddFundo.SelectedValue.Equals("0") || ddPotrero.SelectedValue.Equals("0") || ddSector.SelectedValue.Equals("0") || ddCuartel.SelectedValue.Equals("0"))
                {
                    lblwarning.Text = "Seleccione todas las opciones para modificar";
                    divWarning.Visible = true;
                }
                else
                {
                    try
                    {
                        int contador = 0;
                        foreach (GridViewRow row in grillaPesajes.Rows)
                        {
                            control.actualizarPesajeMasivo(row.Cells[0].Text, ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddVariedad.SelectedValue, ddCuartel.SelectedValue, DateTime.Now.ToString("dd/MM/yyyy HH:mm"), Application["usuario"].ToString());
                            contador++;
                        }
                        lblsuccess.Text = "Se modificaron " + contador + " registros de " + lblcantidadbandejas.Text + " seleccionados";
                        divSuccess.Visible = true;
                        txtCant.Text = "0";
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        lbldanger.Text = "No se pudieron actualizar los registros seleccionados";
                        divDanger.Visible = true;
                    }
                }
            }
            else
            {
                lblwarning.Text = "El rango de fecha seleccionado no puede estar entre dos días diferentes, no se puede modificar";
                divWarning.Visible = true;
            }
        }
    }
}