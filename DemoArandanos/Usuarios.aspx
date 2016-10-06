<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DemoArandanos.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Administración de cuentas de usuario</h1>

    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                    <asp:Label ID="lbldanger" runat="server" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- formulario usuarios -->
        <asp:UpdatePanel ID="UpdatePanel" UpdateMode="Always" runat="server">
            <ContentTemplate>
                <div class="col-md-1"></div>
                <div class="col-md-4">
                    <br />
                    <label for="txtUser">Nombre de usuario</label>
                    <asp:TextBox ID="txtUser" runat="server" type="input" class="form-control" placeholder="Ingrese nombre de usuario"></asp:TextBox>
                    <br />
                    <label for="ddTipo">Tipo de usuario</label>
                    <asp:DropDownList ID="ddTipo" CssClass="form-control" runat="server">
                        <asp:ListItem Selected="True" Value="normal">Normal</asp:ListItem>
                        <asp:ListItem Value="admin">Administrador</asp:ListItem>
                        <asp:ListItem Value="informes">Gerencia</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <label for="txtPass1">Contraseña</label>
                    <asp:TextBox ID="txtPass1" runat="server" type="password" class="form-control" placeholder="Ingrese contraseña"></asp:TextBox>
                    <br />
                    <label for="txtPass2">Repita contraseña</label>
                    <asp:TextBox ID="txtPass2" runat="server" type="password" class="form-control" placeholder="Repita contraseña"></asp:TextBox>
                    <br />
                    <div class="btn-group" role="group" aria-label="...">
                        <asp:Button ID="btnIngresarUsuario" runat="server" Text="Insertar" type="submit" class="btn btn-default" OnClick="btnIngresarUsuario_Click" />
                        <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btnEliminarUsuario_Click" onclientclick="return confirm('¿Está seguro de que desea eliminar el Usuario?');" />
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
                            <h3 class="panel-title">Usuarios</h3>
                        </div>
                        <div class="panel-body">
                            <!-- grilla -->
                            <div class="table-responsive">
                                <asp:GridView ID="grillaUsuarios" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="dsUsuarios" OnSelectedIndexChanged="grillaUsuarios_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                        <asp:BoundField DataField="user" HeaderText="Usuario" SortExpression="user" />
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo2 %>" SelectCommand="SELECT [user], [tipo] FROM [Usuarios]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>
