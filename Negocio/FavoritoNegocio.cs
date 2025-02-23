using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDatos;

namespace Negocio
{
    public class FavoritoNegocio
    {
        Conexion conexion = new Conexion();




        public void AgregarFavorito(string idUser, string idArticulo)
        {
            try
            {

                conexion.setParametro("@idUser", idUser);
                conexion.setParametro("@idArticulo", idArticulo);
                conexion.setQuery("insert into FAVORITOS (IdUser,IdArticulo) values (@idUser,@idArticulo)");
                conexion.ejecutarAccion();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Esta(string idUser, string idArticulo)
        {
            try
            {
                conexion.setParametro("@idUser", idUser);
                conexion.setParametro("@idArticulo", idArticulo);
                conexion.setQuery("Select * from FAVORITOS where IdUser=@idUser and idArticulo=@idArticulo");
                conexion.ejecutarLectura();

                if (conexion.Lector.Read())
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public void Eliminar(string idUser, string idArticulo)
        {
            try
            {
                conexion.setParametro("@idUser", idUser);
                conexion.setParametro("@idArticulo", idArticulo);
                conexion.setQuery("delete from FAVORITOS where IdUser=@idUser and idArticulo=@idArticulo");
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Favorito> ListarFavoritos(string idUser)
        {

            try
            {
                conexion.setParametro("@idUser", idUser);
                conexion.setQuery("Select Id, IdUser,IdArticulo from FAVORITOS where IdUser=@idUser");
                conexion.ejecutarLectura();
                List<Favorito> favoritos = new List<Favorito>();
                while (conexion.Lector.Read())
                {
                    Favorito favorito = new Favorito();

                    favorito.Id = (int)conexion.Lector["Id"];
                    favorito.IdUser = (int)conexion.Lector["IdUser"];
                    favorito.IdArticulo = (int)conexion.Lector["IdArticulo"];
                    favoritos.Add(favorito);
                }
                return favoritos;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }



    }
}
