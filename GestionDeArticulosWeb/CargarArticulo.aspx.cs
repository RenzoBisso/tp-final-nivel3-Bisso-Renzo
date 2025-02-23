using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeArticulosWeb
{
    public partial class CargarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("error", "No tienes permiso para acceder");
                Response.Redirect("Error.aspx", false);
            }
            else
            {

                if (!IsPostBack)
                {


                    MarcaNegocio marca = new MarcaNegocio();
                    CategoriaNegocio categoria = new CategoriaNegocio();

                    List<Marca> listaMarca = new List<Marca>();
                    listaMarca = marca.ListarMarca();
                    foreach (Marca item in listaMarca)
                    {
                        ddlMarca.Items.Add(new ListItem(item.Descripcion));
                    }

                    List<Categoria> listaCategoria = new List<Categoria>();
                    listaCategoria = categoria.ListarCategoria();
                    foreach (Categoria item in listaCategoria)
                    {
                        ddlCategoria.Items.Add(new ListItem(item.Descripcion));
                    }
                }

                if (Request.QueryString["Id"] == null)
                {
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;

                }
                else
                {
                    if (!IsPostBack)
                    {
                        btnAgregar.Visible = false;
                        btnEliminar.Visible = true;
                        Articulo articulo = new Articulo();
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        articulo = articuloNegocio.BuscarPorId(Request.QueryString["Id"].ToString());

                        txtCodigo.Text = articulo.Codigo;
                        txtDescripcion.Text = articulo.Descripcion;
                        txtNombre.Text = articulo.Nombre;
                        txtPrecio.Text = articulo.Precio.ToString("F2");
                        ddlCategoria.Text = articulo.Categoria;
                        ddlMarca.Text = articulo.Marca;
                        imgArticulo.ImageUrl = articulo.ImagenUrl;
                    }

                }
            }





        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Articulo articuloNuevo = new Articulo();
                articuloNuevo.Descripcion = txtDescripcion.Text;
                articuloNuevo.Categoria = ddlCategoria.SelectedItem.Text;
                articuloNuevo.Nombre = txtNombre.Text;
                articuloNuevo.Marca = ddlMarca.SelectedItem.Text;
                articuloNuevo.Precio = decimal.Parse(txtPrecio.Text);
                articuloNuevo.Codigo = txtCodigo.Text;

                string ruta = Server.MapPath("./Imagenes/Articulo/");
                string rutaImagen = ruta + "Articulo-" + txtNombre.Text + ".jpg";
                urlImagenArticulo.PostedFile.SaveAs(rutaImagen);
                articuloNuevo.ImagenUrl = "Articulo-" + txtNombre.Text + ".jpg";

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                if (!(articuloNegocio.EsVacio(articuloNuevo)))
                {
                    articuloNegocio.AgregarArticulo(articuloNuevo);

                }
                else
                {
                    Session.Add("error", "No se permiten valores vacios exepto de la imagen");
                    Response.Redirect("Error.aspx", false);
                }



            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }



        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdmin.aspx", false);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {

                Articulo articulo = new Articulo();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                articulo.Marca = ddlMarca.SelectedItem.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Nombre = txtNombre.Text;
                articulo.Id = int.Parse(Request.QueryString["Id"]);
                articulo.Categoria = ddlCategoria.SelectedItem.Text;
                articulo.Codigo = txtCodigo.Text;

                string ruta = Server.MapPath("./Imagenes/Articulo/");
                string rutaImagen = ruta + "Articulo-" + txtNombre.Text + ".jpg";
                urlImagenArticulo.PostedFile.SaveAs(rutaImagen);
                articulo.ImagenUrl = "Articulo-" + txtNombre.Text + ".jpg";

                if (!(articuloNegocio.EsVacio(articulo)))
                {
                    articuloNegocio.AgregarArticulo(articulo);
                    Response.Redirect("PanelAdmin.aspx", false);
                }
                else
                {
                    Session.Add("error", "No se permiten valores vacios exepto de la imagen");
                    Response.Redirect("Error.aspx", false);
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
            finally
            {

            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articuloNegocio.EliminarArticulo(int.Parse(Request.QueryString["Id"]));
            Response.Redirect("PanelAdmin.aspx", false);
        }
    }
}