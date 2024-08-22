using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { FirstName = "Melisa", LastName="Akkuş",City="Ankara",Id=10};
            //elimdeki nesneyi kullanarak o nesnenin bir klonunu oluşturacağım

            var customer2 = (Customer)customer1.Clone();
            //nesneyi klonladığımızda onu Person olarak alıyor ; customer2. dediğimizde city gelmedi,(Customer) ekledik
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.ReadLine();
            //yeni bir nesne oluşturuluyor ikisi ayrı nesne isimleri birbirini etkilemiyor
        }
    }

    //prototip temel nesne : Person
    //temel nesneyi prototip haline getirmek için onun soyut bir klon metodundan beslenmesi gerekir
    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone() //elimizdeki Customerı klonlamamızı sağlar
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone() //elimizdeki Customerı klonlamamızı sağlar
        {
            return (Person)MemberwiseClone();
        }
    }
}

//Amaç nesne üretim maliyetlerini minimize etmektir
//Elimizdeki temel bir sınıfın prototipini oluşturup onun üzerinden yeni nesne klonlama sürecini sürdürebiliriz.

//Prototype Design Pattern, yazılım tasarımında kullanılan bir kreasyonel tasarım desenidir.
//Bu desen, mevcut bir nesnenin kopyalarını oluşturarak yeni nesneler yaratmayı sağlar. Kopyalama işlemi, genellikle
//derin kopya (deep copy) veya yüzeysel kopya (shallow copy) yöntemleriyle gerçekleştirilir.

//Bir oyun geliştirdiğinizi düşünün. Bu oyunda birçok farklı türde düşman (enemy) var ve
//her düşmanın farklı bir yapısı ve özellikleri bulunuyor. Ancak, bu düşmanları sürekli olarak sıfırdan yaratmak yerine,
//mevcut bir düşmanın kopyasını alarak, özelliklerini değiştirmek ve oyuna eklemek çok daha verimli olur.

//4.Çeşitli Özelliklerin Kopyalanması:
//Bir nesnenin bir kısmının veya belirli özelliklerinin kopyalanması gerektiğinde, Prototype deseni daha uygun olabilir.
//Bu durumda, bir nesneyi kopyalayarak özelliklerini değiştirmek, onu baştan oluşturmaktan daha kolay ve güvenilir olabilir.