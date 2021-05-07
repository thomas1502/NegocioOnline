using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegocioOnline
{
    public class Detalle
    {
        string codProducto;
        string descripcionProducto;
        int cantidadVendida;
        double precioUnitario;
        double total;

        public string CodProducto { get => codProducto; set => codProducto = value; }
        public string DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }
        public int CantidadVendida { get => cantidadVendida; set => cantidadVendida = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public double Total { get => total; set => total = value; }
    }
    public class Venta
    {
        string nit;
        string codVenta;
        DateTime fechaVenta;
        string estado;
        List<Detalle> productosVendidos = new List<Detalle>();

        public string Nit { get => nit; set => nit = value; }
        public DateTime FechaVenta { get => fechaVenta; set => fechaVenta = value; }
        public string Estado { get => estado; set => estado = value; }
        public List<Detalle> ProductosVendidos { get => productosVendidos; set => productosVendidos = value; }
        public string CodVenta { get => codVenta; set => codVenta = value; }

        // Constructor
        public Venta()
        {
            ProductosVendidos = new List<Detalle>();
        }
    }
}