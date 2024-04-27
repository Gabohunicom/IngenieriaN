using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Prueba
{
  public class mail
  { public string Enviar(string Para, string Asunto, String Texto)
    { string Desde = "tucorreoelectronico@gmail.com";
      try
      { MailMessage correo = new MailMessage();
        correo.From = new MailAddress(Desde, "Verification code");
        correo.To.Add(new MailAddress(Para));
        correo.Subject = Asunto;
        correo.Body = Texto;
        correo.IsBodyHtml = false;

        SmtpClient Envio = new SmtpClient("smtp.gmail.com", 587);
        Envio.Credentials = new NetworkCredential(Desde, "tucontraseña");
        Envio.DeliveryMethod = SmtpDeliveryMethod.Network;
        Envio.EnableSsl = true;
        //Envio.UseDefaultCredentials = false;

        Envio.Send(correo);
        return "Ok";
      }
      catch(Exception er)
      { return er.Message.ToString(); }
    }
  }
}