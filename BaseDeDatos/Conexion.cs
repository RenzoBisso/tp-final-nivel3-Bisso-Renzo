using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class Conexion
    {


        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public Conexion()
        {

            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void setQuery(string consulta)
        {
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }


        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

        public void setParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarAccion()
        {
            try
            {

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

    }
}
