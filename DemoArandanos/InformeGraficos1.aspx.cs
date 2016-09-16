using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformeGraficos1 : System.Web.UI.Page
    {
        Controler control = new Controler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtFechaTermino.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;

            //double[] yVal = { 558, 666, 216, 305, 824, 457 };
            //string[] xName = { "17 A", "17 B", "17 C", "17 D", "11 C", "11 D" };
            String inicio = DateTime.Parse(txtFechaInicio.Text + " 00:00:00").ToString("yyyy-MM-ddTHH:mm:ss");
            String fin = DateTime.Parse(txtFechaTermino.Text + " 23:59:59").ToString("yyyy-MM-ddTHH:mm:ss");
            cargarGrafico(GraficoVariedad, control.getCantidadPorVariedad(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, DateTime.Parse(inicio), DateTime.Parse(fin)), control.getVariedades(), true);
            cargarGrafico(GraficoCuartel, control.getCantidadTotal(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, DateTime.Parse(inicio), DateTime.Parse(fin)), control.getNombres(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue), false);
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
                for (int i = 0; i < xNombres.Length; i++) //xValues.Lenght = 4 in this case where you have 4 Data number
                {
                    if (i == 0) // Don't forget xValues[0] is Data4 in your case
                        graf.Series[0].Points[i].Color = Color.Blue;
                    if (i == 1)
                        graf.Series[0].Points[i].Color = Color.Yellow;
                    if (i == 2)
                        graf.Series[0].Points[i].Color = Color.Violet;
                    if (i == 3)
                        graf.Series[0].Points[i].Color = Color.SkyBlue;
                    if (i == 4)
                        graf.Series[0].Points[i].Color = Color.Orange;
                    if (i == 5)
                        graf.Series[0].Points[i].Color = Color.Green;
                    if (i == 6)
                        graf.Series[0].Points[i].Color = Color.Pink;
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
                graf.PaletteCustomColors = new Color[] { Color.DarkViolet };
                lbltotal.Text = yValores.Sum().ToString();
            }

            graf.ImageType = ChartImageType.Jpeg;
            graf.ChartAreas.Add(new ChartArea());
        }               

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            //ddFundo.Items.Insert(0, new ListItem("Todo", ""));
            String inicio = DateTime.Parse(txtFechaInicio.Text + " 00:00:00").ToString("yyyy-MM-ddTHH:mm:ss");
            String fin = DateTime.Parse(txtFechaTermino.Text + " 23:59:59").ToString("yyyy-MM-ddTHH:mm:ss");
            cargarGrafico(GraficoCuartel, control.getCantidadTotal(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, DateTime.Parse(inicio), DateTime.Parse(fin)), control.getNombres(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue), false);
        }

        protected void ddPotrero_DataBound(object sender, EventArgs e)
        {
            ddPotrero.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void ddSector_DataBound(object sender, EventArgs e)
        {
            ddSector.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void ddCuartel_DataBound(object sender, EventArgs e)
        {
            ddCuartel.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
        {

        }
    }
}