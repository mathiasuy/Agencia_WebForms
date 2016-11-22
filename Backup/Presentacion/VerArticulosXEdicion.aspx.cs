using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ExcepcionesPersonalizadas;
using EntidadesCompartidas;
using Logica;

namespace Presentacion
{
    public partial class VerArticulosXEdicion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlEdicion.DataSource = LogicaEdicion.ListarEdiciones();
                    ddlEdicion.DataTextField = "Numero";
                    ddlEdicion.DataBind();

                    if (ddlEdicion.Items.Count == 0)
                    {
                        lblMensaje.Text = "¡Atención! No hay ediciones disponibles.";
                    }
                }

                cargarArticulos();

                ddlEdicion.Focus();
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al cargar la página.";
            }

        }

        protected void ddlEdicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarArticulos();
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al cargar los artículos.";
            }
        }

        protected void cargarArticulos()
        {
            if (ddlEdicion.SelectedIndex != -1)
            {
                List<Articulo> articulos = LogicaEdicion.ListarArticulosXEdicion(Convert.ToInt32(ddlEdicion.SelectedItem.Text));
                
                List<Articulo> ar = new List<Articulo>();

                foreach (Articulo a in articulos)
                {
                    if (!pertenece(ar, a))
                    {
                        ar.Add(a);
                    }
                }
                

                grdArticulos.DataSource = ar;
                grdArticulos.DataBind();
                lblMensaje.Text = "";
                if (ar.Count == 0) lblMensaje.Text = "No se han encontrado resultados para tu búsqueda ";
            }
        }

        protected bool pertenece(List<Articulo> articulos, Articulo articulo)
        {
            foreach (Articulo a in articulos)
            {
                if (a.Id == articulo.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Edicion> ediciones { get; set; }
    }
}