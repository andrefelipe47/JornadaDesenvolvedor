using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca.Models
{
    abstract public class Veiculo
    {
        public string Combustivel { get; set; }
        public decimal Consumo { get; set; }
        public decimal Peso { get; set; }

        public decimal CalcularConsumo(int distancia, int litrosConsumidos)
        {
            Consumo = distancia / litrosConsumidos;
            return Consumo;
        }
    }
}
