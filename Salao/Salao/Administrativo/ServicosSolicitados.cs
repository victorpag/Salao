using System;

namespace Salao.Administrativo
{
    public class ServicoSolicitado
    {
        public int Id { get; set; }
        public Funcionario.Servico serv { get; set; }
       public Funcionarios Funcionario { get; set; }
        public StatusServico Status { get; set; }
        public DateTime DtServico { get; set; }

        public enum StatusServico
        {
            ARealizar,
            Realizado,
            Reagendado,
            CanceladoPeloCliente,
            CanceladoPeloSalao
        }

        public void IncluirServicoSolicitado(int id, Funcionario.Servico servico, Funcionarios func)
        {
            Id = id;
            serv = servico;
            Funcionario = func;
        }
    }
}
