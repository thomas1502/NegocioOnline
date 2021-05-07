using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegocioOnline
{
    public class Cliente
    {
        string nit;
        string nombre;
        string direccion;
        string telefono;
        string correo;

        public string Nit { get => nit; set => nit = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}