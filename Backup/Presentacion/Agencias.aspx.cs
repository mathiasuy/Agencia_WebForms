using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Logica;

namespace Presentacion
{
    public partial class Agencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtId.Focus();
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

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                try
                {
                    id = Convert.ToInt32(txtId.Text);
                }
                catch
                {
                    throw new ExcepcionPresentacion("El ID no es un número entero válido.");
                }
                
                Fuente periodista = new Agencia(
                    id,
                    txtNombre.Text,
                    txtPaisDeOrigen.Text
                        );

                Logica.LogicaFuente.AltaFuente(periodista);
                limpiarFormulario();
                lblMensaje.Text = "☺¡Agencia ingresada!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! No se pudo dar de alta la Agencia";
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
                catch
                {
                    throw new ExcepcionPresentacion("El número no es un número entero válido.");
                }
                limpiarFormulario();
                Agencia agencia = LogicaFuente.BuscarAgencia(id);
                
                txtId.Text = agencia.Id.ToString();
                txtNombre.Text = agencia.Nombre;
                txtPaisDeOrigen.Text = agencia.PaisOrigen;
                
                lblMensaje.Text = "☺¡Agencia encontrada!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! No se pudo buscar la Agencia.";
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
                catch
                {
                    throw new ExcepcionPresentacion("El ID no es un número entero válido.");
                }

                Fuente agencia = new Agencia(
                    id,
                    txtNombre.Text,
                    txtPaisDeOrigen.Text
                        );
                
                Logica.LogicaFuente.ModificarFuente(agencia);
                limpiarFormulario();
                lblMensaje.Text = "☺¡Agencia modificada!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! No se pudo modificar la Agencia";
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                int id;

                try
                {
                    id = Convert.ToInt32(txtId.Text);
                }
                catch
                {
                    throw new ExcepcionPresentacion("El ID no es un número entero válido.");
                }

                LogicaFuente.BajaAgencia(id);
                limpiarFormulario();
                lblMensaje.Text = "☺¡Agencia borrada!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! No se pudo dar de baja la Agencia";
            }       
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        protected void limpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPaisDeOrigen.Text = string.Empty;

            lblMensaje.Text = string.Empty;

            txtId.Focus();
        }
    }
}