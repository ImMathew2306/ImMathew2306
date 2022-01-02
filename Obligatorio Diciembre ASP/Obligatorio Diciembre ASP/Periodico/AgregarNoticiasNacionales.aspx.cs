using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Logica;
using EntidadesCompartidas;

public partial class AgregarNoticiasNacionales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
            LoadData();


    }
    
    private void LoadData()
    {

        try
        {

            List<Secciones> colSecciones = LogicaSeccion.ListarSecciones();
            List<Periodista> colPeriodista = LogicaPeriodista.ListarPeriodistas();
            Session["Allsec"] = colSecciones;
            Session["AllPerri"] = colPeriodista;
            if (colSecciones.Count > 0 && colPeriodista.Count > 0)
            {
                ddlPeriodistas.DataSource = colPeriodista;
                ddlPeriodistas.DataTextField = "MostrarPerri";
                ddlPeriodistas.DataValueField = "CodigoPeriodista";
                ddlPeriodistas.DataBind();
                ddlPeriodistas.Items.Insert(0, new ListItem("-------------"));

                ddlSecciones.DataSource = colSecciones;
                ddlSecciones.DataTextField = "MostrarSec";
                ddlSecciones.DataValueField = "CodigoSecciones";
                ddlSecciones.DataBind();
                ddlSecciones.Items.Insert(0, new ListItem("-------------"));
            }
            else
            {
                lblError.Text = "No Existe Secciones  y/o Periodistas para mostrar";

                ddlSecciones.Enabled = false;
                ddlPeriodistas.Enabled = false;
                txtTitulo.Enabled = false;
               
                txtContenido.Enabled = false;
                txtResumen.Enabled = false;
                btnAgregar.Enabled = false;
            }

           
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
            string titulo = txtTitulo.Text;
            string resumen = txtResumen.Text;
            string contenido = txtContenido.Text;
            string seccion;
            int codigoperri;

            List<Secciones> colSecciones = (List<Secciones>)Session["Allsec"];
            Secciones oSec = null;
            if (ddlSecciones.SelectedIndex != 0)
            {
                seccion = ddlSecciones.SelectedValue;
            }
            else
            {
                throw new Exception("Elija una seccion");
            }
            foreach (Secciones s in colSecciones)
            {
                if (s.CodigoSecciones == seccion)
                {
                    oSec = s;
                    break;
                
                }
            }
            List<Periodista> colPeriodista = (List<Periodista>)Session["AllPerri"];
            Periodista perri = null;
            if (ddlPeriodistas.SelectedIndex != 0)
            {
                codigoperri = Convert.ToInt32(ddlPeriodistas.SelectedValue);

            
            
            }
            else
            {
                throw new Exception("Debe Seleccionar un Periodista");
            }
            foreach (Periodista p in colPeriodista)
            {
                if (p.CodigoPeriodista == codigoperri)
                {
                    perri = p;
                    break;
                }
            }
           Nacionales news = new Nacionales(0, titulo, resumen, contenido, Calnoticias.SelectedDate,perri,oSec);
            int n =LogicaNoticia.Agregar(news);
            lblError.ForeColor = Color.Green;
            lblError.Text = "Se ha creado la noticia Nº: " + n;

            txtContenido.Text = "";
            txtTitulo.Text = "";
            txtResumen.Text = "";
            Calnoticias.SelectedDate = DateTime.Today;
            ddlPeriodistas.SelectedIndex = 0;
            ddlSecciones.SelectedIndex = 0;
            LoadData();
            
          
        }
        catch (Exception ex)
        {

            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}