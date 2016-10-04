using DemoArandanos.Controlador;
using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace DemoArandanos
{
    public partial class Reportes : System.Web.UI.Page
    {
        Controler control = new Controler();
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (fileExtention == ".xls" || fileExtention == ".xlsx")
                    {
                        string fileName = System.IO.Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("~/ExcelSheet/" + fileName));
                        /*Read excel sheet*/
                        string excelSheetFilename = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/ExcelSheet/" + fileName) + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        OleDbConnection objcon = new OleDbConnection(excelSheetFilename);
                        string queryForExcel = "Select * from [Hoja1$];";
                        OleDbDataAdapter objda = new OleDbDataAdapter(queryForExcel, objcon);
                        DataSet objds = new DataSet();
                        objda.Fill(objds);
                        if (objds.Tables[0].Rows.Count > 0)
                        {
                            grillaExcel.DataSource = objds.Tables[0];
                            grillaExcel.DataBind();
                        }
                        else
                        {
                            lblinfo.Text = "El archivo excel no contiene datos";
                            divInfo.Visible = true;
                        }
                    }
                    else
                    {
                        lbldanger.Text = "El archivo que intenta cargar no posee el formato correcto";
                        divDanger.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "El archivo que intenta cargar no posee el formato correcto";
                    divDanger.Visible = true;
                }
            }
        }

        protected void btInsertarBD_Click(object sender, EventArgs e)
        {
            String id_hilera = "";
            //recorre la fila de hileras e inserta de a una
            for (int i = 1; i < grillaExcel.Rows[5].Cells.Count; i++)
            {
                int hilera = int.Parse(grillaExcel.Rows[5].Cells[i].Text);
                if (hilera < 10 && hilera > 0)
                {
                    id_hilera = "H000" + hilera;
                }
                else
                {
                    if (hilera < 100 && hilera >= 10)
                    {
                        id_hilera = "H00" + hilera;
                    }
                    else
                    {
                        if (hilera < 1000 && hilera >= 100)
                        {
                            id_hilera = "H0" + hilera;
                        }
                        else
                        {
                            id_hilera = "H" + hilera;
                        }
                    }
                }
                //insertar hilera
                control.insertarHilera(id_hilera, grillaExcel.Rows[3].Cells[1].Text, grillaExcel.Rows[2].Cells[1].Text, grillaExcel.Rows[1].Cells[1].Text, grillaExcel.Rows[0].Cells[1].Text, grillaExcel.Rows[4].Cells[1].Text);
                control.insertarSyncHilera(id_hilera, grillaExcel.Rows[3].Cells[1].Text, grillaExcel.Rows[2].Cells[1].Text, grillaExcel.Rows[1].Cells[1].Text, grillaExcel.Rows[0].Cells[1].Text, grillaExcel.Rows[4].Cells[1].Text, "insert");

                //recorre la columna de la hilera e inserta las plantas
                bool existe = false;
                String estado = "";
                String id_planta = "";
                for (int j = 6; j < grillaExcel.Rows.Count; j++)
                {
                    int planta = int.Parse(grillaExcel.Rows[j].Cells[0].Text);
                    if (planta < 10 && planta > 0)
                    {
                        id_planta = "PL000" + planta;
                    }
                    else
                    {
                        if (planta < 100 && planta >= 10)
                        {
                            id_planta = "PL00" + planta;
                        }
                        else
                        {
                            if (planta < 1000 && planta >= 100)
                            {
                                id_planta = "PL0" + planta;
                            }
                            else
                            {
                                id_planta = "PL" + planta;
                            }
                        }
                    }

                    if (!grillaExcel.Rows[j].Cells[i].Text.Equals("-"))
                    {
                        if (grillaExcel.Rows[j].Cells[i].Text.Equals("G") || grillaExcel.Rows[j].Cells[i].Text.Equals("g"))
                        {
                            estado = "GRANDE";
                            existe = true;
                        }
                        else
                        {
                            if (grillaExcel.Rows[j].Cells[i].Text.Equals("C") || grillaExcel.Rows[j].Cells[i].Text.Equals("c"))
                            {
                                estado = "CHICA";
                                existe = true;
                            }
                            else
                            {
                                if (grillaExcel.Rows[j].Cells[i].Text.Equals("M") || grillaExcel.Rows[j].Cells[i].Text.Equals("m"))
                                {
                                    estado = "MEDIANA";
                                    existe = true;
                                }
                                else
                                {
                                    if (grillaExcel.Rows[j].Cells[i].Text.Equals("X") || grillaExcel.Rows[j].Cells[i].Text.Equals("x"))
                                    {
                                        estado = "SIN_PLANTA";
                                        existe = true;
                                    }
                                    else
                                    {
                                        existe = false;
                                    }
                                }
                            }
                        }

                        //insertar planta
                        if (existe)
                        {
                            control.insertarPlanta(id_planta, id_hilera, grillaExcel.Rows[3].Cells[1].Text, grillaExcel.Rows[2].Cells[1].Text, grillaExcel.Rows[1].Cells[1].Text, grillaExcel.Rows[0].Cells[1].Text, estado, "", "");
                            control.insertarSyncPlanta(id_planta, id_hilera, grillaExcel.Rows[3].Cells[1].Text, grillaExcel.Rows[2].Cells[1].Text, grillaExcel.Rows[1].Cells[1].Text, grillaExcel.Rows[0].Cells[1].Text, estado, "", "", "insert");
                        }

                    }
                }
            }
            lblsuccess.Text = "Datos guardados en la BD";
            divSuccess.Visible = true;
        }
    }
}