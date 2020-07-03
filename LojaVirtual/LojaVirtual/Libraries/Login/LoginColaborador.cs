using LojaVirtual.Libraries.Session;
using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private Sessao _sessao;
        private string Key = "Login.Colaborador";

        public LoginColaborador(Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            string colaboradorJsonString = JsonConvert.SerializeObject(colaborador);

            _sessao.Cadastrar(Key, colaboradorJsonString);
        }

        public Colaborador GetColaborador()
        {
            string colaboradorJsonString = _sessao.Consultar(Key);

            if (!string.IsNullOrEmpty(colaboradorJsonString))
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJsonString);

            return null;
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}