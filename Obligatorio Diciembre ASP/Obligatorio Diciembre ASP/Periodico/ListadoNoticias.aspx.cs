using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Logica;
using EntidadesCompartidas;

public partial class ListadoNoticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
             
                List<Noticia> Noticol = LogicaNoticia.ListarNoticias();
               
                Session["AllNews"] = Noticol;
                if (Noticol.Count == 0)
                {
                    ddlListadoNoticias.Enabled = false;
                    throw new Exception("No hay noticias para mostrar");
                }
            
            
            
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
            
        }

    }

    protected void ddlListadoNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Noticia> Noticol = (List<Noticia>)Session["AllNews"];
            LbNoticias.Items.Clear();
            if (ddlListadoNoticias.SelectedIndex == 0)
            {
                throw new Exception("Seleccione una opcion");
            
            }
            else if (ddlListadoNoticias.SelectedIndex == 1)
            {
                LbNoticias.DataSource = Noticol;
                LbNoticias.DataBind();
           }
            else if (ddlListadoNoticias.SelectedIndex == 2)
            {
                foreach (Noticia p in Noticol)
                {
                    if (p is Nacionales)
                    {
                        LbNoticias.Items.Add(p.ToString());
                    
                    }
                
                }
           }
            else if (ddlListadoNoticias.SelectedIndex == 3)
            {
                foreach (Noticia p in Noticol)
                {
                    if (p is Internacionales)
                    {
                        LbNoticias.Items.Add(p.ToString());
                    }
                }
            
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
            
        }
    }
   
}