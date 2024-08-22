using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {
            //private bir constructor ile dış erişim engellenir:constructorı olan ama dışarıdan erişilemeyen bir nesne
            //Private bir constructor oluşturmanın amacı, sınıfın dışından bu sınıfın örneğinin (instance) oluşturulmasını engellemektir.
            //Yani, sınıfın new anahtar kelimesiyle dışarıdan direkt olarak örneklendirilememesini sağlar.
        }

        //singleton örneğini oluşturacak metot static olarak yazılır ve bu nesne kendisini döndürür
        //eğer daha önce CustomerManager oluşuturulduysa onu döndürelim, yoksa yeni oluşturalım
        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
                return _customerManager;
            }

            // return _customerManager ?? (_customerManager = new CustomerManager());

            //?? Operatörü: Bu operatör, null - coalescing operatörü olarak adlandırılır.
            //Sol tarafındaki ifade null ise sağ tarafındaki ifadeyi döndürür.
            //Sol tarafındaki ifade null değilse, yani zaten bir değeri varsa, bu değeri döndürür.
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}



