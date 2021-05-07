using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;

namespace NegocioOnline
{
    public partial class About : Page
    {
        // Listas
        static List<Producto> productos = new List<Producto>();
        static int indice = -1;
        // Funciones propias
        private void GuardarJson()
        {
            string json = JsonConvert.SerializeObject(productos);
            string archivo = Server.MapPath("Productos.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private void Habilitar()
        {
            LabelModificarNombre.Visible = true;
            txtModificarNombre.Visible = true;
            LabelModificarDescripcion.Visible = true;
            txtModificarExistencia.Visible = true;
            LabelModificarPrecio.Visible = true;
            txtModificarPrecio.Visible = true;
            LabelModificarExistencia.Visible = true;
            txtModificarExistencia.Visible = true;

            ButtonGuardar.Visible = true;

            LabelBuscarProducto.Visible = true;
            txtBuscarProducto.Visible = true;
            ButtonBuscar.Visible = true;

            ButtonEliminar.Visible = true;
        }
        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
        }
        private void Ocultar()
        {
            LabelModificarNombre.Visible = false;
            txtModificarNombre.Visible = false;
            LabelModificarDescripcion.Visible = false;
            txtModificarDescripcion.Visible = false;
            LabelModificarPrecio.Visible = false;
            txtModificarPrecio.Visible = false;
            LabelModificarExistencia.Visible = false;
            txtModificarExistencia.Visible = false;

            ButtonGuardar.Visible = false;

            ButtonEliminar.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Leer los datos de la lista Json
                string archivo = Server.MapPath("Productos.json");
                StreamReader jsonStream = File.OpenText(archivo);
                string json = jsonStream.ReadToEnd();

                jsonStream.Close();
                productos = JsonConvert.DeserializeObject<List<Producto>>(json);
            }
            // Mostar datos 
            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();
            // Ocultar comandos 
            Ocultar();
            // Evitar que se recargue la página hasta arriba
            MaintainScrollPositionOnPostBack = true;
        }

        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            Producto pro = productos.Find(u => u.Codigo == txtCodigo.Text);
            if(pro != null)
            {
                Response.Write("<script>alert('Este código ya fue registrado!')</script>");
            }
            else
            {
                Producto producto = new Producto();
                producto.Codigo = txtCodigo.Text;
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Marca = cmbMarca.SelectedValue;
                producto.Precio = float.Parse(txtPrecio.Text);
                producto.Existencia = int.Parse(txtExistencia.Text);
                // Cargar una imagen
                string archivoOrigen = Path.GetFileName(FileUploadImagen.FileName);
                try
                {
                    FileUploadImagen.SaveAs(Server.MapPath("~/Imagenes/") + archivoOrigen);
                    LabelEstado.Text = "Exitosamente Subido";
                }
                catch (Exception ex)
                {
                    LabelEstado.Text = "No se pudo subir, se generó el siguiente error:  " + ex.Message;
                }
                string archivo = "~/imagenes/" + FileUploadImagen.FileName;
                // Lo agregamos a las propiedades de nuestra lista
                producto.Imagen = archivo;

                productos.Add(producto);
                GuardarJson();
                Limpiar();
                Response.Write("<script>alert('Producto registrado!')</script>");
            }

            // Actualizar la tabla con los productos
            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();
            // Hacer visible comandos
            LabelBuscarProducto.Visible = true;
            txtBuscarProducto.Visible = true;
            ButtonBuscar.Visible = true;
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < productos.Count; x++)
            {
                if (productos[x].Codigo.Equals(txtBuscarProducto.Text))
                {
                    indice = x;
                    break;
                }
            }
            // Mostrar el nombre si existe
            if (indice > -1)
            {
                txtModificarNombre.Text = productos[indice].Nombre;
                txtModificarDescripcion.Text = productos[indice].Descripcion;
                txtModificarPrecio.Text = Convert.ToString(productos[indice].Precio);
                txtModificarExistencia.Text = Convert.ToString(productos[indice].Existencia);
                // Hacer visible los comandos
                Habilitar();
            }
            else
            {
                Response.Write("<script>alert('El código no existe!')</script>");
                txtBuscarProducto.Text = "";
                indice = -1;
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            productos[indice].Nombre = txtModificarNombre.Text;
            productos[indice].Descripcion = txtModificarDescripcion.Text;
            productos[indice].Precio = float.Parse(txtModificarPrecio.Text);
            productos[indice].Existencia = Convert.ToInt32(txtModificarExistencia.Text);
            GuardarJson();

            Response.Write("<script>alert('Datos del producto actualizado!')</script>");
            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();
            // Mostrar comandos
            LabelBuscarProducto.Visible = true;
            txtBuscarProducto.Visible = true;
            ButtonBuscar.Visible = true;
            // Limpiar campo para buscar carné
            txtBuscarProducto.Text = "";
            indice = -1;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            productos.RemoveAt(indice);
            GuardarJson();

            Response.Write("<script>alert('Producto eliminado!')</script>");
            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();
            // Limpiar
            txtBuscarProducto.Text = "";
            indice = -1;
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonExaminar_Click(object sender, EventArgs e)
        {

        }
    }
}