<%@ Page Title="Agregar Categoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="GestionDeArticulosWeb.AgregarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4"></div>
        <div class="col">
            <br />
            <br />
            <asp:Label runat="server" Text="Categoria: "></asp:Label><asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click" Text="Agregar" />
            <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" OnClick="btnEditar_Click" Text="Editar" />
            <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <asp:Button ID="btnSalir" runat="server" CssClass="btn btn-primary" OnClick="btnSalir_Click" Text="Salir" />
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
