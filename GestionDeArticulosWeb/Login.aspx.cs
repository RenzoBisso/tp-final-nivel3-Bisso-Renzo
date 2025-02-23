using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Negocio;
using BaseDeDatos;

namespace GestionDeArticulosWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Registro.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                UserNegocio negocio = new UserNegocio();
                User user = negocio.Logear(txtEmail.Text, txtPass.Text);
                if (user != null)
                {
                    Session.Add("user", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Email o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }


    }
}