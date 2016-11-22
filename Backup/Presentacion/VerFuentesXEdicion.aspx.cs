using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ExcepcionesPersonalizadas;
using Logica;
using EntidadesCompartidas;

namespace Presentacion
{
    public partial class VerFuentesXEdicion : System.Web.UI.Page
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

                cargarFuentes();

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
                cargarFuentes();
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al cargar las fuentes.";
            }
        }
 
        protected void ddlFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarFuentes();
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al cargar las fuentes.";
            }
        }


        protected void cargarFuentes()
        {
            List<Fuente> fu = new List<Fuente>();

            if (ddlEdicion.SelectedIndex != -1 && ddlFuente.SelectedIndex != -1)
            {
                List<Fuente> fuentes = new List<Fuente>();
                switch (ddlFuente.SelectedItem.Text)
                {
                    case "Agencias de Noticias":
                        fuentes = LogicaEdicion.ListarAgenciasXEdicion(Convert.ToInt32(ddlEdicion.SelectedValue));
                        break;
                    case "Periodistas Independientes":
                        fuentes = LogicaEdicion.ListarPeriodistasXEdicion(Convert.ToInt32(ddlEdicion.SelectedValue));
                        break;
                    case "Todas":
                        fuentes = LogicaEdicion.ListarAgenciasXEdicion(Convert.ToInt32(ddlEdicion.SelectedValue));
                        fuentes.AddRange(LogicaEdicion.ListarPeriodistasXEdicion(Convert.ToInt32(ddlEdicion.SelectedValue)));
                       break;
                }

                foreach (Fuente f in fuentes)
                {
                    if (!pertenece(fu,f))
                    {
                        fu.Add(f);
                    }
                }
                
                grdFuentes.DataSource = fu;
                grdFuentes.DataBind();
                lblMensaje.Text = "";
                if (fu.Count == 0) lblMensaje.Text = "No se han encontrado resultados para tu búsqueda ";
            }
        }

        protected bool pertenece(List<Fuente> fuentes, Fuente fuente)
        {
            foreach (Fuente f in fuentes)
            {
                if (f.Id == fuente.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}