using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Logica;

namespace SegundoObligatorio
{
    public partial class Ediciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    calFechaPublicacion.SelectedDate = DateTime.Today;
                    calFechaPublicacion.VisibleDate = calFechaPublicacion.SelectedDate;

                    ddlArticulo.DataSource = LogicaArticulo.ListarArticulos();
                    ddlArticulo.DataTextField = "ATexto";
                    ddlArticulo.DataValueField = "Id";
                    ddlArticulo.DataBind();

                    if (ddlArticulo.Items.Count == 0)
                    {
                        lblMensaje.Text = "¡Atención! No hay artículos disponibles.";
                    }
                }

                txtNumero.Focus();
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

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlArticulo.SelectedIndex != -1)
                {
                    bool articuloAgregado = false;

                    foreach (ListItem li in lstArticulos.Items)
                    {
                        if (li.Value == ddlArticulo.SelectedValue)
                        {
                            articuloAgregado = true;

                            break;
                        }
                    }

                    if (!articuloAgregado)
                    {
                        lstArticulos.Items.Add(new ListItem(ddlArticulo.SelectedItem.Text, ddlArticulo.SelectedValue));
                    }
                }
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al agregar el artículo.";
            }
        }

        protected void btnQuitarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstArticulos.SelectedIndex != -1)
                {
                    lstArticulos.Items.RemoveAt(lstArticulos.SelectedIndex);
                }
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al quitar el artículo.";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;

                try
                {
                    numero = Convert.ToInt32(txtNumero.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Número no es un número entero válido.");
                }
                limpiarFormulario();
                Edicion edicion = LogicaEdicion.BuscarEdicion(numero);

                
                txtNumero.Text = edicion.Numero.ToString();
                calFechaPublicacion.SelectedDate = edicion.FechaPublicacion;
                calFechaPublicacion.VisibleDate = calFechaPublicacion.SelectedDate;
                List<Articulo> articulosXedicion = LogicaEdicion.ListarArticulosXEdicion(edicion.Numero);
                
                foreach (Articulo a in articulosXedicion)
                    {
                        lstArticulos.Items.Add(new ListItem(a.ToString(), a.Id.ToString()));
                    }

                lblMensaje.Text = "☺¡Edición encontrada!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al buscar la edición.";
            }
        }

        protected void btnDarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;

                try
                {
                    numero = Convert.ToInt32(txtNumero.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Número no es un número entero válido.");
                }

                DateTime fechaPublicacion = calFechaPublicacion.SelectedDate;

                Edicion edicion = new Edicion(numero, fechaPublicacion);

                Articulo articulo;

                foreach (ListItem li in lstArticulos.Items)
                {
                    articulo = LogicaArticulo.BuscarArticulo(Convert.ToInt32(li.Value));

                    edicion.AgregarArticulo(articulo);
                }

                LogicaEdicion.AltaEdicion(edicion);

                limpiarFormulario();

                lblMensaje.Text = "☺¡Edición dada de alta con éxito!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al dar de alta la edición.";
            }
        }

        protected void btnDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;

                try
                {
                    numero = Convert.ToInt32(txtNumero.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Número no es un número entero válido.");
                }

                LogicaEdicion.BajaEdicion(numero);

                limpiarFormulario();

                lblMensaje.Text = "☺¡Edición dada de baja con éxito!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al dar de baja la edición.";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;

                try
                {
                    numero = Convert.ToInt32(txtNumero.Text);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPresentacion("El Id no es un número entero válido.");
                }

                DateTime fechaPublicacion = calFechaPublicacion.SelectedDate;

                Edicion edicion = new Edicion(numero, fechaPublicacion);

                Articulo articulo;

                foreach (ListItem li in lstArticulos.Items)
                {
                    articulo = LogicaArticulo.BuscarArticulo(Convert.ToInt32(li.Value));

                    edicion.AgregarArticulo(articulo);
                }

                LogicaEdicion.ModificarEdicion(edicion);

                limpiarFormulario();

                lblMensaje.Text = "☺¡Edición modificada con éxito!";
            }
            catch (ExcepcionSistema ex)
            {
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al modificar la edición.";
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
                lblMensaje.Text = "¡Error! " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al limpiar el formulario.";
            }
        }

        protected void limpiarFormulario()
        {
            txtNumero.Text = string.Empty;
            calFechaPublicacion.SelectedDate = DateTime.Today;
            calFechaPublicacion.VisibleDate = calFechaPublicacion.SelectedDate;

            if (ddlArticulo.Items.Count > 0)
            {
                ddlArticulo.SelectedIndex = 0;
            }

            lstArticulos.Items.Clear();

            lblMensaje.Text = string.Empty;
        }


    }
}
