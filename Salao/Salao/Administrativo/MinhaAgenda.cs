using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Administrativo
{
    class MinhaAgenda
    {
        public List<Agenda> Agendamentos { get; set; }

        public bool AgendarServicos(int id, Cliente cliente, List<ServicoSolicitado> servicosSolicitados,
            DateTime dtAgendamento, string anotacao = "")
        {
            Agenda agenda = new Agenda();
            //agenda.IncluirAgendamento(id, cliente, servicosSolicitados, dtAgendamento, anotacao);
            return true;
        }
    }
}
