<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Maquina1.aspx.cs" Inherits="DemoArandanos.Maquina1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Cosecha Arándanos Contratistas</h1>
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
                        <span style="font-size: 20px; background-color: #F3F5F6; padding: 0 10px;">Administración Cosecha Contratistas</span>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="col-md-5">
                        <br />
                        <label for="txtDescripcion">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" type="input" required="required" class="form-control" placeholder="Cosecha externa, máquina, contratistas..."></asp:TextBox>
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
                        <asp:SqlDataSource ID="dsFundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Fundo, Nombre FROM VistaAll WHERE ID_Producto = '32' AND (ID_Variedad LIKE @ID_Variedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="ddPotrero">Potrero</label>
                        <asp:DropDownList ID="ddPotrero" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombrePotrero" DataValueField="ID_Potrero" DataSourceID="potrerosDEfundoVista" OnDataBound="ddPotrero_DataBound"></asp:DropDownList>
                        <asp:SqlDataSource ID="potrerosDEfundoVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Potrero, nombrePotrero FROM VistaAll WHERE ID_Producto = '32' AND (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" DefaultValue="" ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="ddSector">Sector</label>
                        <asp:DropDownList ID="ddSector" CssClass="form-control" AutoPostBack="True" runat="server" DataTextField="nombreSector" DataValueField="ID_Sector" DataSourceID="sectoresDEpotreroVista" OnDataBound="ddSector_DataBound"></asp:DropDownList>
                        <asp:SqlDataSource ID="sectoresDEpotreroVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT ID_Sector, nombreSector FROM VistaAll WHERE ID_Producto = '32' AND (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
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
                        <asp:SqlDataSource ID="cuartelesDEsectorVista" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo7 %>" SelectCommand="SELECT DISTINCT nombreCuartel, ID_Cuartel FROM VistaAll WHERE ID_Producto = '32' AND (ID_Fundo LIKE @ID_Fundo + '%') AND (ID_Potrero LIKE @ID_Potrero + '%') AND (ID_Sector LIKE @ID_Sector + '%') AND (ID_Variedad LIKE @ID_Variedad + '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddVariedad" ConvertEmptyStringToNull="False" Name="ID_Variedad" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>

                    <div class="col-md-2">
                        <label for="txtKilos">Kilos</label>
                        <asp:TextBox ID="txtKilos" runat="server" type="input" onkeypress="return onKeyDecimal(event,this);" required="required" class="form-control" placeholder=""></asp:TextBox>
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
                    </div>

                    <div class="col-md-2">
                        <br />
                        <label for="txtBandejas">Bandejas</label>
                        <asp:TextBox ID="txtBandejas" runat="server" type="number" required="required" class="form-control" placeholder=""></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <br />
                        <label for="txtGuia">Guía</label>
                        <asp:TextBox ID="txtGuia" runat="server" type="input" required="required" class="form-control" placeholder=""></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <br />
                        <label for="txtRecepcion">Recepción</label>
                        <asp:TextBox ID="txtRecepcion" runat="server" type="input" required="required" class="form-control" placeholder=""></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <br />
                        <label for="txtFechaCosecha">Fecha</label>
                        <asp:TextBox ID="txtFechaCosecha" AutoPostBack="true" CssClass="form-control" TextMode="Date" required="required" runat="server" placeholder="aaaa-MM-dd"></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        <br />
                        <!-- GRUPO DE BOTONES -->
                        <label>Seleccione una opción</label>
                        <div class="btn-group" role="group" aria-label="...">
                            <asp:Button ID="btGuardarCosechaMaquina" runat="server" Text="Registrar" type="submit" class="btn btn-default" OnClick="btGuardarCosechaMaquina_Click" />
                            <asp:Button ID="btActualizarCosechaMaquina" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClientClick="return confirm('¿Está seguro de que desea actualizar los datos de cosecha de máquina?');" OnClick="btActualizarCosechaMaquina_Click" />
                            <asp:Button ID="btEliminarCosechaMaquina" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClientClick="return confirm('¿Está seguro de que desea eliminar la cosecha de máquina?');" OnClick="btEliminarCosechaMaquina_Click" />
                        </div>
                        <asp:Button ID="btLimpiar" runat="server" formnovalidate Text="Limpiar" type="submit" class="btn btn-default" OnClick="btLimpiar_Click" />
                    </div>

                </div>

                <!-- DIVIDER -->
                <div class="col-md-12">
                    <br />
                    <br />
                    <div style="width: 100%; height: 20px; border-bottom: 1px solid black; text-align: center">
                        <span style="font-size: 20px; background-color: #F3F5F6; padding: 0 10px;">Seleccionar Cosecha Contratistas</span>
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

                <div class="col-md-4">
                    <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-md-12">
                    <br />
                    <!-- grilla -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Cosechas Contratistas</h3>
                        </div>
                        <div class="panel-body" style="max-height: 500px; overflow-y: scroll; font-size: 100%">
                            <div class="table-responsive">
                                <asp:GridView ID="grillaMaquina" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsCosechaMaquina" OnSelectedIndexChanged="grillaMaquina_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                        <asp:BoundField DataField="Variedad" HeaderText="Variedad" SortExpression="Variedad" />
                                        <asp:BoundField DataField="Fundo" HeaderText="Fundo" SortExpression="Fundo" />
                                        <asp:BoundField DataField="Potrero" HeaderText="Potrero" SortExpression="Potrero" />
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" />
                                        <asp:BoundField DataField="Cuartel" HeaderText="Cuartel" SortExpression="Cuartel" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="PesoNeto" HeaderText="Kilos" SortExpression="PesoNeto" DataFormatString="{0:n}" />
                                        <asp:BoundField DataField="Bandejas" HeaderText="Bandejas" SortExpression="Bandejas" DataFormatString="{0:n0}" />
                                        <asp:BoundField DataField="Guia" HeaderText="Guía" SortExpression="Guia" />
                                        <asp:BoundField DataField="Recepcion" HeaderText="Recepción" SortExpression="Recepcion" />
                                        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                                    </Columns>
                                </asp:GridView>

                                <asp:SqlDataSource ID="dsCosechaMaquina" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo %>" SelectCommand="SELECT * FROM [CosechaMaquina] WHERE Producto = '32' AND [Fecha] BETWEEN (@Fecha + '') AND (@Fecha2 + '') ORDER BY [Fecha]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtFechaInicio" Name="Fecha" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" DefaultValue="1999-01-01" />
                                        <asp:ControlParameter ControlID="txtFechaTermino" Name="Fecha2" PropertyName="Text" Type="DateTime" ConvertEmptyStringToNull="True" DefaultValue="2099-01-01" />
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

