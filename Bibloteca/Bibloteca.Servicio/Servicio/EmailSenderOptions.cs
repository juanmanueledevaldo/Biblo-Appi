using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Service.Service
{
    public class EmailSenderOptions
    {
        string host = "3amprg.gomez.vallejo.rodrigo.gmail.com";
        int port = 587;
        string user = "rodrigogomez1234";//aqui va el correo
        private readonly string password = "";//aqui va el password del correo



        private SmtpClient cliente;
      
        private MailMessage email;
        public void GestorCorreo()
        {
            cliente = new SmtpClient(host, port)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, password)
            };
        }
        public void EnviarCorreo(string destinatario, string asunto, string mensaje, bool esHtlm = false)
        {
            GestorCorreo();
            email = new MailMessage(user, destinatario, asunto, mensaje);
            email.IsBodyHtml = esHtlm;

            cliente.Send(email);
        }
        public void EnviarCorreo(MailMessage message)
        {
            cliente.Send(message);
        }
        public async Task EnviarCorreoAsync(MailMessage message)
        {
            await cliente.SendMailAsync(message);
        }
    }
}
