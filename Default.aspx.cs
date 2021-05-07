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
    public partial class _Default : Page
    {
        // Listas y variables globales
        static List<Producto> productos = new List<Producto>();
        static List<Venta> ventas = new List<Venta>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Detalle> detalles = new List<Detalle>();
        static int posicion = -1; static int posx = -1; static int indice = -1;
        // Funciones propias
        private void GuardarProducto()
        {
            string json = JsonConvert.SerializeObject(productos);
            string archivo = Server.MapPath("Productos.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private void GuardarVenta()
        {
            string json = JsonConvert.SerializeObject(ventas);
            string archivo = Server.MapPath("Ventas.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private void Habilitar()
        {
            LabelNit.Visible = true;
            txtNit.Visible = true;
            LabelCodVenta.Visible = true;
            txtCodVenta.Visible = true;
            LabelFechadeVenta.Visible = true;
            CalendarFechaVenta.Visible = true;
            LabelProductosComprados.Visible = true;
            GridViewCompras.Visible = true;
            LabelTotal.Visible = true;
            txtTotal.Visible = true;

            ButtonPagar.Visible = true;
            ButtonCliente.Visible = true;

            LabelNombre.Visible = true;
            LabelDireccion.Visible = true;
            LabelTelefono.Visible = true;
            LabelCorreo.Visible = true;
        }
        private void Limpiar()
        {
            txtNit.Text = "";
            txtCodVenta.Text = "";
            txtTotal.Text = "";
            LabelNombre.Text = "";
            LabelDireccion.Text = "";
            LabelTelefono.Text = "";
            LabelCodVenta.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Leer los datos de la lista Json de P¨roductos
                string archivo = Server.MapPath("Productos.json");
                StreamReader jsonStream = File.OpenText(archivo);
                string json = jsonStream.ReadToEnd();

                jsonStream.Close();
                productos = JsonConvert.DeserializeObject<List<Producto>>(json);

                // ----------------------------------------------------------------------

                // Leer los datos de la lista Json de Ventas
                string archivo2 = Server.MapPath("Ventas.json");
                StreamReader jsonStream2 = File.OpenText(archivo2);
                string json2 = jsonStream2.ReadToEnd();

                jsonStream.Close();
                ventas = JsonConvert.DeserializeObject<List<Venta>>(json2);

                // -----------------------------------------------------------------------

                // Leer los datos de la lista Json de P¨roductos
                string archivo3 = Server.MapPath("Clientes.json");
                StreamReader jsonStream3 = File.OpenText(archivo3);
                string json3 = jsonStream3.ReadToEnd();

                jsonStream.Close();
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(json3);
            }
            // Mostar datos 
            GridViewProductos.DataSource = productos;
            GridViewProductos.DataBind();
            // Ocultar();
            // Evitar que se recargue la página hasta arriba
            MaintainScrollPositionOnPostBack = true;
        }

        protected void ButtonComprar_Click(object sender, EventArgs e)
        {
            if(productos[posicion].Existencia == 0)
            {
                Response.Write("<script>alert('Este producto está agotado, lo sentimos!')</script>");
            }
            else
            {
                for (int x = 0; x < detalles.Count; x++)
                {
                    if (productos[posicion].Codigo.Equals(detalles[x].CodProducto))
                    {
                        posx = x;
                    }
                }
                // Verificar si el producto seleccionado ya se selecciono previamente
                if (posx > -1)
                {
                    detalles[posx].CantidadVendida += 1; // Sumamos +1 a la cantitad de ventas de este producto 
                    double precio = detalles[posx].PrecioUnitario; // Recuperamos el precio de nuestro producto
                    detalles[posx].Total += precio; // Actualizamos el precio total
                    productos[posicion].Existencia -= 1; // Restar 1 a la existencia
                    GuardarProducto();
                    posx = -1;
                    //
                    Response.Write("<script>alert('Producto agregado al carrito!')</script>");
                }
                else
                {
                    Detalle detalle = new Detalle();
                    detalle.CodProducto = productos[posicion].Codigo;
                    detalle.DescripcionProducto = productos[posicion].Descripcion;
                    detalle.CantidadVendida += 1;
                    detalle.PrecioUnitario = productos[posicion].Precio;
                    detalle.Total += (detalle.CantidadVendida * detalle.PrecioUnitario);
                    productos[posicion].Existencia -= 1; // Restar 1 a la existencia
                    GuardarProducto();
                    detalles.Add(detalle);
                    //
                    Response.Write("<script>alert('Producto agregado al carrito!')</script>");
                }
            }
        }

        protected void GridViewProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicion = GridViewProductos.SelectedIndex;
        }

        protected void ButtonFacturar_Click(object sender, EventArgs e)
        {
            // Mostrar productos comprados
            GridViewCompras.DataSource = detalles;
            GridViewCompras.DataBind();
            // Mostrar campos
            Habilitar();
            double t = 0;
            for(int x = 0; x < detalles.Count;x++)
            {
                t += detalles[x].Total;
            }
            txtTotal.Text = Convert.ToString(t);
            Habilitar();
        }

        protected void ButtonPagar_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.Nit = txtNit.Text;
            venta.CodVenta = txtCodVenta.Text;
            venta.FechaVenta = CalendarFechaVenta.SelectedDate;
            venta.Estado = "En Proceso";
            venta.ProductosVendidos = detalles.ToList();
            ventas.Add(venta);
            GuardarVenta();

            detalles.Clear();
            // Limpiar y ocultar los capos
            Limpiar(); 
            //Ocultar();
            Response.Write("<script>alert('Factura procesada. Gracias por tu compra!')</script>");
        }

        protected void ButtonCliente_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < clientes.Count; x++)
            {
                if (clientes[x].Nit.Equals(txtNit.Text))
                {
                    indice = x;
                    break;
                }
            }
            // Mostrar el nombre si existe
            if (indice > -1)
            {
                LabelNombre.Text = clientes[indice].Nombre;
                LabelDireccion.Text = clientes[indice].Direccion;
                LabelTelefono.Text = clientes[indice].Telefono;
                LabelCorreo.Text = clientes[indice].Correo;
            }
            else
            {
                Response.Write("<script>alert('El NIT no existe en nuestra base de datos!')</script>");
                txtNit.Text = "";
                indice = -1;
            }
        }

        protected void CalendarFechaVenta_SelectionChanged(object sender, EventArgs e)
        {
            Habilitar();
        }
    }
}