using LojaVirtual.DataBase;
using LojaVirtual.Models;
using LojaVirtual.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Respositories.Contracts
{
    public class NewsletterRepository : INewsletterRepository
    {
        private LojaVirtualContext _banco;

        public NewsletterRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(NewsletterEmail newsletter)
        {
            _banco.NewsletterEmails.Add(newsletter);
            _banco.SaveChanges();
            
        }

        public IEnumerable<NewsletterEmail> ObterTodasNewLetter()
        {
            return _banco.NewsletterEmails.ToList();   
        }
    }
}
