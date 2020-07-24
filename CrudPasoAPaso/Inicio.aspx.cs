using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudPasoAPaso
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["usermane"].ToString();

            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btningresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }
        protected void btneliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarProducto.aspx");
        }
        protected void btneditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarProducto.aspx");
        }
        protected void btncerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usermane");
            Response.Redirect("Login.aspx");
        }
    }
}