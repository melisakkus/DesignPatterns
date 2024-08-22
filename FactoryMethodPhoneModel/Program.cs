using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPhoneModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TurkiyePhoneFactory turkiyePhoneFactory = new TurkiyePhoneFactory();
            turkiyePhoneFactory.OrderPhone("Samsung");
            Console.WriteLine("Samsung ordered in Türkiye");


            ChinesePhoneFactory chinesePhoneFactory = new ChinesePhoneFactory();
            chinesePhoneFactory.OrderPhone("Oppo");
            Console.WriteLine("Oppo ordered in Chine");

            Console.ReadLine();
        }
    }

    interface IPhone
    {
        void Colour();
        void Model();
    }

    public class SamsungPhone : IPhone
    {
        public void Colour()
        {
            Console.WriteLine("Samsung Colours : white, black, grey,purple");
        }

        public void Model()
        {
            Console.WriteLine("Samsung Models : A2, A3, A4");
        }
    }

    public class OppoPhone : IPhone
    {
        public void Colour()
        {
            Console.WriteLine("Oppo Colours : white, black, grey");
        }

        public void Model()
        {
            Console.WriteLine("Oppo Models : A2, A3, A4");
        }
    }

    abstract class PhoneFactory
    {
        protected abstract IPhone CreatePhone(string askedphone);

        public IPhone OrderPhone(string askedphone)
        {
            IPhone phone = CreatePhone(askedphone);
            phone.Model();
            phone.Colour();
            return phone;
        }
    }

    class TurkiyePhoneFactory : PhoneFactory
    {
        protected override IPhone CreatePhone(string askedphone)
        {
            switch (askedphone)
            {
                case "Samsung":
                    return new SamsungPhone();
                case "Oppo":
                    return new OppoPhone();
                default:
                    throw new ArgumentException("Invalid phone type", nameof(askedphone));
            }
        }
    }

    class ChinesePhoneFactory : PhoneFactory
    {
        protected override IPhone CreatePhone(string askedphone)
        {
            switch (askedphone)
            {
                case "Samsung":
                    return new SamsungPhone();
                case "Oppo":
                    return new OppoPhone();
                default:
                    throw new ArgumentException("Invalid phone type", nameof(askedphone));
            }
        }
    }
}




