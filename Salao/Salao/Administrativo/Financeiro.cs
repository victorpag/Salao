using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Salao.Administrativo
{
    class Financeiro
    {

        public List<DataSemanal> LucroSemana { get; set; }
        public List<DataMensal> LucroMensal { get; set; }
        public decimal LucroSemanaEmpresa { get; set; }
        public decimal LucroMensalEmpresa { get; set; }

        public DateTime DataVer { get; set; }

        public Financeiro()
        {
            LucroSemana = new List<DataSemanal>();
            LucroMensal = new List<DataMensal>();
        }

        public void CalculoLucroPorServiço(List<Agenda> agdFi, List<Funcionarios> funcA)
        {
            var listConc = agdFi.FindAll(x => x.Status ==
            Agenda.StatusAgenda.Realizado);
            for (int j = 0; j < listConc.Count; j++)
            {
                var ValorBruto = listConc[j].ServicoSolicitado.serv.Preco;
                var LucroFuncionario = ValorBruto / 100 * 30;
                LucroSemanaEmpresa += ValorBruto - LucroFuncionario;
                LucroMensalEmpresa += ValorBruto - LucroFuncionario;
                var a = funcA.FirstOrDefault(x => x.ID == listConc[j].ServicoSolicitado.serv._Func.ID);
                a.AdicionarGanhoPorServico(LucroFuncionario);
            }
        }

        public void CalculoSemanal(List<Funcionarios>funcA)
        {

            /*Se for segunda feira ele registra o lucro e zera o valor da semana 
             * Iniciando uma nova contagem da nova semana
             */

            Calendario car = new Calendario();
            DataSemanal dt = new DataSemanal();
            
            if (car.Data.DayOfWeek == DayOfWeek.Monday)
            {
                dt.Incluir(car.Data, LucroSemanaEmpresa);
                LucroSemana.Add(dt);
                LucroSemanaEmpresa = 0;

            }
            var a = funcA;
            a.ForEach(delegate (Funcionarios func) 
            {
                func.RegistrarGanhoSemana();
            });


        }

        public void CalculoMensal(List<Funcionarios> funcA)
        {
            //se for dia 1 registra lucro e zera contagem
            Calendario car = new Calendario();
            DataMensal dtm = new DataMensal();
            if(car.Data.Day == 1)
            {
                dtm.Incluir(car.Data, LucroMensalEmpresa);
                LucroMensal.Add(dtm);
                LucroMensalEmpresa = 0;

            }
            var a = funcA;
            a.ForEach(delegate (Funcionarios func)
            {
                func.RegistrarGanhoMes();
            });
        }
    }
}
