using DemoArandanos.Controlador;
using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class InformePlantas : System.Web.UI.Page
    {
        Controler control = new Controler();
        //private int chicas;
        //private int medianas;
        //private int grandes;
        //private int sin_planta;
        //private int total;

        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            if (!IsPostBack)
            {
                ddMapeo.DataBind();
                ddFundo.DataBind();
                Session["chicas"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "CHICA", int.Parse(ddMapeo.SelectedValue), "");
                Session["medianas"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "MEDIANA", int.Parse(ddMapeo.SelectedValue), "");
                Session["grandes"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "GRANDE", int.Parse(ddMapeo.SelectedValue), "");
                Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), "");
                Session["replante"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "REPLANTE", int.Parse(ddMapeo.SelectedValue), "");
                cargarGrafico((int)Session["chicas"], (int)Session["medianas"], (int)Session["grandes"], (int)Session["sin_planta"], (int)Session["replante"]);
                Session["total"] = (int)Session["chicas"] + (int)Session["medianas"] + (int)Session["grandes"] + (int)Session["replante"];
                lbltotal.Text = Session["total"].ToString();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                lblvariedad.Text = "Todas";
                if (ddFundo.SelectedItem != null)
                {
                    //lblgrafico.Text = "FUNDO " + ddFundo.SelectedItem.Text;
                    lbltemporada.Text = ddMapeo.SelectedItem.Text;
                    lblfundo.Text = ddFundo.SelectedItem.Text;
                }
                UpdatePanel2.Update();
            }
        }

        protected void ddVariedad_DataBound(object sender, EventArgs e)
        {
            ddVariedad.Items.Insert(0, new ListItem("Todas", ""));
            lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
        }

        protected void ddFundo_DataBound(object sender, EventArgs e)
        {
            ddFundo.Items.Insert(0, new ListItem("Todos", "0"));
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

        protected void ddHilera_DataBound(object sender, EventArgs e)
        {
            ddHilera.Items.Insert(0, new ListItem("Todas", "0"));
            nombresImp();
        }

        public void cargarGrafico(int chicas, int medianas, int grandes, int sin_planta, int replante)
        {
            //SET UP THE DATA TO PLOT  
            double[] yVal = { grandes, medianas, chicas, replante, sin_planta };
            string[] xName = { "GRANDES:", "MEDIANAS:", "CHICAS:", "REPLANTE", "SIN PLANTA:" };

            //CREATE THE CHART
            // Don't need to create the chart because it's a control!

            //BIND THE DATA TO THE CHART
            Grafico1.Series.Add(new Series());
            Grafico1.Series[0].Points.DataBindXY(xName, yVal);

            //SET THE CHART TYPE TO BE PIE
            Grafico1.Series[0].ChartType = SeriesChartType.Pie;
            Grafico1.Series[0]["PieLabelStyle"] = "Outside";
            Grafico1.Series[0]["PieStartAngle"] = "-90";

            //SET THE COLOR PALETTE FOR THE CHART TO BE A PRESET OF NONE 
            //DEFINE OUR OWN COLOR PALETTE FOR THE CHART 
            Grafico1.Palette = ChartColorPalette.None;
            Grafico1.PaletteCustomColors = new Color[] { Color.Green, Color.LawnGreen, Color.Yellow, Color.LightBlue, Color.Gray };

            //SET THE IMAGE OUTPUT TYPE TO BE JPEG
            Grafico1.ImageType = ChartImageType.Jpeg;

            //ADD A PLACE HOLDER CHART AREA TO THE CHART
            //SET THE CHART AREA TO BE 3D
            Grafico1.ChartAreas.Add(new ChartArea());
            Grafico1.ChartAreas[0].Area3DStyle.Enable3D = true;

            //ADD A PLACE HOLDER LEGEND TO THE CHART
            //DISABLE THE LEGEND
            Grafico1.Legends.Add(new Legend());
            Grafico1.Legends[0].Enabled = true;

            //otras opciones      "#PERCENT{P2}"      "#VALX (#PERCENT)"
            Grafico1.Series[0].Label = "#VALX #PERCENT";
            Grafico1.Series[0].LegendText = "#VALX #VALY";
            Grafico1.Legends[0].Docking = Docking.Bottom;
            Grafico1.Legends[0].Alignment = StringAlignment.Center;
        }

        public void nombresImp()
        {
            lbltemporada.Text = ddMapeo.SelectedItem.Text;
            if (ddFundo.SelectedItem != null)
            {
                try
                {
                    lblfundo.Text = ddFundo.SelectedItem.Text;
                    lblpotrero.Text = ddPotrero.SelectedItem.Text;
                    lblsector.Text = ddSector.SelectedItem.Text;
                    lblcuartel.Text = ddCuartel.SelectedItem.Text;
                    lblhilera.Text = ddHilera.SelectedItem.Text;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

            }
        }

        protected void ddFundo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["chicas"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "CHICA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["medianas"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "MEDIANA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["grandes"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "GRANDE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["replante"] = control.countPlantas(ddFundo.SelectedValue, "0", "0", "0", "0", "REPLANTE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            cargarGrafico((int)Session["chicas"], (int)Session["medianas"], (int)Session["grandes"], (int)Session["sin_planta"], (int)Session["replante"]);
            Session["total"] = (int)Session["chicas"] + (int)Session["medianas"] + (int)Session["grandes"] + (int)Session["replante"];
            lbltotal.Text = Session["total"].ToString();
            lblgrafico.Text = "FUNDO " + ddFundo.SelectedItem.Text;
            nombresImp();
            String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
            lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
            UpdatePanel2.Update();
        }

        protected void ddPotrero_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["chicas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, "0", "0", "0", "CHICA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["medianas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, "0", "0", "0", "MEDIANA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["grandes"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, "0", "0", "0", "GRANDE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, "0", "0", "0", "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["replante"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, "0", "0", "0", "REPLANTE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            cargarGrafico((int)Session["chicas"], (int)Session["medianas"], (int)Session["grandes"], (int)Session["sin_planta"], (int)Session["replante"]);
            Session["total"] = (int)Session["chicas"] + (int)Session["medianas"] + (int)Session["grandes"] + (int)Session["replante"];
            lbltotal.Text = Session["total"].ToString();
            if (ddPotrero.SelectedValue.Equals("0"))
            {
                lblgrafico.Text = "FUNDO " + ddFundo.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
            }
            else
            {
                lblgrafico.Text = " " + ddPotrero.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
            }
            UpdatePanel2.Update();
        }

        protected void ddSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["chicas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, "0", "0", "CHICA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["medianas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, "0", "0", "MEDIANA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["grandes"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, "0", "0", "GRANDE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, "0", "0", "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["replante"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, "0", "0", "REPLANTE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            cargarGrafico((int)Session["chicas"], (int)Session["medianas"], (int)Session["grandes"], (int)Session["sin_planta"], (int)Session["replante"]);
            Session["total"] = (int)Session["chicas"] + (int)Session["medianas"] + (int)Session["grandes"] + (int)Session["replante"];
            lbltotal.Text = Session["total"].ToString();
            if (ddSector.SelectedValue.Equals("0"))
            {
                lblgrafico.Text = " " + ddPotrero.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
            }
            else
            {
                lblgrafico.Text = " " + ddSector.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
            }
            UpdatePanel2.Update();
        }

        protected void ddCuartel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["chicas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, "0", "CHICA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["medianas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, "0", "MEDIANA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["grandes"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, "0", "GRANDE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, "0", "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["replante"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, "0", "REPLANTE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            cargarGrafico((int)Session["chicas"], (int)Session["medianas"], (int)Session["grandes"], (int)Session["sin_planta"], (int)Session["replante"]);
            Session["total"] = (int)Session["chicas"] + (int)Session["medianas"] + (int)Session["grandes"] + (int)Session["replante"];
            lbltotal.Text = Session["total"].ToString();
            if (ddCuartel.SelectedValue.Equals("0"))
            {
                lblgrafico.Text = " " + ddSector.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                if (ddVariedad.SelectedItem.Text.Equals("Todas"))
                {
                    lblvariedad.Text = "Variedad: " + variedades;
                }
                else
                {
                    lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
                }
            }
            else
            {
                lblgrafico.Text = " " + ddCuartel.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                if (ddVariedad.SelectedItem.Text.Equals("Todas"))
                {
                    lblvariedad.Text = "Variedad: " + variedades;
                }
                else
                {
                    lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
                }
            }
            UpdatePanel2.Update();
        }

        protected void ddHilera_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["chicas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "CHICA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["medianas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "MEDIANA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["grandes"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "GRANDE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["replante"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "REPLANTE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            cargarGrafico((int)Session["chicas"], (int)Session["medianas"], (int)Session["grandes"], (int)Session["sin_planta"], (int)Session["replante"]);
            Session["total"] = (int)Session["chicas"] + (int)Session["medianas"] + (int)Session["grandes"] + (int)Session["replante"];
            lbltotal.Text = Session["total"].ToString();
            if (ddHilera.SelectedValue.Equals("0"))
            {
                lblgrafico.Text = " " + ddCuartel.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                if (ddVariedad.SelectedItem.Text.Equals("Todas"))
                {
                    lblvariedad.Text = "Variedad: " + variedades;
                }
                else
                {
                    lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
                }
            }
            else
            {
                lblgrafico.Text = "HILERA " + ddHilera.SelectedItem.Text;
                nombresImp();
                String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
                if (ddVariedad.SelectedItem.Text.Equals("Todas"))
                {
                    lblvariedad.Text = "Variedad: " + variedades;
                }
                else
                {
                    lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
                }
            }
            UpdatePanel2.Update();
        }

        protected void ddVariedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddFundo.DataBind();
            Session["chicas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "CHICA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["medianas"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "MEDIANA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["grandes"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "GRANDE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["sin_planta"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "SIN_PLANTA", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);
            Session["replante"] = control.countPlantas(ddFundo.SelectedValue, ddPotrero.SelectedValue, ddSector.SelectedValue, ddCuartel.SelectedValue, ddHilera.SelectedValue, "REPLANTE", int.Parse(ddMapeo.SelectedValue), ddVariedad.SelectedValue);

            cargarGrafico((int)Session["chicas"], (int)Session["medianas"], (int)Session["grandes"], (int)Session["sin_planta"], (int)Session["replante"]);
            Session["total"] = (int)Session["chicas"] + (int)Session["medianas"] + (int)Session["grandes"] + (int)Session["replante"];
            lbltotal.Text = Session["total"].ToString();
            nombresImp();
            String variedades = string.Join(", ", control.variedades(ddHilera.SelectedValue, ddCuartel.SelectedValue, ddSector.SelectedValue, ddPotrero.SelectedValue, ddFundo.SelectedValue, int.Parse(ddMapeo.SelectedValue)).ToArray());
            lblvariedad.Text = "Variedad: " + ddVariedad.SelectedItem.Text;
            lblgrafico.Text = "";
            UpdatePanel2.Update();
        }

        protected void btVerHileras_Click(object sender, EventArgs e)
        {
            if (!ddCuartel.SelectedValue.Equals("0"))
            {
                Application["mapeo"] = ddMapeo.SelectedValue;
                Application["fundo"] = ddFundo.SelectedValue;
                Application["potrero"] = ddPotrero.SelectedValue;
                Application["sector"] = ddSector.SelectedValue;
                Application["cuartel"] = ddCuartel.SelectedValue;
                Application["variedad"] = ddVariedad.SelectedValue;
                Application["titulo"] = ddFundo.SelectedItem.Text + ", " + ddPotrero.SelectedItem.Text + ", " + ddSector.SelectedItem.Text + ", " + ddCuartel.SelectedItem.Text;
                //Response.Write("<script>window.open('hileras.aspx','popup','width=500,height=500,scrollbars=no,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no'); </script>");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "newwindow", "window.open('hileras.aspx', null, 'height=screen.availHeigth,width=screen.availWidth,scrollbars=1,resizable=1,status=1,toolbar=1,menubar=0,location=0');", true);

            }
        }


    }
}