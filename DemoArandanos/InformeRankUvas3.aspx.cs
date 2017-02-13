using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace DemoArandanos
{
    public partial class InformeRankUvas3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;

            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 3)
                {
                    Server.Transfer("Login.aspx", true);
                }
                lblinfo.Text = "Los valores para cada trabajador varían según el rango de fecha asignado";
                divInfo.Visible = true;
                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            imp();
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            grillaRanking.DataBind();
            imp();
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaRanking.DataBind();
            imp();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            grillaRanking.DataBind();
            imp();
        }
        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            grillaRanking.DataBind();
            imp();
        }

        private void imp()
        {
            lblfiltr.Text = txtFiltro.Text.ToUpper();
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
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.AddHeader("content-disposition", "attachment;filename=Ranking-Vinedos-'" + lbldesde.Text + "' - '" + lblhasta.Text + "' -" + lblfiltr.Text + ".xls");
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