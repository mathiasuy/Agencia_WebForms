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
    public partial class PeriodistasIndependientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtId.Focus();
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
                    throw new ExcepcionPresentacion("El ID no es un número entero válido.");
                }
                limpiarFormulario();
                Periodista periodista  = LogicaFuente.BuscarPeriodista(id);

                txtId.Text = periodista.Id.ToString();
                txtDireccion.Text=periodista.Direccion;
                txtNombre.Text = periodista.Nombre;
                txtDocumento.Text = periodista.DocumentoIdentidad;
                txtTelefono.Text = periodista.Telefono;

                lblMensaje.Text = "☺¡Periodista encontrado!";
            
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! no se encontró el periodista";
            }       
        }

        protected void limpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;


            lblMensaje.Text = string.Empty;

            txtId.Focus();
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

                    // limpiarFormulario();
                    Fuente periodista = new Periodista(
                        id,
                        txtNombre.Text,
                        txtDocumento.Text,
                        txtDireccion.Text,
                        txtTelefono.Text
                            );
                        
                    Logica.LogicaFuente.AltaFuente(periodista);
                    limpiarFormulario();    
                        lblMensaje.Text = "☺¡Periodista ingresado!";
                }
                catch (ExcepcionSistema ex)
                {
                    lblMensaje.Text = ex.Message;
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "¡Error! No se pudo dar de alta el Periodista";
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

                LogicaFuente.BajaPeriodista(id);

                limpiarFormulario();
                lblMensaje.Text = "☺¡Periodista borrado!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! No se pudo dar de baja el Periodista";
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
                     
                    Fuente periodista = new Periodista(
                        id,
                        txtNombre.Text,
                        txtDocumento.Text,
                        txtDireccion.Text,
                        txtTelefono.Text
                            );
                        Logica.LogicaFuente.ModificarFuente(periodista);
                        limpiarFormulario();
                        lblMensaje.Text = "☺¡Periodista modificado!";
                }
              catch (ExcepcionSistema ex)
              {
                  lblMensaje.Text = ex.Message;
              }
              catch (Exception ex)
                {
                    lblMensaje.Text = "¡Error! No se pudo modificar el Periodista";
                }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }
    }
}