 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeCosecha1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 1)
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
    }
}