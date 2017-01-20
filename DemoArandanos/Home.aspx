<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DemoArandanos.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Mantenedores</h1>

    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="tabs" role="tabpanel">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active">
                    <a href="#fundo" aria-controls="fundo" role="tab" data-toggle="tab">Fundo</a>
                </li>
                <li role="presentation">
                    <a href="#potrero" aria-controls="potrero" role="tab" data-toggle="tab">Potrero</a>
                </li>
                <li role="presentation">
                    <a href="#sector" aria-controls="sector" role="tab" data-toggle="tab">Sector</a>
                </li>
                <li role="presentation">
                    <a href="#cuartel" aria-controls="cuartel" role="tab" data-toggle="tab">Cuartel</a>
                </li>
                <li role="presentation">
                    <a href="#hilera" aria-controls="hilera" role="tab" data-toggle="tab">Hilera</a>
                </li>
                <li role="presentation">
                    <a href="#planta" aria-controls="planta" role="tab" data-toggle="tab">Planta</a>
                </li>
                <li role="presentation">
                    <a href="#estado" aria-controls="estado" role="tab" data-toggle="tab">Estado</a>
                </li>
                <li role="presentation">
                    <a href="#variedad" aria-controls="variedad" role="tab" data-toggle="tab">Variedad</a>
                </li>
                <li role="presentation">
                    <a href="#mapeo" aria-controls="mapeo" role="tab" data-toggle="tab">Mapeo</a>
                </li>
            </ul>

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
                        <asp:Label ID="lbldanger" runat="server" Text=""></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- Tab panes -->
            <div class="tab-content">
                <!-- Mantenedor Fundo -->
                <div role="tabpanel" class="tab-pane active" id="fundo">
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIdFundo">Código de Fundo</label>
                                <asp:TextBox ID="txtIdFundo" runat="server" type="input" class="form-control" placeholder="Ingrese código de fundo"></asp:TextBox>
                                <br />
                                <label for="txtNombreFundo">Nombre de Fundo</label>
                                <asp:TextBox ID="txtNombreFundo" runat="server" type="input" class="form-control" placeholder="Ingrese nombre de fundo"></asp:TextBox>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btnIngresarFundo" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btnIngresarFundo_Click" />
                                    <asp:Button ID="btnActualizarFundo" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btnActualizarFundo_Click" />
                                    <asp:Button ID="btnEliminarFundo" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btnEliminarFundo_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar el Fundo?');"/>
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Fundos</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaFundos" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaFundos_SelectedIndexChanged" DataKeyNames="ID_Fundo" DataSourceID="dsFundos">

                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Fundo" HeaderText="Código Fundo" ReadOnly="True" SortExpression="ID_Fundo" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HtmlEncode="False" />
                                                </Columns>

                                            </asp:GridView>
                                            <asp:SqlDataSource ID="dsFundos" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Fundo]"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Potrero -->
                <div role="tabpanel" class="tab-pane" id="potrero">
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIdPotrero">Código de Potrero</label>
                                <asp:TextBox ID="txtIdPotrero" runat="server" type="input" class="form-control" placeholder="Ingrese código de potrero"></asp:TextBox>
                                <br />
                                <label for="txtNombrePotrero">Nombre de Potrero</label>
                                <asp:TextBox ID="txtNombrePotrero" runat="server" type="input" class="form-control" placeholder="Ingrese nombre de potrero"></asp:TextBox>
                                <br />
                                <label for="ddFundo">Fundo</label>
                                <asp:DropDownList ID="ddFundo" CssClass="form-control" AutoPostBack="true" runat="server" DataSourceID="dsFundos" DataTextField="Nombre" DataValueField="ID_Fundo"></asp:DropDownList>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btInsertarPotrero" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btInsertarPotrero_Click" />
                                    <asp:Button ID="btActualizarPotrero" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarPotrero_Click" />
                                    <asp:Button ID="btEliminarPotrero" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarPotrero_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar el Potrero?');" />
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Potreros</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaPotreros" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaPotreros_SelectedIndexChanged" DataKeyNames="ID_Potrero,ID_Fundo" DataSourceID="potrerosDEfundo">

                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Potrero" HeaderText="Código Potrero" ReadOnly="True" SortExpression="ID_Potrero" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Fundo" HeaderText="Fundo" ReadOnly="True" SortExpression="ID_Fundo" HtmlEncode="False" />
                                                </Columns>

                                            </asp:GridView>
                                            <asp:SqlDataSource ID="potrerosDEfundo" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Potrero] WHERE ([ID_Fundo] = @ID_Fundo)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddFundo" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Sector -->
                <div role="tabpanel" class="tab-pane" id="sector">
                    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIdSector">Código de Sector</label>
                                <asp:TextBox ID="txtIdSector" runat="server" type="input" class="form-control" placeholder="Ingrese código de sector"></asp:TextBox>
                                <br />
                                <label for="txtNombreSector">Nombre de Sector</label>
                                <asp:TextBox ID="txtNombreSector" runat="server" type="input" class="form-control" placeholder="Ingrese nombre de sector"></asp:TextBox>
                                <br />
                                <label for="ddFundo2">Fundo</label>
                                <asp:DropDownList ID="ddFundo2" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="dsFundos" DataTextField="Nombre" DataValueField="ID_Fundo"></asp:DropDownList>
                                <br />
                                <label for="ddPotrero">Potrero</label>
                                <asp:DropDownList ID="ddPotrero" AutoPostBack="True" CssClass="form-control" runat="server" DataTextField="Nombre" DataSourceID="potrerosDEfundo2" DataValueField="ID_Potrero"></asp:DropDownList>
                                <asp:SqlDataSource ID="potrerosDEfundo2" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Potrero] WHERE ([ID_Fundo] = @ID_Fundo)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddFundo2" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btInsertarSector" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btInsertarSector_Click" />
                                    <asp:Button ID="btActualizarSector" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarSector_Click" />
                                    <asp:Button ID="btEliminarSector" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarSector_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar el Sector?');" />
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Sectores</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaSector" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaSector_SelectedIndexChanged" DataKeyNames="ID_Sector,ID_Potrero,ID_Fundo" DataSourceID="sectoresDEpotrero">
                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Sector" HeaderText="Código Sector" ReadOnly="True" SortExpression="ID_Sector" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Potrero" HeaderText="Potrero" ReadOnly="True" SortExpression="ID_Potrero" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Fundo" HeaderText="Fundo" ReadOnly="True" SortExpression="ID_Fundo" HtmlEncode="False" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="sectoresDEpotrero" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Sector] WHERE (([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddPotrero" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddFundo2" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Cuartel -->
                <div role="tabpanel" class="tab-pane" id="cuartel">
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIdCuartel">Código de Cuartel</label>
                                <asp:TextBox ID="txtIdCuartel" runat="server" type="input" class="form-control" placeholder="Ingrese código de cuartel"></asp:TextBox>
                                <br />
                                <label for="txtNombreCuartel">Nombre Cuartel</label>
                                <asp:TextBox ID="txtNombreCuartel" runat="server" type="input" class="form-control" placeholder="Ingrese nombre del cuartel"></asp:TextBox>
                                <br />
                                <label for="txtSuperficie">Superficie Cuartel (m²)</label>
                                <asp:TextBox ID="txtSuperficie" runat="server" type="number" class="form-control" placeholder="Ingrese superficie del cuartel"></asp:TextBox>
                                <br />
                                <label for="ddFundo3">Fundo</label>
                                <asp:DropDownList ID="ddFundo3" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="dsFundos" DataTextField="Nombre" DataValueField="ID_Fundo"></asp:DropDownList>
                                <br />
                                <label for="ddPotrero2">Potrero</label>
                                <asp:DropDownList ID="ddPotrero2" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="potrerosDEfundo3" DataTextField="Nombre" DataValueField="ID_Potrero"></asp:DropDownList>
                                <asp:SqlDataSource ID="potrerosDEfundo3" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Potrero] WHERE ([ID_Fundo] = @ID_Fundo)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddFundo3" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <label for="ddSector">Sector</label>
                                <asp:DropDownList ID="ddSector" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="sectoresDEpotrero2" DataTextField="Nombre" DataValueField="ID_Sector"></asp:DropDownList>
                                <asp:SqlDataSource ID="sectoresDEpotrero2" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Sector] WHERE (([ID_Fundo] = @ID_Fundo) AND ([ID_Potrero] = @ID_Potrero))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddFundo3" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddPotrero2" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btInsertarCuartel" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btInsertarCuartel_Click" />
                                    <asp:Button ID="btActualizarCuartel" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarCuartel_Click" />
                                    <asp:Button ID="btEliminarCuartel" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarCuartel_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar el Cuartel?');" />
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Cuarteles</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaCuarteles" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaCuarteles_SelectedIndexChanged" DataKeyNames="ID_Cuartel,ID_Sector,ID_Potrero,ID_Fundo" DataSourceID="cuartelesDEsector">
                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Cuartel" HeaderText="Código Cuartel" ReadOnly="True" SortExpression="ID_Cuartel" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Superficie" HeaderText="Superficie" SortExpression="Superficie" />
                                                    <asp:BoundField DataField="ID_Sector" HeaderText="Sector" ReadOnly="True" SortExpression="ID_Sector" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Potrero" HeaderText="Potrero" ReadOnly="True" SortExpression="ID_Potrero" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Fundo" HeaderText="Fundo" ReadOnly="True" SortExpression="ID_Fundo" HtmlEncode="False" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="cuartelesDEsector" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Cuartel] WHERE (([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddSector" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddPotrero2" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddFundo3" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Hilera -->
                <div role="tabpanel" class="tab-pane" id="hilera">
                    <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIdHilera">Código de Hilera</label>
                                <asp:TextBox ID="txtIdHilera" runat="server" type="input" class="form-control" placeholder="Ingrese código de hilera con este formato: H****"></asp:TextBox>
                                <br />
                                <label for="ddVariedad">Variedad</label>
                                <asp:DropDownList ID="ddVariedad" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="dsVariedades" DataTextField="Nombre" DataValueField="Nombre"></asp:DropDownList>
                                <asp:SqlDataSource ID="dsVariedades" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Variedad]"></asp:SqlDataSource>
                                <br />
                                <label for="ddFundo4">Fundo</label>
                                <asp:DropDownList ID="ddFundo4" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="dsFundos" DataValueField="ID_Fundo" DataTextField="Nombre"></asp:DropDownList>
                                <br />
                                <label for="ddPotrero3">Potrero</label>
                                <asp:DropDownList ID="ddPotrero3" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="potreroDEfundo4" DataValueField="ID_Potrero" DataTextField="Nombre"></asp:DropDownList>
                                <asp:SqlDataSource ID="potreroDEfundo4" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Potrero] WHERE ([ID_Fundo] = @ID_Fundo)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddFundo4" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <label for="ddSector2">Sector</label>
                                <asp:DropDownList ID="ddSector2" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="sectoresDEpotrero3" DataTextField="Nombre" DataValueField="ID_Sector"></asp:DropDownList>
                                <asp:SqlDataSource ID="sectoresDEpotrero3" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Sector] WHERE (([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddPotrero3" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddFundo4" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <label for="ddCuartel">Cuartel</label>
                                <asp:DropDownList ID="ddCuartel" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="cuartelesDEsector2" DataTextField="Nombre" DataValueField="ID_Cuartel"></asp:DropDownList>
                                <asp:SqlDataSource ID="cuartelesDEsector2" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Cuartel] WHERE (([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddSector2" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddPotrero3" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddFundo4" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btInsertarHilera" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btInsertarHilera_Click" />
                                    <asp:Button ID="btActualizarHilera" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarHilera_Click" />
                                    <asp:Button ID="btEliminarHilera" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarHilera_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar la Hilera?');" />
                                </div>
                                <br />
                                <br />
                            </div>
                            
                            <div class="col-md-7">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Hileras</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaHilera" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaHilera_SelectedIndexChanged" DataSourceID="hilerasDEcuartel" DataKeyNames="ID_Hilera,ID_Cuartel,ID_Sector,ID_Potrero,ID_Fundo">
                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Hilera" HeaderText="Código Hilera" ReadOnly="True" SortExpression="ID_Hilera" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Variedad" HeaderText="Variedad" SortExpression="Variedad" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Cuartel" HeaderText="Cuartel" ReadOnly="True" SortExpression="ID_Cuartel" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Sector" HeaderText="Sector" ReadOnly="True" SortExpression="ID_Sector" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Potrero" HeaderText="Potrero" ReadOnly="True" SortExpression="ID_Potrero" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Fundo" HeaderText="Fundo" ReadOnly="True" SortExpression="ID_Fundo" HtmlEncode="False" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="hilerasDEcuartel" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Hilera] WHERE (([ID_Cuartel] = @ID_Cuartel) AND ([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddCuartel" Name="ID_Cuartel" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddSector2" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddPotrero3" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddFundo4" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Planta -->
                <div role="tabpanel" class="tab-pane" id="planta">
                    <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIdPlanta">Código de Planta</label>
                                <asp:TextBox ID="txtIdPlanta" runat="server" type="input" class="form-control" placeholder="Ingrese código de plantacon este formato: PL****"></asp:TextBox>
                                <br />
                                <label for="ddEstado">Estado</label>
                                <asp:DropDownList ID="ddEstado" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="dsEstado" DataTextField="ID_Estado" DataValueField="ID_Estado"></asp:DropDownList>
                                <asp:SqlDataSource ID="dsEstado" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Estado]"></asp:SqlDataSource>
                                <br />
                                <label for="txtFechaPlantacion">Fecha Plantación</label>
                                <asp:TextBox ID="txtFechaPlantacion" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-mm-dd"></asp:TextBox>
                                <br />
                                <label for="txtObservaciones">Observaciones</label>
                                <asp:TextBox ID="txtObservaciones" type="input" class="form-control" TextMode="MultiLine" Height="100px" placeholder="Ingrese observaciones de planta" runat="server"></asp:TextBox>
                                <br />
                                <label for="ddFundo5">Fundo</label>
                                <asp:DropDownList ID="ddFundo5" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="dsFundos" DataTextField="Nombre" DataValueField="ID_Fundo"></asp:DropDownList>
                                <br />
                                <label for="ddPotrero4">Potrero</label>
                                <asp:DropDownList ID="ddPotrero4" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="potrerosDEfundo5" DataTextField="Nombre" DataValueField="ID_Potrero"></asp:DropDownList>
                                <asp:SqlDataSource ID="potrerosDEfundo5" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Potrero] WHERE ([ID_Fundo] = @ID_Fundo)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddFundo5" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <label for="ddSector3">Sector</label>
                                <asp:DropDownList ID="ddSector3" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="sectoresDEpotrero4" DataTextField="Nombre" DataValueField="ID_Sector"></asp:DropDownList>
                                <asp:SqlDataSource ID="sectoresDEpotrero4" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Sector] WHERE (([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddPotrero4" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddFundo5" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <label for="ddCuartel2">Cuartel</label>
                                <asp:DropDownList ID="ddCuartel2" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="cuartelesDEsector3" DataTextField="Nombre" DataValueField="ID_Cuartel"></asp:DropDownList>
                                <asp:SqlDataSource ID="cuartelesDEsector3" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Cuartel] WHERE (([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddSector3" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddPotrero4" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddFundo5" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <label for="ddHilera">Hilera</label>
                                <asp:DropDownList ID="ddHilera" AutoPostBack="True" CssClass="form-control" runat="server" DataSourceID="hilerasDEcuartel2" DataTextField="ID_Hilera" DataValueField="ID_Hilera"></asp:DropDownList>
                                <asp:SqlDataSource ID="hilerasDEcuartel2" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Hilera] WHERE (([ID_Cuartel] = @ID_Cuartel) AND ([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddCuartel2" Name="ID_Cuartel" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddSector3" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddPotrero4" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                        <asp:ControlParameter ControlID="ddFundo5" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btInsertarPlanta" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btInsertarPlanta_Click" />
                                    <asp:Button ID="btActualizarPlanta" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarPlanta_Click" />
                                    <asp:Button ID="btEliminarPlanta" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarPlanta_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar la Planta?');" />
                                </div>
                                <br />
                                <br />
                            </div>                            
                            <div class="col-md-8">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Plantas</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaPlantas" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaPlantas_SelectedIndexChanged" DataKeyNames="ID_Planta,ID_Hilera,ID_Cuartel,ID_Sector,ID_Potrero,ID_Fundo" DataSourceID="plantasDEhilera">

                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Planta" HeaderText="Código Planta" ReadOnly="True" SortExpression="ID_Planta" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Fecha_Plantacion" HeaderText="Fecha Plantación" SortExpression="Fecha_Plantacion" DataFormatString="{0:d}" />
                                                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" SortExpression="Observaciones" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Hilera" HeaderText="Hilera" ReadOnly="True" SortExpression="ID_Hilera" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Cuartel" HeaderText="Cuartel" ReadOnly="True" SortExpression="ID_Cuartel" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Sector" HeaderText="Sector" ReadOnly="True" SortExpression="ID_Sector" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Potrero" HeaderText="Potrero" ReadOnly="True" SortExpression="ID_Potrero" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Fundo" HeaderText="Fundo" ReadOnly="True" SortExpression="ID_Fundo" HtmlEncode="False" />
                                                </Columns>

                                            </asp:GridView>
                                            <asp:SqlDataSource ID="plantasDEhilera" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Planta] WHERE (([ID_Hilera] = @ID_Hilera) AND ([ID_Cuartel] = @ID_Cuartel) AND ([ID_Sector] = @ID_Sector) AND ([ID_Potrero] = @ID_Potrero) AND ([ID_Fundo] = @ID_Fundo))">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddHilera" Name="ID_Hilera" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddCuartel2" Name="ID_Cuartel" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddSector3" Name="ID_Sector" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddPotrero4" Name="ID_Potrero" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                    <asp:ControlParameter ControlID="ddFundo5" Name="ID_Fundo" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="False" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Estado -->
                <div role="tabpanel" class="tab-pane" id="estado">
                    <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIdEstado">Estado de Planta</label>
                                <asp:TextBox ID="txtIdEstado" runat="server" type="input" class="form-control" placeholder="Ingrese estado de planta"></asp:TextBox>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btInsertarEstado" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btInsertarEstado_Click" />
                                    <asp:Button ID="btEliminarEstado" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarEstado_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar el Estado?');" />
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Estados de planta</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaEstado" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaEstado_SelectedIndexChanged" DataSourceID="dsEstado">

                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Estado" HeaderText="Estado" ReadOnly="True" SortExpression="ID_Estado" HtmlEncode="False" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Variedad -->
                <div role="tabpanel" class="tab-pane" id="variedad">
                    <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtIDVariedad">Código Variedad</label>
                                <asp:TextBox ID="txtIDvariedad" runat="server" type="input" class="form-control" placeholder="Ingrese código de variedad"></asp:TextBox>
                                <br />
                                <label for="txtNombreVariedad">Nombre Variedad</label>
                                <asp:TextBox ID="txtNombreVariedad" runat="server" type="input" class="form-control" placeholder="Ingrese nombre de variedad"></asp:TextBox>
                                <br />
                                <label for="ddProducto">Producto</label>
                                <asp:DropDownList ID="ddProducto" AutoPostBack="True" CssClass="form-control" runat="server" DataTextField="Nombre" DataValueField="ID_Producto" DataSourceID="dsProducto"></asp:DropDownList>
                                <br />
                                <asp:SqlDataSource ID="dsProducto" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo6 %>" SelectCommand="SELECT * FROM [Producto]"></asp:SqlDataSource>

                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="btInsertarVariedad" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btInsertarVariedad_Click" />
                                    <asp:Button ID="btActualizarVariedad" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarVariedad_Click"  />
                                    <asp:Button ID="btEliminarVariedad" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarVariedad_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar la Variedad?');" />
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Variedades por hilera</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaVariedad" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grillaVariedad_SelectedIndexChanged" DataSourceID="dsVariedades">

                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Variedad" HeaderText="ID_Variedad" ReadOnly="True" SortExpression="ID_Variedad" HtmlEncode="False" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HtmlEncode="False" />
                                                    <asp:BoundField DataField="ID_Producto" HeaderText="ID_Producto" ReadOnly="True" SortExpression="ID_Producto" HtmlEncode="False" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Mantenedor Mapeo -->
                <div role="tabpanel" class="tab-pane" id="mapeo">
                    <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <br />
                                <label for="txtInicio">Fecha Inicio Mapeo</label>
                                <asp:TextBox ID="txtInicio" runat="server" type="input" class="form-control" TextMode="Date"></asp:TextBox>
                                <br />
                                <label for="txtFin">Fecha Término Mapeo</label>
                                <asp:TextBox ID="TextBox1" runat="server" type="input" class="form-control" TextMode="Date"></asp:TextBox>
                                <br />
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Button ID="Button1" runat="server" Text="Generar Nuevo Mapeo" type="submit" class="btn btn-default" />
                                    <asp:Button ID="Button2" runat="server" Text="Eliminar" type="submit" class="btn btn-default" onclientclick="return confirm('¿Está seguro de que desea eliminar el Mapeo? (Esto puede ser peligrooooso...)');" />
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Mapeos</h3>
                                    </div>
                                    <div class="panel-body" style="max-height: 500px ;overflow-y: scroll;">
                                        <!-- grilla -->
                                        <div class="table-responsive">
                                            <asp:GridView ID="grillaMapeo" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_Mapeo" DataSourceID="dsMapeo">
                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="ID_Mapeo" HeaderText="ID Mapeo" InsertVisible="False" ReadOnly="True" SortExpression="ID_Mapeo" />
                                                    <asp:BoundField DataField="Fecha_Inicio" HeaderText="Fecha Inicio Mapeo" SortExpression="Fecha_Inicio" DataFormatString="{0:d}" />
                                                    <asp:BoundField DataField="Fecha_Termino" HeaderText="Fecha Termino Mapeo" SortExpression="Fecha_Termino" DataFormatString="{0:d}" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="dsMapeo" runat="server" ConnectionString="<%$ ConnectionStrings:ArandanosConnectionString %>" SelectCommand="SELECT * FROM [Map]"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
