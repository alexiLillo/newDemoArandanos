<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="InformePlantas.aspx.cs" Inherits="DemoArandanos.InformePlantas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Informe Plantas</h1>
    <br />
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class=" col-md-6">
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

        <div class="col-md-6"></div>

        <!-- DropDowns -->
        
        <div class="col-md-4">
            <div class="visible-print">
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" runat="server">
                    <ContentTemplate>
                        <label>
                            Temporada:
                    <asp:Label ID="lbltemporada" runat="server" Text=""></asp:Label></label>
                        <br />
                        <label>
                            Fundo:
                    <asp:Label ID="lblfundo" runat="server" Text=""></asp:Label></label>
                        <br />
                        <label>
                            Potrero:
                    <asp:Label ID="lblpotrero" runat="server" Text=""></asp:Label></label>
                        <br />
                        <label>
                            Sector:
                    <asp:Label ID="lblsector" runat="server" Text=""></asp:Label></label>
                        <br />
                        <label>
                            Cuartel:
                    <asp:Label ID="lblcuartel" runat="server" Text=""></asp:Label></label>
                        <br />
                        <label>
                            Hilera:
                    <asp:Label ID="lblhilera" runat="server" Text=""></asp:Label></label>
                        <br />
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="hidden-print">
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                    <ContentTemplate>
                        <label for="ddMapeo">Temporada</label>
                        <asp:DropDownList ID="ddMapeo" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsMapeo" DataTextField="temp" DataValueField="ID_Mapeo" DataTextFormatString="{0:d}">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsMapeo" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo3 %>" SelectCommand="SELECT ID_Mapeo, SUBSTRING(cast(Fecha_Inicio as varchar) + ' / ' + cast(Fecha_Termino as varchar),1,4) as temp FROM [Map]"></asp:SqlDataSource>
                        <br />
                        <label for="ddVariedad">Variedad</label>
                        <asp:DropDownList ID="ddVariedad" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsVariedad" DataTextField="Nombre" DataValueField="Nombre" OnDataBound="ddVariedad_DataBound" OnSelectedIndexChanged="ddVariedad_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsVariedad" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo6 %>" SelectCommand="SELECT * FROM [Variedad] WHERE ([ID_Producto] = @ID_Producto)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="32" Name="ID_Producto" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                        <label for="ddFundo">Fundo</label>
                        <asp:DropDownList ID="ddFundo" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="Nombre" DataValueField="ID_Fundo" DataSourceID="dsFundoVista" OnSelectedIndexChanged="ddFundo_SelectedIndexChanged" OnDataBound="ddFundo_DataBound"></asp:DropDownList>
                        <asp:SqlDataSource ID="dsFundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll WHERE (nombreVariedad LIKE @nombreVariedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddVariedad" Name="nombreVariedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsFundo" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo3 %>" SelectCommand="SELECT * FROM [Fundo]"></asp:SqlDataSource>
                        <br />
                        <label for="ddPotrero">Potrero</label>
                        <asp:DropDownList ID="ddPotrero" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVista" OnDataBound="ddPotrero_DataBound" OnSelectedIndexChanged="ddPotrero_SelectedIndexChanged"></asp:DropDownList>
                        <asp:SqlDataSource ID="potrerosDEfundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Potrero, nombrePotrero FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (nombreVariedad LIKE @nombreVariedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" Name="nombreVariedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>                        
                        <asp:SqlDataSource ID="potrerosDEfundo" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo3 %>" SelectCommand="SELECT * FROM [Potrero] WHERE ([ID_Fundo] = @ID_Fundo)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                        <label for="ddSector">Sector</label>
                        <asp:DropDownList ID="ddSector" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVista" OnDataBound="ddSector_DataBound" OnSelectedIndexChanged="ddSector_SelectedIndexChanged"></asp:DropDownList>
                        <asp:SqlDataSource ID="sectoresDEpotreroVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (nombreVariedad LIKE @nombreVariedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" Name="nombreVariedad" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sectoresDEpotrero" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo3 %>" SelectCommand="SELECT * FROM [Sector] WHERE (([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                        <label for="ddCuartel">Cuartel</label>
                        <div class="input-group">
                            <asp:DropDownList ID="ddCuartel" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreCuartel" DataValueField="ID_Cuartel" DataSourceID="cuartelesDEsectorVista" OnDataBound="ddCuartel_DataBound" OnSelectedIndexChanged="ddCuartel_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource ID="cuartelesDEsectorVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT nombreCuartel, ID_Cuartel FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%') AND (nombreVariedad LIKE @nombreVariedad + '%')">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddVariedad" ConvertEmptyStringToNull="False" Name="nombreVariedad" PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <span class="input-group-btn">
                                <asp:Button ID="btVerHileras" type="button" AutoPostBack="False" class="btn btn-default" runat="server" Text="Ver" OnClick="btVerHileras_Click" />
                            </span>
                        </div>
                        <asp:SqlDataSource ID="cuartelesDEsector" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo3 %>" SelectCommand="SELECT * FROM [Cuartel] WHERE (([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                        <label for="ddHilera">Hilera</label>
                        <asp:DropDownList ID="ddHilera" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="ID_Hilera" DataValueField="ID_Hilera" DataSourceID="hilerasDEcuartelVista" OnDataBound="ddHilera_DataBound" OnSelectedIndexChanged="ddHilera_SelectedIndexChanged"></asp:DropDownList>
                        <asp:SqlDataSource ID="hilerasDEcuartelVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Hilera FROM VistaAll WHERE (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%') AND (ID_Cuartel LIKE @ID_Cuartel + '%') AND (nombreVariedad LIKE @nombreVariedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddCuartel" Name="ID_Cuartel" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" ConvertEmptyStringToNull="False" Name="nombreVariedad" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="hilerasDEcuartel" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo3 %>" SelectCommand="SELECT * FROM [Hilera] WHERE (([ID_Cuartel] = @ID_Cuartel) AND ([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddCuartel" Name="ID_Cuartel" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="ddMapeo" Name="ID_Mapeo" PropertyName="SelectedValue" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                        <div class="hidden-print">
                            <p align="right">
                                <input type="button" class="btn btn-default" name="VerMapa" value="Ver Mapa" onclick="window.open('mapa.aspx', null, 'height=740,width=1100', 'resizable=yes');">
                                <input type="button" class="btn btn-default" name="Imprimir" value="Imprimir" onclick="window.print();">
                            </p>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="col-md-8">
            <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server" RenderMode="Block">
                <ContentTemplate>
                    <h3>Cantidad de plantas
                        <asp:Label ID="lblgrafico" runat="server" Text=""></asp:Label></h3>
                    <br />
                    <label>
                        Total de Plantas:
                        <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label></label>
                    <br />
                    <label>
                        <asp:Label ID="lblvariedad" runat="server" Text=""></asp:Label></label>
                    <asp:Chart ID="Grafico1" runat="server" Width="750" Height="380" />
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</asp:Content>
