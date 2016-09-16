﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="InformeGraficos1.aspx.cs" Inherits="DemoArandanos.InformeGraficos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Informe Producción Gráficos</h1>
    <br />
    <form runat="server">
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
                            }, 4000);
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

        <div class="col-md-12">
            <div class="col-md-2">
                <label for="ddFundo">Fundo</label>
                <asp:DropDownList ID="ddFundo" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="Nombre" DataValueField="ID_Fundo" DataSourceID="dsFundoVista" OnDataBound="ddFundo_DataBound"></asp:DropDownList>
                <asp:SqlDataSource ID="dsFundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll "></asp:SqlDataSource>
                <br />
                <br />
            </div>

            <div class="col-md-2">
                <label for="ddPotrero">Potrero</label>
                <asp:DropDownList ID="ddPotrero" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVista" OnDataBound="ddPotrero_DataBound"></asp:DropDownList>
                <asp:SqlDataSource ID="potrerosDEfundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Potrero, nombrePotrero FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" DefaultValue="0" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br />
            </div>

            <div class="col-md-2">
                <label for="ddSector">Sector</label>
                <asp:DropDownList ID="ddSector" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVista" OnDataBound="ddSector_DataBound"></asp:DropDownList>
                <asp:SqlDataSource ID="sectoresDEpotreroVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%')">
                    <SelectParameters>
                        <asp:ControlParameter DefaultValue="0" ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter DefaultValue="0" ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br />
            </div>

            <div class="col-md-3">
                <label for="txtFechaInicio">Fecha filtro inicio</label>
                <asp:TextBox ID="txtFechaInicio" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaInicio_TextChanged"></asp:TextBox>
                <br />
                <br />
            </div>
            <div class="col-md-3">
                <label for="txtFechaTermino">Fecha filtro fin</label>
                <asp:TextBox ID="txtFechaTermino" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
                <br />
                <br />
            </div>
        </div>

        <div class=" col-md-12">
            <div class=" col-md-2">
                <label for="ddCuartel">Cuartel</label>
                <asp:DropDownList ID="ddCuartel" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreCuartel" DataValueField="ID_Cuartel" DataSourceID="cuartelesDEsectorVista" OnDataBound="ddCuartel_DataBound"></asp:DropDownList>
                <asp:SqlDataSource ID="cuartelesDEsectorVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT nombreCuartel, ID_Cuartel FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%')">
                    <SelectParameters>
                        <asp:ControlParameter DefaultValue="0" ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter DefaultValue="0" ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter DefaultValue="0" ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </div>
            <div class=" col-md-4">
                <label>Gráfico por Variedades Kilos Neto</label>
            </div>
            <div class=" col-md-1"></div>
            <div class=" col-md-5">
                <label>Gráfico Total Kilos Neto: <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label></label>
            </div>
        </div>
        <asp:Chart ID="GraficoVariedad" runat="server" Width="568" Height="426" />
        <asp:Chart ID="GraficoCuartel" runat="server" Width="568" Height="426" />
    </form>

</asp:Content>
