<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GestionDeArticulosWeb.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        #imgArticulo {
            height: 200px;
            width: 250px;
        }
    </style>
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col-2">
                <h1>Filtro</h1>
                <asp:TextBox ID="txtFiltroNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnFiltroRapido" CssClass="btn btn-primary" OnClick="btnFiltroRapido_Click" runat="server" Text="Filtrar" />
                <br />
                <br />
                <asp:CheckBox ID="cbxFiltroAvanzado" CssClass="form-check-label" AutoPostBack="true" Text="Filtro Avanzado" runat="server" />
                <% if (cbxFiltroAvanzado.Checked)
                    {%>


                <asp:DropDownList ID="ddlfiltroAvanzado" CssClass="btn btn-outline-primary dropdown-toggle" OnSelectedIndexChanged="ddlfiltroAvanzado_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem Text="Todos"></asp:ListItem>
                    <asp:ListItem Text="Marca"></asp:ListItem>
                    <asp:ListItem Text="Categoria"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:DropDownList ID="ddlCriterio" CssClass="btn btn-outline-primary dropdown-toggle" AutoPostBack="true" runat="server">
                    <asp:ListItem Text="Todos"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />

                <br />
                <br />
                <asp:Button ID="btnFiltroAvanzado" OnClick="btnFiltroAvanzado_Click" CssClass="btn btn-primary" runat="server" Text="Filtrar" />
                <%}%>
            </div>
            <div class="col">
                <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="upPanel" runat="server">
                    <ContentTemplate>
                        <div class="row row-cols-1 row-cols-md-3 g-4">
                            <asp:Repeater OnItemDataBound="repArticulos_ItemDataBound" ID="repArticulos" runat="server">
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="card">

                                            <asp:Image ID="imgArticulo" Height="200px" Width="250px" alt="Imagen del artículo" runat="server" />
                                            <div class="card-body d-flex flex-column">
                                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                                <p class="card-text flex-grow-1"><%#Eval("Descripcion") %></p>
                                                <p class="card-text"><strong>$<%#Eval("Precio") %></strong></p>
                                                <div class="mt-auto">
                                                    <asp:Button ID="btnFavorito" CommandName="VerDescripcion" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" runat="server" OnClick="btnFavorito_Click" Text="☆" />
                                                    <asp:Button ID="btnVerDescipcion" CommandName="VerDescripcion" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" OnClick="btnVerDescipcion_Click" runat="server" Text="Ver Detalle" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-2"></div>
        </div>
    </div>
</asp:Content>
