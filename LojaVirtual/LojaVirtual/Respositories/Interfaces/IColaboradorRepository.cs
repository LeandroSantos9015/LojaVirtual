using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Respositories.Interfaces
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string email, string senha);

        #region Crud
        void Cadastrar(Colaborador colaborador);

        void Atualizar(Colaborador colaborador);

        void Excluir(int id);

        Colaborador ObterColaborador(int id);

        IEnumerable<Colaborador> ObterTodosColaboradores();
        #endregion
    }
}