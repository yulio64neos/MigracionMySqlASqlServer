<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MigracionSqlFinal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Index</title>
    <link href="Estilos/StyleSheet1.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="nav-link" href="WebForm1.aspx">Home</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="row mt-5 text-center">
                <p class="subtitle">TEST CONEXIONES</p>
                <div class="col-lg-6">
                    <img src="Assets/MySQL-logo.png" class="img-fluid imgMysql"/>
                    <asp:Button ID="btnConexion" runat="server" Text="Probar Conexion MySql" OnClick="btnConexion_Click" CssClass="btn"/>
                </div>
                <div class="col-lg-6">
                    <img src="Assets/SQL-Server-PNG-Photos.png" class="img-fluid imgSql"/>
                    <asp:Button ID="btnConexion2" runat="server" Text="Probar Conexion SqlServer" OnClick="btnConexion2_Click" CssClass="btn"/>
                </div>
            </div>

            <div class="row mt-5 text-center">
                <p class="subtitle">CONSULTAS</p>
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-dark table-striped table-hover"></asp:GridView>
            </div>
            <div class="row mt-5 text-center">
                <p class="subtitle">MIGRACIÓN</p>
                <div class="col-lg-12">
                    <asp:Button ID="btnMigracion" runat="server" Text="Haz Clic para MIGRAR" CssClass="btn" OnClick="btnMigracion_Click"/>
                </div>
            </div>
        </div>
         <div class="mt-5">
                <section>                    
                    <footer class="text-center text-white" style="background-color: #0a4275;">                        
                        <div class="container p-4 pb-0">
                            <section class="">
                                <p class="d-flex justify-content-center align-items-center">
                                    <span class="me-3">Universidad Tecnológica de Puebla</span>
                                    <button type="button" class="btn btn-outline-light btn-rounded">
                                        Vistala ¡YA!
                                    </button>
                                </p>
                            </section>
                        </div>
                        
                        <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
                            © 2022 Copyright:
                            <a class="text-white" href="https://www.utpuebla.edu.mx">Universidad Tecnológica de Puebla</a>
                        </div>
                    </footer>                    
                </section>
            </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
