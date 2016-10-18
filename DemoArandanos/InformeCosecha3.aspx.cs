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
    public partial class InformeCosecha3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 3)
                {
                    Server.Transfer("Login.aspx", true);
                }
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            //grillaCosecha.DataBind();
            if (!IsPostBack)
            {
                lblinfo.Text = "Bandejas Total y Kilos Total varían según el rango de fecha asignado";
                divInfo.Visible = true;

                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-01");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
                imp();
            }
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            //grillaCosecha.DataBind();
            lblfund.Text = ddFundo.SelectedItem.Text;

        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            ddPotrero.Items.Insert(0, new ListItem("Todos...", "0"));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            ddSector.Items.Insert(0, new ListItem("Todos...", "0"));
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
            imp();
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
            imp();
        }

        protected void ddFundo_SelectedIndexChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
            lblfund.Text = ddFundo.SelectedItem.Text;
        }

        protected void ddPotrero_SelectedIndexChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
            imp();
        }

        protected void ddSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
            imp();
        }

        private void imp()
        {
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
        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Cosecha - '" + lbldesde.Text + "' - '" + lblhasta.Text + "'.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                GridView1.DataBind();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

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