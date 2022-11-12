using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public  class MailSender
    {
        public static void EnviarMailBloqueo(string pDireccion, string pUserName, string pClave)
        {
            MailMessage mensaje = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            mensaje.From = new MailAddress("GlobalLogistics.Noreply@gmail.com");
            mensaje.To.Add(new MailAddress(pDireccion));
            mensaje.Subject = "Cambio de clave por bloqueo";
            string texto = "Estimado " + pUserName + ", usted bloqueó su cuenta en Global Logistics por repetidos intentos incorrectos de login. Su contraseña fue modificada. Por favor tome nota de la nueva clave e intente ingresar con la misma. La nueva clave es: " + pClave + ". ";
            string textolisto = texto.Replace("/n", Environment.NewLine);
            mensaje.Body = textolisto;

            smtp.Port = 25;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("GlobalLogistics.Noreply@gmail.com", "irctknqzrcjsakxx");
           // smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mensaje);
        }
    }
}
