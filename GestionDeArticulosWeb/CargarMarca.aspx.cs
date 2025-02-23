using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Modelo;
using Negocio;

namespace GestionDeArticulosWeb
{
    public partial class CargarMarca : System.Web.UI.Page
    {
        MarcaNegocio marcaNegocio = new MarcaNegocio();

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
                    if (Request.QueryString["Id"] == null)
                    {
                        btnEditar.Visible = false;

                    }
                    else
                    {
                        btnAgregar.Visible = false;
                        btnEditar.Visible = true;
                        txtNombreMarca.Text = marcaNegocio.DevolverNombre(int.Parse(Request.QueryString["Id"]));
                    }
                }
            }




        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

            Response.Redirect("PanelAdmin.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreMarca.Text))
            {

                marcaNegocio.CargarMarca(txtNombreMarca.Text);
                Response.Redirect("PanelAdmin.aspx", false);

            }
            else
            {
                Session.Add("error", "No se permiten valores vacios");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreMarca.Text))
            {

                marcaNegocio.EditarMarca(Request.QueryString["Id"], txtNombreMarca.Text);
                Response.Redirect("PanelAdmin.aspx", false);

            }
            else
            {
                Session.Add("error", "No se permiten valores vacios");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            marcaNegocio.EliminarMarca(Request.QueryString["Id"]);
            Response.Redirect("PanelAdmin.aspx", false);

        }
    }
}