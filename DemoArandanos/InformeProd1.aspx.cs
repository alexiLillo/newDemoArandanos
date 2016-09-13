using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeProd1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
        }

        protected void ddVariedad_DataBound(object sender, EventArgs e)
        {
            ddVariedad.Items.Insert(0, new ListItem("Todas...", ""));
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            ddFundo.Items.Insert(0, new ListItem("Todos...", ""));
        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            ddPotrero.Items.Insert(0, new ListItem("Todos...", ""));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            ddSector.Items.Insert(0, new ListItem("Todos...", ""));
        }

        protected void ddCuartel_DataBound(object sender, EventArgs e)
        {
            ddCuartel.Items.Insert(0, new ListItem("Todos...", ""));
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
    }
}