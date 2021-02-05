using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Salao.Administrativo
{
    public class Agenda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        //public List<ServicoSolicitado> ServicosSolicitados { get; set; }
        public ServicoSolicitado ServicoSolicitado { get; set; }
        public DateTime? DtAgendamento { get; set; }
        public DateTime DataChegada { get; set; }
        public string Anotacao { get; set; }
        public StatusAgenda Status { get; set; }

        public enum StatusAgenda
        {
            ARealizar,
            Realizado,
            Reagendado,
            CanceladoPeloCliente,
            NaoCompareceu,
            CanceladoPeloSalao,
            Pendente
        }
        public string IncluirAgendamento(int id, Cliente cliente,
     //List<ServicoSolicitado> servicosSolicitados, 
     Funcionarios func,Administrativo.ServicoSolicitado serv,
     DateTime dtAgendamento, List<Agenda> agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda,serv, dtAgendamento))
            {
                return "Esse horário não está livre.";
            }
            else
            {
                Id = id;
                Cliente = cliente;
                //ServicosSolicitados = servicosSolicitados;
                DtAgendamento = dtAgendamento;
                Anotacao = anotacao;
                return "Agendamento feito com sucesso.";
            }
        }
        private bool PermiteAgendar(List<Agenda> agenda,Administrativo.ServicoSolicitado servp ,DateTime dtAgendamento)
        {
            DateTime dataTerminoParaAgendar = dtAgendamento.AddMinutes(servp.serv.MinutosParaExecucao);
            return (agenda.Any(a => a.DtAgendamento >= dtAgendamento &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)) &&
                agenda.Any(a => a.DtAgendamento <= dataTerminoParaAgendar &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)));
        }
    }
}
