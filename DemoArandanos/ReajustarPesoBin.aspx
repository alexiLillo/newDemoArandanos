﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterManza1.Master" AutoEventWireup="true" CodeBehind="ReajustarPesoBin.aspx.cs" Inherits="DemoArandanos.ReajustarPesoBin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Reajustar Pesos de Bins</h1>
    <br />
    <form runat="server">
        <div class="hidden-print">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class=" col-md-12">

                <script language="javascript" type="text/javascript">
                    function printDiv(divName) {
                        var printContents = document.getElementById(divName).innerHTML;
                        var originalContents = document.body.innerHTML;

                        document.body.innerHTML = printContents;

                        window.print();

                        document.body.innerHTML = originalContents;
                    }

                </script>

                <!-- Alertas de Bootstrap -->
                <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Always" runat="server">
                    <ContentTemplate>
                        <!-- Funcion para desvanecer alertas -->
                        <script language="javascript" type="text/javascript">
                            function pageLoad() {
                                window.setTimeout(function () {
                                    $(".alert").fadeTo(500, 0).slideUp(500, function () {
                                        $(this).remove();
                                    });
                                }, 6000);
                            }
                        </script>
                        <div class="alert alert-success fade in" role="alert" id="divSuccess" runat="server">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>OK!</strong>
                            <asp:Label ID="lblsuccess" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert alert-warning fade in" role="alert" id="divWarning" runat="server">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>Atención!</strong>
                            <asp:Label ID="lblwarning" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert alert-info fade in" role="alert" id="divInfo" runat="server">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>Atención!</strong>
                            <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert alert-danger fade in" role="alert" id="divDanger" runat="server">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>Error!</strong>
                            <asp:Label ID="lbldanger" runat="server"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="col-md-3">
            <label for="txtFecha">Seleccionar día a reajustar</label>
            <asp:TextBox ID="txtFecha" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd"> </asp:TextBox>
            <br />
        </div>
        <div class="col-md-4">
            <label for="txtFecha">
                Peso del día:
                <asp:Label ID="lblpesodeldia" runat="server" Text=""></asp:Label></label>
            <br />
            <asp:Button ID="btReajustarPeso" class="btn btn-default" runat="server" Text="Reajustar Pesos" OnClick="btReajustarPeso_Click" OnClientClick="return confirm('¿Está seguro de que desea reajustar el peso de todos los registros de bins del día seleccionado?');" />
        </div>
       <%-- <div class="col-md-5">
            <div class="loading" align="center">
                <strong>Reajustando, por favor espere...</strong><br />
                <br />
                <img src="loader.gif" alt="" />
            </div>
        </div>--%>

    </form>

</asp:Content>
