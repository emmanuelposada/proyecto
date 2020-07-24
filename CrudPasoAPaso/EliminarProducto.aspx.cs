using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace CrudPasoAPaso
{
    public partial class EliminarProducto : System.Web.UI.Page
    {
        MySqlConnection conec = new MySqlConnection("server=127.0.0.1; database=chaleco; Uid=root; pwd=;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usermane"] == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            conec.Open();
            MySqlCommand cmd = conec.CreateCommand();
            cmd.CommandText = "select * from productos";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            gvdlista.DataSource = dt;
            gvdlista.DataBind();
            conec.Close();

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = datos.ObtenerConexion();
                MySqlCommand comand = new MySqlCommand("SELECT * FROM productos WHERE ID=@ID", conexion);
                comand.Parameters.AddWithValue("@ID", txtid.Text);
                MySqlDataReader registro = comand.ExecuteReader();
                if (registro.Read())
                {
                    alerta.Text = "<script>Swal.fire('Sea seleccionado con exito.', '', 'success'); </script>";

                    txtmarca.Text = registro["Marca"].ToString();
                    txtprecio.Text = registro["Precio"].ToString();
                    txtproducto.Text = registro["Producto"].ToString();
                    txtcantidad.Text = registro["Cantidad"].ToString();
                }
                conexion.Close();
            }
            catch
            {
                alerta.Text = "<script>Swal.fire('Algo salio mal Intentalo otra vez', 'Verifique que ID se correcto', 'error') </script>";

            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            if (txtmarca.Text.Trim() != "" && txtproducto.Text.Trim() != "" && txtprecio.Text.Trim() != "" && txtcantidad.Text.Trim() != "" && txtid.Text.Trim() != "")
            {

                conexiones.Eliminar(Convert.ToInt32(txtid.Text));
                conec.Open();
                MySqlCommand cmd = conec.CreateCommand();
                cmd.CommandText = "select * from productos";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                gvdlista.DataSource = dt;
                gvdlista.DataBind();



                txtproducto.Text = "";
                txtprecio.Text = "";
                txtcantidad.Text = "";
                txtid.Text = "";
                txtmarca.Text = "";
                alerta.Text = "<script>Swal.fire('Su producto se Eliminado con exito.', '¡Gracias por preferirnos!', 'success'); </script>";


            }
            else
            {
                alerta.Text = "<script>Swal.fire('OOPS', 'No deje espacios en blanco', 'error') </script>";
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}