using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.DataBase;
using LojaVirtual.Respositories;
using LojaVirtual.Respositories.Interfaces;
using Microsoft.AspNetCore.Http;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Libraries.Filtro;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _repositoryCliente;
        private INewsletterRepository _repositoryNewsLetter;
        private LoginCliente _loginCliente;

        public HomeController(IClienteRepository repositoryCliente, INewsletterRepository repositoryNewsLetter, LoginCliente loginCliente)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryNewsLetter = repositoryNewsLetter;
            _loginCliente = loginCliente;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] NewsletterEmail newsletter)
        {
            // validações do data anottations
            if (ModelState.IsValid)
            {
                _repositoryNewsLetter.Cadastrar(newsletter);

                TempData["MSG_S"] = "E-mail cadastrado! Agora você vai receber promoções especiais no seu e-mail!! Fique atento as novidades!!";

                return View(); //RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato();

                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool ehValido = Validator.TryValidateObject(contato, contexto, listaMensagens, true);


                if (ehValido)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var v in listaMensagens)
                        sb.Append(v.ErrorMessage + "<br />");

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }

            }
            catch (Exception e)
            {
                e.ToString();
                ViewData["MSG_E"] = "Ocorreu algum erro ao tentar enviar a msg";

                //TODO - Melhorar mensagem
            }

            return View("Contato");

        }

        public IActionResult Contato()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Cliente cliente)
        {
            Cliente clienteDB = _repositoryCliente.Login(cliente.Email, cliente.Senha);

            if (clienteDB != null)
            {
                _loginCliente.Login(clienteDB);

                return new RedirectResult(Url.Action(nameof(Painel)));

            }
            else
            {
                ViewData["MSG_E"] = "Usuário e/ou senha não encontrados, verifique o e-mail e senha digitados";
                return View();
            }
        }

        [HttpGet]
        [ClienteAutorizacao]
        public IActionResult Painel()
        {
            return new ContentResult { Content = "Este é o painel do cliente!" };

        }

        [HttpGet]
        public IActionResult CadastroCliente()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositoryCliente.Cadastrar(cliente);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!!";

                //TODO - Implementar redirecionamento diferente (painel, carrinho de compras)

                return View();

            }

            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }


    }
}

