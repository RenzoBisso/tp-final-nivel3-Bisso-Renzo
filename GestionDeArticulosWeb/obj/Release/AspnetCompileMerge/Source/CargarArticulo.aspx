<%@ Page Title="Cargar Articulo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarArticulo.aspx.cs" Inherits="GestionDeArticulosWeb.CargarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-2"></div>
            <div class="col">
                <br />
                <asp:Label ID="lblCodigo" class="form-label" runat="server" Text="Codigo"></asp:Label><br />
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblNombre" class="form-label" runat="server" Text="Nombre"></asp:Label><br />
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblDescripcion" class="form-label" runat="server" Text="Descripcion"></asp:Label><br />
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblPrecio" class="form-label" runat="server" Text="Precio"></asp:Label><br />
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnEditar" CssClass="btn btn-primary" OnClick="btnEditar_Click" runat="server" Text="Editar" />
                <asp:Button ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" Text="Agregar" />
                <asp:Button ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />
                <asp:Button ID="btnSalir" CssClass="btn btn-primary" OnClick="btnSalir_Click" runat="server" Text="Salir" />
            </div>
            <div class="col">
                <br />
                <asp:Label ID="lblMarca" class="form-label" runat="server" Text="Marca:"></asp:Label>
                <asp:DropDownList AutoPostBack="true" CssClass="btn btn-primary dropdown-toggle" ID="ddlMarca" runat="server"></asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblCategoria" class="form-label" runat="server" Text="Categoria:"></asp:Label>
                <asp:DropDownList AutoPostBack="true" CssClass="btn btn-primary dropdown-toggle" ID="ddlCategoria" runat="server"></asp:DropDownList>
                <br />
                <br />
                <label for="formFile" class="form-label">Imagen del articulo</label>
                <input class="form-control" id="urlImagenArticulo" type="file" runat="server">
                <br />
                <asp:Image ID="imgArticulo" Width="300px" ImageUrl="Imagenes/noImage.jpg" runat="server" />
            </div>
            <div class="col-2"></div>

        </div>
    </div>




</asp:Content>
