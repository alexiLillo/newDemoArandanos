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
    public partial class InformeProd2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 2)
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

        protected void ddVariedad_DataBound(object sender, EventArgs e)
        {
            if (ddVariedad.Items.Count > 1)
                ddVariedad.Items.Insert(0, new ListItem("Todas", ""));
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            if (ddFundo.Items.Count > 1)
                ddFundo.Items.Insert(0, new ListItem("Todo", ""));
        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            if (ddPotrero.Items.Count > 1)
                ddPotrero.Items.Insert(0, new ListItem("Todos", ""));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            if (ddSector.Items.Count > 1)
                ddSector.Items.Insert(0, new ListItem("Todos", ""));
        }

        protected void ddCuartel_DataBound(object sender, EventArgs e)
        {
            if (ddCuartel.Items.Count > 1)
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
            List<String> lista = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                kilos += Decimal.Parse(grillaPesajesProd.Rows[i].Cells[5].Text);
                lista.Add(grillaPesajesProd.Rows[i].Cells[1].Text);
            }

            int trabajadores = new HashSet<String>(lista).Count;

            lbltotalbandejas.Text = rows.ToString();
            lbltotalkilos.Text = decimal.Round(kilos, 2).ToString();
            lbltotaltrabajadores.Text = trabajadores.ToString();
            decimal prom = 0;
            try
            {
                prom = decimal.Round(kilos / trabajadores, 2);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            lblpromkltrab.Text = prom.ToString();

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

            lblvaried.Text = ddVariedad.SelectedItem.Text;
            lblfund.Text = ddFundo.SelectedItem.Text;
            if (ddPotrero.SelectedItem != null)
                lblpotrer.Text = ddPotrero.SelectedItem.Text;
            if (ddSector.SelectedItem != null)
                lblsect.Text = ddSector.SelectedItem.Text;
            if (ddCuartel.SelectedItem != null)
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
            Response.AddHeader("content-disposition", "attachment;filename=Produccion-Arandanos-" + lblvaried.Text + "-" + lblfund.Text + "-" + lblpotrer.Text + "-" + lblsect.Text + "-" + lblcuart.Text + "-'" + lbldesde.Text + "'-'" + lblhasta.Text + "'-" + lblfiltr.Text + ".xls");
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