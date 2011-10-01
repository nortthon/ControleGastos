using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAD.ControleDeGastos.Entidades
{
    public class Extrato
    {
        public DateTime Data { get; set; }
        public Decimal Tipo { get; set; }
        public String Descricao { get; set; }
        public Double Valor { get; set; }
    }
}
