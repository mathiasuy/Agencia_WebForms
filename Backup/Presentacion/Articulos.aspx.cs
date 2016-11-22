using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Logica;

namespace SegundoObligatorio
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected static int numero;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlFuente.DataSource = LogicaFuente.ListarFuentes();
                    ddlFuente.DataTextField = "Nombre";
                    ddlFuente.DataValueField = "Id";
                    ddlFuente.DataBind();

                    if (ddlFuente.Items.Count == 0)
                    {
                        lblMensaje.Text = "¡Atención! No hay fuentes disponibles.";
                    }
                }

                ddlFuente.Focus();
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al cargar la página.";
            }
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                int id;    
                try
                {
                    id = Convert.ToInt32(txtId.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Id no es un número entero válido.");
                }


                limpiarFormulario();
                Articulo articulo = LogicaArticulo.BuscarArticulo(id);

                
                txtId.Text = articulo.Id.ToString();
                ddlFuente.SelectedValue = articulo.Fuente.Id.ToString();
                txtSeccion.Text = articulo.Seccion;
                chkImagenIlustrativa.Checked = articulo.ImagenIlustrativa;
                txtCosto.Text = articulo.Costo.ToString();
                txtContenido.Text = articulo.Contenido;
                
                lblMensaje.Text = "☺¡Artículo encontrado!";
                txtId.Focus();

            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al buscar el artículo.";
            }
        }

        protected void btnDarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Fuente fuente = LogicaFuente.BuscarFuente(Convert.ToInt32(ddlFuente.SelectedValue));
                string seccion = txtSeccion.Text;
                bool imagenIlustrativa = chkImagenIlustrativa.Checked;

                decimal costo;

                try
                {
                    costo = Convert.ToDecimal(txtCosto.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Costo no es un número decimal válido.");
                }

                string contenido = txtContenido.Text;

                Articulo articulo = new Articulo(0, seccion, imagenIlustrativa, costo, contenido, fuente);

                int id;
                LogicaArticulo.DarAltaArticulo(articulo,out id);

                limpiarFormulario();
                txtId.Text = id.ToString();
                lblMensaje.Text = "☺¡Artículo dado de alta con éxito con Id: " + id + "!";
                txtId.Focus();
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al dar de alta el artículo.";
            }
        }

        protected void btnDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                int id;

                try
                {
                    id = Convert.ToInt32(txtId.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Id no es un número entero válido.");
                }

                LogicaArticulo.DarBajaArticulo(id);

                limpiarFormulario();

                lblMensaje.Text = "☺¡Artículo dado de baja con éxito!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al dar de baja el artículo.";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id;

                try
                {
                    id = Convert.ToInt32(txtId.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Id no es un número entero válido.");
                }

                Fuente fuente = LogicaFuente.BuscarFuente(Convert.ToInt32(ddlFuente.SelectedValue));
                string seccion = txtSeccion.Text;
                bool imagenIlustrativa = chkImagenIlustrativa.Checked;

                decimal costo;

                try
                {
                    costo = Convert.ToDecimal(txtCosto.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Costo no es un número decimal válido.");
                }

                string contenido = txtContenido.Text;

                Articulo articulo = new Articulo(id, seccion, imagenIlustrativa, costo, contenido, fuente);

                LogicaArticulo.ModificarArticulo(articulo);

                limpiarFormulario();

                lblMensaje.Text = "☺¡Artículo modificado con éxito!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al modificar el artículo.";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarFormulario();
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al limpiar el formulario.";
            }
        }

        protected void limpiarFormulario()
        {
            txtId.Text = string.Empty;

            if (ddlFuente.Items.Count > 0)
            {
                ddlFuente.SelectedIndex = 0;
            }

            txtSeccion.Text = string.Empty;
            chkImagenIlustrativa.Checked = false;
            txtCosto.Text = string.Empty;
            txtContenido.Text = string.Empty;

            lblMensaje.Text = string.Empty;
        }
    }
}
