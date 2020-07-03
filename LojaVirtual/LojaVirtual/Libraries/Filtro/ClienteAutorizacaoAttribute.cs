using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    /*
     - Autorização
     - Recurso
     - Ação
     - Exceção
     - Resultado
     */
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter //, IResourceFilter, IActionFilter, IExceptionFilter, IResourceFilter
    {
        LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = context.HttpContext.RequestServices.GetService(typeof(LoginCliente)) as LoginCliente;

            Cliente cliente = _loginCliente.GetCliente();

            if (cliente is null)
            {
                 context.Result = new ContentResult() { Content = $"Acesso Negado" };
            }
            else
            {

            }
        }
    }
}
