using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Salao.Funcionario
{
    class ServicosPrestados
    {
        public List<Servico> Servicos { get; set; }

        public ServicosPrestados()
        {
            Servicos = new List<Servico>();
        }

        public void Incluir(Servico serv)
        {
            Servicos.Add(serv);
        }

        public void AlterarUmServico(int id, string nomeNovo, int minutosParaExecucaoNovo, decimal precoNovo)
        {
            Servico servico = Servicos.FirstOrDefault();
            if (servico != null)
            {
                servico.Alterar(nomeNovo, minutosParaExecucaoNovo, precoNovo);
            }
        }

        public void ExcluirUmServico(int id)
        {
            Servicos.RemoveAll(serv => serv.Id == id);
        }
    }
}
