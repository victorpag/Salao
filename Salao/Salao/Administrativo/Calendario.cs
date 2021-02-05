using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Administrativo
{
    class Calendario
    {
        public DateTime Data { get; set; }
        public DateTime UltimaVeriData { get; set; }

        public Calendario()
        {
            Data = DateTime.Today;
        }
    }
}
