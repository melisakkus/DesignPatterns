using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee melisa = new Employee { Name = "Melisa Akkuş" };
            Employee ahmet = new Employee { Name = "Ahmet Akkuş" };
            Employee sena = new Employee { Name = "Sena Akkuş" };
            Employee pilotlar = new Employee { Name = "THY pilotları" };
            Employee doktorlar = new Employee { Name = "Ankara Hastanesi Çalışanları" };

            //ağaç yapısı
            melisa.AddSubordinate(ahmet);
            melisa.AddSubordinate(sena);
            ahmet.AddSubordinate(pilotlar);
            sena.AddSubordinate(doktorlar);

            Console.WriteLine("Yönetici: " + melisa.Name);
            foreach (Employee manager in melisa)
            {
                Console.WriteLine("  Müdür: " + manager.Name);
                foreach(IPerson employee in manager)
                {
                    Console.WriteLine("    Çalışan: " + employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
    
    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person) //hiyerarşiye birisini eklemek
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person) //hiyerarşiyden birisini çıkarmak
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)//hiyerarşideki bir nesneye ulaşmak
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}

//nesneler arası hiyerarşi ve bu hiyerarşik nesnelere istediğimiz zaman ulaşabilmek
//bir kurumdaki roller ve bu rollerin ağaç yapısı gibi
//nesnelere ulaşabilmek için (hiyerarşik yapı) Enumerable bir yapı ile implemente ettik
//foreach ile gezmemizi sağlaycak IEnumerable özelliği katmak ve liste vasıtasıyla altnesnelere ekleme çıkarmalar yapmak

//public IEnumerator<IPerson> GetEnumerator()
//{
//    throw new NotImplementedException();
//}

//IEnumerator IEnumerable.GetEnumerator()
//{
//    throw new NotImplementedException();
//}

//IPerson kullanarak tedarikçi gibi farklı sınıflarıda dahil edip AddSubordinate ile hiyerarşiye ekleyebilirim
