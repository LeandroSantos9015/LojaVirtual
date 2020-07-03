using LojaVirtual.DataBase;
using LojaVirtual.Models;
using LojaVirtual.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Respositories.Contracts
{
    public class ClienteRepository : IClienteRepository
    {
        private LojaVirtualContext _banco;

        public ClienteRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Cliente cliente)
        {
            _banco.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _banco.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Cliente cliente = ObterCliente(Id);

            _banco.Remove(cliente);
            _banco.SaveChanges();
        }

        public Cliente Login(string email, string senha)
        {
            return _banco.Clientes.Where(x => x.Email.Equals(email) && x.Senha.Equals(senha)).FirstOrDefault();
        }

        public Cliente ObterCliente(int Id)
        {
            return _banco.Clientes.Find(Id);
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            return _banco.Clientes.ToList();
        }
    }
}
