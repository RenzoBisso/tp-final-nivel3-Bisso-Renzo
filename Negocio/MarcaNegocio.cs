using BaseDeDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        Conexion conexion = new Conexion();


        public List<Marca> ListarMarca()
        {

            try
            {
                List<Marca> listaMarca = new List<Marca>();

                conexion.setQuery("select Id,Descripcion from MARCAS");
                conexion.ejecutarLectura();
                while (conexion.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)conexion.Lector["Id"];
                    marca.Descripcion = (string)conexion.Lector["Descripcion"];
                    listaMarca.Add(marca);

                }
                return listaMarca;
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

        public int DevolverId(string descripcion)
        {

            try
            {

                conexion.setParametro("@Descripcion", descripcion);
                conexion.setQuery("select Id from MARCAS where Descripcion=@Descripcion");
                conexion.ejecutarLectura();
                if (conexion.Lector.Read())
                {
                    int valor = (int)conexion.Lector["Id"];
                    return valor;
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


        public void EditarMarca(string Id, string Descripcion)
        {
            try
            {
                conexion.setParametro("@Id", Id);
                conexion.setParametro("@Descripcion", Descripcion);
                conexion.setQuery("update MARCAS set Descripcion=@Descripcion where Id=@Id");
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

        public void EliminarMarca(string Id)
        {
            try
            {
                conexion.setParametro("@Id", Id);
                conexion.setQuery("delete from MARCAS where Id=@Id");
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
        public void CargarMarca(string nombre)
        {
            try
            {
                conexion.setParametro("@Nombre", nombre);
                conexion.setQuery("insert into MARCAS (Descripcion) values (@Nombre)");
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

        public string DevolverNombre(int id)
        {

            try
            {
                conexion.setParametro("@Id", id);
                conexion.setQuery("select Descripcion from MARCAS where Id=@Id");
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



    }


}

