using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sessionActiva(Object user)
        {
            User userSession = user != null ? (User)user : null;
            if (userSession != null && userSession.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool esAdmin(Object user)
        {
            if (sessionActiva(user))
            {
                User userAdmin = new User();
                userAdmin = (User)user;
                if (userAdmin.Admin == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
