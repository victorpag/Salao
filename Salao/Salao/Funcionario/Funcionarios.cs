using System;
using System.Collections.Generic;
using System.Text;

namespace Salao
{
   public class Funcionarios
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public CargoFunc Cargo { get; set; }
        public List<Administrativo.DataSemanal> GanhosSemanal { get; set; }
        public List<Administrativo.DataMensal> GanhosMensal { get; set; }
        public decimal GanhosSemanalvar { get; set; }
        public decimal GanhosMensalvar { get; set; }
        public DateTime HorarioEntrada { get { return Convert.ToDateTime("10:00"); } }
        public DateTime HorarioSaida { get { return Convert.ToDateTime("19:00"); } }

        public Funcionarios()
        {
            GanhosSemanal = new List<Administrativo.DataSemanal>();
        }
        public enum CargoFunc
        {
            Cabelereiro,
            Barbeiro
            
        }

        public void Incluir(string nome, string telefone, CargoFunc cargo)
        {
            //Matricula = matricula;
            Nome = nome;
            Telefone = telefone;
            Cargo = cargo;
        }

        public void RegistrarGanhoMes()
        {
            Administrativo.Calendario cl = new Administrativo.Calendario();
            if (cl.Data.Day == 1)
            {
                Administrativo.DataMensal dm = new Administrativo.DataMensal();
                dm.Incluir(cl.Data, GanhosMensalvar);
                GanhosMensal.Add(dm);
                GanhosMensalvar = 0;
            }

        }
        public void RegistrarGanhoSemana()
        {
            Administrativo.Calendario cl = new Administrativo.Calendario();

            if (cl.Data.DayOfWeek == DayOfWeek.Monday)
            {
                Administrativo.DataSemanal ds = new Administrativo.DataSemanal();
                ds.Incluir(cl.Data, GanhosSemanalvar);
                GanhosSemanal.Add(ds);
                GanhosSemanalvar = 0;
            }
        }
        public void AdicionarGanhoPorServico(decimal ganho)
        {
            GanhosMensalvar += ganho;
            GanhosSemanalvar += ganho;
        }

    }
}
