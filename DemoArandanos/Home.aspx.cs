using DemoArandanos.Controlador;
using System;

namespace DemoArandanos
{
    public partial class Home : System.Web.UI.Page
    {
        Controler control = new Controler();
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

            if (!IsPostBack)
            {
                dataBind("all");
            }

            //if (Request.Cookies.Get("login") == null)
            //{
            //    Server.Transfer("Login.aspx", true);
            //}
        }

        //ACTUALIZACION GENERAL DE TABLAS (GRILLAS) Y DROPDOWNS

        public void dataBind(String cual)
        {
            grillaFundos.DataBind();
            grillaPotreros.DataBind();
            grillaSector.DataBind();
            grillaCuarteles.DataBind();
            grillaHilera.DataBind();
            grillaPlantas.DataBind();
            grillaEstado.DataBind();
            grillaVariedad.DataBind();

            if (cual.Equals("all"))
            {
                ddFundo.DataBind();
                ddFundo2.DataBind();
                ddFundo3.DataBind();
                ddFundo4.DataBind();
                ddFundo5.DataBind();
                ddPotrero.DataBind();
                ddPotrero2.DataBind();
                ddPotrero3.DataBind();
                ddPotrero4.DataBind();
                ddSector.DataBind();
                ddSector2.DataBind();
                ddSector3.DataBind();
                ddCuartel.DataBind();
                ddCuartel2.DataBind();
                ddHilera.DataBind();
                ddEstado.DataBind();
                ddVariedad.DataBind();
            }

            if (cual.Equals("p"))
            {
                ddFundo2.DataBind();
                ddFundo3.DataBind();
                ddFundo4.DataBind();
                ddFundo5.DataBind();
                ddPotrero.DataBind();
                ddPotrero2.DataBind();
                ddPotrero3.DataBind();
                ddPotrero4.DataBind();
                ddSector.DataBind();
                ddSector2.DataBind();
                ddSector3.DataBind();
                ddCuartel.DataBind();
                ddCuartel2.DataBind();
                ddHilera.DataBind();
                ddEstado.DataBind();
                ddVariedad.DataBind();
            }

            if (cual.Equals("s"))
            {
                ddFundo.DataBind();
                ddFundo3.DataBind();
                ddFundo4.DataBind();
                ddFundo5.DataBind();
                ddPotrero2.DataBind();
                ddPotrero3.DataBind();
                ddPotrero4.DataBind();
                ddSector.DataBind();
                ddSector2.DataBind();
                ddSector3.DataBind();
                ddCuartel.DataBind();
                ddCuartel2.DataBind();
                ddHilera.DataBind();
                ddEstado.DataBind();
                ddVariedad.DataBind();
            }

            if (cual.Equals("c"))
            {
                ddFundo.DataBind();
                ddFundo2.DataBind();
                ddFundo4.DataBind();
                ddFundo5.DataBind();
                ddPotrero.DataBind();
                ddPotrero3.DataBind();
                ddPotrero4.DataBind();
                ddSector2.DataBind();
                ddSector3.DataBind();
                ddCuartel.DataBind();
                ddCuartel2.DataBind();
                ddHilera.DataBind();
                ddEstado.DataBind();
                ddVariedad.DataBind();
            }

            if (cual.Equals("h"))
            {
                ddFundo.DataBind();
                ddFundo2.DataBind();
                ddFundo3.DataBind();
                ddFundo5.DataBind();
                ddPotrero.DataBind();
                ddPotrero2.DataBind();
                ddPotrero4.DataBind();
                ddSector.DataBind();
                ddSector3.DataBind();
                ddCuartel2.DataBind();
                ddHilera.DataBind();
                ddEstado.DataBind();
            }

            if (cual.Equals("pl"))
            {
                ddFundo.DataBind();
                ddFundo2.DataBind();
                ddFundo3.DataBind();
                ddFundo4.DataBind();
                ddPotrero.DataBind();
                ddPotrero2.DataBind();
                ddPotrero3.DataBind();
                ddSector.DataBind();
                ddSector2.DataBind();
                ddCuartel.DataBind();
                ddVariedad.DataBind();
            }
        }

        ////SELECCION DE DATOS DESDE TABLAS (GRILLAS)

