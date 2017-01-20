<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="Trabajadores2.aspx.cs" Inherits="DemoArandanos.Trabajadores2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Enrolamiento Trabajadores</h1>
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

        <div class="col-md-5">
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                <ContentTemplate>
                    <label for="txtRutTrabajador">Rut</label>
                    <asp:TextBox ID="txtRutTrabajador" runat="server" required="required" type="input" class="form-control" placeholder="Ingrese Rut de Trabajador"></asp:TextBox>
                    <br />
                    <label for="txtNombreTrabajador">Nombre</label>
                    <asp:TextBox ID="txtNombreTrabajador" runat="server" required="required" type="input" class="form-control" placeholder="Ingrese Nombre de Trabajador"></asp:TextBox>
                    <br />
                    <label for="txtApellidoTrabajador">Apellido</label>
                    <asp:TextBox ID="txtApellidoTrabajador" runat="server" required="required" type="input" class="form-control" placeholder="Ingrese Apellido de Trabajador"></asp:TextBox>
                    <br />
                    <label for="txtFechaNacimiento">Fecha Nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-mm-dd"></asp:TextBox>
                    <br />
                    <label for="txtFechaIngreso">Fecha Ingreso</label>
                    <asp:TextBox ID="txtFechaIngreso" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-mm-dd"></asp:TextBox>
                    <br />
                    <label for="txtFicha">Número Ficha</label>
                    <asp:TextBox ID="txtFicha" runat="server" type="number" required="required" class="form-control"></asp:TextBox>
                    <br />
                    <div class="btn-group" role="group" aria-label="...">
                        <asp:Button ID="btGuardarTrabajador" runat="server" Text="Registrar" type="submit" class="btn btn-default" OnClick="btGuardarTrabajador_Click" />
                        <asp:Button ID="btGenerarQR" runat="server" Text="Generar QR" type="submit" class="btn btn-default" OnClick="btGenerarQR_Click" />
                        <asp:Button ID="btActualizarTrabajador" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarTrabajador_Click" />
                        <asp:Button ID="btEliminarTrabajador" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarTrabajador_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar el Trabajador?');" />
                    </div>
                    <br />
                    <div id="printableArea">
                        <asp:PlaceHolder ID="plBarCode" runat="server" />
                        <div class="visible-print">
                            <asp:Label ID="lblQR" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <input type="button" class="btn btn-default" name="Imprimir QR" value="Imprimir QR" onclick="printDiv('printableArea')">
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-7">
            <label for="txtFiltroRut">Buscar Trabajador</label>
            <div class="input-group">
                <asp:TextBox ID="txtFiltroRut" AutoPostBack="true" runat="server" type="input" class="form-control" placeholder="Ingrese rut, nombre o ficha para filtrar la tabla" OnTextChanged="txtFiltroRut_TextChanged"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="btFiltrar" formnovalidate type="button" AutoPostBack="False" class="btn btn-default" runat="server" Text="Filtrar" OnClick="btFiltrar_Click" />
                </span>
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
                <ContentTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Trabajadores</h3>
                        </div>
                        <div class="panel-body" style="max-height: 480px; overflow-y: scroll; font-size: 85%">
                            <!-- grilla -->
                            <div class="table-responsive">
                                <asp:GridView ID="grillaTrabajadores" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaTrabajadores_SelectedIndexChanged" DataKeyNames="Rut" DataSourceID="dsTrabajadores">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                        <asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="True" SortExpression="Rut" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HtmlEncode="False" />
                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" HtmlEncode="False" />
                                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" SortExpression="FechaIngreso" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Ficha" HeaderText="Ficha" SortExpression="Ficha" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsTrabajadores" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo9 %>" SelectCommand="SELECT [Rut], [Nombre], [Apellido], [FechaNacimiento], [FechaIngreso], [Ficha] FROM [Trabajador] WHERE (([Rut] LIKE @RutTrabajador + '%') OR ([Ficha] LIKE @RutTrabajador + '%') OR ([Nombre] LIKE @RutTrabajador + '%') OR ([Apellido] LIKE @RutTrabajador + '%')) ORDER BY [Nombre], [Apellido]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtFiltroRut" Name="RutTrabajador" PropertyName="Text" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Button ID="Button1" formnovalidate Style="margin-right: 5px; float: right" class="btn btn-default" runat="server" Text="Exportar a Excel" OnClick="ExportToExcel" />
    </form>
</asp:Content>
