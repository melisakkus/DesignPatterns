using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Cashing : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttongConcernsFacade();
        }

        public void Save()
        {
            _concerns.Logging.Log(); 
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
        }
    }

    class CrossCuttongConcernsFacade
    {//bu sınıfları her seferinde tanımlamak ve kullanmak yerine bunları bir yerde topladım ve oradan çağıracağım
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttongConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Cashing();
            Authorize = new Authorize();
        }
    }
}


// facade : cephe, dış görünüş
// çeşitli sınıfları bir cephede toplayıp o cephe üzerinden sınıflara ulaşmak

////private ILogging _logging;
////private ICaching _caching;
////private IAuthorize _authorize;

////public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)
////{
////    _logging = logging;
////    _caching = caching;
////    _authorize = authorize;
////}
////public void Save()
////{
////    _logging.Log();
////    _caching.Cache();
////    _authorize.CheckUser();
////    Console.WriteLine("Saved");
////}
