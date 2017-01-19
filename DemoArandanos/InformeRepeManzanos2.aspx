<%@ Page Title="" Language="C#" MasterPageFile="~/MasterManza2.Master" AutoEventWireup="true" CodeBehind="InformeRepeManzanos2.aspx.cs" Inherits="DemoArandanos.InformeRepeManzanos2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Informe Registros Repetidos</h1>
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
        </div>

        <div class="col-md-12">
            <div class="col-md-3">
                <label for="txtFecha">Fecha filtro</label>
                <asp:TextBox ID="txtFecha" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="hidden-print">
            <div class="col-md-12">
                <!-- grilla -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Registros de bins repetidos del día</h3>
                    </div>
                    <div class="panel-body" style="max-height: 480px; overflow-y: scroll; font-size: 83%">
                        <div class="table-responsive">
                            <asp:GridView ID="grillaRepetidas" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="dsRepetidas" OnDataBound="grillaRepetidas_DataBound" OnSelectedIndexChanged="grillaRepetidas_SelectedIndexChanged">
                                <Columns>

                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <strong><asp:Button ID="btEliminarRepe" runat="server" CommandName="Select" Text="X"
                                                OnClientClick="return confirm('¿Está seguro de que desea eliminar el registro repetido?');" /></strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="QRenvase" HeaderText="QR Envase" SortExpression="QRenvase" />
                                    <asp:BoundField DataField="Cuadrilla" HeaderText="Cuadrilla" SortExpression="Cuadrilla" />
                                    <asp:BoundField DataField="RutTrabajador" HeaderText="Rut Trabajador" SortExpression="RutTrabajador" />
                                    <asp:BoundField DataField="RutPesador" HeaderText="Rut Pesador" SortExpression="RutPesador" />
                                    <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero" />
                                    <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" />
                                    <asp:BoundField DataField="Variedad" HeaderText="Variedad" SortExpression="Variedad" />
                                    <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel" />
                                    <asp:BoundField DataField="FechaHora" HeaderText="Fecha Hora" SortExpression="FechaHora" />
                                    <asp:BoundField DataField="PesoNeto" HeaderText="Peso Neto" SortExpression="PesoNeto" DataFormatString="{0:n2}" />
                                    <asp:BoundField DataField="TipoRegistro" HeaderText="Tipo Registro" SortExpression="TipoRegistro" />
                                    <asp:BoundField DataField="FechaHoraModificacion" HeaderText="Fecha Hora Modificación" SortExpression="FechaHoraModificacion" />
                                    <asp:BoundField DataField="UsuarioModificacion" HeaderText="Usuario que Modificó" SortExpression="UsuarioModificacion" />
                                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="dsRepetidas" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo11 %>" SelectCommand="
                                                SELECT *
                                                FROM dbo.Pesaje
                                                WHERE dbo.Pesaje.Producto = '25' and (CONVERT (VARCHAR(10), FechaHora, 103) = @Fecha)

												and (dbo.Pesaje.QRenvase + dbo.Pesaje.RutTrabajador)
                                                IN (
                                                SELECT (dbo.Pesaje.QRenvase + dbo.Pesaje.RutTrabajador)
                                                FROM dbo.Pesaje
                                                WHERE (CONVERT (VARCHAR(10), FechaHora, 103) = @Fecha)
                                                GROUP BY (dbo.Pesaje.QRenvase + dbo.Pesaje.RutTrabajador)
                                                HAVING count(dbo.Pesaje.QRenvase + dbo.Pesaje.RutTrabajador) &gt; 1)

                                                ORDER BY dbo.Pesaje.QRenvase">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtFecha" Name="Fecha" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
            <input type="button" style="float: right" class="btn btn-default" name="Imprimir" value="Imprimir" onclick="window.print()">
            <asp:Button ID="Button1" formnovalidate Style="margin-right: 5px; float: right" class="btn btn-default" runat="server" Text="Exportar a Excel" OnClick="ExportToExcel" />
        </div>

        <div class="visible-print">
            <div class="table-responsive">
                <asp:GridView ID="grillaImp" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="dsRepetidas">
                    <Columns>
                        <asp:BoundField DataField="QRenvase" HeaderText="QR Envase" SortExpression="QRenvase" />
                        <asp:BoundField DataField="Cuadrilla" HeaderText="Cuadrilla" SortExpression="Cuadrilla" />
                        <asp:BoundField DataField="RutTrabajador" HeaderText="Rut Trabajador" SortExpression="RutTrabajador" />
                        <asp:BoundField DataField="RutPesador" HeaderText="Rut Pesador" SortExpression="RutPesador" />
                        <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero" />
                        <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" />
                        <asp:BoundField DataField="Variedad" HeaderText="Variedad" SortExpression="Variedad" />
                        <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel" />
                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha Hora" SortExpression="FechaHora" />
                        <asp:BoundField DataField="PesoNeto" HeaderText="Peso Neto" SortExpression="PesoNeto" DataFormatString="{0:n2}" />
                        <asp:BoundField DataField="TipoRegistro" HeaderText="Tipo Registro" SortExpression="TipoRegistro" />
                        <asp:BoundField DataField="FechaHoraModificacion" HeaderText="Fecha Hora Modificación" SortExpression="FechaHoraModificacion" />
                        <asp:BoundField DataField="UsuarioModificacion" HeaderText="Usuario que Modificó" SortExpression="UsuarioModificacion" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

</asp:Content>
