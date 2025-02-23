using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using BaseDeDatos;
using System.Net;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace Negocio
{
    public class ArticuloNegocio
    {


        public bool verificarImagen(Articulo articulo)
        {
            try
            {
                // Crear la solicitud HTTP
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(articulo.ImagenUrl);
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

        public void EliminarArticulo(int id)
        {
            try
            {
                Conexion conexion = new Conexion();

                conexion.setParametro("@Id", id);
                conexion.setQuery("delete from ARTICULOS where Id=@Id");
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool EsVacio(Articulo articulo)
        {

            if (string.IsNullOrEmpty(articulo.Descripcion) || string.IsNullOrEmpty(articulo.Nombre) || string.IsNullOrEmpty(articulo.Precio.ToString()) || string.IsNullOrEmpty(articulo.Marca) || string.IsNullOrEmpty(articulo.Codigo) || string.IsNullOrEmpty(articulo.Categoria))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public List<Articulo> listarArticulos()
        {
            try
            {
                List<Articulo> listaDeArticulos = new List<Articulo>();


                Conexion conexion = new Conexion();

                conexion.setQuery("select Id,Codigo, Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio from ARTICULOS");
                conexion.ejecutarLectura();
                while (conexion.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    MarcaNegocio marca = new MarcaNegocio();

                    articulo.Id = (int)conexion.Lector["Id"];
                    articulo.Codigo = (string)conexion.Lector["Codigo"];
                    articulo.Nombre = (string)conexion.Lector["Nombre"];
                    articulo.Descripcion = (string)conexion.Lector["Descripcion"];
                    articulo.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    articulo.Precio = Math.Round((decimal)conexion.Lector["Precio"], 2);
                    articulo.Categoria = categoria.DevolverNombre((int)conexion.Lector["IdCategoria"]);
                    articulo.Marca = marca.DevolverNombre((int)conexion.Lector["IdMarca"]);




                    listaDeArticulos.Add(articulo);

                }
                return listaDeArticulos;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return null;
        }

        public List<Articulo> listarArticulos(int idMarca)
        {
            try
            {
                Conexion conexion = new Conexion();

                List<Articulo> listaDeArticulos = new List<Articulo>();

                conexion.setParametro("@Marca", idMarca);



                conexion.setQuery("select Id,Codigo, Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio from ARTICULOS where IdMarca=@Marca");
                conexion.ejecutarLectura();
                while (conexion.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    MarcaNegocio marca = new MarcaNegocio();

                    articulo.Id = (int)conexion.Lector["Id"];
                    articulo.Codigo = (string)conexion.Lector["Codigo"];
                    articulo.Nombre = (string)conexion.Lector["Nombre"];
                    articulo.Descripcion = (string)conexion.Lector["Descripcion"];
                    articulo.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)conexion.Lector["Precio"];
                    articulo.Categoria = categoria.DevolverNombre((int)conexion.Lector["IdCategoria"]);
                    articulo.Marca = marca.DevolverNombre((int)conexion.Lector["IdMarca"]);


                    listaDeArticulos.Add(articulo);

                }
                return listaDeArticulos;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return null;
        }


        public List<Articulo> listarArticulos(string nombre)
        {

            try
            {
                Conexion conexion = new Conexion();

                List<Articulo> listaDeArticulos = new List<Articulo>();

                conexion.setParametro("@Nombre", "%" + nombre + "%");

                conexion.setQuery("select Id,Codigo, Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio from ARTICULOS where Nombre like @Nombre");
                conexion.ejecutarLectura();
                while (conexion.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    MarcaNegocio marca = new MarcaNegocio();

                    articulo.Id = (int)conexion.Lector["Id"];
                    articulo.Codigo = (string)conexion.Lector["Codigo"];
                    articulo.Nombre = (string)conexion.Lector["Nombre"];
                    articulo.Descripcion = (string)conexion.Lector["Descripcion"];
                    articulo.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)conexion.Lector["Precio"];
                    articulo.Categoria = categoria.DevolverNombre((int)conexion.Lector["IdCategoria"]);
                    articulo.Marca = marca.DevolverNombre((int)conexion.Lector["IdMarca"]);

                    listaDeArticulos.Add(articulo);

                }
                return listaDeArticulos;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return null;
        }
        public Articulo BuscarPorId(string id)
        {

            try
            {
                Conexion conexion = new Conexion();

                CategoriaNegocio categoria = new CategoriaNegocio();
                MarcaNegocio marca = new MarcaNegocio();

                conexion.setParametro("@Id", int.Parse(id));
                conexion.setQuery("select Id,Codigo, Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio from ARTICULOS where Id=@Id");
                conexion.ejecutarLectura();
                if (conexion.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)conexion.Lector["Id"];
                    articulo.Codigo = (string)conexion.Lector["Codigo"];
                    articulo.Nombre = (string)conexion.Lector["Nombre"];
                    articulo.Descripcion = (string)conexion.Lector["Descripcion"];
                    articulo.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)conexion.Lector["Precio"];
                    articulo.Categoria = categoria.DevolverNombre((int)conexion.Lector["IdCategoria"]);
                    articulo.Marca = marca.DevolverNombre((int)conexion.Lector["IdMarca"]);
                    return articulo;

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return null;

        }


        public void EditarArticulo(Articulo articuloEditado)
        {
            try
            {
                Conexion conexion = new Conexion();

                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();


                conexion.setParametro("@Codigo", articuloEditado.Codigo);
                conexion.setParametro("@Nombre", articuloEditado.Nombre);
                conexion.setParametro("@Descripcion", articuloEditado.Descripcion);
                conexion.setParametro("@Precio", articuloEditado.Precio);
                conexion.setParametro("@IdMarca", marcaNegocio.DevolverId(articuloEditado.Marca));
                conexion.setParametro("@IdCategoria", categoriaNegocio.DevolverId(articuloEditado.Categoria));
                conexion.setParametro("@ImagenUrl", articuloEditado.ImagenUrl);
                conexion.setParametro("@Id", articuloEditado.Id);
                conexion.setQuery("update ARTICULOS set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, Precio=@Precio, IdMarca=@IdMarca, IdCategoria=@IdCategoria, ImagenUrl=@ImagenUrl where Id=@Id");
                conexion.ejecutarAccion();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Articulo> listarArticulosSeccion(int seccion)
        {

            try
            {
                List<Articulo> listaDeArticulos = new List<Articulo>();
                Conexion conexion = new Conexion();

                conexion.setParametro("@Seccion", seccion);



                conexion.setQuery("select Id,Codigo, Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio from ARTICULOS where IdCategoria=@Seccion");
                conexion.ejecutarLectura();
                while (conexion.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    MarcaNegocio marca = new MarcaNegocio();

                    articulo.Id = (int)conexion.Lector["Id"];
                    articulo.Codigo = (string)conexion.Lector["Codigo"];
                    articulo.Nombre = (string)conexion.Lector["Nombre"];
                    articulo.Descripcion = (string)conexion.Lector["Descripcion"];
                    articulo.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)conexion.Lector["Precio"];
                    articulo.Categoria = categoria.DevolverNombre((int)conexion.Lector["IdCategoria"]);
                    articulo.Marca = marca.DevolverNombre((int)conexion.Lector["IdMarca"]);

                    listaDeArticulos.Add(articulo);

                }
                return listaDeArticulos;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return null;
        }

        public void AgregarArticulo(Articulo articuloNuevo)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Conexion conexion = new Conexion();

                conexion.setParametro("@Codigo", articuloNuevo.Codigo);
                conexion.setParametro("@Nombre", articuloNuevo.Nombre);
                conexion.setParametro("@Descripcion", articuloNuevo.Descripcion);
                conexion.setParametro("@IdMarca", marcaNegocio.DevolverId(articuloNuevo.Marca));
                conexion.setParametro("@IdCategoria", categoriaNegocio.DevolverId(articuloNuevo.Categoria));
                conexion.setParametro("@ImagenUrl", articuloNuevo.ImagenUrl);
                conexion.setParametro("@Precio", articuloNuevo.Precio);

                conexion.setQuery("insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl, Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)");
                conexion.ejecutarAccion();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

