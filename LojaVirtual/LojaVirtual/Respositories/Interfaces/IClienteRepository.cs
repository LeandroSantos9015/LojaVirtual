using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Respositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Login(string email, string senha);

        #region Crud
        void Cadastrar(Cliente cliente);

        void Atualizar(Cliente cliente);

        void Excluir(int Id);

        Cliente ObterCliente(int Id);

        IEnumerable<Cliente> ObterTodosClientes();

        #endregion
    }
}
