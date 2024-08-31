using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CreditManager manager = new CreditManager();
            CreditBase manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            Console.ReadLine();
        }
    }

    abstract class CreditBase //temel operasyon sınıfımız
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {//kredi hesaplamasında iflerle halletmek yerine concrete oluşturup onunla işlemi yapmak

            int result = 1;
            for(int i = 1 ; i < 5; i++)
            {
                result *= i ;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        int _cachedValue;
        public override int Calculate()
        {
            if(_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
}

// Bir sınıfın çağırdığı bir işlem var, ilk kez çağrıldığında onu oluştur, tekrar çağrıldığında daha önce çağrıldığındakini kullanma süreci üzerine
// basit bir cacheleme gibi
// bir kaynak veya hesaplama sonucu sabit bir işlem gibiyse kullanılabilir
// Thread.Sleep(1000); 1000 milisaniye(1 saniye) süreyle beklemesini sağlar