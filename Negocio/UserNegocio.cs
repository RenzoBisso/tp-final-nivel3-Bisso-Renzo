using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BaseDeDatos;
using Modelo;

namespace Negocio
{
    public class UserNegocio
    {

        Conexion conexion = new Conexion();




        public User Logear(string email, string pass)
        {
            User user = new User();

            try
            {
                conexion.setParametro("@email", email);
                conexion.setParametro("@pass", pass);

                conexion.setQuery("select Id,email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where pass=@pass and email=@email");
                conexion.ejecutarLectura();

                if (conexion.Lector.Read())
                {
                    user.Nombre = (string)conexion.Lector["nombre"];
                    user.Apellido = (string)conexion.Lector["apellido"];
                    user.UrlImagenPerfil = (string)conexion.Lector["urlImagenPerfil"];
                    user.Pass = (string)conexion.Lector["pass"];
                    user.Id = (int)conexion.Lector["Id"];
                    user.Email = (string)conexion.Lector["email"];
                    user.Admin = Convert.ToBoolean(conexion.Lector["admin"]);
                    return user;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return null;
        }
        public bool verificarImagen(User user)
        {
            try
            {
                // Crear la solicitud HTTP
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(user.UrlImagenPerfil);
                request.Method = "HEAD";

                // Obtener la respuesta
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        public void Eliminar(string Id)
        {

            try
            {
                conexion.setParametro("@Id", Id);


                conexion.setQuery("delete USERS where Id=@Id ");
                conexion.ejecutarAccion();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }

        }

        public void ActualizarUser(User user)
        {
            try
            {
                conexion.setParametro("@Id", user.Id);
                conexion.setParametro("@nombre", user.Nombre);
                conexion.setParametro("@apellido", user.Apellido);
                conexion.setParametro("@email", user.Email);
                conexion.setParametro("@urlImagenPerfil", user.UrlImagenPerfil);
                conexion.setParametro("@pass", user.Pass);


                if (user.Admin)
                {
                    conexion.setParametro("@admin", 1);

                }
                else
                {
                    conexion.setParametro("@admin", 0);
                }

                conexion.setQuery("UPDATE USERS SET email = @email, nombre = @nombre,pass=@pass ,apellido = @apellido, urlImagenPerfil = @UrlImagenPerfil, admin = @admin WHERE Id = @Id");
                conexion.ejecutarAccion();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Registro(User user)
        {
            try
            {
                conexion.setParametro("@nombre", user.Nombre);
                conexion.setParametro("@apellido", user.Apellido);
                conexion.setParametro("@email", user.Email);
                conexion.setParametro("@pass", user.Pass);
                conexion.setParametro("@urlImagenPerfil", user.UrlImagenPerfil);
                conexion.setParametro("@admin", 0);

                conexion.setQuery("insert into USERS (email,pass,nombre,apellido,urlImagenPerfil,admin) values (@email,@pass,@nombre,@apellido,@UrlImagenPerfil,@admin)");
                conexion.ejecutarAccion();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public User BuscarPorId(string Id)
        {

            try
            {

                User newUser = new User();

                conexion.setParametro("@Id", Id);
                conexion.setQuery("select Id,email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where Id=@Id");
                conexion.ejecutarLectura();

                while (conexion.Lector.Read())
                {

                    newUser.Nombre = (string)conexion.Lector["nombre"];
                    newUser.Apellido = (string)conexion.Lector["apellido"];
                    newUser.UrlImagenPerfil = (string)conexion.Lector["urlImagenPerfil"];
                    newUser.Pass = (string)conexion.Lector["pass"];
                    newUser.Id = (int)conexion.Lector["Id"];
                    newUser.Email = (string)conexion.Lector["email"];
                    newUser.Admin = Convert.ToBoolean(conexion.Lector["admin"]);
                    return newUser;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        public List<User> ListarUsuarios()
        {
            List<User> listaUsuarios = new List<User>();
            try
            {
                conexion.setQuery("select Id,email, pass, nombre, apellido, urlImagenPerfil, admin from USERS");
                conexion.ejecutarLectura();

                while (conexion.Lector.Read())
                {
                    User user = new User();

                    user.Nombre = (string)conexion.Lector["nombre"];
                    user.Apellido = (string)conexion.Lector["apellido"];
                    user.UrlImagenPerfil = (string)conexion.Lector["urlImagenPerfil"];
                    user.Pass = (string)conexion.Lector["pass"];
                    user.Id = (int)conexion.Lector["Id"];
                    user.Email = (string)conexion.Lector["email"];
                    user.Admin = Convert.ToBoolean(conexion.Lector["admin"]);
                    listaUsuarios.Add(user);
                }
                return listaUsuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return null;
        }


    }
}
