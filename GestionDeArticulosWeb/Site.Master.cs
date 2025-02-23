using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Negocio;

namespace GestionDeArticulosWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = Session["user"] as User;
                if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                {
                    imgPerfil.ImageUrl = "~/Imagenes/Perfil/Perfil-" + user.Email + ".jpg";
                }
                else
                {
                    imgPerfil.ImageUrl = "~/Imagenes/noImage.jpg";
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void btnEditarPefil_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            Response.Redirect($"Registro.aspx?Id={user.Id}");
        }
    }
}