using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDatos;
using Modelo;
namespace Negocio
{
    public class CategoriaNegocio
    {

        Conexion conexion = new Conexion();

        public bool esVacio(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Descripcion))
            {
                return false;
            }
            else
            {
                return true;
            }


        }
        public List<Categoria> ListarCategoria()
        {

            try
            {
                List<Categoria> listaCategoria = new List<Categoria>();

                conexion.setQuery("select Id,Descripcion from CATEGORIAS");
                conexion.ejecutarLectura();
                while (conexion.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)conexion.Lector["Id"];
                    categoria.Descripcion = (string)conexion.Lector["Descripcion"];
                    listaCategoria.Add(categoria);

                }
                return listaCategoria;
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


        public string DevolverNombre(int id)
        {

            try
            {
                conexion.setParametro("@Id", id);
                conexion.setQuery("select Descripcion from CATEGORIAS where Id=@Id");
                conexion.ejecutarLectura();
                if (conexion.Lector.Read())
                {
                    return (string)conexion.Lector["Descripcion"];
                }
                else
                {
                    return null;
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

        public int DevolverId(string descripcion)
        {

            try
            {

                conexion.setParametro("@Descripcion", descripcion);
                conexion.setQuery("select Id from CATEGORIAS where Descripcion=@Descripcion");
                conexion.ejecutarLectura();
                if (conexion.Lector.Read())
                {
                    return (int)conexion.Lector["Id"];
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
            return -1;
        }
        public void EditarCategoria(string Id, string Descripcion)
        {
            try
            {
                conexion.setParametro("@Id", Id);
                conexion.setParametro("@Descripcion", Descripcion);
                conexion.setQuery("update CATEGORIAS set Descripcion=@Descripcion where Id=@Id");
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

        public void EliminarCategoria(string Id)
        {
            try
            {
                conexion.setParametro("@Id", Id);
                conexion.setQuery("delete from CATEGORIAS where Id=@Id");
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
        public void CargarCategoria(string nombre)
        {
            try
            {
                conexion.setParametro("@Nombre", nombre);
                conexion.setQuery("insert into CATEGORIAS (Descripcion) values (@Nombre)");
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

    }


}
