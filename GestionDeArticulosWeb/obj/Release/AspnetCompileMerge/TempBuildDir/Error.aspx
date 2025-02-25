<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="GestionDeArticulosWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <h1 class="display-1 fw-bold text-danger">ERROR</h1>

        <p class="fs-3"><span class="text-danger">Oops!</span></p>
        <asp:Label CssClass="lead" ID="lblMensajeError" runat="server" Text=""></asp:Label>
        <br />
        <a href="Home.aspx" class="btn btn-primary">Volver al inicio</a>
    </div>

</asp:Content>
