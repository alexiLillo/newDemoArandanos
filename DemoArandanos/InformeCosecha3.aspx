<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInformes.Master" AutoEventWireup="true" CodeBehind="InformeCosecha3.aspx.cs" Inherits="DemoArandanos.InformeCosecha3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="hidden-print">
        <h1>Informe Cosecha</h1>
        <br />
    </div>
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
        <div class="hidden-print">
            <div class="col-md-12">
                <div class="col-md-2">
                    <label for="ddFundo">Fundo</label>
                    <asp:DropDownList ID="ddFundo" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="Nombre" DataValueField="ID_Fundo" DataSourceID="dsFundoVista" OnDataBound="ddFundo_DataBound" OnSelectedIndexChanged="ddFundo_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsFundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll "></asp:SqlDataSource>
                    <br />
                    <br />
                </div>

                <div class="col-md-2">
                    <label for="ddPotrero">Potrero</label>
                    <asp:DropDownList ID="ddPotrero" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVista" OnDataBound="ddPotrero_DataBound" OnSelectedIndexChanged="ddPotrero_SelectedIndexChanged"></asp:DropDownList>
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
                    <asp:DropDownList ID="ddSector" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVista" OnDataBound="ddSector_DataBound" OnSelectedIndexChanged="ddSector_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="sectoresDEpotreroVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
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
                    <label for="txtFechaTermino">Fecha filtro fin (hoy)</label>
                    <asp:TextBox ID="txtFechaTermino" AutoPostBack="true" disabled="true" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-MM-dd" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
                    <br />
                    <br />
                </div>
            </div>
        </div>

        <div class="visible-print">
            <div class="col-md-12">
                <div class="visible-print">
                    <h2>Informe de Cosecha Arándanos</h2>
                    <br />
                    <h6>Fundo: <asp:Label ID="lblfund" runat="server" Text=""></asp:Label></h6>
                    <h5>Desde: <asp:Label ID="lbldesde" runat="server" Text=""></asp:Label></h5>
                    <h5>Hasta: <asp:Label ID="lblhasta" runat="server" Text=""></asp:Label></h5>                    
                    <br />
                </div>
            </div>
        </div>

        <div class="hidden-print">
            <div class="col-md-12">
                <!-- grilla -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Cosecha</h3>
                    </div>
                    <div class="panel-body" style="max-height: 420px; overflow-y: scroll;">
                        <div class="table-responsive">
                            <asp:GridView ID="grillaCosecha" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsCosecha">
                                <Columns>
                                    <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Dias" HeaderText="Cosechado" ReadOnly="True" SortExpression="Dias" DataFormatString="Hace {0:d} dias">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BandejasDia" HeaderText="Bandejas Hoy" ReadOnly="True" SortExpression="BandejasDia" DataFormatString="{0:n0}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="KilosDia" HeaderText="Kilos Hoy" ReadOnly="True" SortExpression="KilosDia" DataFormatString="{0:n2}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BandejasTotal" HeaderText="Bandejas Total" ReadOnly="True" SortExpression="BandejasTotal" DataFormatString="{0:n0}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="KilosTotal" HeaderText="Kilos Total" ReadOnly="True" SortExpression="KilosTotal" DataFormatString="{0:n2}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>

                            <asp:SqlDataSource ID="dsCosecha" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo11 %>" SelectCommand="SP_VistaCosecha" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtFechaInicio" Name="FEC_D" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" />
                                    <asp:ControlParameter ControlID="txtFechaTermino" Name="FEC_H" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" />
                                    <asp:ControlParameter ControlID="ddFundo" Name="FUNDO" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    <asp:ControlParameter ControlID="ddPotrero" Name="POTRERO" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    <asp:ControlParameter ControlID="ddSector" Name="SECTOR" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="visible-print">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsCosecha">
                    <Columns>
                        <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Dias" HeaderText="Cosechado" ReadOnly="True" SortExpression="Dias" DataFormatString="Hace {0:d} dias">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BandejasDia" HeaderText="Bandejas Hoy" ReadOnly="True" SortExpression="BandejasDia" DataFormatString="{0:n0}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KilosDia" HeaderText="Kilos Hoy" ReadOnly="True" SortExpression="KilosDia" DataFormatString="{0:n2}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BandejasTotal" HeaderText="Bandejas Total" ReadOnly="True" SortExpression="BandejasTotal" DataFormatString="{0:n0}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KilosTotal" HeaderText="Kilos Total" ReadOnly="True" SortExpression="KilosTotal" DataFormatString="{0:n2}">
                            <HeaderStyle HorizontalAlign="Center" />
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
