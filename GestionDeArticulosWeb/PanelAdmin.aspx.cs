using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using BaseDeDatos;
using Negocio;

namespace GestionDeArticulosWeb
{
    public partial class PanelAdmin : System.Web.UI.Page
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
                btnAgregarArticulo.Visible = false;

            }


        }

        protected void btnArticulo_Click(object sender, EventArgs e)
        {

            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = articuloNegocio.listarArticulos();

                grdView.DataSource = listaArticulos;
                grdView.DataBind();
                lblGridView.Text = "Articulos";
                btnAgregarArticulo.Visible = true;
                btnAgregarCategoria.Visible = false;
                btnAgregarMarca.Visible = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
            }

        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                UserNegocio userNegocio = new UserNegocio();
                List<User> listaUsuarios = userNegocio.ListarUsuarios();

                grdView.DataSource = listaUsuarios;
                grdView.DataBind();
                lblGridView.Text = "Usuarios";
                btnAgregarArticulo.Visible = false;
                btnAgregarCategoria.Visible = false;
                btnAgregarMarca.Visible = false;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
            }
        }

        protected void btnCategorias_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategoria = categoriaNegocio.ListarCategoria();

                grdView.DataSource = listaCategoria;
                grdView.DataBind();
                lblGridView.Text = "Categorias";
                btnAgregarArticulo.Visible = false;
                btnAgregarMarca.Visible = false;

                btnAgregarCategoria.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
            }


        }

        protected void btnMarcas_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> listaMarca = marcaNegocio.ListarMarca();

                grdView.DataSource = listaMarca;
                grdView.DataBind();
                lblGridView.Text = "Marcas";

                btnAgregarMarca.Visible = true;
                btnAgregarArticulo.Visible = false;
                btnAgregarCategoria.Visible = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargarArticulo.aspx", false);
        }

        protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
        {


            var x = grdView.SelectedRow.Cells[1].Text;
            if (lblGridView.Text == "Articulos")
            {

                Response.Redirect($"CargarArticulo.aspx?Id={x}", false);
            }
            else if (lblGridView.Text == "Usuarios")
            {

                Response.Redirect($"Registro.aspx?Id={x}", false);
            }
            else if (lblGridView.Text == "Marcas")
            {


                Response.Redirect($"CargarMarca.aspx?Id={x}", false);

            }
            else if (lblGridView.Text == "Categorias")
            {
                Response.Redirect($"AgregarCategoria.aspx?Id={x}", false);
            }
            else
            {
                Response.Redirect("Error.aspx", false);

            }
        }


        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect($"CargarMarca.aspx", false);

        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect($"AgregarCategoria.aspx", false);

        }
    }
}