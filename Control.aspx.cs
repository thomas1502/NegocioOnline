using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioOnline
{
    public partial class Control : System.Web.UI.Page
    {
        // Listas
        static List<Venta> ventas = new List<Venta>();
        static int indice = -1;
        // Funciones propias
        private void Habilitar()
        {
            LabelModificarEstado.Visible = true;
            txtModificarEstado.Visible = true;

            ButtonGuardar.Visible = true;

            LabelBuscarEstado.Visible = true;
            txtBuscarEstado.Visible = true;
            ButtonBuscar.Visible = true;
        }
        private void GuardarJson()
        {
            string json = JsonConvert.SerializeObject(ventas);
            string archivo = Server.MapPath("Ventas.json");
            System.IO.File.WriteAllText(archivo, json);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Leer los datos de la lista Json de P¨roductos
                string archivo = Server.MapPath("Ventas.json");
                StreamReader jsonStream = File.OpenText(archivo);
                string json = jsonStream.ReadToEnd();

                jsonStream.Close();
                ventas = JsonConvert.DeserializeObject<List<Venta>>(json);
            }
            // Cargar los datos de las Ventas
            GridViewVentas.DataSource = ventas;
            GridViewVentas.DataBind();
            // Ocultar
            LabelModificarEstado.Visible = false;
            txtModificarEstado.Visible = false;
            ButtonGuardar.Visible = false;
        }

        protected void GridViewVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            indice = GridViewVentas.SelectedIndex;
            GridViewProductos.DataSource = ventas[indice].ProductosVendidos;
            GridViewProductos.DataBind();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < ventas.Count; x++)
            {
                if (ventas[x].CodVenta.Equals(txtBuscarEstado.Text))
                {
                    indice = x;
                    break;
                }
            }
            // Mostrar el nombre si existe
            if (indice > -1)
            {
                txtModificarEstado.Text = ventas[indice].Estado;
                // Hacer visible los comandos
                Habilitar();
                // Mostrar 
                LabelModificarEstado.Visible = true;
                txtModificarEstado.Visible = true;
                ButtonGuardar.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('El código de venta no existe!')</script>");
                txtBuscarEstado.Text = "";
                indice = -1;
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            ventas[indice].Estado = txtModificarEstado.Text;
            GuardarJson();

            Response.Write("<script>alert('Estado producto actualizado!')</script>");
            GridViewVentas.DataSource = ventas;
            GridViewVentas.DataBind();
            // Mostrar comandos
            LabelBuscarEstado.Visible = true;
            txtBuscarEstado.Visible = true;
            ButtonBuscar.Visible = true;
            // Limpiar campo para buscar carné
            LabelBuscarEstado.Text = "";
            indice = -1;
        }
    }
}