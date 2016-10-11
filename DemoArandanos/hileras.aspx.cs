using DemoArandanos.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoArandanos
{
    public partial class hileras : System.Web.UI.Page
    {
        Controler control = new Controler();
        List<string> listaHileras;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["log"] == null || (bool)Session["log"] == false)
                {
                    Server.Transfer("Login.aspx", true);
                }
            }

            int mapeo = int.Parse(Application["mapeo"].ToString());
            string fundo = Application["fundo"].ToString();
            string potrero = Application["potrero"].ToString();
            string sector = Application["sector"].ToString();
            string cuartel = Application["cuartel"].ToString();
            string variedad = Application["variedad"].ToString();
            lbltitulo.Text = Application["titulo"].ToString();

            if (Application["variedad"].ToString().Equals(""))
            {
                lblvariedad.Text = "Todas";
            }
            else
            {
                lblvariedad.Text = Application["variedad"].ToString();
            }

            lblgrande.Text = " Grandes: " + control.countPlantas(fundo, potrero, sector, cuartel, "0", "GRANDE", mapeo, variedad) + " ";
            lblgrande.BackColor = Color.Green;
            lblgrande.ForeColor = Color.White;
            lblmediana.Text = " Medianas: " + control.countPlantas(fundo, potrero, sector, cuartel, "0", "MEDIANA", mapeo, variedad) + " ";
            lblmediana.BackColor = Color.LawnGreen;
            lblmediana.ForeColor = Color.Gray;
            lblchica.Text = " Chicas: " + control.countPlantas(fundo, potrero, sector, cuartel, "0", "CHICA", mapeo, variedad) + " ";
            lblchica.BackColor = Color.Yellow;
            lblchica.ForeColor = Color.Gray;
            lblsin_planta.Text = " Sin planta: " + control.countPlantas(fundo, potrero, sector, cuartel, "0", "SIN_PLANTA", mapeo, variedad);
            lblsin_planta.BackColor = Color.Gray;
            lblsin_planta.ForeColor = Color.White;
            lblreplante.Text = " Replante: " + control.countPlantas(fundo, potrero, sector, cuartel, "0", "REPLANTE", mapeo, variedad);
            lblreplante.BackColor = Color.LightBlue;
            lblreplante.ForeColor = Color.Gray;

            listaHileras = control.listaHileras(cuartel, sector, potrero, fundo, mapeo);
            DataTable dt = new DataTable();
            List<string> listaIDPlantas;
            List<string> listaEstadosPlantas;
            DataRow dr;
            bool first = true;
            dt.Columns.Add(new DataColumn("Hileras"));


            foreach (string idHilera in listaHileras)
            {
                if (first)
                {
                    listaIDPlantas = control.listaIDPlantas(cuartel, sector, potrero, fundo, mapeo);
                    foreach (string id in listaIDPlantas)
                    {
                        dr = dt.NewRow();
                        dr["Hileras"] = id;
                        dt.Rows.Add(dr);
                    }
                }
                first = false;
            }

            foreach (string idHilera in listaHileras)
            {
                dt.Columns.Add(new DataColumn(idHilera));
                listaEstadosPlantas = control.listaEstadosPlantas(idHilera, cuartel, sector, potrero, fundo, mapeo);
                for (int i = 0; i < listaEstadosPlantas.Count; i++)
                {
                    if (listaEstadosPlantas[i].EndsWith("GRANDE"))
                    {
                        dt.Rows[int.Parse(listaEstadosPlantas[i].Substring(2, 4)) - 1][idHilera] = "G";
                    }
                    else
                    {
                        if (listaEstadosPlantas[i].EndsWith("MEDIANA"))
                        {
                            dt.Rows[int.Parse(listaEstadosPlantas[i].Substring(2, 4)) - 1][idHilera] = "M";
                        }
                        else
                        {
                            if (listaEstadosPlantas[i].EndsWith("CHICA"))
                            {
                                dt.Rows[int.Parse(listaEstadosPlantas[i].Substring(2, 4)) - 1][idHilera] = "C";
                            }
                            else
                            {
                                if (listaEstadosPlantas[i].EndsWith("REPLANTE"))
                                {
                                    dt.Rows[int.Parse(listaEstadosPlantas[i].Substring(2, 4)) - 1][idHilera] = "R";
                                }
                                else
                                {
                                    if (listaEstadosPlantas[i].EndsWith("SIN_PLANTA"))
                                    {
                                        dt.Rows[int.Parse(listaEstadosPlantas[i].Substring(2, 4)) - 1][idHilera] = "X";
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //me agrega el primer estadon en todas
            //foreach (string idHilera in listaHileras)
            //{
            //    dt.Columns.Add(new DataColumn(idHilera));
            //    listaIDPlantas = control.listaIDPlantas(cuartel, sector, potrero, fundo, mapeo);
            //    for (int i = 0; i < listaIDPlantas.Count; i++)
            //    {
            //        listaEstadosPlantas = control.listaEstadosPlantas(idHilera, cuartel, sector, potrero, fundo, mapeo);
            //        foreach (string estado in listaEstadosPlantas)
            //        {
            //            dt.Rows[i][idHilera] = estado;
            //        }
            //    }
            //}

            grillaHileras.DataSource = dt;
            grillaHileras.DataBind();

            //PINTAR ENCABEZADOS
            //int z = 1;
            //foreach (string idHilera in listaHileras)
            //{
            //    String vari = control.getVariedadHilera(idHilera, cuartel, sector, potrero, fundo, mapeo);
            //    if (vari.Equals("TIFBLUE"))
            //    {
            //        grillaHileras.HeaderRow.Cells[z].BackColor = Color.Blue;
            //        grillaHileras.HeaderRow.Cells[z].ForeColor = Color.White;
            //    }
            //    if (vari.Equals("BRIGHTWELL"))
            //    {
            //        grillaHileras.HeaderRow.Cells[z].BackColor = Color.Gold;
            //        grillaHileras.HeaderRow.Cells[z].ForeColor = Color.White;
            //    }
            //    z++;
            //}            

            //PINTAR BLANCA COLUMNA DE OTRA VARIEDAD
            int z = 1;
            foreach (string idHilera in listaHileras)
            {
                String vari = control.getVariedadHilera(idHilera, cuartel, sector, potrero, fundo, mapeo);
                if (!vari.Equals(lblvariedad.Text) && !lblvariedad.Text.Equals("Todas"))
                {
                    foreach (GridViewRow row in grillaHileras.Rows)
                    {
                        row.Cells[z].BackColor = Color.White;
                        row.Cells[z].ForeColor = Color.White;
                    }
                }
                z++;
            }

        }


        protected void grillaHileras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i <= listaHileras.Count; i++)
                {
                    if (e.Row.Cells[i].Text.Equals("G"))
                    {
                        e.Row.Cells[i].BackColor = Color.Green;
                        e.Row.Cells[i].ForeColor = Color.Green;
                    }
                    else
                    {
                        if (e.Row.Cells[i].Text.Equals("M"))
                        {
                            e.Row.Cells[i].BackColor = Color.LawnGreen;
                            e.Row.Cells[i].ForeColor = Color.LawnGreen;
                        }
                        else
                        {
                            if (e.Row.Cells[i].Text.Equals("C"))
                            {
                                e.Row.Cells[i].BackColor = Color.Yellow;
                                e.Row.Cells[i].ForeColor = Color.Yellow;
                            }
                            else
                            {
                                if (e.Row.Cells[i].Text.Equals("R"))
                                {
                                    e.Row.Cells[i].BackColor = Color.LightBlue;
                                    e.Row.Cells[i].ForeColor = Color.LightBlue;
                                }
                                else
                                {
                                    if (e.Row.Cells[i].Text.Equals("X"))
                                    {
                                        e.Row.Cells[i].BackColor = Color.Gray;
                                        e.Row.Cells[i].ForeColor = Color.Gray;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}