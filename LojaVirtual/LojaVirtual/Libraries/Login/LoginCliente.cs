using LojaVirtual.Libraries.Session;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private Sessao _sessao;
        private string Key = "Login.Cliente";

        public LoginCliente(Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //Armazenar na sessao
            //Serializar
            string clienteJsonString = JsonConvert.SerializeObject(cliente);

            _sessao.Cadastrar(Key, clienteJsonString);
        }

        public Cliente GetCliente()
        {
            string clienteJsonString = _sessao.Consultar(Key);

            if (!string.IsNullOrEmpty(clienteJsonString))
                return JsonConvert.DeserializeObject<Cliente>(clienteJsonString);

            return null;
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}