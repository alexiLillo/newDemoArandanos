using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeProd3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            double kilos = 0;
            List<String> lista = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                kilos += Double.Parse(grillaPesajesProd.Rows[i].Cells[5].Text);
                lista.Add(grillaPesajesProd.Rows[i].Cells[1].Text);
            }

            int trabajadores = new HashSet<String>(lista).Count;

            lbltotalbandejas.Text = rows.ToString();
            lbltotalkilos.Text = kilos.ToString();
            lbltotaltrabajadores.Text = trabajadores.ToString();
            double prom = kilos / trabajadores;
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
    }
}