using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Administrativo
{
    public class DataMensal
    {
        public DateTime DataHoje { get; set; }
        public decimal SaldoDaData { get; set; }

        public void Incluir(DateTime datahj, decimal saldo)
        {
            DataHoje = datahj;
            SaldoDaData = saldo;
        }
    }
}
