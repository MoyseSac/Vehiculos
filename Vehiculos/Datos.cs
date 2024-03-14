using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    internal class Datos
    {
        string placa;
        string marca;
        string modelo;
        string color;
        decimal precioKilo;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public decimal PrecioKilo { get => precioKilo; set => precioKilo = value; }
    }
}
