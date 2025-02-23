<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestionDeArticulosWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-4"></div>
            <div class="col">
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="name@example.com" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtPass" class="form-label">Password</label>
                    <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnIniciarSesion" CssClass="btn btn-primary" runat="server" Text="Iniciar" OnClick="btnIniciarSesion_Click" />
                <asp:Button ID="btnRegistro" CssClass="btn btn-primary" OnClick="btnRegistro_Click" runat="server" Text="Registrarse" />


            </div>
            <div class="col-4"></div>
        </div>
    </div>
</asp:Content>
