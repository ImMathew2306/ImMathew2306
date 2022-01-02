using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Logica;
using EntidadesCompartidas;


public partial class MantenimientoPeriodistas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
        {
            LimpioFomulario();
        
        }

    }

    private void LimpioFomulario()
    {
        txtCodigoPeriodista.Enabled = true;
        txtApellido.Enabled = false;
        txtNombre.Enabled = false;
        txtMail.Enabled = false;

        txtCodigoPeriodista.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtMail.Text = "";

        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        btnLimpiar.Enabled = false;
    
    
    }

    private void ActivoBotones(bool alta = true)
    {
        btnModificar.Enabled = !alta;
        btnEliminar.Enabled = !alta;
        btnAgregar.Enabled = alta;
        btnBuscar.Enabled = false;
        btnLimpiar.Enabled = true;


        txtCodigoPeriodista.Enabled = false;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtMail.Enabled = true;
        
   }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LimpioFomulario();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int codigperiodista=0;
            try
            {
                codigperiodista=Convert.ToInt32(txtCodigoPeriodista.Text);

            }
            catch 
            {

                throw new Exception("Ingreso mal el codigo del Periodista, debe ser un nùmero de 4 Dìgitos Ej: 1111");
            }

            Periodista Peri = LogicaPeriodista.Buscar(codigperiodista);
            if (Peri != null)
            {
                txtNombre.Text = Peri.Nombre;
                txtApellido.Text = Peri.Apellido;
                txtMail.Text = Peri.Mail;

                ActivoBotones(false);
                Session["UnPeriodista"] = Peri;
            }
            else
            {
                lblError.ForeColor = Color.PowderBlue;
                lblError.Text = "No existe un Periodista con este Codigo";
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
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string mail = txtMail.Text.Trim();

            Periodista perri = (Periodista)Session["UnPeriodista"];

            perri.Nombre = nombre;
            perri.Apellido = apellido;
            perri.Mail = mail;


            LogicaPeriodista.Modificar(perri);
            LimpioFomulario();
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
            Periodista perri = (Periodista)Session["UnPeriodista"];

            LogicaPeriodista.Eliminar(perri);
            LimpioFomulario();
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
            int codiperiodista = Convert.ToInt32(txtCodigoPeriodista.Text);
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string mail = txtMail.Text.Trim();

            Periodista periodista = new Periodista(codiperiodista, nombre, apellido, mail);
            LogicaPeriodista.Agregar(periodista);
            LimpioFomulario();
            lblError.ForeColor = Color.Green;
            lblError.Text = "Alta con èxito";

        }
        catch (Exception ex)
        {

            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }

    }
}