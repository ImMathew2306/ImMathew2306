using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Logica;
using EntidadesCompartidas;

public partial class ListadoSecciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            if (!IsPostBack)
                LoadData();
     

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
            
        }
    }

    private void LoadData()
    {
        try
        {
            List<Secciones> colSecciones = LogicaSeccion.ListarSecciones();
            List<Noticia> colNoticias = LogicaNoticia.ListarNoticias();
            Session["Allsec"] = colSecciones;
            Session["Allnews"] = colNoticias;
            if (colSecciones.Count > 0)
            {
                
                gvSecciones.DataSource = colSecciones;
                gvSecciones.DataBind();
               
                
            }
            else if (colNoticias.Count <= 0)
            { 
              throw new Exception ("No hay noticias para mostrar");
            
            }


            else
            {
                gvSecciones.DataSource = null;
                gvSecciones.DataBind();
                throw new Exception("No hay secciones disponibles");
            }


        }
        catch (Exception ex)
        {

            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }  
    
    }

    protected void gvSecciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Secciones> colSecciones = (List<Secciones>)Session["Allsec"];
            List<Noticia> colNoticia = (List<Noticia>)Session["Allnews"];

           

            int indice = gvSecciones.SelectedIndex;
            Secciones oSeccion = colSecciones[indice];
            List<Noticia> colAuxiliar = new List<Noticia>();


            foreach ( Noticia n in colNoticia)
            {
                if (n is Nacionales)
                {
                    if (((Nacionales)n).Seccion.CodigoSecciones == oSeccion.CodigoSecciones)
                    {
                        colAuxiliar.Add(n);
                    }
                }
            }
             if(colAuxiliar.Count==0)
                 
                 {
                     gvNoticias.DataSource = null;
                     gvNoticias.DataBind();
                     throw new Exception("esta seccion no tiene noticias");

                 }
              gvNoticias.DataSource = colAuxiliar;
                gvNoticias.DataBind();
            
        }
        catch (Exception ex)
        {

            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }


 
}