        protected void grillaFundos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdFundo.Text = grillaFundos.Rows[grillaFundos.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtNombreFundo.Text = grillaFundos.Rows[grillaFundos.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
        }

        protected void grillaPotreros_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdPotrero.Text = grillaPotreros.Rows[grillaPotreros.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtNombrePotrero.Text = grillaPotreros.Rows[grillaPotreros.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            ddFundo.SelectedValue = grillaPotreros.Rows[grillaPotreros.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
        }

        protected void grillaSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdSector.Text = grillaSector.Rows[grillaSector.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtNombreSector.Text = grillaSector.Rows[grillaSector.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            ddPotrero.SelectedValue = grillaSector.Rows[grillaSector.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            ddFundo2.SelectedValue = grillaSector.Rows[grillaSector.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
        }

        protected void grillaCuarteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCuartel.Text = grillaCuarteles.Rows[grillaCuarteles.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtNombreCuartel.Text = grillaCuarteles.Rows[grillaCuarteles.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            txtSuperficie.Text = grillaCuarteles.Rows[grillaCuarteles.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            ddSector.SelectedValue = grillaCuarteles.Rows[grillaCuarteles.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
            ddPotrero2.SelectedValue = grillaCuarteles.Rows[grillaCuarteles.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");
            ddFundo3.SelectedValue = grillaCuarteles.Rows[grillaCuarteles.SelectedIndex].Cells[6].Text.Replace("&nbsp;", "");
        }

        protected void grillaHilera_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdHilera.Text = grillaHilera.Rows[grillaHilera.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            ddVariedad.SelectedValue = grillaHilera.Rows[grillaHilera.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            ddCuartel.SelectedValue = grillaHilera.Rows[grillaHilera.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
            ddSector2.SelectedValue = grillaHilera.Rows[grillaHilera.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
            ddPotrero3.SelectedValue = grillaHilera.Rows[grillaHilera.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");
            ddFundo4.SelectedValue = grillaHilera.Rows[grillaHilera.SelectedIndex].Cells[6].Text.Replace("&nbsp;", "");
        }

        protected void grillaPlantas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdPlanta.Text = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            ddEstado.SelectedValue = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            DateTime d = DateTime.Parse(grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "").ToString());
            txtFechaPlantacion.Text = d.ToString("yyyy-MM-dd");
            txtObservaciones.Text = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[4].Text.Replace("&nbsp;", "");
            ddHilera.SelectedValue = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[5].Text.Replace("&nbsp;", "");
            ddCuartel2.SelectedValue = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[6].Text.Replace("&nbsp;", "");
            ddSector3.SelectedValue = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[7].Text.Replace("&nbsp;", "");
            ddPotrero4.SelectedValue = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[8].Text.Replace("&nbsp;", "");
            ddFundo5.SelectedValue = grillaPlantas.Rows[grillaPlantas.SelectedIndex].Cells[9].Text.Replace("&nbsp;", "");

        }

        protected void grillaEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdEstado.Text = grillaEstado.Rows[grillaEstado.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
        }

        protected void grillaVariedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDvariedad.Text = grillaVariedad.Rows[grillaVariedad.SelectedIndex].Cells[1].Text.Replace("&nbsp;", "");
            txtNombreVariedad.Text = grillaVariedad.Rows[grillaVariedad.SelectedIndex].Cells[2].Text.Replace("&nbsp;", "");
            ddProducto.SelectedValue = grillaVariedad.Rows[grillaVariedad.SelectedIndex].Cells[3].Text.Replace("&nbsp;", "");
        }

        //OPERACIONES DE BOTONES, VISTA -> CONTROLADOR

        protected void btnIngresarFundo_Click(object sender, EventArgs e)
        {
            if (!txtIdFundo.Text.Equals("") || !txtNombreFundo.Text.Equals(""))
            {
                try
                {
                    control.insertarFundo(txtIdFundo.Text, txtNombreFundo.Text);
                    control.insertarSyncFundo(txtIdFundo.Text, txtNombreFundo.Text, "insert");
                    dataBind("all");
                    lblsuccess.Text = "Fundo ingresado correctamente.";
                    divSuccess.Visible = true;
                    txtIdFundo.Text = "";
                    txtNombreFundo.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar el Fundo";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btnEliminarFundo_Click(object sender, EventArgs e)
        {
            if (!txtIdFundo.Text.Equals(""))
            {
                try
                {
                    control.eliminarFundo(txtIdFundo.Text);
                    control.insertarSyncFundo(txtIdFundo.Text, txtNombreFundo.Text, "delete");
                    dataBind("all");
                    lblwarning.Text = "Fundo eliminado.";
                    divWarning.Visible = true;
                    txtIdFundo.Text = "";
                    txtNombreFundo.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar el Fundo";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btnActualizarFundo_Click(object sender, EventArgs e)
        {
            if (!txtIdFundo.Text.Equals("") || !txtNombreFundo.Text.Equals(""))
            {
                try
                {
                    control.actualizarFundo(txtIdFundo.Text, txtNombreFundo.Text);
                    control.insertarSyncFundo(txtIdFundo.Text, txtNombreFundo.Text, "update");
                    dataBind("all");
                    lblinfo.Text = "Datos de fundo actualizados.";
                    divInfo.Visible = true;
                    txtIdFundo.Text = "";
                    txtNombreFundo.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "Ingrese datos válidos para poder actualizar";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btInsertarPotrero_Click(object sender, EventArgs e)
        {
            if (!txtIdPotrero.Text.Equals("") || !txtNombrePotrero.Text.Equals(""))
            {
                try
                {
                    control.insertarPotrero(txtIdPotrero.Text, ddFundo.SelectedValue, txtNombrePotrero.Text);
                    control.insertarSyncPotrero(txtIdPotrero.Text, ddFundo.SelectedValue, txtNombrePotrero.Text, "insert");
                    dataBind("p");
                    lblsuccess.Text = "Potrero ingresado correctamente.";
                    divSuccess.Visible = true;
                    txtIdPotrero.Text = "";
                    txtNombrePotrero.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar el Potrero";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarPotrero_Click(object sender, EventArgs e)
        {
            if (!txtIdPotrero.Text.Equals(""))
            {
                try
                {
                    control.eliminarPotrero(txtIdPotrero.Text, ddFundo.SelectedValue);
                    control.insertarSyncPotrero(txtIdPotrero.Text, ddFundo.SelectedValue, txtNombrePotrero.Text, "delete");
                    dataBind("p");
                    lblwarning.Text = "Potrero eliminado.";
                    divWarning.Visible = true;
                    txtIdPotrero.Text = "";
                    txtNombrePotrero.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar el Potrero";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btActualizarPotrero_Click(object sender, EventArgs e)
        {
            if (!txtIdPotrero.Text.Equals("") || !txtNombrePotrero.Text.Equals(""))
            {
                try
                {
                    control.actualizarPotrero(txtIdPotrero.Text, ddFundo.SelectedValue, txtNombrePotrero.Text);
                    control.insertarSyncPotrero(txtIdPotrero.Text, ddFundo.SelectedValue, txtNombrePotrero.Text, "update");
                    dataBind("p");
                    lblinfo.Text = "Datos de potrero actualizados.";
                    divInfo.Visible = true;
                    txtIdPotrero.Text = "";
                    txtNombrePotrero.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "Ingrese datos válidos para poder actualizar";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btInsertarSector_Click(object sender, EventArgs e)
        {
            if (!txtIdSector.Text.Equals("") || !txtNombreSector.Text.Equals(""))
            {
                try
                {
                    control.insertarSector(txtIdSector.Text, ddPotrero.SelectedValue, ddFundo2.SelectedValue, txtNombreSector.Text);
                    control.insertarSyncSector(txtIdSector.Text, ddPotrero.SelectedValue, ddFundo2.SelectedValue, txtNombreSector.Text, "insert");
                    dataBind("s");
                    lblsuccess.Text = "Sector ingresado correctamente.";
                    divSuccess.Visible = true;
                    txtIdSector.Text = "";
                    txtNombreSector.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar el Sector ";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btActualizarSector_Click(object sender, EventArgs e)
        {
            if (!txtIdSector.Text.Equals("") || !txtNombreSector.Text.Equals(""))
            {
                try
                {
                    control.actualizarSector(txtIdSector.Text, ddPotrero.SelectedValue, ddFundo2.SelectedValue, txtNombreSector.Text);
                    control.insertarSyncSector(txtIdSector.Text, ddPotrero.SelectedValue, ddFundo2.SelectedValue, txtNombreSector.Text, "update");
                    dataBind("s");
                    lblinfo.Text = "Datos de sector actualizados.";
                    divInfo.Visible = true;
                    txtIdSector.Text = "";
                    txtNombreSector.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "Ingrese datos válidos para poder actualizar";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarSector_Click(object sender, EventArgs e)
        {
            if (!txtIdSector.Text.Equals(""))
            {
                try
                {
                    control.eliminarSector(txtIdSector.Text, ddPotrero.SelectedValue, ddFundo2.SelectedValue);
                    control.insertarSyncSector(txtIdSector.Text, ddPotrero.SelectedValue, ddFundo2.SelectedValue, txtNombreSector.Text, "delete");
                    dataBind("s");
                    lblwarning.Text = "Sector eliminado.";
                    divWarning.Visible = true;
                    txtIdSector.Text = "";
                    txtNombreSector.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar el Sector";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btInsertarCuartel_Click(object sender, EventArgs e)
        {
            if (!txtIdCuartel.Text.Equals("") || !txtNombreCuartel.Text.Equals(""))
            {
                try
                {
                    control.insertarCuartel(txtIdCuartel.Text, ddSector.SelectedValue, ddPotrero2.SelectedValue, ddFundo3.SelectedValue, txtSuperficie.Text, txtNombreCuartel.Text);
                    control.insertarSyncCuartel(txtIdCuartel.Text, ddSector.SelectedValue, ddPotrero2.SelectedValue, ddFundo3.SelectedValue, txtSuperficie.Text, txtNombreCuartel.Text, "insert");
                    dataBind("c");
                    lblsuccess.Text = "Cuartel ingresado correctamente.";
                    divSuccess.Visible = true;
                    txtIdCuartel.Text = "";
                    txtSuperficie.Text = "";
                    txtNombreCuartel.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar el Cuartel";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btActualizarCuartel_Click(object sender, EventArgs e)
        {
            if (!txtIdCuartel.Text.Equals("") || !txtNombreCuartel.Text.Equals(""))
            {
                try
                {
                    control.actualizarCuartel(txtIdCuartel.Text, ddSector.SelectedValue, ddPotrero2.SelectedValue, ddFundo3.SelectedValue, txtNombreCuartel.Text, txtSuperficie.Text);
                    control.insertarSyncCuartel(txtIdCuartel.Text, ddSector.SelectedValue, ddPotrero2.SelectedValue, ddFundo3.SelectedValue, txtNombreCuartel.Text, txtNombreCuartel.Text, "update");
                    dataBind("c");
                    lblinfo.Text = "Datos de cuartel actualizados.";
                    divInfo.Visible = true;
                    txtIdCuartel.Text = "";
                    txtNombreCuartel.Text = "";
                    txtSuperficie.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "Ingrese datos válidos para poder actualizar";                    
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarCuartel_Click(object sender, EventArgs e)
        {
            if (!txtIdCuartel.Text.Equals(""))
            {
                try
                {
                    control.eliminarCuartel(txtIdCuartel.Text, ddSector.SelectedValue, ddPotrero2.SelectedValue, ddFundo3.SelectedValue);
                    control.insertarSyncCuartel(txtIdCuartel.Text, ddSector.SelectedValue, ddPotrero2.SelectedValue, ddFundo3.SelectedValue, txtSuperficie.Text, txtNombreCuartel.Text, "delete");
                    dataBind("c");
                    lblwarning.Text = "Cuartel eliminado.";
                    divWarning.Visible = true;
                    txtIdCuartel.Text = "";
                    txtNombreCuartel.Text = "";
                    txtSuperficie.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar el Cuartel";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btInsertarHilera_Click(object sender, EventArgs e)
        {
            if (!txtIdHilera.Text.Equals(""))
            {
                try
                {
                    control.insertarHilera(txtIdHilera.Text, ddCuartel.SelectedValue, ddSector2.SelectedValue, ddPotrero3.SelectedValue, ddFundo4.SelectedValue, ddVariedad.SelectedValue);
                    control.insertarSyncHilera(txtIdHilera.Text, ddCuartel.SelectedValue, ddSector2.SelectedValue, ddPotrero3.SelectedValue, ddFundo4.SelectedValue, ddVariedad.SelectedValue, "insert");
                    dataBind("h");
                    lblsuccess.Text = "Hilera ingresada correctamente.";
                    divSuccess.Visible = true;
                    txtIdHilera.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar la Hilera";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btActualizarHilera_Click(object sender, EventArgs e)
        {
            if (!txtIdHilera.Text.Equals(""))
            {
                try
                {
                    control.actualizarHilera(txtIdHilera.Text, ddCuartel.SelectedValue, ddSector2.SelectedValue, ddPotrero3.SelectedValue, ddFundo4.SelectedValue, ddVariedad.SelectedValue);
                    control.insertarSyncHilera(txtIdHilera.Text, ddCuartel.SelectedValue, ddSector2.SelectedValue, ddPotrero3.SelectedValue, ddFundo4.SelectedValue, ddVariedad.SelectedValue, "update");
                    dataBind("h");
                    lblinfo.Text = "Datos de hilera actualizados.";
                    divInfo.Visible = true;
                    txtIdHilera.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "Ingrese datos válidos para poder actualizar";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarHilera_Click(object sender, EventArgs e)
        {
            if (!txtIdHilera.Text.Equals(""))
            {
                try
                {
                    control.eliminarHilera(txtIdHilera.Text, ddCuartel.SelectedValue, ddSector2.SelectedValue, ddPotrero3.SelectedValue, ddFundo4.SelectedValue);
                    control.insertarSyncHilera(txtIdHilera.Text, ddCuartel.SelectedValue, ddSector2.SelectedValue, ddPotrero3.SelectedValue, ddFundo4.SelectedValue, ddVariedad.SelectedValue, "delete");
                    dataBind("h");
                    lblwarning.Text = "Hilera eliminada.";
                    divWarning.Visible = true;
                    txtIdHilera.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar la Hilera";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btInsertarPlanta_Click(object sender, EventArgs e)
        {
            if (!txtIdPlanta.Text.Equals(""))
            {
                try
                {
                    control.insertarPlanta(txtIdPlanta.Text, ddHilera.SelectedValue, ddCuartel2.SelectedValue, ddSector3.SelectedValue, ddPotrero4.SelectedValue, ddFundo5.SelectedValue, ddEstado.SelectedValue, txtFechaPlantacion.Text, txtObservaciones.Text);
                    control.insertarSyncPlanta(txtIdPlanta.Text, ddHilera.SelectedValue, ddCuartel2.SelectedValue, ddSector3.SelectedValue, ddPotrero4.SelectedValue, ddFundo5.SelectedValue, ddEstado.SelectedValue, txtFechaPlantacion.Text, txtObservaciones.Text, "insert");
                    dataBind("pl");
                    lblsuccess.Text = "Planta ingresada correctamente.";
                    divSuccess.Visible = true;
                    txtIdPlanta.Text = "";
                    txtFechaPlantacion.Text = "";
                    txtObservaciones.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar la Planta";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btActualizarPlanta_Click(object sender, EventArgs e)
        {
            if (!txtIdPlanta.Text.Equals(""))
            {
                try
                {
                    control.actualizarPlanta(txtIdPlanta.Text, ddHilera.SelectedValue, ddCuartel2.SelectedValue, ddSector3.SelectedValue, ddPotrero4.SelectedValue, ddFundo5.SelectedValue, ddEstado.SelectedValue, txtFechaPlantacion.Text, txtObservaciones.Text);
                    control.insertarSyncPlanta(txtIdPlanta.Text, ddHilera.SelectedValue, ddCuartel2.SelectedValue, ddSector3.SelectedValue, ddPotrero4.SelectedValue, ddFundo5.SelectedValue, ddEstado.SelectedValue, txtFechaPlantacion.Text, txtObservaciones.Text, "update");
                    dataBind("pl");
                    lblinfo.Text = "Datos de planta actualizados.";
                    divInfo.Visible = true;
                    txtIdPlanta.Text = "";
                    txtFechaPlantacion.Text = "";
                    txtObservaciones.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "Ingrese datos válidos para poder actualizar";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarPlanta_Click(object sender, EventArgs e)
        {
            if (!txtIdPlanta.Text.Equals(""))
            {
                try
                {
                    control.eliminarPlanta(txtIdPlanta.Text, ddHilera.SelectedValue, ddCuartel2.SelectedValue, ddSector3.SelectedValue, ddPotrero4.SelectedValue, ddFundo5.SelectedValue);
                    control.insertarSyncPlanta(txtIdPlanta.Text, ddHilera.SelectedValue, ddCuartel2.SelectedValue, ddSector3.SelectedValue, ddPotrero4.SelectedValue, ddFundo5.SelectedValue, ddEstado.SelectedValue, txtFechaPlantacion.Text, txtObservaciones.Text, "delete");
                    dataBind("pl");
                    lblwarning.Text = "Planta eliminada.";
                    divWarning.Visible = true;
                    txtIdPlanta.Text = "";
                    txtFechaPlantacion.Text = "";
                    txtObservaciones.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar la Planta";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btInsertarEstado_Click(object sender, EventArgs e)
        {
            if (!txtIdEstado.Text.Equals(""))
            {
                try
                {
                    control.insertarEstado(txtIdEstado.Text);
                    control.insertarSyncEstado(txtIdEstado.Text, "insert");
                    dataBind("all");
                    lblsuccess.Text = "Estado ingresado correctamente.";
                    divSuccess.Visible = true;
                    txtIdEstado.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar el Estado";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        //protected void btActualizarEstado_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        control.actualizarEstado(grillaEstado.Rows[grillaEstado.SelectedIndex].Cells[1].Text, txtIdEstado.Text);
        //        control.insertarSyncEstado(grillaEstado.Rows[grillaEstado.SelectedIndex].Cells[1].Text, txtIdEstado.Text);
        //        dataBind("all");
        //        lblinfo.Text = "Datos de estado actualizados.";
        //        divInfo.Visible = true;
        //        txtIdEstado.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        lbldanger.Text = "Ingrese datos válidos para poder actualizar";
        //        divDanger.Visible = true;
        //    }
        //}

        protected void btEliminarEstado_Click(object sender, EventArgs e)
        {
            if (!txtIdEstado.Text.Equals(""))
            {
                try
                {
                    control.eliminarEstado(txtIdEstado.Text);
                    control.insertarSyncEstado(txtIdEstado.Text, "delete");
                    dataBind("all");
                    lblwarning.Text = "Estado eliminado.";
                    divWarning.Visible = true;
                    txtIdEstado.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar el Estado";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btInsertarVariedad_Click(object sender, EventArgs e)
        {
            if (!txtIDvariedad.Text.Equals("") || !txtNombreVariedad.Text.Equals(""))
            {
                try
                {
                    control.insertarVariedad(txtIDvariedad.Text, txtNombreVariedad.Text, ddProducto.SelectedValue);
                    control.insertarSyncVariedad(txtIDvariedad.Text, txtNombreVariedad.Text, ddProducto.SelectedValue, "insert");
                    dataBind("all");
                    lblsuccess.Text = "Variedad ingresada correctamente.";
                    divSuccess.Visible = true;
                    txtIDvariedad.Text = "";
                    txtNombreVariedad.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "No se pudo ingresar la Variedad";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btEliminarVariedad_Click(object sender, EventArgs e)
        {
            if (!txtIDvariedad.Text.Equals(""))
            {
                try
                {
                    control.eliminarVariedad(txtIDvariedad.Text, ddProducto.SelectedValue);
                    control.insertarSyncVariedad(txtIDvariedad.Text, txtNombreVariedad.Text, ddProducto.SelectedValue, "delete");
                    dataBind("all");
                    lblwarning.Text = "Variedad eliminada.";
                    divWarning.Visible = true;
                    txtIDvariedad.Text = "";
                    txtNombreVariedad.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lblwarning.Text = "No se pudo eliminar la Variedad";
                    divWarning.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }

        protected void btActualizarVariedad_Click(object sender, EventArgs e)
        {
            if (!txtIDvariedad.Text.Equals("") || !txtNombreVariedad.Text.Equals(""))
            {
                try
                {
                    control.actualizarVariedad(txtIDvariedad.Text, txtNombreVariedad.Text, ddProducto.SelectedValue);
                    control.insertarSyncVariedad(txtIDvariedad.Text, txtNombreVariedad.Text, ddProducto.SelectedValue, "update");
                    dataBind("all");
                    lblinfo.Text = "Datos de variedad actualizados.";
                    divInfo.Visible = true;
                    txtIdHilera.Text = "";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    lbldanger.Text = "Ingrese datos válidos para poder actualizar";
                    divDanger.Visible = true;
                }
            }
            else
            {
                lbldanger.Text = "Complete todos los campos";
                divDanger.Visible = true;
            }
        }
    }
}