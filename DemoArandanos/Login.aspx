<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoArandanos.Login" %>

<%@ OutputCache Location="None" NoStore="true" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>Producción CAF El Alamo</title>

    <!-- Bootstrap core CSS -->
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="../../assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="starter-template.css" rel="stylesheet">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="../../assets/js/ie-emulation-modes-warning.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <link href="content/css/bootstrap.css" rel="stylesheet" type="text/css">
</head>

<body>

    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Producción CAF El Alamo</a>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>

    <div class="container">
        <br>
        <br>
        <br>
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <h2>Iniciar sesión</h2>
            <form role="form" runat="server">
                <br />
                <br />
                <br />
                <br />
                <label>Sitio:</label>
                <br />
                <asp:RadioButton ID="rbtArandanos" GroupName="Login" runat="server" class="radio-inline" Text="Arandanos" />
                <asp:RadioButton ID="rbtManzanos" GroupName="Login" Style="float: right" runat="server" class="radio-inline" Text="Manzanos" />
                <br />
                <br />
                <asp:RadioButton ID="rbtVinedos" GroupName="Login" runat="server" class="radio-inline" Text="Viñedos" />
                <br />
                <br />
                <br />
                <label for="txtUser">Usuario:</label>
                <asp:TextBox ID="txtUser" Text="user" runat="server" type="input" required class="form-control" placeholder="Ingrese nombre de usuario"></asp:TextBox>
                <br />
                <label for="txtPass">Contraseña:</label>
                <asp:TextBox ID="txtPass" Text="user" runat="server" type="password" required class="form-control" placeholder="Ingrese contraseña"></asp:TextBox>
                <br />
                <div class="alert alert-danger fade in" id="divBadLogin" runat="server">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Error!</strong>
                    <asp:Label ID="lblLogin" runat="server" Text="Label"></asp:Label>
                </div>
                <asp:Button ID="btnLogin" runat="server" Style="float: right" Text="Ingresar" type="submit" class="btn btn-default" OnClick="btnLogin_Click" />
            </form>
        </div>
        <div class="col-md-4"></div>
    </div>
    <!-- /.container -->


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.0.0.min.js"></script>
</body>
</html>
