using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeProdManzanos3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 3)
                {
                    Server.Transfer("Login.aspx", true);
                }
                //dsGrillaPesajeProd.SelectParameters["FechaHora"].DefaultValue = DateTime.Now.ToString("dd-MM-yyyy");
                //dsGrillaPesajeProd.SelectParameters["FechaHora2"].DefaultValue = DateTime.Now.ToString("dd-MM-yyyy");

                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;

            //resumen();
        }

        protected void ddClase_DataBound(object sender, EventArgs e)
        {
            ddClase.Items.Insert(0, new ListItem("Todas", ""));
        }

        protected void ddVariedad_DataBound(object sender, EventArgs e)
        {
            ddVariedad.Items.Insert(0, new ListItem("Todas", ""));
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            ddFundo.Items.Insert(0, new ListItem("Todo", ""));
        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            ddPotrero.Items.Insert(0, new ListItem("Todos", ""));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            ddSector.Items.Insert(0, new ListItem("Todos", ""));
        }

        protected void ddCuartel_DataBound(object sender, EventArgs e)
        {
            ddCuartel.Items.Insert(0, new ListItem("Todos", ""));
        }


        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            grillaPesajesProd.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            grillaPesajesProd.DataBind();
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            grillaPesajesProd.DataBind();
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaPesajesProd.DataBind();
        }

        public void resumen()
        {
            int rows = grillaPesajesProd.Rows.Count;
            decimal kilos = 0;
            decimal bins = 0;
            List<String> lista = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                kilos += Decimal.Parse(grillaPesajesProd.Rows[i].Cells[6].Text);
                lista.Add(grillaPesajesProd.Rows[i].Cells[2].Text);
            }

            for (int i = 0; i < rows; i++)
            {
                bins += Decimal.Parse(grillaPesajesProd.Rows[i].Cells[7].Text);
            }

            int trabajadores = new HashSet<String>(lista).Count;

            if (txtFiltro.Text.Equals(""))
                lbltotalbins.Text = decimal.Round(bins, 0).ToString();
            else
                lbltotalbins.Text = decimal.Round(bins, 2).ToString();

            //lbltotalbins.Text = decimal.Round(bins, 2).ToString();
            lbltotalkilos.Text = kilos.ToString();
            lbltotaltrabajadores.Text = trabajadores.ToString();
            decimal prom = 0;
            try
            {
                prom = decimal.Round(bins / trabajadores, 2);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            lblprombinstrab.Text = prom.ToString();

            //imprimir
            try
            {
                DateTime desde = DateTime.Parse(txtFechaInicio.Text);
                lbldesde.Text = desde.ToString("dd-MM-yyyy");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldesde.Text = "-";
            }

            try
            {
                DateTime hasta = DateTime.Parse(txtFechaTermino.Text);
                lblhasta.Text = hasta.ToString("dd-MM-yyyy");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblhasta.Text = "-";
            }

            lblcateg.Text = ddClase.SelectedItem.Text;
            lblvaried.Text = ddVariedad.SelectedItem.Text;
            lblfund.Text = ddFundo.SelectedItem.Text;
            if (!ddPotrero.SelectedItem.Text.Equals("Todos"))
                lblpotrer.Text = ddPotrero.SelectedItem.Text;
            if (!ddSector.SelectedItem.Text.Equals("Todos"))
                lblsect.Text = ddSector.SelectedItem.Text;
            if (!ddCuartel.SelectedItem.Text.Equals("Todos"))
                lblcuart.Text = ddCuartel.SelectedItem.Text;
            lblfiltr.Text = txtFiltro.Text;

        }

        protected void grillaPesajesProd_DataBound(object sender, EventArgs e)
        {
            resumen();
        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.AddHeader("content-disposition", "attachment;filename=Produccion-Manzanos-" + lblcateg.Text + "-" + lblvaried.Text + "-" + lblfund.Text + "-" + lblpotrer.Text + "-" + lblsect.Text + "-" + lblcuart.Text + "-'" + lbldesde.Text + "'-'" + lblhasta.Text + "'-" + lblfiltr.Text + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grillaPesajesProd.AllowPaging = false;
                grillaPesajesProd.DataBind();

                grillaPesajesProd.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grillaPesajesProd.HeaderRow.Cells)
                {
                    cell.BackColor = grillaPesajesProd.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grillaPesajesProd.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grillaPesajesProd.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grillaPesajesProd.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grillaPesajesProd.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


    }
}