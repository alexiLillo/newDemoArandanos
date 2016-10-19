using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeRepetidas1 : System.Web.UI.Page
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
    }
}