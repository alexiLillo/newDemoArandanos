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
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;

            //double[] yVal = { 558, 666, 216, 305, 824, 457 };
            //string[] xName = { "17 A", "17 B", "17 C", "17 D", "11 C", "11 D" };
            cargarGrafico(GraficoVariedad, control.getCantidadPorVariedad(), control.getVariedades(), true);
            cargarGrafico(GraficoCuartel, control.getCantidadPorVariedad(), control.getVariedades(), false);
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
                graf.PaletteCustomColors = new Color[] { Color.Violet };
            }

            graf.ImageType = ChartImageType.Jpeg;
            graf.ChartAreas.Add(new ChartArea());
        }
    }
}