using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager1 = new ProductManager(new MlsLogger());
            productManager1.Save();

            ProductManager productManager2 = new ProductManager(new Log4NetAdapter());
            productManager2.Save();
        }
    }

    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class MlsLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged,{0}",message);
        }
    }

    //yeni bir loglama frameworkü kullanmak istersek? NuGetten aldık, classı değiştiremiyoruz
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged,{0}", message);
        }
    }

    //productManager da log4Net'i productManager içerisine dokunmadan
    //(SOLID-O : yeni bir özellik eklediğinde mevcut sistemin değişikliğe uğramaması) nasıl çağırabilirim?

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}

//özellikle farklı sistemlerin kendi sistemlerimize entegre edilmesi durumunda
//kendi sistemimiz bozulmadan farklı sistemin bizim sistemimizmiş gibi davranmasını sağlamak 

//bir servisi referans ettiğimizde direkt olarak metot içerisinde kullanırsak ona bağımlı kalırız
//bu bağımlılığın önüne geçmek istiyoruz

//ILogger cinsini istemiştim ProductManagerda. Yeni sistemi bir adapter ile ILogger'a adapte edebilirim.
