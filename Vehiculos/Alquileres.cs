using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    internal class Alquileres
    {

        int nit;
        string placa;
        string fechAlq;
        string fechaDev;
        int kilRecorridos;

        public int Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public string FechAlq { get => fechAlq; set => fechAlq = value; }
        public string FechaDev { get => fechaDev; set => fechaDev = value; }
        public int KilRecorridos { get => kilRecorridos; set => kilRecorridos = value; }
    }
}
