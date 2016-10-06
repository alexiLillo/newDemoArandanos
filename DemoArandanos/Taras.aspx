<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Taras.aspx.cs" Inherits="DemoArandanos.Taras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Tara</h1>
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

        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
            <ContentTemplate>
                <div class="col-md-4">
                    <label for="txtCodTara">Código Tara</label>
                    <asp:TextBox ID="txtCodTara" runat="server" type="input" required="required" class="form-control" placeholder="Ingrese Código de Tara: 0"></asp:TextBox>
                    <br />
                    <label for="txtPesoTara">Peso Tara</label>
                    <asp:TextBox ID="txtPesoTara" runat="server" type="input" onkeypress="return onKeyDecimal(event,this);" required="required" class="form-control" placeholder="Ingrese peso de Tara: 0.000"></asp:TextBox>

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
                    <label for="ddProducto">Producto</label>
                    <asp:DropDownList ID="ddProducto" CssClass="form-control" AutoPostBack="True" runat="server" DataSourceID="dsProducto" DataTextField="Nombre" DataValueField="ID_Producto"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsProducto" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo10 %>" SelectCommand="SELECT * FROM [Producto] ORDER BY [Nombre]"></asp:SqlDataSource>
                    <br />
                    <label for="txtFormato">Formato</label>
                    <asp:TextBox ID="txtFormato" runat="server" type="input" required="required" class="form-control" placeholder="Ingrese formato de Tara: bandeja, bin..."></asp:TextBox>
                    <br />
                    <label for="txtDescripcion">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" type="input" TextMode="MultiLine" Height="100px" class="form-control" placeholder="Ingrese observaciones de Tara"></asp:TextBox>
                    <br />
                    <div class="btn-group" role="group" aria-label="...">
                        <asp:Button ID="btGuardarTara" runat="server" Text="Registrar" type="submit" class="btn btn-default" OnClick="btGuardarTara_Click" />
                        <asp:Button ID="btActualizarTara" runat="server" Text="Actualizar" type="submit" class="btn btn-default" OnClick="btActualizarTara_Click" />
                        <asp:Button ID="btEliminarTara" runat="server" Text="Eliminar" type="submit" class="btn btn-default" OnClick="btEliminarTara_Click"  onclientclick="return confirm('¿Está seguro de que desea eliminar la Tara?');" />
                    </div>
                </div>
                <div class="col-md-8">
                    <!-- grilla -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Taras</h3>
                        </div>
                        <div class="panel-body" style="max-height: 500px; overflow-y: scroll;">
                            <div class="table-responsive">
                                <asp:GridView ID="grillaTaras" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_Tara" DataSourceID="dsTaras" OnSelectedIndexChanged="grillaTaras_SelectedIndexChanged">

                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/ic_mode_edit_black_24dp_1x.png" ShowSelectButton="True" />
                                        <asp:BoundField DataField="ID_Tara" HeaderText="ID Tara" ReadOnly="True" SortExpression="ID_Tara" />
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" />
                                        <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" />
                                        <asp:BoundField DataField="Formato" HeaderText="Formato" SortExpression="Formato" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                    </Columns>

                                </asp:GridView>

                                <asp:SqlDataSource ID="dsTaras" runat="server" ConnectionString="<%$ ConnectionStrings:Modelo10 %>" SelectCommand="SELECT * FROM [Tara] ORDER BY [Peso], [ID_Tara]"></asp:SqlDataSource>

                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>

</asp:Content>
