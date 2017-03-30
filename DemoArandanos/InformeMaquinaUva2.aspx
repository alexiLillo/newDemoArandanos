<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUva2.Master" AutoEventWireup="true" CodeBehind="InformeMaquinaUva2.aspx.cs" Inherits="DemoArandanos.InformeMaquinaUva2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Informe Producción Contratistas, Viñedos</h1>
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

        <div class="col-md-12">
            <div id="printableArea">

                <div class="col-md-12">
                    <div class="visible-print">
                        <h2>Informe de Producción Uvas, Contratistas</h2>
                        <br />
                        <h5>Desde:
                            <asp:Label ID="lbldesde" runat="server" Text=""></asp:Label></h5>
                        <h5>Hasta:
                            <asp:Label ID="lblhasta" runat="server" Text=""></asp:Label></h5>
                        <br />
                        <h6>Variedad:
                            <asp:Label ID="lblvaried" runat="server" Text=""></asp:Label>
                            - Fundo:
                            <asp:Label ID="lblfund" runat="server" Text=""></asp:Label>
                            -
                            <asp:Label ID="lblpotrer" runat="server" Text=""></asp:Label>
                            -
                            <asp:Label ID="lblsect" runat="server" Text=""></asp:Label>
                            -
                            <asp:Label ID="lblcuart" runat="server" Text=""></asp:Label></h6>
                    </div>
                </div>

                <div class="col-md-4">
                    <h3>Total Bandejas:
                <asp:Label ID="lbltotalbandejas" runat="server" Text=""></asp:Label></h3>
                    <h3>Total Kilos Neto:
                <asp:Label ID="lbltotalkilos" runat="server" Text=""></asp:Label></h3>
                    <br />
                    <br />
                </div>
                <div class="col-md-5">
                    <%--<h3>Cantidad Trabajadores:
                <asp:Label ID="lbltotaltrabajadores" runat="server" Text=""></asp:Label></h3>
                    <h3>Promedio Kg/Trabajador:
                <asp:Label ID="lblpromkltrab" runat="server" Text=""></asp:Label></h3>--%>
                </div>
            </div>
            <div class="col-md-3">
                <br />
                <br />
                <br />
                <input type="button" style="float: left" class="btn btn-default" name="Imprimir" value="Imprimir" onclick="printDiv('printableArea')">
                <asp:Button ID="btExportExcel" Style="margin-right: 5px; float: right" class="btn btn-default" runat="server" Text="Exportar a Excel" OnClick="ExportToExcel" />
            </div>
        </div>

        <div class="col-md-2">
            <label for="ddVariedad">Variedad</label>
            <asp:DropDownList ID="ddVariedad" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsVariedad" DataTextField="Nombre" DataValueField="ID_Variedad" OnDataBound="ddVariedad_DataBound">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsVariedad" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo6 %>" SelectCommand="SELECT * FROM [Variedad] WHERE ([ID_Producto] = @ID_Producto)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="33" Name="ID_Producto" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
            <label for="ddFundo">Fundo</label>
            <asp:DropDownList ID="ddFundo" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="Nombre" DataValueField="ID_Fundo" DataSourceID="dsFundoVista" OnDataBound="ddFundo_DataBound"></asp:DropDownList>
            <asp:SqlDataSource ID="dsFundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll WHERE (ID_Variedad LIKE @ID_Variedad + '%')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
            <label for="ddPotrero">Potrero</label>
            <asp:DropDownList ID="ddPotrero" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVista" OnDataBound="ddPotrero_DataBound"></asp:DropDownList>
            <asp:SqlDataSource ID="potrerosDEfundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Potrero, nombrePotrero FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" DefaultValue="0" />
                    <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
            <label for="ddSector">Sector</label>
            <asp:DropDownList ID="ddSector" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVista" OnDataBound="ddSector_DataBound"></asp:DropDownList>
            <asp:SqlDataSource ID="sectoresDEpotreroVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                <SelectParameters>
                    <asp:ControlParameter DefaultValue="0" ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter DefaultValue="0" ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter DefaultValue="0" ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
            <label for="ddCuartel">Cuartel</label>
            <asp:DropDownList ID="ddCuartel" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreCuartel" DataValueField="ID_Cuartel" DataSourceID="cuartelesDEsectorVista" OnDataBound="ddCuartel_DataBound"></asp:DropDownList>
            <asp:SqlDataSource ID="cuartelesDEsectorVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT nombreCuartel, ID_Cuartel FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                <SelectParameters>
                    <asp:ControlParameter DefaultValue="0" ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter DefaultValue="0" ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter DefaultValue="0" ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="ddVariedad" ConvertEmptyStringToNull="False" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
        </div>
        <div class="col-md-10">
            <div class="col-md-12">
                <br />
                <div class="col-md-4">
                    <label for="txtFechaInicio">Fecha filtro inicio</label>
                    <asp:TextBox ID="txtFechaInicio" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaInicio_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="txtFechaTermino">Fecha filtro fin</label>
                    <asp:TextBox ID="txtFechaTermino" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-4">
                </div>
                <br />
            </div>
            <!-- grilla -->
            <div class="panel panel-default">

                <div class="panel-body" style="max-height: 400px; overflow-y: scroll;">
                    <div class="table-responsive">
                        <asp:GridView ID="grillaProdMaquina" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsGrillaMaquina" OnDataBound="grillaProdMaquina_DataBound" >
                            <Columns>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                <asp:BoundField DataField="Variedad" HeaderText="Variedad" SortExpression="Variedad" />
                                <asp:BoundField DataField="Fundo" HeaderText="Fundo" SortExpression="Fundo" />
                                <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero" />
                                <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" />
                                <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="PesoNeto" HeaderText="Kilos" SortExpression="PesoNeto" DataFormatString="{0:n}" />
                                <asp:BoundField DataField="Bandejas" HeaderText="Bins" SortExpression="Bandejas" DataFormatString="{0:n0}" />
                                <asp:BoundField DataField="Guia" HeaderText="Guía" SortExpression="Guia" />
                                <asp:BoundField DataField="Recepcion" HeaderText="Recepción" SortExpression="Recepcion" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsGrillaMaquina" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo10 %>" SelectCommand="SELECT * FROM [CosechaMaquina] WHERE Producto = '33' AND ((Fundo LIKE  @ID_Fundo + '%') AND (Potrero LIKE @ID_Potrero + '%') AND (Sector LIKE @ID_Sector + '%') AND (Cuartel LIKE @ID_Cuartel + '%') AND (Variedad LIKE @ID_Variedad + '%')) AND [Fecha] BETWEEN (@Fecha1 + '') AND (@Fecha2 + '') ORDER BY [Fecha]">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" ConvertEmptyStringToNull="False" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddPotrero" ConvertEmptyStringToNull="False" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddSector" ConvertEmptyStringToNull="False" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddCuartel" ConvertEmptyStringToNull="False" Name="ID_Cuartel" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" ConvertEmptyStringToNull="False" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />

                                <asp:ControlParameter ControlID="txtFechaInicio" Name="Fecha1" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" />
                                <asp:ControlParameter ControlID="txtFechaTermino" Name="Fecha2" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>

    </form>

</asp:Content>
