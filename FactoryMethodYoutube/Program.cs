using FactoryMethodPizzaMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPizzaMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnkaraPizzaStore ankaraPizzaStore = new AnkaraPizzaStore();
            ankaraPizzaStore.OrderPizza("cheese");
            Console.WriteLine("Pizza ordered in Ankara");

            İstanbulPizzaStore istanbulPizzaStore = new İstanbulPizzaStore();
            istanbulPizzaStore.OrderPizza("veggie");
            Console.WriteLine("Pizza ordered in İstanbul");

            Console.ReadLine();
        }
    }


    interface IPizza
    {
        void Prepare();
        void Bake();
        void Cut();
    }

    class CheesePizza : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baked!");
        }

        public void Cut()
        {
            Console.WriteLine("Cut!");
        }

        public void Prepare()
        {
            Console.WriteLine("Prepared!");
        }
    }

    class VeggiePizza : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baked!");
        }

        public void Cut()
        {
            Console.WriteLine("Cut!");
        }

        public void Prepare()
        {
            Console.WriteLine("Prepared!");
        }
    }

    abstract class PizzaStore
    {
        protected abstract IPizza CreatePizza(string type); //protected ile bu metot sadece kalıtım yoluyla PizzaStore alındıysa 3çağrılabilir

        public IPizza OrderPizza(string type)
        {//PizzaStore da öncelikle bir Cheese ya da Veggie Pizza oluşturalım
            IPizza pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            return pizza;
        }//herhangi bir mağazada bir pizza sipariş edildiğinde hangi adımlar uygulanıyor merkezileştirmiş olduk
    }

    //CreatePizza metodu ile pizzanın yaratılması işlemini alt sınıflara yüklenmiş oldum, sipariş verme işlemi ortak bir noktadan yapıldı.
    class AnkaraPizzaStore : PizzaStore
    {
        protected override IPizza CreatePizza(string type)
        {
            switch (type)
            {
                case "cheese":
                    return new CheesePizza();
                case "veggie":
                    return new VeggiePizza();
                default:
                    throw new ArgumentException("Invalid pizza type", nameof(type));
            }
        }
    }
    class İstanbulPizzaStore : PizzaStore
        {
            protected override IPizza CreatePizza(string type)
            {
                switch (type)
                {
                    case "cheese":
                        return new CheesePizza();
                    case "veggie":
                        return new VeggiePizza();
                    default:
                        throw new ArgumentException("Invalid pizza type", nameof(type));
                }
        }
    }
}
