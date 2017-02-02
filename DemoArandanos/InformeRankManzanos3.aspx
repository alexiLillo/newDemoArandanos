<%@ Page Title="" Language="C#" MasterPageFile="~/MasterManza3.Master" AutoEventWireup="true" CodeBehind="InformeRankManzanos3.aspx.cs" Inherits="DemoArandanos.InformeRankManzanos3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hidden-print">
        <h1>Ranking de Trabajadores Manzanos</h1>
        <br />
    </div>
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
            <div class="hidden-print">
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
                                }, 8000);
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

        <div class="hidden-print">
            <div class="col-md-12">
                <div class="col-md-6">
                    <label for="txtFiltro">Filtrar por Rut o Nombre de Trabajador</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtFiltro" AutoPostBack="true" runat="server" type="input" class="form-control" placeholder="Ingrese rut o nombre para filtrar la tabla" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btFiltrar" type="button" AutoPostBack="False" class="btn btn-default" runat="server" Text="Filtrar" OnClick="btFiltrar_Click" />
                        </span>
                    </div>
                    <br />
                </div>
                <div class="col-md-3">
                    <label for="txtFechaInicio">Fecha filtro inicio</label>
                    <asp:TextBox ID="txtFechaInicio" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaInicio_TextChanged"></asp:TextBox>
                    <br />
                </div>
                <div class="col-md-3">
                    <label for="txtFechaTermino">Fecha filtro fin</label>
                    <asp:TextBox ID="txtFechaTermino" AutoPostBack="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
                    <br />
                </div>
            </div>
        </div>

        <div class="visible-print">
            <div class="col-md-12">
                <div class="visible-print">
                    <h2>Ranking de Trabajadores Manzanos</h2>
                    <br />
                    <h5>Desde:
                        <asp:Label ID="lbldesde" runat="server" Text=""></asp:Label></h5>
                    <h5>Hasta:
                        <asp:Label ID="lblhasta" runat="server" Text=""></asp:Label></h5>
                    <h6>Filtro:
                        <asp:Label ID="lblfiltr" runat="server" Text=""></asp:Label></h6>
                    <br />
                </div>
            </div>
        </div>

        <div class="hidden-print">
            <div class="col-md-12">
                <!-- grilla -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Ranking</h3>
                    </div>
                    <div class="panel-body" style="max-height: 420px; overflow-y: scroll;">
                        <div class="table-responsive">
                            <asp:GridView ID="grillaRanking" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsRanking" DataKeyNames="Rut">
                                <Columns>
                                    <asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="True" SortExpression="Rut" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombres" SortExpression="Nombre" HtmlEncode="False" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellidos" SortExpression="Apellido" HtmlEncode="False" />
                                    <asp:BoundField DataField="Cuadrilla" HeaderText="Cuadrilla" SortExpression="Cuadrilla" HtmlEncode="False" />
                                    <asp:BoundField DataField="Bins" HeaderText="Bins" ReadOnly="True" DataFormatString="{0:n1}" SortExpression="Bins">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Kilos" HeaderText="Kilos" ReadOnly="True" DataFormatString="{0:n2}" SortExpression="Kilos">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DiasTrabajados" HeaderText="Dias Trabajados" DataFormatString="{0:n0}" ReadOnly="True" SortExpression="DiasTrabajados">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="dsRanking" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo11 %>" SelectCommand="SP_VistaRankingManzanos" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtFiltro" Name="FILTRO" PropertyName="Text" Type="String" ConvertEmptyStringToNull="False" />
                                    <asp:ControlParameter ControlID="txtFechaInicio" Name="FEC_D" PropertyName="Text" Type="DateTime" />
                                    <asp:ControlParameter ControlID="txtFechaTermino" Name="FEC_H" PropertyName="Text" Type="DateTime" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="visible-print">
            <div class="table-responsive">
                <!-- grilla de impresion -->
                <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsRanking" DataKeyNames="Rut">
                    <Columns>
                        <asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="True" SortExpression="Rut" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombres" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellidos" SortExpression="Apellido" />
                        <asp:BoundField DataField="Cuadrilla" HeaderText="Cuadrilla" SortExpression="Cuadrilla" HtmlEncode="False" />
                        <asp:BoundField DataField="Bins" HeaderText="Bins" ReadOnly="True" DataFormatString="{0:n1}" SortExpression="Bins">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Kilos" HeaderText="Kilos Aprox." ReadOnly="True" DataFormatString="{0:n2}" SortExpression="Kilos">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasTrabajados" HeaderText="Dias Trabajados" DataFormatString="{0:n0}" ReadOnly="True" SortExpression="DiasTrabajados">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="hidden-print">
            <input type="button" style="float: right" class="btn btn-default" name="Imprimir" value="Imprimir" onclick="window.print()">
            <asp:Button ID="Button1" Style="margin-right:5px; float: right" class="btn btn-default" runat="server" Text="Exportar a Excel" OnClick="ExportToExcel" />
        </div>
    </form>

</asp:Content>

