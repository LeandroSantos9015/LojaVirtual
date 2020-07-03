using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            string endSmtp = "smtp.live.com";
            int porta = 587;
            string email = "leandrosantos_11@hotmail.com";
            string senha = "1qaz2wsX1qaz11";

            string destino = "leandrosantos_11@hotmail.com";

            string assunto = "Contato Loja Virtual";
            string corpoMsg = String.Format(@"<h2>Contato Loja Virtual</h2>" +
                "<b>Nome: </b>{0} <br />" +
                "<b>Email: </b>{1} <br />" +
                "<b>Texto: </b>{2} <br />" +
                "<br />E-mail enviado automaticamente do site LojaVirtual.",
                contato.Nome, contato.Email, contato.Texto
                );


            // Servidor de envio
            SmtpClient smtp = new SmtpClient(endSmtp, porta);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(email, senha);
            smtp.EnableSsl = true;

            // construtor de mensagens
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(email);
            mensagem.To.Add(destino);
            mensagem.Subject = assunto;
            mensagem.IsBodyHtml = true;
            mensagem.Body = corpoMsg;

            smtp.Send(mensagem);

        }

    }
}
