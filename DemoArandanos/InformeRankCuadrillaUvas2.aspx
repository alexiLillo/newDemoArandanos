<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUva2.Master" AutoEventWireup="true" CodeBehind="InformeRankCuadrillaUvas2.aspx.cs" Inherits="DemoArandanos.InformeRankCuadrillaUvas2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hidden-print">
        <h1>Ranking de Cuadrillas Viñedos</h1>
        <br />
    </div>
    <form runat="server">
        <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
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
                <asp:updatepanel id="UpdatePanel9" updatemode="Always" runat="server">
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
                </asp:updatepanel>
            </div>
        </div>

        <div class="hidden-print">
            <div class="col-md-12">
                <div class="col-md-6">
                    <label for="txtFiltro">Filtrar por Cuadrilla</label>
                    <div class="input-group">
                        <asp:textbox id="txtFiltro" autopostback="true" runat="server" type="input" class="form-control" placeholder="Ingrese rut o nombre para filtrar la tabla" ontextchanged="txtFiltro_TextChanged"></asp:textbox>
                        <span class="input-group-btn">
                            <asp:button id="btFiltrar" type="button" autopostback="False" class="btn btn-default" runat="server" text="Filtrar" onclick="btFiltrar_Click" />
                        </span>
                    </div>
                    <br />
                </div>
                <div class="col-md-3">
                    <label for="txtFechaInicio">Fecha filtro inicio</label>
                    <asp:textbox id="txtFechaInicio" autopostback="true" cssclass="form-control" textmode="Date" runat="server" placeholder="aaaa-MM-dd" ontextchanged="txtFechaInicio_TextChanged"></asp:textbox>
                    <br />
                </div>
                <div class="col-md-3">
                    <label for="txtFechaTermino">Fecha filtro fin</label>
                    <asp:textbox id="txtFechaTermino" autopostback="true" cssclass="form-control" textmode="Date" runat="server" placeholder="aaaa-MM-dd" ontextchanged="txtFechaTermino_TextChanged"></asp:textbox>
                    <br />
                </div>
            </div>
        </div>

        <div class="visible-print">
            <div class="col-md-12">
                <div class="visible-print">
                    <h2>Ranking de Cuadrillas Viñedos</h2>
                    <br />
                    <h5>Desde:
                        <asp:label id="lbldesde" runat="server" text=""></asp:label>
                    </h5>
                    <h5>Hasta:
                        <asp:label id="lblhasta" runat="server" text=""></asp:label>
                    </h5>
                    <h6>Filtro:
                        <asp:label id="lblfiltr" runat="server" text=""></asp:label>
                    </h6>
                    <br />
                </div>
            </div>
        </div>

        <div class="hidden-print">
            <div class="col-md-12">
                <!-- grilla -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Ranking Cuadrillas</h3>
                    </div>
                    <div class="panel-body" style="max-height: 420px; overflow-y: scroll;">
                        <div class="table-responsive">
                            <asp:gridview id="grillaRanking" class="table table-bordered" runat="server" autogeneratecolumns="False" datasourceid="dsRanking" datakeynames="Cuadrilla">
                                <Columns>
                                    <%--<asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="True" SortExpression="Rut" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombres" SortExpression="Nombre" HtmlEncode="False" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellidos" SortExpression="Apellido" HtmlEncode="False" />--%>
                                    <asp:BoundField DataField="Cuadrilla" HeaderText="Cuadrilla" SortExpression="Cuadrilla" HtmlEncode="False" />
                                    <asp:BoundField DataField="Bins" HeaderText="Bins" ReadOnly="True" DataFormatString="{0:n0}" SortExpression="Bins">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Kilos" HeaderText="Kilos" ReadOnly="True" DataFormatString="{0:n2}" SortExpression="Kilos">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DiasTrabajados" HeaderText="Dias Trabajados" DataFormatString="{0:n0}" ReadOnly="True" SortExpression="DiasTrabajados">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Trabajadores" HeaderText="Cantidad Trabajadores" ReadOnly="True" DataFormatString="{0:n0}" SortExpression="Trabajadores">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:gridview>
                            <asp:sqldatasource id="dsRanking" runat="server" connectionstring="<%$ ConnectionStrings:Modelo11 %>" selectcommand="SP_RankingCuadrillasUvas" selectcommandtype="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtFiltro" Name="FILTRO" PropertyName="Text" Type="String" ConvertEmptyStringToNull="False" />
                                    <asp:ControlParameter ControlID="txtFechaInicio" Name="FEC_D" PropertyName="Text" Type="DateTime" />
                                    <asp:ControlParameter ControlID="txtFechaTermino" Name="FEC_H" PropertyName="Text" Type="DateTime" />
                                </SelectParameters>
                            </asp:sqldatasource>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="visible-print">
            <div class="table-responsive">
                <!-- grilla de impresion -->
                <asp:gridview id="GridView1" class="table table-bordered" runat="server" autogeneratecolumns="False" datasourceid="dsRanking" datakeynames="Cuadrilla">
                    <Columns>
                        <%--<asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="True" SortExpression="Rut" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombres" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellidos" SortExpression="Apellido" />--%>
                        <asp:BoundField DataField="Cuadrilla" HeaderText="Cuadrilla" SortExpression="Cuadrilla" HtmlEncode="False" />
                        <asp:BoundField DataField="Bins" HeaderText="Bins" ReadOnly="True" DataFormatString="{0:n0}" SortExpression="Bins">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Kilos" HeaderText="Kilos Aprox." ReadOnly="True" DataFormatString="{0:n2}" SortExpression="Kilos">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasTrabajados" HeaderText="Dias Trabajados" DataFormatString="{0:n0}" ReadOnly="True" SortExpression="DiasTrabajados">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:gridview>
            </div>
        </div>

        <div class="hidden-print">
            <input type="button" style="float: right" class="btn btn-default" name="Imprimir" value="Imprimir" onclick="window.print()">
            <asp:button id="Button1" style="margin-right: 5px; float: right" class="btn btn-default" runat="server" text="Exportar a Excel" onclick="ExportToExcel" />
        </div>
    </form>

</asp:Content>
