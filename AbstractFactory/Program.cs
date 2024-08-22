using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log();
    }

    public class Log4NetLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    public class NLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache();
    }

    public class MemCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {//loglama ve casch için bir fabrika açtık 
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    //CrossCuttingConcernsFactoryden yeni fabrikalar üretelim
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    //burada fabrika demek iş süreçleri ; iş katmanındaki işlemler
    //client bu iş katmanını kullanan kişi
    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log();
            _caching.Cache();
            Console.WriteLine("Products Listed");
        }
    }
}

//somut bir nesne herhangi bir inheritance ya da implementasyon almadıysa !!!

//Abstract Factory Design toplu nesne kullanımı ihtiyaçlarında nesne kullanımını kolaylaştırmak,
//standart nesne ihtiyacı olması durumunda kullanılır

//Caching ve Logging olmak üzere iki temel nesne oluşturduk (soyut)
//bunları inherite eden istediğimiz kadar yeni nesne oluiturabiliriz
//her seferinde iflerle döngü oluşturmak istemedik

//Duruma göre bizim için Loglama olarak Log4Net - Cashing olarak RedisCache üreten fabrikalara ihtiyacımız var