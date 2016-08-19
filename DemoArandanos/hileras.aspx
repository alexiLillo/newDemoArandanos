<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hileras.aspx.cs" Inherits="DemoArandanos.hileras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plantas por Cuartel</title>

    <%--    <link href="content/css/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script src="scripts/gridviewScroll.min.js" type="text/html"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=grillaHileras.ClientID%>').gridviewScroll({
                width: 600,
                height: 300,
                startHorizontal: 0,
                wheelsteep: 10,
                freezesize: 1,
                barhovercolor: "#3399F",
                barcolor: "3399F",
                IsInUpdatePanel : true
            });
        }
    </script>--%>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="../../favicon.ico" />

    <meta http-equiv="REFRESH" content="1803;URL=Login.aspx" />
    <!-- Bootstrap core CSS -->
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="../../assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="starter-template.css" rel="stylesheet" />

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="../../assets/js/ie-emulation-modes-warning.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <link href="content/css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            <label>
                <asp:Label ID="lbltitulo" runat="server" Text="Cuartel"></asp:Label></label>

        </h2>
        <h3>
            <label>
                <asp:Label ID="Label2" runat="server" Text="Variedad: "></asp:Label>
            </label>
            <label>
                <asp:Label ID="lblvariedad" runat="server" Text=""></asp:Label>
            </label>
        </h3>        
        <label>
            <asp:Label ID="Label1" runat="server" Text="Cantidad de Plantas: "></asp:Label>
        </label>
        <label>
            <asp:Label ID="lblgrande" runat="server" Text=""></asp:Label>
        </label>
        <label>
            <asp:Label ID="lblmediana" runat="server" Text=""></asp:Label>
        </label>
        <label>
            <asp:Label ID="lblchica" runat="server" Text=""></asp:Label>
        </label>
        <label>
            <asp:Label ID="lblreplante" runat="server" Text=""></asp:Label>
        </label>
        <label>
            <asp:Label ID="lblsin_planta" runat="server" Text=""></asp:Label>
        </label>
        
        <asp:GridView ID="grillaHileras" class="table table-bordered" runat="server" OnRowDataBound="grillaHileras_RowDataBound" AutoGenerateColumns="true">
        </asp:GridView>

    </form>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.0.0.min.js"></script>

</body>
</html>
