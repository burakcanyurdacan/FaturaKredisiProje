using FaturaKredisiProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FaturaKredisiProje.MyMethods
{
    public class EpostaGonder
    {
        public string Gonder(Mail p)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("info@nakitfaturanda.com", "MazluM7272!");
                smtp.Port = 587;
                smtp.Host = "mail.nakitfaturanda.com";
                smtp.EnableSsl = false;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress("info@nakitfaturanda.com");
                mailMessage.To.Add("chrelloss34@gmail.com");
                mailMessage.Subject = "Yeni Kredi Başvurusu İşlemi - " + p.AdSoyad;
                mailMessage.Body = "Aşağıda bilgileri bulunan kişi, faturalı hattı için bireysel kredi başvurusunda bulunmak istemektedir.<br/><br/>" +
                    "<strong>Ad - Soyad: </strong>" + p.AdSoyad + "<br/>" +
                    "<strong>Telefon numarası: </strong>" + p.Telefon + "<br/>" +
                    "<strong>Doğum Yılı: </strong>" + p.Dogumyil + "<br/>" +
                    "<strong>Şehir: </strong>" + p.Sehir + "<br/>" +
                    "<strong>Kullandığı hat: </strong>" + p.TelefonHat;

                smtp.Send(mailMessage);
                return "0";
            }
            catch (Exception ex)
            {
                return ex.HResult.ToString() + " " + ex.Message;
            }
        }
    }
}