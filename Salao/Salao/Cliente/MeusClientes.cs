using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Salao
{
    class MeusClientes
    {
        public List<Cliente> Clientes { get; set; }

        public MeusClientes()
        {
            Clientes = new List<Cliente>();
        }

        public void Incluir(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void AlterarUmCliente(int id, string nomeNovo, string telefoneNovo)
        {
            Cliente cliente = Clientes.FirstOrDefault(cli => cli.Id == id);
            if (cliente != null)
            {
                cliente.Alterar(nomeNovo, telefoneNovo);
            }
        }

        public void ExcluirUmCliente(int id)
        {
            Clientes.RemoveAll(cli => cli.Id == id);
        }
    }
}
