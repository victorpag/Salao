using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Salao.Funcionario
{
    class MeusFuncionarios
    {
        public List<Funcionarios> Funcionarios { get; set; }

        public MeusFuncionarios()
        {
            Funcionarios = new List<Funcionarios>();
        }


        public void Incluir(Funcionarios func)
        {
            int iD = 0;
            if (Funcionarios.Any())
                iD = Funcionarios.Last().ID + 1;
            else
                iD++;
            func.ID = iD;
            Funcionarios.Add(func);
        }


    }
}
