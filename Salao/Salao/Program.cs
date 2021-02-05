using System;
using System.Linq;
using System.Collections.Generic;

namespace Salao
{
    class Program
    {
        
        static void Main(string[] args)
        {

            var MeusClientes = CadastrarCliente();
            var MeusFuncionarios = CadastrarFuncionario();
            var MeusSerivcos = IncluirMeusServicos();

            #region AGENDAMENTO
            List<Administrativo.Agenda> agenda = new List<Administrativo.Agenda>();
            agenda.Add(new Administrativo.Agenda
            {
                Id = 2,
                ServicoSolicitado = new Administrativo.ServicoSolicitado
                {
                    Id = 2,
                    serv = MeusSerivcos.Servicos.First()
                },
                DtAgendamento = new DateTime(2021, 1, 29, 12, 0, 0),
                Status = Administrativo.Agenda.StatusAgenda.Realizado
            });
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Agendamento feito com Sucesso");
            Console.WriteLine("------------------------------------------------");
            #endregion

            #region CALCULAR FINANCEIRO
            Administrativo.Financeiro finc = new Administrativo.Financeiro();
            finc.CalculoLucroPorServiço(agenda, MeusFuncionarios.Funcionarios);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Calculo feito com Sucesso");
            Console.WriteLine("------------------------------------------------");
            finc.CalculoSemanal(MeusFuncionarios.Funcionarios);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Calculo Semanal");
            finc.LucroSemana.ForEach(delegate (Administrativo.DataSemanal dt) 
            {
                Console.WriteLine($"Lucro de {dt.DataHoje} foi {dt.SaldoDaData}");
            });
            Console.WriteLine("------------------------------------------------");
            finc.CalculoMensal(MeusFuncionarios.Funcionarios);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Calculo Mensal");
            finc.LucroMensal.ForEach(delegate (Administrativo.DataMensal dt)
            {
                Console.WriteLine($"Lucro de {dt.DataHoje.Month} foi {dt.SaldoDaData}");
            });
            Console.WriteLine("------------------------------------------------");
           
            //EXIBE REGISTRO DE GANHOS MENSAIS E SEMANAIS DOS FUNCIONARIOS
            MeusFuncionarios.Funcionarios.ForEach(delegate (Funcionarios func)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine($"Registro Mensal do funcionario {func.Nome}");
                func.GanhosMensal.ForEach(delegate (Administrativo.DataMensal a) 
                {
                    Console.WriteLine($"De {a.DataHoje} foi de {a.SaldoDaData}");
                });
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine($"Registro Semanal do funcionario {func.Nome}");
                func.GanhosSemanal.ForEach(delegate (Administrativo.DataSemanal b)
                {
                    Console.WriteLine($"De {b.DataHoje} foi de {b.SaldoDaData}");
                });
            });
            Console.WriteLine("------------------------------------------------");

            #endregion
        }

        #region Cadastrar CLIENTES,FUNCIONARIOS E SERVIÇOS
        static MeusClientes CadastrarCliente()
        {
            Cliente c1 = new Cliente();
            c1.Incluir(1, "Thamirys", "999999999", "12345678901");
            MeusClientes mc = new MeusClientes();
            mc.Incluir(c1);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Cliente Cadastrado com Sucesso");
            Console.WriteLine("------------------------------------------------");
            return mc;
        }

        static Funcionario.MeusFuncionarios CadastrarFuncionario()
        {
            Funcionarios f1 = new Funcionarios();
            f1.Incluir("Marcos", "999999999", Funcionarios.CargoFunc.Cabelereiro);
            Funcionario.MeusFuncionarios funs = new Funcionario.MeusFuncionarios();
            funs.Incluir(f1);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Funcionario Cadastrado com Sucesso");
            Console.WriteLine("------------------------------------------------");
            return funs;
        }

        static Funcionario.ServicosPrestados IncluirMeusServicos()
        {
            Funcionario.Servico s1 = new Funcionario.Servico();
            
            s1.Incluir(1, "Corte de Cabelo", 59, 130,
              CadastrarFuncionario().Funcionarios.FirstOrDefault
              (x => x.Cargo == Funcionarios.CargoFunc.Cabelereiro));

            Funcionario.ServicosPrestados sp = new Funcionario.ServicosPrestados();
            sp.Incluir(s1);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Serviço Cadastrado com Sucesso");
            Console.WriteLine("------------------------------------------------");
            return sp;
        }
        #endregion



    }
}
