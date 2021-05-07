using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegocioOnline
{
    public class Producto
    {        
        string codigo;
        string nombre;
        string descripcion;
        string marca;
        float precio;
        int existencia;
        string imagen;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Marca { get => marca; set => marca = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Existencia { get => existencia; set => existencia = value; }
        public string Imagen { get => imagen; set => imagen = value; }

        // Se puede utilizar herencia para aplicar en secciones de productos
    }
}