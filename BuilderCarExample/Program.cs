using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderCarExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(new HondaBuilder());
            Vehicle hondaInstance = director.CreateInstance();
            Console.WriteLine(hondaInstance);

            Director director2 = new Director(new MercedesBuilder());
            Vehicle mercedesInstance = director2.CreateInstance();
            Console.WriteLine(mercedesInstance);
        }
    }

    interface IVehicleBuilder //nesnenin oluşma adımlarını içerir ve geriye nesneyi döndürür
    {
        void SetBrand();
        void SetModel();
        void SetProperties();
        Vehicle GetVehicle();
    }

    class Vehicle
    {
        public string Brand;
        public string Model;
        public Dictionary<string, object> Properties { get; set; }
            = new Dictionary<string, object>();
        public override string ToString()
        {
            return $"{Model} model {Brand} marka araç üretilmiştir";
        }
    }

    class MercedesBuilder : IVehicleBuilder
    {
        private readonly Vehicle vehicle = new Vehicle(); //vehicle'ı mercedes özellikeleriyle dolduruyorum
        public Vehicle GetVehicle()
        {
            return vehicle;
        }

        public void SetBrand()
        {
            vehicle.Brand = "Mercedes";
        }

        public void SetModel()
        {
            vehicle.Model = "S600";
        }

        public void SetProperties()
        {
            vehicle.Properties["weight"] = 1500;
            vehicle.Properties["colour"] = "red";
        }
    }


    class HondaBuilder : IVehicleBuilder
    {
        private readonly Vehicle vehicle = new Vehicle();
        public Vehicle GetVehicle()
        {
            return vehicle;
        }

        public void SetBrand()
        {
            vehicle.Brand = "Honda";
        }

        public void SetModel()
        {
            vehicle.Model = "XM";
        }

        public void SetProperties()
        {
            vehicle.Properties["weight"] =  1200;
            vehicle.Properties["colour"] = "blue";
        }
    }

    class Director // adımları belirler ve clienttan gizler
    {
        private IVehicleBuilder _vehicleBuilder;
        public Director(IVehicleBuilder vehicleBuilder)
        {
            _vehicleBuilder = vehicleBuilder;
        }

        public Vehicle CreateInstance()
        {
            _vehicleBuilder.SetBrand();
            _vehicleBuilder.SetModel();
            _vehicleBuilder.SetProperties();
            return _vehicleBuilder.GetVehicle();
        }
    }
}
