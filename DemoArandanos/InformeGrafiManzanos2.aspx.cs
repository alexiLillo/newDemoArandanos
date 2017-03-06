using DemoArandanos.Controlador;
using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeGrafiManzanos2 : System.Web.UI.Page
    {
        Controler control = new Controler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (int)Session["log"] != 2)
                {
                    Server.Transfer("Login.aspx", true);
                }
                lblKilosOEnvases1.Text = ddEnvaseOKilo.SelectedValue;
                lblKilosOEnvases2.Text = ddEnvaseOKilo.SelectedValue;
            }

            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;

            if (!IsPostBack)
            {
                lblinfo.Text = "Seleccione un rango de fecha";
                divInfo.Visible = true;
                //txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-01");
                //txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                load();
            }
        }

        public void load()
        {
            String inicio = DateTime.Parse(txtFechaInicio.Text + " 00:00").ToString("yyyy-MM-ddTHH:mm");
            String fin = DateTime.Parse(txtFechaTermino.Text + " 23:59").ToString("yyyy-MM-ddTHH:mm");
            cargarGrafico(GraficoVariedad, control.getCantidadPorVariedad(ddEnvaseOKilo.SelectedValue, "25", ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(inicio), DateTime.Parse(fin)), control.getVariedades("25"), true);
            cargarGrafico(GraficoCuartel, control.getCantidadTotal(ddEnvaseOKilo.SelectedValue, "25", ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, DateTime.Parse(inicio), DateTime.Parse(fin)), control.getNombres("25", ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue), false);
        }

        public void cargarGrafico(Chart graf, double[] yValores, String[] xNombres, bool colores)
        {
            graf.Series.Add(new Series());
            graf.Series[0].Points.DataBindXY(xNombres, yValores);
            graf.Series[0].ChartType = SeriesChartType.Column;
            graf.Series[0].Label = "#VALY{0.00}";
            graf.Series[0].LabelForeColor = Color.White;
            graf.Series[0].LabelBackColor = Color.Gray;
            graf.Series[0].LabelBorderColor = Color.Gray;
            //graf.Series[0].Label = "#VALX #VALY";

            if (colores)
            {
                for (int i = 0; i < xNombres.Length; i++)
                {
                    if (i == 0)
                        graf.Series[0].Points[i].Color = Color.PaleGreen;       //BRIGITTA
                    if (i == 1)
                        graf.Series[0].Points[i].Color = Color.Violet;          //LEGACY
                    if (i == 2)
                        graf.Series[0].Points[i].Color = Color.Salmon;          //DUKE
                    if (i == 3)
                        graf.Series[0].Points[i].Color = Color.SkyBlue;         //BLUEGOLD
                    if (i == 4)
                        graf.Series[0].Points[i].Color = Color.Khaki;           //CAMELIA
                    if (i == 5)
                        graf.Series[0].Points[i].Color = Color.DodgerBlue;      //TIFBLUE
                    if (i == 6)
                        graf.Series[0].Points[i].Color = Color.DeepSkyBlue;     //BRIGHTWELL
                    if (i == 7)
                        graf.Series[0].Points[i].Color = Color.Purple;
                    if (i == 8)
                        graf.Series[0].Points[i].Color = Color.AliceBlue;
                    if (i == 9)
                        graf.Series[0].Points[i].Color = Color.Brown;
                    if (i == 10)
                        graf.Series[0].Points[i].Color = Color.DarkRed;
                    if (i == 11)
                        graf.Series[0].Points[i].Color = Color.GreenYellow;
                    if (i == 12)
                        graf.Series[0].Points[i].Color = Color.Olive;
                }
            }
            else
            {
                graf.Series[0].Color = Color.Blue;
                lbltotal.Text = decimal.Round(Convert.ToDecimal(yValores.Sum()), 0).ToString();
            }

            graf.ImageType = ChartImageType.Jpeg;
            graf.ChartAreas.Add(new ChartArea());
            graf.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            //labels imprimir
            try
            {
                DateTime desde = DateTime.Parse(txtFechaInicio.Text);
                lbldesdeimp.Text = desde.ToString("dd-MM-yyyy");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lbldesdeimp.Text = "-";
            }

            try
            {
                DateTime hasta = DateTime.Parse(txtFechaTermino.Text);
                lblhastaimp.Text = hasta.ToString("dd-MM-yyyy");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                lblhastaimp.Text = "-";
            }
            lblfundimp.Text = ddFundo.SelectedItem.Text;
            if (ddPotrero.SelectedItem != null)
                lblpotrerimp.Text = ddPotrero.SelectedItem.Text;
            if (ddSector.SelectedItem != null)
                lblsectimp.Text = ddSector.SelectedItem.Text;
            if (ddCuartel.SelectedItem != null)
                lblcuartelimp.Text = ddCuartel.SelectedItem.Text;
            lbltotalimp.Text = lbltotal.Text;
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            //if (ddPotrero.Items.Count > 1)
            ddPotrero.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            //if (ddSector.Items.Count > 1)
            ddSector.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void ddCuartel_DataBound(object sender, EventArgs e)
        {
            //if (ddCuartel.Items.Count > 1)
            ddCuartel.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddEnvaseOKilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblKilosOEnvases1.Text = ddEnvaseOKilo.SelectedValue;
            lblKilosOEnvases2.Text = ddEnvaseOKilo.SelectedValue;
        }
    }
}