using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace GestionDeArticulosWeb
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                Articulo articulo = new Articulo();
                if (Request.QueryString["Id"] != null)
                {
                    string id = Request.QueryString["Id"];
                    articulo = articuloNegocio.BuscarPorId(id);
                    lblMarca.Text = articulo.Marca;
                    lblPrecio.Text = "$" + articulo.Precio.ToString();
                    lblCategoria.Text = articulo.Categoria;
                    lblTitulo.Text = articulo.Nombre;
                    lblDescripcion.Text = articulo.Descripcion;

                    if (articuloNegocio.verificarImagen(articulo))
                    {
                        imgArticulo.ImageUrl = articulo.ImagenUrl;
                    }
                    else if (articulo.ImagenUrl.Contains("Articulo-"))
                    {
                        imgArticulo.ImageUrl = "~/Imagenes/Articulo/Articulo-" + articulo.Nombre + ".jpg";

                    }
                    else
                    {
                        imgArticulo.ImageUrl = "~/Imagenes/noImage.jpg";
                    }

                }
                else
                {
                    Response.Redirect("Home.aspx", false);

                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }






        }
    }
}