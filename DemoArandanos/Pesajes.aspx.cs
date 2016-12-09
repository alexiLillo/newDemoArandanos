using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class Pesajes : System.Web.UI.Page
    {
        Controler control = new Controler();
        public String qrold;
        public DateTime fechaold;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 1)
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
        }

        protected void ddVariedad_DataBound(object sender, EventArgs e)
        {
            ddVariedad.Items.Insert(0, new ListItem("Seleccione...", ""));
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

        public void limpiarCampos()
        {
            grillaPesajes.DataBind();
            txtQRenvase.Attributes.Remove("readonly");
            txtFechaHora.Attributes.Remove("readonly");
            txtQRenvase.Text = "";
            txtRutTrabajador.Text = "";
            txtRutPesador.Text = "";
            txtFechaHora.Text = "";
            txtPesoBruto.Text = "";
            btGuardarPesaje.Attributes.Remove("disabled");
            txtPesoBruto.Attributes.Remove("disabled");
            //btEliminarPesaje.Attributes.Remove("disabled");
        }

        protected void btGuardarPesaje_Click(object sender, EventArgs e)
        {
            if (ddFundo.SelectedValue != "0" && ddPotrero.SelectedValue != "0" && ddSector.SelectedValue != "0" && ddVariedad.SelectedValue != "0" && ddCuartel.SelectedValue != "0")
            {
                try
                {
                    decimal pesoNeto = Decimal.Parse(txtPesoBruto.Text.Replace(".", ",")) - Decimal.Parse(ddTara.SelectedValue.Replace(".", ","));
                    String[] split = ddTara.SelectedItem.Text.Split(':');
                    String formato = split[0];
                    control.insertarPesaje("32", txtQRenvase.Text, txtRutTrabajador.Text, txtRutPesador.Text, ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddVariedad.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(txtFechaHora.Text), pesoNeto, Decimal.Parse(ddTara.SelectedValue), formato, 1, 1, 1, "", "Manual", "-", Session["usuario"].ToString());
                    lblsuccess.Text = "Pesaje ingresado correctamente.";
                    divSuccess.Visible = true;
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar Pesaje";
                    divDanger.Visible = true;
                }

            }
            else
            {
                lblwarning.Text = "Seleccione todos los campos para poder registrar Pesaje";
                divWarning.Visible = true;
            }
        }

        protected void grillaPesajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQRenvase.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtRutTrabajador.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            txtRutPesador.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            DateTime d = DateTime.Parse(grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[9].Text.Replace("&nbsp;", "").ToString());
            txtFechaHora.Text = d.ToString("yyyy-MM-ddTHH:mm:ss");
            decimal neto = Decimal.Parse(grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[10].Text.Replace("&nbsp;", "").ToString().Replace(".", ","));
            decimal tara = Decimal.Parse(grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[11].Text.Replace("&nbsp;", "").ToString().Replace(".", ","));
            decimal bruto = neto + tara;
            txtPesoBruto.Text = bruto.ToString().Replace(",", ".");
            ddTara.SelectedValue = tara.ToString();
            ddVariedad.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[7].Text.Replace("&nbsp;", "");
            ddFundo.DataBind();
            ddFundo.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
            ddPotrero.DataBind();
            ddPotrero.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");
            ddSector.DataBind();
            ddSector.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[6].Text.Replace("&nbsp;", "");
            ddCuartel.DataBind();
            ddCuartel.SelectedValue = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[8].Text.Replace("&nbsp;", "");

            lblqrold.Text = grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            lblfechaold.Text = d.ToString("yyyy-MM-ddTHH:mm:ss");

            btGuardarPesaje.Attributes.Add("disabled", "true");

            if (grillaPesajes.Rows[grillaPesajes.SelectedIndex].Cells[12].Text.Replace("&nbsp;", "").ToString().Equals("CELULAR"))
            {
                txtPesoBruto.Attributes.Add("disabled", "true");
                //btEliminarPesaje.Attributes.Add("disabled", "true");
            }
            else
            {
                txtPesoBruto.Attributes.Remove("disabled");
                //btEliminarPesaje.Attributes.Remove("disabled");
            }
        }

        protected void btActualizarPesaje_Click(object sender, EventArgs e)
        {
            if (ddFundo.SelectedValue != "0" && ddPotrero.SelectedValue != "0" && ddSector.SelectedValue != "0" && ddVariedad.SelectedValue != "0" && ddCuartel.SelectedValue != "0")
            {
                try
                {
                    decimal pesoNeto = Decimal.Parse(txtPesoBruto.Text.Replace(".", ",")) - Decimal.Parse(ddTara.SelectedValue.Replace(".", ","));
                    String[] split = ddTara.SelectedItem.Text.Split(':');
                    String formato = split[0];
                    control.actualizarPesaje(lblqrold.Text, DateTime.Parse(lblfechaold.Text), "32", txtQRenvase.Text, txtRutTrabajador.Text, txtRutPesador.Text, ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddVariedad.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(txtFechaHora.Text), pesoNeto, Decimal.Parse(ddTara.SelectedValue), formato, 1, 1, 1, "", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), Session["usuario"].ToString());
                    lblsuccess.Text = "Pesaje actualizado correctamente.";
                    divSuccess.Visible = true;
                    limpiarCampos();
                    btGuardarPesaje.Attributes.Remove("disabled");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo actualizar Pesaje ";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lblwarning.Text = "Seleccione todos los campos para poder actualizar Pesaje";
                divWarning.Visible = true;
            }
        }

        protected void btEliminarPesaje_Click(object sender, EventArgs e)
        {
            try
            {
                control.eliminarPesaje("32", txtQRenvase.Text, DateTime.Parse(txtFechaHora.Text));
                lblinfo.Text = "Pesaje eliminado.";
                divInfo.Visible = true;
                limpiarCampos();
                btGuardarPesaje.Attributes.Remove("disabled");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldanger.Text = "No se pudo eliminar Pesaje";
                divDanger.Visible = true;
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
            Response.AddHeader("content-disposition", "attachment;filename=Pesajes-" + txtFiltroRut.Text + "-'" + txtFechaInicio.Text + "'-'" + txtFechaTermino.Text + "'.xls");
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
    }
}