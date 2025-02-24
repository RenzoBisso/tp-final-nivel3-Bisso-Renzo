using Modelo;
using Negocio;
using BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


namespace GestionDeArticulosWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                List<Articulo> listaArticulo = new List<Articulo>();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                listaArticulo = articuloNegocio.listarArticulos();

                repArticulos.DataSource = listaArticulo;
                repArticulos.DataBind();
            }


        }


        protected void cargarDdl()
        {


            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();

            if (ddlfiltroAvanzado.SelectedItem.Text == "Marca")
            {
                ddlCriterio.Items.Clear();
                List<Marca> listaMarca = new List<Marca>();
                listaMarca = marca.ListarMarca();
                foreach (Marca item in listaMarca)
                {
                    ddlCriterio.Items.Add(new ListItem(item.Descripcion));
                }
            }
            else if (ddlfiltroAvanzado.SelectedItem.Text == "Categoria")
            {
                ddlCriterio.Items.Clear();
                List<Categoria> listaCategoria = new List<Categoria>();
                listaCategoria = categoria.ListarCategoria();
                foreach (Categoria item in listaCategoria)
                {
                    ddlCriterio.Items.Add(new ListItem(item.Descripcion));
                }
            }



        }

        protected void btnFiltroRapido_Click(object sender, EventArgs e)
        {

            List<Articulo> listaArticulo = new List<Articulo>();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            listaArticulo = articuloNegocio.listarArticulos(txtFiltroNombre.Text);
            txtFiltroNombre.Text = "";

            repArticulos.DataSource = listaArticulo;
            repArticulos.DataBind();

        }
        protected void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion = new Conexion();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                if (ddlfiltroAvanzado.Text == "Marca")
                {
                    List<Articulo> listaArticulos = new List<Articulo>();

                    int criterio = marcaNegocio.DevolverId(ddlCriterio.SelectedItem.Text);
                    listaArticulos = articuloNegocio.listarArticulos(criterio);
                    repArticulos.DataSource = listaArticulos;
                    repArticulos.DataBind();
                }
                else if (ddlfiltroAvanzado.Text == "Categoria")
                {
                    List<Articulo> listaArticulos = new List<Articulo>();

                    int seccion = categoriaNegocio.DevolverId(ddlCriterio.SelectedItem.Text);
                    listaArticulos = articuloNegocio.listarArticulosSeccion(seccion);
                    repArticulos.DataSource = listaArticulos;
                    repArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }


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

        protected void btnFavorito_Click(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                Button btn = (Button)sender;
                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                string idArticulo = btn.CommandArgument.ToString();
                User user = Session["user"] as User;
                string idUser = user.Id.ToString();

                if (!favoritoNegocio.Esta(idUser, idArticulo))
                {
                    favoritoNegocio.AgregarFavorito(idUser, idArticulo);
                }

            }
        }



        protected void ddlfiltroAvanzado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDdl();
        }
    }
}