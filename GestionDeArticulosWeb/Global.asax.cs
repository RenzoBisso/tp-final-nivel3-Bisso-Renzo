using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace GestionDeArticulosWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }
        void Applicaction_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Console.WriteLine(ex.Message);
            Session.Add("error", "Hubo un problema con el servidor");
            Server.Transfer("Error.aspx");
        }
    }
}