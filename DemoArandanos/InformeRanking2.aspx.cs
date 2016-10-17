using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeRanking2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;

            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 1)
                {
                    Server.Transfer("Login.aspx", true);
                }
                lblinfo.Text = "Los valores para cada trabajador varían según el rango de fecha asignado";
                divInfo.Visible = true;
                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-01");
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
    }
}