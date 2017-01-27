<%@ Page Title="" Language="C#" MasterPageFile="~/MasterManza1.Master" AutoEventWireup="true" CodeBehind="PesajesManzanos1.aspx.cs" Inherits="DemoArandanos.PesajesManzanos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registros de Bins</h1>
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


        <!-- DIVIDER -->
        <div class="col-md-12">
            <div style="width: 100%; height: 20px; border-bottom: 1px solid black; text-align: center">
                <span style="font-size: 20px; background-color: #F3F5F6; padding: 0 10px;">Administración de Registros de Bins</span>
            </div>
            <br />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblqrold" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblfechaold" runat="server" Text=""></asp:Label>
                <div class="col-md-4">
                    <label for="txtQRenvase">Código QR de Bin</label>
                    <asp:TextBox ID="txtQRenvase" runat="server" type="input" required="required" class="form-control" placeholder="Ingrese QR de bin: BIN0000000"></asp:TextBox>
                    <br />
                    <label for="txtCuadrilla">Cuadrilla</label>
                    <asp:TextBox ID="txtCuadrilla" runat="server" type="input" required="required" class="form-control" placeholder="Ingrese código de cuadrilla: CUADRILLA-0.0"></asp:TextBox>
                    <br />
                    <label for="txtRutTrabajador">Rut Trabajador</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtRutTrabajador" runat="server" type="input" class="form-control" placeholder="Ingrese Rut de Trabajador: 11111111-1"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btAgregarTrabajador" formnovalidate type="button" AutoPostBack="False" class="btn btn-default" runat="server" Text="+" OnClick="btAgregarTrabajador_Click" />
                        </span>
                        <span class="input-group-btn">
                            <asp:Button ID="btQuitarTrabajador" formnovalidate type="button" AutoPostBack="False" class="btn btn-default" runat="server" Text="-" OnClick="btQuitarTrabajador_Click" />
                        </span>
                    </div>
                    <br />
                    <label for="ddTrabajadores">Listado Trabajadores (<asp:Label ID="lblcantidadTrabajadores" runat="server" Text=""></asp:Label>)</label>
                    <asp:DropDownList ID="ddTrabajadores" CssClass="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddTrabajadores_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label for="txtRutPesador">Rut Pesador</label>
                    <asp:TextBox ID="txtRutPesador" runat="server" type="input" required="required" class="form-control" placeholder="Ingrese Rut de Pesador: 11111111-1"></asp:TextBox>
                    <br />
                    <label for="txtFechaHora">Fecha y Hora Cosecha</label>
                    <asp:TextBox ID="txtFechaHora" CssClass="form-control" TextMode="DateTimeLocal" required="required" runat="server" placeholder="aaaa-MM-dd hh:mm"></asp:TextBox>

                    <%--<label for="txtPesoBruto">Peso Bruto</label>
                    <asp:TextBox ID="txtPesoBruto" runat="server" type="text" onkeypress="return onKeyDecimal(event,this);" required="required" class="form-control" placeholder="Ingrese Peso bruto de la Bandeja: 0.00"></asp:TextBox>

                    <script language="javascript" type="text/javascript">
                        function onKeyDecimal(e, thix) {
                            var keynum = window.event ? window.event.keyCode : e.which;
                            if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
                                return false;
                            if ((keynum == 8 || keynum == 48 || keynum == 46))
                                return true;
                            if (keynum <= 47 || keynum >= 58) return false;
                            return /\d/.test(String.fromCharCode(keynum));
                        }
                    </script>
                    <br />
                    <label for="ddTara">Tara</label>
                    <asp:DropDownList ID="ddTara" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsTara" DataTextField="descri" DataValueField="Peso"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsTara" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo9 %>" SelectCommand="SELECT (Formato + ': ' + cast(Peso as varchar) + 'kl - ' + Descripcion) as descri, Peso FROM [Tara] WHERE Producto = '32' ORDER BY [Formato]"></asp:SqlDataSource>--%>

                    <br />
                    <label for="ddVariedad">Variedad</label>
                    <asp:DropDownList ID="ddVariedad" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsVariedad" DataTextField="Nombre" DataValueField="ID_Variedad" OnDataBound="ddVariedad_DataBound">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="dsVariedad" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo6 %>" SelectCommand="SELECT * FROM [Variedad] WHERE ([ID_Producto] = @ID_Producto)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="25" Name="ID_Producto" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <label for="ddFundo">Fundo</label>
                    <asp:DropDownList ID="ddFundo" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="Nombre" DataValueField="ID_Fundo" DataSourceID="dsFundoVista" OnDataBound="ddFundo_DataBound"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsFundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll WHERE ID_Producto = '25' and (ID_Variedad LIKE @ID_Variedad + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-md-4">
                    <label for="ddPotrero">Potrero</label>
                    <asp:DropDownList ID="ddPotrero" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVista" OnDataBound="ddPotrero_DataBound"></asp:DropDownList>
                    <asp:SqlDataSource ID="potrerosDEfundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Potrero, nombrePotrero FROM VistaAll WHERE ID_Producto = '25' and (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <label for="ddSector">Sector</label>
                    <asp:DropDownList ID="ddSector" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVista" OnDataBound="ddSector_DataBound"></asp:DropDownList>
                    <asp:SqlDataSource ID="sectoresDEpotreroVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE ID_Producto = '25' and (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <label for="ddCuartel">Cuartel</label>
                    <asp:DropDownList ID="ddCuartel" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreCuartel" DataValueField="ID_Cuartel" DataSourceID="cuartelesDEsectorVista" OnDataBound="ddCuartel_DataBound"></asp:DropDownList>
                    <asp:SqlDataSource ID="cuartelesDEsectorVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT nombreCuartel, ID_Cuartel FROM VistaAll WHERE ID_Producto = '25' and (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddVariedad" ConvertEmptyStringToNull="False" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <label for="ddClase">Categoría</label>
                    <asp:DropDownList ID="ddClase" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsClase" DataTextField="Clase" DataValueField="Clase"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsClase" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo %>" SelectCommand="SELECT [Clase] FROM [Clase]"></asp:SqlDataSource>
                    <br />
                </div>
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <label for="ddTipoEnvase">Tipo Envase</label>
                    <asp:DropDownList ID="ddTipoEnvase" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsTipoEnvase" DataTextField="TipoEnvase" DataValueField="KilosNetoEnvase" ></asp:DropDownList>
                    <asp:SqlDataSource ID="dsTipoEnvase" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo %>" SelectCommand="SELECT [TipoEnvase], [KilosNetoEnvase] FROM [ClaseVariedadPeso] WHERE (([ID_Producto] = @ID_Producto) AND ([ID_Variedad] = @ID_Variedad) AND ([Clase] = @Clase))">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="25" Name="ID_Producto" Type="String" />
                            <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddClase" Name="Clase" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>                
                <div class="col-md-4">
                    <!-- GRUPO DE BOTONES -->
                    <label>Seleccione una opción</label>
                    <div class="btn-group" role="group" aria-label="...">
                        <asp:Button ID="btGuardarPesaje" runat="server" Text="Registrar" type="submit" class="btn btn-default" OnClick="btGuardarPesaje_Click" />
                        <asp:Button ID="btActualizarPesaje" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarPesaje_Click" OnClientClick="return confirm('¿Está seguro de que desea actualizar todos los registros asociados al Bin seleccionado?');" />
                        <asp:Button ID="btEliminarPesaje" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarPesaje_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar todos los registros asociados al Bin seleccionado?');" />
                    </div>
                    <asp:Button ID="btLimpiar" runat="server" formnovalidate Text="Limpiar" type="submit" class="btn btn-default" OnClick="btLimpiar_Click" />
                    <br />
                    <br />
                    <br />
                </div>
                
                <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
                <!-- DIVIDER -->
                <div class="col-md-12">
                    <div style="width: 100%; height: 20px; border-bottom: 1px solid black; text-align: center">
                        <span style="font-size: 20px; background-color: #F3F5F6; padding: 0 10px;">Tabla de Registros de Bins</span>
                    </div>
                </div>
                <%--<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
            <ContentTemplate>--%>
                <div class="col-md-4">
                    <br />
                    <label for="txtFiltroRut">Filtrar por QR o Rut de Trabajador</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtFiltroRut" AutoPostBack="true" runat="server" type="input" class="form-control" placeholder="Ingrese qr o rut para filtrar la tabla" OnTextChanged="txtFiltroRut_TextChanged"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btFiltrar" formnovalidate type="button" AutoPostBack="False" class="btn btn-default" runat="server" Text="Filtrar" OnClick="btFiltrar_Click" />
                        </span>
                    </div>
                </div>
                <div class="col-md-4">
                    <br />
                    <label for="txtFechaInicio">Fecha filtro inicio</label>
                    <asp:TextBox ID="txtFechaInicio" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaInicio_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <br />
                    <label for="txtFechaTermino">Fecha filtro fin</label>
                    <asp:TextBox ID="txtFechaTermino" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <br />
                    <!-- grilla -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Registros de Bins</h3>
                        </div>
                        <div class="panel-body" style="max-height: 500px; overflow-y: scroll; font-size: 83%">
                            <div class="table-responsive">
                                <asp:GridView ID="grillaPesajes" AutoPostBack="true" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsPesajesFiltrados" OnSelectedIndexChanged="grillaPesajes_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                        <asp:BoundField DataField="QRenvase" HeaderText="QR Envase" SortExpression="QRenvase"></asp:BoundField>
                                        <asp:BoundField DataField="Cuadrilla" HeaderText="Cuadrilla" SortExpression="Cuadrilla"></asp:BoundField>
                                        <asp:BoundField DataField="RutTrabajador" HeaderText="Rut Trabajador" SortExpression="RutTrabajador"></asp:BoundField>
                                        <asp:BoundField DataField="RutPesador" HeaderText="Rut Pesador" SortExpression="RutPesador"></asp:BoundField>
                                        <asp:BoundField DataField="Fundo" HeaderText="Fundo" SortExpression="Fundo" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="Variedad" HeaderText="Variedad" SortExpression="Variedad" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="Clase" HeaderText="Categoría" SortExpression="Clase" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha Hora" SortExpression="FechaHora" DataFormatString="{0:dd/MM/yyyy HH:mm}"></asp:BoundField>
                                        <asp:BoundField DataField="PesoNeto" HeaderText="Peso Neto" SortExpression="PesoNeto" DataFormatString="{0:n2}"></asp:BoundField>
                                        <asp:BoundField DataField="Tara" HeaderText="Tara" SortExpression="Tara" DataFormatString="{0:n1}"></asp:BoundField>
                                        <asp:BoundField DataField="TipoRegistro" HeaderText="Registro" SortExpression="TipoRegistro" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="FechaHoraModificacion" HeaderText="Fecha Modificación" SortExpression="FechaHoraModificacion"></asp:BoundField>
                                        <asp:BoundField DataField="UsuarioModificacion" HeaderText="Usuario que modificó" SortExpression="UsuarioModificacion" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <%--<asp:SqlDataSource ID="dsPesajesFiltrados" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo9 %>" SelectCommand="SELECT [QRenvase], [RutTrabajador], [RutPesador], [Fundo], [Potrero], [Sector], [Variedad], [Cuartel], [FechaHora], [PesoNeto], [Tara], [TipoRegistro], [FechaHoraModificacion], [UsuarioModificacion] FROM [Pesaje] WHERE Producto = '25' and (([RutTrabajador] LIKE '%' + @RutTrabajador + '%' OR [QRenvase] LIKE '%' + @RutTrabajador + '%' OR [RutPesador] LIKE '%' + @RutTrabajador + '%') AND [FechaHora] BETWEEN (@FechaHora + ' 00:00') AND (@FechaHora2 + ' 23:59')) ORDER BY [FechaHora]">--%>
                                <asp:SqlDataSource ID="dsPesajesFiltrados" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo9 %>" SelectCommand="SELECT * FROM [Pesaje] WHERE Producto = '25' and (([RutTrabajador] LIKE '%' + @RutTrabajador + '%' OR [QRenvase] LIKE '%' + @RutTrabajador + '%' OR [RutPesador] LIKE '%' + @RutTrabajador + '%') AND [FechaHora] BETWEEN (@FechaHora + ' 00:00') AND (@FechaHora2 + ' 23:59')) ORDER BY [FechaHora]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtFiltroRut" Name="RutTrabajador" PropertyName="Text" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="txtFechaInicio" Name="FechaHora" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" DefaultValue="1999-01-01" />
                                        <asp:ControlParameter ControlID="txtFechaTermino" Name="FechaHora2" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" DefaultValue="2099-01-01" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="Button1" formnovalidate Style="margin-right: 5px; float: right" class="btn btn-default" runat="server" Text="Exportar a Excel" OnClick="ExportToExcel" />
    </form>

</asp:Content>
