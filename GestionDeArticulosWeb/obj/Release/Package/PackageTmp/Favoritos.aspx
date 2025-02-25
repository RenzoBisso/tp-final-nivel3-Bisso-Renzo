<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="GestionDeArticulosWeb.Favoritos" %>

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
                                                <asp:Button ID="btnVerDescipcion" CommandName="VerDescripcion" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" OnClick="btnVerDescipcion_Click" runat="server" Text="Ver Detalle" />
                                                <asp:Button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />

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

</asp:Content>
