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
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            grillaCosecha.DataBind();
            if (!IsPostBack)
            {
                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-01");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            ddPotrero.Items.Insert(0, new ListItem("Todos...", "0"));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            ddSector.Items.Insert(0, new ListItem("Todos...", "0"));
        }

        //protected void ddCuartel_DataBound(object sender, EventArgs e)
        //{
        //    ddCuartel.Items.Insert(0, new ListItem("Todos", "0"));
        //}

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
        }

        protected void ddPotrero_SelectedIndexChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
        }

        protected void ddSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            grillaCosecha.DataBind();
        }
    }
}