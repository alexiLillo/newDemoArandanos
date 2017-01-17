using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeRepeManzanos1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 1)
                {
                    Server.Transfer("Login.aspx", true);
                }

                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaRepetidas.DataBind();
        }

        protected void grillaRepetidas_DataBound(object sender, EventArgs e)
        {
            string vari = "";
            bool change = true;
            foreach (GridViewRow row in grillaRepetidas.Rows)
            {
                if (!vari.Equals(row.Cells[0].Text))
                {
                    //cambia color
                    if (change)
                        change = false;
                    else
                        change = true;
                }

                if (!change)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        row.Cells[i].BackColor = Color.LightGray;
                        //row.Cells[i].ForeColor = Color.White;
                    }
                }

                vari = row.Cells[0].Text;
            }


            vari = "";
            change = true;
            foreach (GridViewRow row in grillaImp.Rows)
            {
                if (!vari.Equals(row.Cells[0].Text))
                {
                    //cambia color
                    if (change)
                        change = false;
                    else
                        change = true;
                }

                if (!change)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        row.Cells[i].BackColor = Color.LightGray;
                        //row.Cells[i].ForeColor = Color.White;
                    }
                }

                vari = row.Cells[0].Text;
            }
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.AddHeader("content-disposition", "attachment;filename=Informe-Registros-Bins-Repetidos-" + txtFecha.Text + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                try
                {
                    //To Export all pages
                    grillaRepetidas.AllowPaging = false;
                    grillaRepetidas.DataBind();

                    grillaRepetidas.Columns[0].Visible = false;

                    grillaRepetidas.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in grillaRepetidas.HeaderRow.Cells)
                    {
                        cell.BackColor = grillaRepetidas.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grillaRepetidas.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grillaRepetidas.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grillaRepetidas.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grillaRepetidas.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();

                    grillaRepetidas.Columns[0].Visible = true;
                }
                catch (Exception)
                {
                    lblwarning.Text = "No se puede convertir a Excel";
                    divWarning.Visible = true;
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}