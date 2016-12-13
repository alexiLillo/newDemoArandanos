<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="ModificarMasivo2.aspx.cs" Inherits="DemoArandanos.ModificarMasivo2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h1>Modificación Masiva</h1>
    <br />
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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

        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
            <ContentTemplate>
                <!-- DIVIDER -->
                <div class="col-md-12">
                    <div style="width: 100%; height: 20px; border-bottom: 1px solid black; text-align: center">
                        <span style="font-size: 20px; background-color: #F3F5F6; padding: 0 10px;">Selección de nuevos criterios</span>
                    </div>
                </div>
                <div class="col-md-12">
                    <br />
                    <div class="col-md-2">
                        <label for="ddVariedad">Variedad</label>
                        <asp:DropDownList ID="ddVariedad" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsVariedad" DataTextField="Nombre" DataValueField="ID_Variedad" OnDataBound="ddVariedad_DataBound">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsVariedad" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo6 %>" SelectCommand="SELECT * FROM [Variedad] WHERE ([ID_Producto] = @ID_Producto)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="32" Name="ID_Producto" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="ddFundo">Fundo</label>
                        <asp:DropDownList ID="ddFundo" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="Nombre" DataValueField="ID_Fundo" DataSourceID="dsFundoVista" OnDataBound="ddFundo_DataBound"></asp:DropDownList>
                        <asp:SqlDataSource ID="dsFundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll WHERE (ID_Variedad LIKE @ID_Variedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="ddPotrero">Potrero</label>
                        <asp:DropDownList ID="ddPotrero" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVista" OnDataBound="ddPotrero_DataBound"></asp:DropDownList>
                        <asp:SqlDataSource ID="potrerosDEfundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Potrero, nombrePotrero FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="ddSector">Sector</label>
                        <asp:DropDownList ID="ddSector" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVista" OnDataBound="ddSector_DataBound"></asp:DropDownList>
                        <asp:SqlDataSource ID="sectoresDEpotreroVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="ddCuartel">Cuartel</label>
                        <asp:DropDownList ID="ddCuartel" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreCuartel" DataValueField="ID_Cuartel" DataSourceID="cuartelesDEsectorVista" OnDataBound="ddCuartel_DataBound"></asp:DropDownList>
                        <asp:SqlDataSource ID="cuartelesDEsectorVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT nombreCuartel, ID_Cuartel FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" ConvertEmptyStringToNull="False" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="btModificarMasivo">
                            <asp:Label ID="lblcantidadbandejas" runat="server" Text=""></asp:Label>
                            Bandejas</label>
                        <asp:Button ID="btModificarMasivo" runat="server" Text="Modificar" type="submit" class="btn btn-default" OnClick="btModificarMasivo_Click" onclientclick="return confirm('¿Está seguro de que desea editar los registros seleccionados?');"/>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
                <!-- DIVIDER -->
                <div class="col-md-12">
                    <div style="width: 100%; height: 20px; border-bottom: 1px solid black; text-align: center">
                        <span style="font-size: 20px; background-color: #F3F5F6; padding: 0 10px;">Filtrar bandejas a modificar</span>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-4">
                        <br />
                        <label for="txtFiltroRut">Filtrar por Rut Pesador</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtFiltroRut" AutoPostBack="true" runat="server" type="input" class="form-control" placeholder="Ingrese rut para filtrar la tabla" OnTextChanged="txtFiltroRut_TextChanged"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btFiltrar" formnovalidate type="button" AutoPostBack="False" class="btn btn-default" runat="server" Text="Filtrar" OnClick="btFiltrar_Click" />
                            </span>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <br />
                        <label for="txtFechaInicio">Fecha filtro inicio</label>
                        <asp:TextBox ID="txtFechaInicio" AutoPostBack="true" CssClass="form-control" TextMode="DateTimeLocal" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaInicio_TextChanged"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <br />
                        <label for="txtFechaTermino">Fecha filtro fin</label>
                        <asp:TextBox ID="txtFechaTermino" AutoPostBack="true" CssClass="form-control" TextMode="DateTimeLocal" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
                    </div>

                    <div class="col-md-12">
                        <br />
                        <br />
                        <div class="col-md-2">
                            <label for="txtCant">Cantidad a filtrar</label>
                            <asp:TextBox ID="txtCant" AutoPostBack="true" runat="server" type="number" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label for="ddVariedadFiltro">Filtro Variedad</label>
                            <asp:DropDownList ID="ddVariedadFiltro" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsVariedadFiltro" DataTextField="Nombre" DataValueField="ID_Variedad" OnDataBound="ddVariedadFiltro_DataBound">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="dsVariedadFiltro" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo6 %>" SelectCommand="SELECT * FROM [Variedad] WHERE ([ID_Producto] = @ID_Producto)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="32" Name="ID_Producto" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-md-2">
                            <label for="ddFundoFiltro">Filtro Fundo</label>
                            <asp:DropDownList ID="ddFundoFiltro" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="Nombre" DataValueField="ID_Fundo" DataSourceID="dsFundoVistaFiltro" OnDataBound="ddFundoFiltro_DataBound"></asp:DropDownList>
                            <asp:SqlDataSource ID="dsFundoVistaFiltro" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll WHERE (ID_Variedad LIKE @ID_Variedad + '%')">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddVariedadFiltro" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-md-2">
                            <label for="ddPotreroFiltro">Filtro Potrero</label>
                            <asp:DropDownList ID="ddPotreroFiltro" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVistaFiltro" OnDataBound="ddPotreroFiltro_DataBound"></asp:DropDownList>
                            <asp:SqlDataSource ID="potrerosDEfundoVistaFiltro" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Potrero, nombrePotrero FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddFundoFiltro" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddVariedadFiltro" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-md-2">
                            <label for="ddSectorFiltro">Filtro Sector</label>
                            <asp:DropDownList ID="ddSectorFiltro" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVistaFiltro" OnDataBound="ddSectorFiltro_DataBound"></asp:DropDownList>
                            <asp:SqlDataSource ID="sectoresDEpotreroVistaFiltro" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddFundoFiltro" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddPotreroFiltro" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddVariedadFiltro" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-md-2">
                            <label for="ddCuartelFiltro">Filtro Cuartel</label>
                            <asp:DropDownList ID="ddCuartelFiltro" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreCuartel" DataValueField="ID_Cuartel" DataSourceID="cuartelesDEsectorVistaFiltro" OnDataBound="ddCuartelFiltro_DataBound"></asp:DropDownList>
                            <asp:SqlDataSource ID="cuartelesDEsectorVistaFiltro" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT nombreCuartel, ID_Cuartel FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddFundoFiltro" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddPotreroFiltro" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddSectorFiltro" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddVariedadFiltro" ConvertEmptyStringToNull="False" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <br />
                        <br />
                    </div>

                    <div class="col-md-12">
                        <br />
                        <!-- grilla -->
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">Pesajes</h3>
                            </div>
                            <div class="panel-body" style="max-height: 500px; overflow-y: scroll; font-size: 83%">
                                <div class="table-responsive">
                                    <asp:GridView ID="grillaPesajes" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsPesajesFiltrados" OnDataBound="grillaPesajes_DataBound">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"></asp:BoundField>
                                            <asp:BoundField DataField="QRenvase" HeaderText="QR Envase" SortExpression="QRenvase"></asp:BoundField>
                                            <asp:BoundField DataField="RutTrabajador" HeaderText="Rut Trabajador" SortExpression="RutTrabajador"></asp:BoundField>
                                            <asp:BoundField DataField="RutPesador" HeaderText="Rut Pesador" SortExpression="RutPesador"></asp:BoundField>
                                            <asp:BoundField DataField="Fundo" HeaderText="Fundo" SortExpression="Fundo" HtmlEncode="False"></asp:BoundField>
                                            <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero" HtmlEncode="False"></asp:BoundField>
                                            <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" HtmlEncode="False"></asp:BoundField>
                                            <asp:BoundField DataField="Variedad" HeaderText="Variedad" SortExpression="Variedad" HtmlEncode="False"></asp:BoundField>
                                            <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel" HtmlEncode="False"></asp:BoundField>
                                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha Hora" SortExpression="FechaHora" DataFormatString="{0:dd/MM/yyyy HH:mm}"></asp:BoundField>
                                            <asp:BoundField DataField="PesoNeto" HeaderText="Peso Neto" SortExpression="PesoNeto" DataFormatString="{0:n2}"></asp:BoundField>
                                            <asp:BoundField DataField="Tara" HeaderText="Tara" SortExpression="Tara"></asp:BoundField>
                                            <asp:BoundField DataField="TipoRegistro" HeaderText="Registro" SortExpression="TipoRegistro" HtmlEncode="False"></asp:BoundField>
                                            <asp:BoundField DataField="FechaHoraModificacion" HeaderText="Fecha Modificación" SortExpression="FechaHoraModificacion"></asp:BoundField>
                                            <asp:BoundField DataField="UsuarioModificacion" HeaderText="Usuario que modificó" SortExpression="UsuarioModificacion" HtmlEncode="False"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsPesajesFiltrados" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo9 %>" SelectCommand="SELECT TOP(@Cant) [QRenvase], [RutTrabajador], [RutPesador], [Fundo], [Potrero], [Sector], [Variedad], [Cuartel], [FechaHora], [PesoNeto], [Tara], [TipoRegistro], [FechaHoraModificacion], [UsuarioModificacion], [id] FROM [Pesaje] WHERE ((Fundo LIKE  @ID_Fundo + '%') AND (Potrero LIKE @ID_Potrero + '%') AND (Sector LIKE @ID_Sector + '%') AND (Cuartel LIKE @ID_Cuartel + '%') AND (Variedad LIKE @ID_Variedad + '%') AND ([RutPesador] LIKE '%' + @RutPesador + '%') AND [FechaHora] BETWEEN (@FechaHora + '') AND (@FechaHora2 + '')) ORDER BY [FechaHora]">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtCant" Name="Cant" PropertyName="Text" Type="Int32" ConvertEmptyStringToNull="False" />
                                            <asp:ControlParameter ControlID="txtFiltroRut" Name="RutPesador" PropertyName="Text" Type="String" ConvertEmptyStringToNull="False" />
                                            <asp:ControlParameter ControlID="txtFechaInicio" Name="FechaHora" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" DefaultValue="1999-01-01" />
                                            <asp:ControlParameter ControlID="txtFechaTermino" Name="FechaHora2" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" DefaultValue="2099-01-01" />

                                            <asp:ControlParameter ControlID="ddFundoFiltro" ConvertEmptyStringToNull="False" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                            <asp:ControlParameter ControlID="ddPotreroFiltro" ConvertEmptyStringToNull="False" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                            <asp:ControlParameter ControlID="ddSectorFiltro" ConvertEmptyStringToNull="False" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                                            <asp:ControlParameter ControlID="ddCuartelFiltro" ConvertEmptyStringToNull="False" Name="ID_Cuartel" PropertyName="SelectedValue" Type="String" />
                                            <asp:ControlParameter ControlID="ddVariedadFiltro" ConvertEmptyStringToNull="False" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />

                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</asp:Content>
