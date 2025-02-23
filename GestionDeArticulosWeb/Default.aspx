<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestionDeArticulosWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">
                <h1 class="display-4 mb-4">¡Bienvenidos a nuestro Catálogo!</h1>
                <p class="lead">Explora nuestra amplia selección de objetos disponibles. Encontrarás productos únicos para satisfacer todas tus necesidades.</p>
                <p>Ya sea que busques algo específico o simplemente quieras navegar, tenemos algo para todos. ¡Comienza a explorar ahora!</p>
                <a href="Home.aspx" class="btn btn-primary btn-lg mt-4">Ver Catálogo</a>
            </div>
        </div>
    </div>
</asp:Content>
