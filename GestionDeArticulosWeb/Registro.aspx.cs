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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {



                if (!IsPostBack)
                {
                    if (Request.QueryString["Id"] == null)
                    {
                        btnEditar.Visible = false;
                        btnEliminar.Visible = false;

                    }
                    else
                    {
                        User user = new User();
                        string id = Request.QueryString["Id"];
                        UserNegocio userNegocio = new UserNegocio();
                        user = userNegocio.BuscarPorId(id);


                        User usuario = Session["user"] as User;
                        if (usuario.Admin)
                        {
                            txtPass.Text = user.Pass;
                            txtPass.ReadOnly = true;
                            cbxAdmin.Visible = true;
                            btnEliminar.Visible = true;
                        }
                        else
                        {
                            btnEliminar.Visible = false;

                            cbxAdmin.Visible = false;
                            txtPass.Visible = true;
                            txtPass.Text = user.Pass;

                        }

                        btnEditar.Visible = true;

                        btnRegistrarse.Visible = false;

                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtEmail.Text = user.Email;
                        txtPass.Text = user.Pass;



                        // Asignar la imagen si existe, de lo contrario, usar una imagen por defecto
                        if (!string.IsNullOrEmpty(user.UrlImagenPerfil) && userNegocio.verificarImagen(user))
                        {
                            imgPerfil.ImageUrl = user.UrlImagenPerfil;
                        }
                        else if (user.UrlImagenPerfil.Contains("Perfil-"))
                        {
                            imgPerfil.ImageUrl = "~/Imagenes/Perfil/Perfil-" + user.Email + ".jpg";
                        }
                        else
                        {
                            imgPerfil.ImageUrl = "Imagenes/noImage.jpg";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }



        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {

                User newUser = new User();
                UserNegocio userNegocio = new UserNegocio();
                newUser.Nombre = txtNombre.Text;
                newUser.Email = txtEmail.Text;
                newUser.Pass = txtPass.Text;
                newUser.Apellido = txtApellido.Text;

                if (!string.IsNullOrEmpty(txtUrlImagenPerfil.Value))
                {
                    string ruta = Server.MapPath("./Imagenes/Perfil/");

                    string rutaImagen = ruta + "perfil-" + txtEmail.Text + ".jpg";
                    txtUrlImagenPerfil.PostedFile.SaveAs(rutaImagen);
                    newUser.UrlImagenPerfil = "perfil-" + txtEmail.Text + ".jpg";
                }
                else
                {
                    newUser.UrlImagenPerfil = DBNull.Value.ToString();
                }


                if (!(string.IsNullOrEmpty(newUser.Nombre) || string.IsNullOrEmpty(newUser.Apellido) || string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.Pass)))
                {

                    if (userNegocio.Registro(newUser))
                    {
                        Session.Add("error", "Email en uso");
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);

                    }



                }
                else
                {
                    Session.Add("error", "No se aceptan campos vacios exepto de la imagen");
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
            try
            {
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            UserNegocio userNegocio = new UserNegocio();

            newUser.Nombre = txtNombre.Text;
            newUser.Email = txtEmail.Text;
            newUser.Apellido = txtApellido.Text;
            newUser.Pass = txtPass.Text;
            newUser.Id = int.Parse(Request.QueryString["Id"]);
            newUser.Admin = cbxAdmin.Checked;
            if (!string.IsNullOrEmpty(txtUrlImagenPerfil.Value))
            {
                string ruta = Server.MapPath("./Imagenes/Perfil/");

                string rutaImagen = ruta + "perfil-" + txtEmail.Text + ".jpg";
                txtUrlImagenPerfil.PostedFile.SaveAs(rutaImagen);
                newUser.UrlImagenPerfil = "perfil-" + txtEmail.Text + ".jpg";
            }
            else
            {
                newUser.UrlImagenPerfil = DBNull.Value.ToString();
            }


            if (userNegocio.ActualizarUser(newUser))
            {
                Session.Add("error", "Email en uso");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                User user = (User)Session["user"] as User;
                if (user.Admin)
                {
                    Response.Redirect("PanelAdmin.aspx", false);

                }
                else
                {
                    Response.Redirect("Default.aspx", false);

                }
            }


        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            UserNegocio userNegocio = new UserNegocio();
            userNegocio.Eliminar(Request.QueryString["Id"]);
            Response.Redirect("PanelAdmin.aspx", false);

        }
    }
}