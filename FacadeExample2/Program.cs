using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeExample2
{// bir siparişin sisteme girilmesi durumunda kullanıcıya mail/sms bilgilendirmesi iletilsin

    internal class Program
    {
        static void Main(string[] args)
        {
            OrderFacade orderFacade = new OrderFacade();
            orderFacade.MakeOrder();
            //SmsSender smsSender = new SmsSender(); 
            //EmailSender emailSender = new EmailSender();
            //Logger logger = new Logger();
            //smsSender.Send();
            //emailSender.Send();
            //logger.Log();
        }
    }

    public class SmsSender
    {
        public void Send() => Console.WriteLine("Sms gönderiliyor..."); 
    }

    class EmailSender
    {
        public void Send() => Console.WriteLine("Email gönderiliyor...");
    }

    class Logger
    {
        public void Log() => Console.WriteLine("Loglama yapılıyor...");
    }

    class OrderFacade
    {
        private readonly SmsSender smsSender = new SmsSender();
        private readonly  EmailSender emailSender = new EmailSender();
        private readonly Logger logger = new Logger();

        public void MakeOrder()
        {
            smsSender.Send();
            emailSender.Send();
            logger.Log();
        }
    }
}
