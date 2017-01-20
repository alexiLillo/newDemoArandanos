<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="CargaExcel.aspx.cs" Inherits="DemoArandanos.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cargar Excel</h1>
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
                        <asp:Label ID="lbldanger" runat="server" Text=""></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:FileUpload ID="FileUpload1" class="btn btn-default btn-file" runat="server" />
            <br />
            <asp:Button ID="btCargar" class="btn btn-default" runat="server" Text="Cargar tabla" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="btInsertarBD" class="btn btn-default" runat="server" Text="Insertar en BD" OnClick="btInsertarBD_Click" />
            <br />
            <br />
        </div>
        <div class="col-md-6"></div>
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Datos de Excel</h3>
                </div>
                <div class="panel-body" style="max-height: 700px ;overflow-y: scroll;">
                    <!-- grilla -->
                    <div class="table-responsive">
                        <asp:GridView ID="grillaExcel" class="table table-bordered" runat="server"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
