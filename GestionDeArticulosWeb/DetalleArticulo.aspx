<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="GestionDeArticulosWeb.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row">
            <div class="col-5"></div>
            <div class="col">
                <asp:Image ID="imgArticulo" Style="width: 300px; height: 380px;" ImageUrl="Imagenes/noImage.jpg" runat="server" />
            </div>
            <div class="col">
                <asp:Label ID="lblTitulo" CssClass="h1 mb-3" runat="server" Text=""></asp:Label><br />
                <asp:Label CssClass="lead" ID="lblDescripcion" runat="server" Text=""></asp:Label>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item"><strong>Categoría:</strong><asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label></li>
                    <li class="list-group-item"><strong>Marca:</strong><asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></li>
                    <li class="list-group-item"><strong>Precio</strong><asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label></li>
                </ul>
            </div>
            <div class="col-5"></div>

        </div>
    </div>
</asp:Content>
