using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeArticulosWeb
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.sessionActiva(Session["user"]))
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarCatalogo();
                }
            }






        }

        public void CargarCatalogo()
        {
            List<Favorito> favoritos = new List<Favorito>();
            List<Articulo> articulos = new List<Articulo>();
            FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            User user = Session["user"] as User;
            favoritos = favoritoNegocio.ListarFavoritos(user.Id.ToString());

            foreach (Favorito favorito in favoritos)
            {
                Articulo articulo = articuloNegocio.BuscarPorId(favorito.IdArticulo.ToString());

                articulos.Add(articulo);

            }
            repArticulos.DataSource = articulos;
            repArticulos.DataBind();
        }
        protected void repArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtener el objeto de datos
                Articulo articulo = (Articulo)e.Item.DataItem;
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                // Encontrar el control de imagen dentro del Repeater
                Image imgArticulo = (Image)e.Item.FindControl("imgArticulo");

                // Asignar la imagen si existe, de lo contrario, usar una imagen por defecto
                if (!string.IsNullOrEmpty(articulo.ImagenUrl) && articuloNegocio.verificarImagen(articulo))
                {
                    imgArticulo.ImageUrl = articulo.ImagenUrl;
                }
                else if (articulo.ImagenUrl.Contains("Articulo-"))
                {
                    imgArticulo.ImageUrl = "~/Imagenes/Articulo/Articulo-" + articulo.Nombre + ".jpg";
                }
                else
                {
                    imgArticulo.ImageUrl = "Imagenes/noImage.jpg";
                }
            }
        }
        protected void btnVerDescipcion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string id = btn.CommandArgument.ToString();

            Response.Redirect($"DetalleArticulo.aspx?Id={id}", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
            Button btn = (Button)sender;
            User user = Session["user"] as User;
            string idArticulo = btn.CommandArgument.ToString();
            string idUser = user.Id.ToString();

            favoritoNegocio.Eliminar(idUser, idArticulo);
            CargarCatalogo();
        }
    }
}