using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class PesajesUvas2 : System.Web.UI.Page
    {
        Controler control = new Controler();
        public String qrold;
        public DateTime fechaold;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 2)
                {
                    Server.Transfer("Login.aspx", true);
                }

                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            lblqrold.Visible = false;
            lblfechaold.Visible = false;
            //CANTIDAD TRABAJADORES
            lblcantidadTrabajadores.Text = ddTrabajadores.Items.Count.ToString();
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
                ddCuartel.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddClase_DataBound(object sender, EventArgs e)
        {
            if (ddClase.Items.Count > 1)
                ddClase.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        protected void ddTipoEnvase_DataBound(object sender, EventArgs e)
        {
            if (ddTipoEnvase.Items.Count > 1)
                ddTipoEnvase.Items.Insert(0, new ListItem("Seleccione...", "0"));
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

        public void limpiarCampos()
        {
            grillaPesajes.DataBind();
            txtQRenvase.Attributes.Remove("disabled");
            txtFechaHora.Attributes.Remove("disabled");
            txtQRenvase.Text = "";
            txtCuadrilla.Text = "";
            txtRutTrabajador.Text = "";
            txtRutPesador.Text = "";
            txtFechaHora.Text = "";
            //txtPesoBruto.Text = "";
            btGuardarPesaje.Attributes.Remove("disabled");
            //txtPesoBruto.Attributes.Remove("disabled");
            btEliminarPesaje.Attributes.Remove("disabled");
            ddTrabajadores.DataSource = null;
            ddTrabajadores.DataBind();

            ddClase.SelectedIndex = 0;

            List<String> listaEliminar = new List<string>();
            foreach (ListItem item in ddTrabajadores.Items)
            {
                listaEliminar.Add(item.Text);
            }
            foreach (String item in listaEliminar)
            {
                ddTrabajadores.Items.Remove(item);
            }

            //CANTIDAD TRABAJADORES
            lblcantidadTrabajadores.Text = ddTrabajadores.Items.Count.ToString();
        }

        protected void btGuardarPesaje_Click(object sender, EventArgs e)
        {
            if (ddTrabajadores.Items.Count > 0 && ddFundo.SelectedValue != "0" && ddPotrero.SelectedValue != "0" && ddSector.SelectedValue != "0" && ddVariedad.SelectedValue != "0" && ddCuartel.SelectedValue != "0")
            {
                try
                {
                    decimal pesoNeto = control.getKilosBin(ddVariedad.SelectedValue, ddClase.SelectedValue, ddTipoEnvase.SelectedItem.Text);
                    //String formato = control.getFormato(ddVariedad.SelectedValue, ddClase.SelectedValue);
                    List<String> listadoTrabajadores = new List<string>();
                    foreach (ListItem rut in ddTrabajadores.Items)
                    {
                        listadoTrabajadores.Add(rut.Text);
                    }
                    control.insertarRegistroBin("33", txtQRenvase.Text, txtCuadrilla.Text, listadoTrabajadores, txtRutPesador.Text, ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddVariedad.SelectedValue, ddClase.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(txtFechaHora.Text), pesoNeto / Convert.ToDecimal(lblcantidadTrabajadores.Text), 0, ddTipoEnvase.SelectedItem.Text, 1, Convert.ToDecimal(lblcantidadTrabajadores.Text), 1 / Convert.ToDecimal(lblcantidadTrabajadores.Text), "", "Manual", "-", Session["usuario"].ToString());
                    lblsuccess.Text = "Registros de bin ingresados correctamente.";
                    divSuccess.Visible = true;
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudieron ingresar los registros de bin";
                    divDanger.Visible = true;
                }

            }
            else
            {
                lblwarning.Text = "Complete todos los campos para poder guardar registros de Bin";
                divWarning.Visible = true;
            }
        }

        protected void grillaPesajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCampos();

            txtQRenvase.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtCuadrilla.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            //txtRutTrabajador.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            txtRutPesador.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
            DateTime d = DateTime.Parse(grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[11].Text.Replace("&nbsp;", "").ToString());
            txtFechaHora.Text = d.ToString("yyyy-MM-ddTHH:mm:ss");
            //decimal neto = Decimal.Parse(grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[12].Text.Replace("&nbsp;", "").ToString().Replace(".", ","));
            //decimal tara = Decimal.Parse(grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[13].Text.Replace("&nbsp;", "").ToString().Replace(".", ","));
            //decimal bruto = neto + tara;
            //txtPesoBruto.Text = bruto.ToString().Replace(",", ".");
            //ddTara.SelectedValue = tara.ToString();
            ddVariedad.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[8].Text.Replace("&nbsp;", "");
            ddFundo.DataBind();
            ddFundo.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");
            ddPotrero.DataBind();
            ddPotrero.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[6].Text.Replace("&nbsp;", "");
            ddSector.DataBind();
            ddSector.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[7].Text.Replace("&nbsp;", "");
            ddCuartel.DataBind();
            ddCuartel.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[10].Text.Replace("&nbsp;", "");

            ddClase.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[9].Text.Replace("&nbsp;", "");

            lblqrold.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            lblfechaold.Text = d.ToString("yyyy-MM-ddTHH:mm:ss");
            foreach (String rut in control.getListadoTrabajadoresBin(lblqrold.Text, DateTime.Parse(lblfechaold.Text)))
            {
                ddTrabajadores.Items.Insert(0, new ListItem(rut));
                ddTrabajadores.SelectedIndex = 0;
                lblcantidadTrabajadores.Text = ddTrabajadores.Items.Count.ToString();
            }

            btGuardarPesaje.Attributes.Add("disabled", "true");
            txtQRenvase.Attributes.Add("disabled", "true");
            txtFechaHora.Attributes.Add("disabled", "true");

            ddTipoEnvase.DataBind();
            ddTipoEnvase.SelectedIndex = ddTipoEnvase.Items.IndexOf(ddTipoEnvase.Items.FindByText(grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[13].Text.Replace("&nbsp;", "").ToString().Replace(".", ",")));
        }

        protected void btActualizarPesaje_Click(object sender, EventArgs e)
        {
            if (ddTrabajadores.Items.Count > 0 && ddFundo.SelectedValue != "0" && ddPotrero.SelectedValue != "0" && ddSector.SelectedValue != "0" && ddVariedad.SelectedValue != "0" && ddCuartel.SelectedValue != "0")
            {
                try
                {
                    if (control.eliminarRegistrosBin(control.getListadoIDsEliminarBin(txtQRenvase.Text, DateTime.Parse(txtFechaHora.Text))))
                    {
                        decimal pesoNeto = control.getKilosBin(ddVariedad.SelectedValue, ddClase.SelectedValue, ddTipoEnvase.SelectedItem.Text);
                        //String formato = control.getFormato(ddVariedad.SelectedValue, ddClase.SelectedValue);
                        List<String> listadoTrabajadores = new List<string>();
                        foreach (ListItem rut in ddTrabajadores.Items)
                        {
                            listadoTrabajadores.Add(rut.Text);
                        }
                        control.insertarRegistroBin("33", txtQRenvase.Text, txtCuadrilla.Text, listadoTrabajadores, txtRutPesador.Text, ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddVariedad.SelectedValue, ddClase.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(txtFechaHora.Text), pesoNeto / Convert.ToDecimal(lblcantidadTrabajadores.Text), 0, ddTipoEnvase.SelectedItem.Text, 1, Convert.ToDecimal(lblcantidadTrabajadores.Text), 1 / Convert.ToDecimal(lblcantidadTrabajadores.Text), "", "Manual", "-", Session["usuario"].ToString());
                        lblsuccess.Text = "Registros de Bin actualizados correctamente.";
                        divSuccess.Visible = true;
                        limpiarCampos();
                        btGuardarPesaje.Attributes.Remove("disabled");
                    }
                    else
                    {
                        lbldanger.Text = "No se pudieron actualizar registros de Bin, no se identificaron registros";
                        divDanger.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudieron actualizar registros de Bin";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lblwarning.Text = "Complete todos los campos para poder actualizar registros de Bin";
                divWarning.Visible = true;
            }
        }

        protected void btEliminarPesaje_Click(object sender, EventArgs e)
        {
            if (ddTrabajadores.Items.Count > 0)
            {
                try
                {
                    control.eliminarRegistrosBin(control.getListadoIDsEliminarBin(txtQRenvase.Text, DateTime.Parse(txtFechaHora.Text)));
                    lblinfo.Text = "Registros de Bin eliminados.";
                    divInfo.Visible = true;
                    limpiarCampos();
                    btGuardarPesaje.Attributes.Remove("disabled");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudieron eliminar registros de Bin";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lblwarning.Text = "Primero seleccine registros de Bin para poder eliminar";
                divWarning.Visible = true;
            }
        }

        protected void btLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.AddHeader("content-disposition", "attachment;filename=Registros-Bins-Uvas-" + txtFiltroRut.Text + "-'" + txtFechaInicio.Text + "'-'" + txtFechaTermino.Text + "'.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grillaPesajes.AllowPaging = false;
                grillaPesajes.DataBind();

                grillaPesajes.Columns[0].Visible = false;

                grillaPesajes.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grillaPesajes.HeaderRow.Cells)
                {
                    cell.BackColor = grillaPesajes.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grillaPesajes.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grillaPesajes.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grillaPesajes.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grillaPesajes.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

                grillaPesajes.Columns[0].Visible = true;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        //AGREGAR TRABAJADOR A DROPDOWN
        protected void btAgregarTrabajador_Click(object sender, EventArgs e)
        {
            if (validarRut(txtRutTrabajador.Text))
            {
                bool noExiste = true;
                foreach (ListItem rut in ddTrabajadores.Items)
                {
                    if (txtRutTrabajador.Text.Equals(rut.Text))
                    {
                        noExiste = false;
                        break;
                    }
                }

                if (noExiste)
                {
                    ddTrabajadores.Items.Insert(0, new ListItem(txtRutTrabajador.Text));
                    ddTrabajadores.SelectedIndex = 0;
                    txtRutTrabajador.Text = "";
                    //CANTIDAD TRABAJADORES
                    lblcantidadTrabajadores.Text = ddTrabajadores.Items.Count.ToString();
                }
                else
                {
                    lbldanger.Text = "Trabajador ya se ingresó anteriormente en la lista";
                    divDanger.Visible = true;
                    txtRutTrabajador.Text = "";
                }
            }
            else
            {
                lbldanger.Text = "Ingrese un rut de trabajador válido";
                divDanger.Visible = true;
            }
        }

        //QUITAR TRABAJADOR DE DROPDOWN
        protected void btQuitarTrabajador_Click(object sender, EventArgs e)
        {
            bool existe = false;
            foreach (ListItem rut in ddTrabajadores.Items)
            {
                if (txtRutTrabajador.Text.Equals(rut.Text))
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                ddTrabajadores.Items.Remove(txtRutTrabajador.Text);
                txtRutTrabajador.Text = "";
                //CANTIDAD TRABAJADORES
                lblcantidadTrabajadores.Text = ddTrabajadores.Items.Count.ToString();
            }
            else
            {
                lbldanger.Text = "Trabajador no existe en la lista";
                divDanger.Visible = true;
            }
        }

        protected void ddTrabajadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRutTrabajador.Text = ddTrabajadores.SelectedItem.Text;
        }

        //VALIDAR RUT
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