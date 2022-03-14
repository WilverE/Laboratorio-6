using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_6
{
    internal class Cliente
    {
        public string Nit { get; set; }        
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Placa { get; set; }
        public string FechaAlquiler { get; set; }
        public string FechaDevolucion { get; set; }
        public decimal KilometrosRecorridos { get; set; }

        internal int FindIndex(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
