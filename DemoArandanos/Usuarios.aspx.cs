﻿using DemoArandanos.Controlador;
using System;

namespace DemoArandanos
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Controler control = new Controler();
        private String us, tip;
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divWarning.Visible = false;
            divInfo.Visible = false;
            divDanger.Visible = false;
            grillaUsuarios.DataBind();
        }

        protected void grillaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUser.Text = grillaUsuarios.Rows[grillaUsuarios.SelectedIndex].Cells[1].Text;
            us = grillaUsuarios.Rows[grillaUsuarios.SelectedIndex].Cells[1].Text;
            ddTipo.SelectedValue = grillaUsuarios.Rows[grillaUsuarios.SelectedIndex].Cells[2].Text;
            tip = grillaUsuarios.Rows[grillaUsuarios.SelectedIndex].Cells[2].Text;
        }

        protected void btnIngresarUsuario_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("") || txtPass1.Text.Equals("") || txtPass2.Text.Equals(""))
            {
                lbldanger.Text = "Complete todos los campos!";
                divDanger.Visible = true;
            }
            else
            {
                if (txtPass1.Text.Equals(txtPass2.Text))
                {
                    control.insertarUsuario(txtUser.Text, txtPass1.Text, ddTipo.SelectedValue);
                    control.insertarSyncUsuario(txtUser.Text, txtPass1.Text, ddTipo.SelectedValue, 0,"insert");
                    txtUser.Text = "";
                    txtPass1.Text = "";
                    txtPass2.Text = "";
                    lblsuccess.Text = "Usuario ingresado correctamente";
                    divSuccess.Visible = true;
                    grillaUsuarios.DataBind();
                }
                else
                {
                    lbldanger.Text = "Las contraseñas no coinciden!";
                    divDanger.Visible = true;
                }
            }
        }        

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("") || txtPass1.Text.Equals("") || txtPass2.Text.Equals(""))
            {
                lbldanger.Text = "Complete todos los campos!";
                divDanger.Visible = true;
            }
            else
            {
                if (txtPass1.Text.Equals(txtPass2.Text))
                {
                    control.eliminarUsuario(txtUser.Text, txtPass1.Text);
                    control.insertarSyncUsuario(txtUser.Text, txtPass1.Text, ddTipo.SelectedValue, 0, "delete");
                    txtUser.Text = "";
                    txtPass1.Text = "";
                    txtPass2.Text = "";
                    lblwarning.Text = "Usuario eliminado!";
                    divWarning.Visible = true;
                    grillaUsuarios.DataBind();
                }
                else
                {
                    lbldanger.Text = "Las contraseñas no coinciden!";
                    divDanger.Visible = true;
                }
            }
        }
    }
}