<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GestionDeArticulosWeb.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-3"></div>
        <div class="col">
            <label for="txtNombre" class="form-label">Nombre</label>

            <asp:TextBox ID="txtNombre" CssClass="form-control " placeholder="Nombre" runat="server"></asp:TextBox>
            <br />
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="ejemplo@ejemplo.com" TextMode="Email" runat="server"></asp:TextBox>
            <br />
            <label for="txtUrlImagenPerfil" class="form-label">Imagen de Perfil</label>
            <div class="input-group">
                <input type="file" class="form-control" id="txtUrlImagenPerfil" runat="server" aria-label="Upload">
            </div>
            <br />
            <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" runat="server" Text="Registrarse" />
            <asp:Button ID="btnSalir" CssClass="btn btn-primary" OnClick="btnSalir_Click" runat="server" Text="Salir" />
            <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-primary" OnClick="Editar_Click" Text="Editar" />
            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="Eliminar_Click" Text="Eliminar" />


        </div>
        <div class="col">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="Apellido" runat="server"></asp:TextBox>
            <br />
            <label for="txtPass" class="form-label">Contraseña</label>
            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:Image ID="imgPerfil" ImageUrl="Imagenes/noImage.jpg" runat="server" CssClass="img-fluid mb-3" />
            <asp:CheckBox ID="cbxAdmin" Visible="false" runat="server" />
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
