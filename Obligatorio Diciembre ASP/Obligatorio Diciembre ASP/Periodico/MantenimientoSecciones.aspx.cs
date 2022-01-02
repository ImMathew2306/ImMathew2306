using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Logica;
using EntidadesCompartidas;

public partial class MantenimientoSecciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
            LimpioFormulario();

    }

    private void LimpioFormulario()
    {
        txtCodeSec.Enabled = true;
        txtNombreSec.Enabled = false;
        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;

        txtNombreSec.Text = "";
        txtCodeSec.Text = "";
        lblError.Text = "";
    }

    private void ActivoBotones(bool alta=true)
    {
        btnBuscar.Enabled = false;
        btnAgregar.Enabled = alta;
        btnModificar.Enabled = !alta;
        btnEliminar.Enabled = !alta;

        txtCodeSec.Enabled = false;
        txtNombreSec.Enabled = true;
    
    
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string codesec ;
            try
            {
                codesec = Convert.ToString(txtCodeSec.Text.Trim());


            }
            catch
            {

                throw new Exception("El codigo no puede estar vacio");

            }

            Secciones sec = LogicaSeccion.Buscar(codesec);
            if (sec != null)
            {
                txtCodeSec.Text = sec.CodigoSecciones;
                txtNombreSec.Text = sec.NombreSeccion;
                ActivoBotones(false);
                Session["UnaSeccion"] = sec;
            }
            else
            {

                ActivoBotones();
                lblError.ForeColor = Color.Purple;
                lblError.Text = "No existe una seccion con ese codigo ";
                Session["UnaSeccion"] = null;
            }

        }
        catch (Exception ex)
        {

            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string nombre = txtNombreSec.Text.Trim();
            string codigosec = txtCodeSec.Text.Trim();

            Secciones seccion = (Secciones)Session["UnaSeccion"];
            seccion.CodigoSecciones = codigosec;
            seccion.NombreSeccion = nombre;
            LogicaSeccion.Modificar(seccion);
            LimpioFormulario();
            lblError.ForeColor = Color.Green;
            lblError.Text = "Modificacion Exitosa";


        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }


    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Secciones seccion = (Secciones)Session["UnaSeccion"];
            LogicaSeccion.Eliminar(seccion);
            LimpioFormulario();
            lblError.ForeColor = Color.Green;
            lblError.Text = "Eliminaciòn Exitosa";


        }
        catch (Exception ex)
        {

            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigosec = Convert.ToString(txtCodeSec.Text.Trim());
            string nombre=Convert.ToString(txtNombreSec.Text.Trim());

            Secciones seccion = new Secciones(codigosec,nombre);
            LogicaSeccion.Agregar(seccion);
            LimpioFormulario();
            lblError.ForeColor = Color.Green;
            lblError.Text = "Alta Con exito";

        }
        catch (Exception ex)
        {

            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}