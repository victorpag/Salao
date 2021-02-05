using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Funcionario
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MinutosParaExecucao { get; set; }
        public decimal Preco { get; set; }
        public Funcionarios _Func { get; set; }

        public void Incluir(int id, string nome, int minutosParaExecucao, decimal preco,Funcionarios func)
        {
            Id = id;
            Nome = nome;
            MinutosParaExecucao = minutosParaExecucao;
            Preco = preco;
            _Func = func;
        }

        public void Alterar(string nome, int minutosParaExecucao, decimal preco)
        {
            Nome = nome;
            MinutosParaExecucao = minutosParaExecucao;
            Preco = preco;
        }
    }
}
