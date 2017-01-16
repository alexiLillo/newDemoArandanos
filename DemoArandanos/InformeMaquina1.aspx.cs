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
    public partial class InformeMaquina1 : System.Web.UI.Page
    {
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

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            grillaProdMaquina.DataBind();
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaProdMaquina.DataBind();
        }

        protected void grillaProdMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            resumen();
        }

        public void resumen()
        {
            int rows = grillaProdMaquina.Rows.Count;
            decimal kilos = 0;
            decimal bandejas = 0;

            for (int i = 0; i < rows; i++)
            {
                kilos += Decimal.Parse(grillaProdMaquina.Rows[i].Cells[6].Text);
            }

            for (int i = 0; i < rows; i++)
            {
                bandejas += Decimal.Parse(grillaProdMaquina.Rows[i].Cells[7].Text);
            }

            lbltotalkilos.Text = kilos.ToString();
            lbltotalbandejas.Text = bandejas.ToString();            
           
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
            if (!ddPotrero.SelectedItem.Text.Equals("Todos"))
                lblpotrer.Text = ddPotrero.SelectedItem.Text;
            if (!ddSector.SelectedItem.Text.Equals("Todos"))
                lblsect.Text = ddSector.SelectedItem.Text;
            if (!ddCuartel.SelectedItem.Text.Equals("Todos"))
                lblcuart.Text = ddCuartel.SelectedItem.Text;
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.AddHeader("content-disposition", "attachment;filename=Produccion-Maquina-Arandanos-" + lblvaried.Text + "-" + lblfund.Text + "-" + lblpotrer.Text + "-" + lblsect.Text + "-" + lblcuart.Text + "-'" + lbldesde.Text + "'-'" + lblhasta.Text + "'-.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grillaProdMaquina.AllowPaging = false;
                grillaProdMaquina.DataBind();

                grillaProdMaquina.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grillaProdMaquina.HeaderRow.Cells)
                {
                    cell.BackColor = grillaProdMaquina.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grillaProdMaquina.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grillaProdMaquina.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grillaProdMaquina.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grillaProdMaquina.RenderControl(hw);

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

        protected void grillaProdMaquina_DataBound(object sender, EventArgs e)
        {
            resumen();
        }
    }
}