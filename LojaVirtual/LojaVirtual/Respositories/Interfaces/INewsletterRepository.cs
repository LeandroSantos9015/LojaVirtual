using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Respositories.Interfaces
{
    public interface INewsletterRepository
    {
        #region Crud
        void Cadastrar(NewsletterEmail newsletter);

        IEnumerable<NewsletterEmail> ObterTodasNewLetter();

        #endregion
    }
}
