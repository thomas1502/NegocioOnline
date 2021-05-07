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
    public partial class Contact : Page
    {
        // Listas y variables globales
        static List<Cliente> clientes = new List<Cliente>();
        static int indice = -1;
        // Funcioes propias
        private void GuardarJson()
        {
            string json = JsonConvert.SerializeObject(clientes);
            string archivo = Server.MapPath("Clientes.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private void Habilitar()
        {
            LabelModificarNombre.Visible = true;
            txtModificarNombre.Visible = true;
            LabelModificarDireccion.Visible = true;
            txtModificarDireccion.Visible = true;
            LabelModificarTelefono.Visible = true;
            txtModificarTelefono.Visible = true;
            LabelModificarCorreo.Visible = true;
            txtModificarCorreo.Visible = true;

            ButtonGuardar.Visible = true;

            LabelBuscarCliente.Visible = true;
            txtBuscarCliente.Visible = true;
            ButtonBuscar.Visible = true;

            ButtonEliminar.Visible = true;
        }
        private void Limpiar()
        {
            txtNit.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }
        private void Ocultar()
        {
            LabelModificarNombre.Visible = false;
            txtModificarNombre.Visible = false;
            LabelModificarDireccion.Visible = false;
            txtModificarDireccion.Visible = false;
            LabelModificarTelefono.Visible = false;
            txtModificarTelefono.Visible = false;
            LabelModificarCorreo.Visible = false;
            txtModificarCorreo.Visible = false;

            ButtonGuardar.Visible = false;
            ButtonEliminar.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Leer los datos de la lista Json
                string archivo = Server.MapPath("Clientes.json");
                StreamReader jsonStream = File.OpenText(archivo);
                string json = jsonStream.ReadToEnd();

                jsonStream.Close();
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
            // Mostar datos 
            GridViewClientes.DataSource = clientes;
            GridViewClientes.DataBind();
            // Ocultar comandos 
            Ocultar();
            // Evitar que se recargue la página hasta arriba
            MaintainScrollPositionOnPostBack = true;
        }

        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            Cliente cli = clientes.Find(u => u.Nit == txtNit.Text);
            if (cli != null)
            {
                Response.Write("<script>alert('Este NIT ya existe!')</script>");
            }
            else
            {
                Cliente cliente = new Cliente();
                cliente.Nit = txtNit.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Correo = txtCorreo.Text;
                clientes.Add(cliente);

                GuardarJson();
                Limpiar();
                Response.Write("<script>alert('Cliente registrado!')</script>");
            }

            // Actualizar la tabla con los productos
            GridViewClientes.DataSource = clientes;
            GridViewClientes.DataBind();
            // Hacer visible comandos
            LabelBuscarCliente.Visible = true;
            txtBuscarCliente.Visible = true;
            ButtonBuscar.Visible = true;
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < clientes.Count; x++)
            {
                if (clientes[x].Nit.Equals(txtBuscarCliente.Text))
                {
                    indice = x;
                    break;
                }
            }
            // Mostrar el nombre si existe
            if (indice > -1)
            {
                txtModificarNombre.Text = clientes[indice].Nombre;
                txtModificarDireccion.Text = clientes[indice].Direccion;
                txtModificarTelefono.Text = clientes[indice].Telefono;
                txtModificarCorreo.Text = clientes[indice].Correo;
                // Hacer visible los comandos
                Habilitar();
            }
            else
            {
                Response.Write("<script>alert('El código no existe!')</script>");
                txtBuscarCliente.Text = "";
                indice = -1;
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            clientes[indice].Nombre = txtModificarNombre.Text;
            clientes[indice].Direccion = txtModificarDireccion.Text;
            clientes[indice].Telefono = txtModificarTelefono.Text;
            clientes[indice].Correo = txtModificarCorreo.Text;
            GuardarJson();

            Response.Write("<script>alert('Nombre de producto actualizado!')</script>");
            GridViewClientes.DataSource = clientes;
            GridViewClientes.DataBind();
            // Mostrar comandos
            LabelBuscarCliente.Visible = true;
            txtBuscarCliente.Visible = true;
            ButtonBuscar.Visible = true;
            // Limpiar campo para buscar carné
            txtBuscarCliente.Text = "";
            indice = -1;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            clientes.RemoveAt(indice);
            GuardarJson();

            Response.Write("<script>alert('Producto eliminado!')</script>");
            GridViewClientes.DataSource = clientes;
            GridViewClientes.DataBind();
            // Limpiar
            txtBuscarCliente.Text = "";
            indice = -1;
        }
    }
}