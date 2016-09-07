<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Produccion.aspx.cs" Inherits="DemoArandanos.Produccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

        <div class="col-md-5">
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                <ContentTemplate>
                    <label for="txtRutTrabajador">Rut</label>
                    <asp:TextBox ID="txtRutTrabajador" runat="server" type="input" class="form-control" placeholder="Ingrese Rut de Trabajador"></asp:TextBox>
                    <br />
                    <label for="txtNombreTrabajador">Nombre</label>
                    <asp:TextBox ID="txtNombreTrabajador" runat="server" type="input" class="form-control" placeholder="Ingrese Nombre de Trabajador"></asp:TextBox>
                    <br />
                    <label for="txtApellidoTrabajador">Apellido</label>
                    <asp:TextBox ID="txtApellidoTrabajador" runat="server" type="input" class="form-control" placeholder="Ingrese Apellido de Trabajador"></asp:TextBox>
                    <br />
                    <label for="txtFechaNacimiento">Fecha Nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server" placeholder="aaaa-mm-dd"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btGenerarQR" runat="server" Text="Guardar y Generar QR" type="submit" class="btn btn-default" OnClick="btGenerarQR_Click" />
                    <br />                    
                    <div id="printableArea">
                        <asp:PlaceHolder ID="plBarCode" runat="server" />
                        <div class="visible-print">
                            <asp:Label ID="lblQR" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <input type="button" class="btn btn-default" name="Imprimir" value="Imprimir" onclick="printDiv('printableArea')">
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-7"></div>

    </form>

</asp:Content>
