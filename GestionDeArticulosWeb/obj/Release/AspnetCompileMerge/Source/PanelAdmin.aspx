<%@ Page Title="Panel Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="GestionDeArticulosWeb.PanelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="d-flex">
        <!-- Sidebar -->
        <div class="bg-primary text-light p-3 vh-100" style="width: 250px;">
            <h4>Admin Panel</h4>
            <br />
            <br />
            <ul class="nav flex-column">
                <li class="nav-item">
                    <asp:Button ID="btnArticulo" OnClick="btnArticulo_Click" CssClass="btn btn-outline-light mt-1" runat="server" Text="Articulos" />
                </li>

                <li class="nav-item">
                    <asp:Button ID="btnUsuarios" CssClass="btn btn-outline-light mt-1" OnClick="btnUsuarios_Click" runat="server" Text="Usuarios" />
                </li>

                <li class="nav-item">
                    <asp:Button ID="btnCategorias" OnClick="btnCategorias_Click" CssClass="btn btn-outline-light mt-1" runat="server" Text="Categorias" />
                </li>

                <li class="nav-item">
                    <asp:Button ID="btnMarcas" OnClick="btnMarcas_Click" CssClass="btn btn-outline-light mt-1" runat="server" Text="Marcas" />
                </li>

                <li class="nav-item">
                    <asp:Button ID="btnSalir" OnClick="btnSalir_Click" CssClass="btn btn-outline-light mt-1" runat="server" Text="Salir" />
                </li>
            </ul>
        </div>

        <!-- Contenido principal -->
        <div class="flex-grow-1 p-4">
            <h2>Panel de Administración</h2>
            <asp:Label ID="lblGridView" runat="server" Text="" Visible="false"></asp:Label>
            <asp:GridView ID="grdView" OnSelectedIndexChanged="grdView_SelectedIndexChanged" CssClass="table-bordered bg-success-subtle" runat="server">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAgregarArticulo" CssClass="btn btn-primary" OnClick="btnAgregarArticulo_Click" runat="server" Visible="false" Text="Agregar" />
            <asp:Button ID="btnAgregarMarca" CssClass="btn btn-primary" OnClick="btnAgregarMarca_Click" runat="server" Visible="false" Text="Agregar" />
            <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-primary" OnClick="btnAgregarCategoria_Click" runat="server" Visible="false" Text="Agregar" />

        </div>
    </div>


</asp:Content>
