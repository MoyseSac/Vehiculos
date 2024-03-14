using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    internal class Informacion
    {
        string nombre;
        string placa;
        string marca;
        string modelo;
        string color;
        decimal precioKilo;
        string fechaDev;
        decimal total;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public decimal PrecioKilo { get => precioKilo; set => precioKilo = value; }
        public string FechaDev { get => fechaDev; set => fechaDev = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
