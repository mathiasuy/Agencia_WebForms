using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = DateTime.Now.ToString("G");
            }
            catch
            {
                lblMensaje.Text = "No se pudo cargar la pagina.";
            }
        }
    }
}