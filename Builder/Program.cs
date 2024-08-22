using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder //arka arkaya işlemler sonucu bir nesne çıkarmak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.IsDiscountedApplied);
            Console.ReadLine();
        }

    }

    class ProdcutViewModel //ekranda kullanıcıya göstereceğiz
    {
        public int Id {  get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice {  get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool IsDiscountedApplied { get; set; }
    }
    //bu view modeli üretecek bir business'a ihtiyacımız var, çeşitli işlemler içerir
    abstract class ProductBuilder     //abstract builder
    {
        public abstract void GetProductData(); //temel ürün bilgilerinin çekilmesi
        public abstract void ApplyDiscount();
        public abstract ProdcutViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProdcutViewModel model = new ProdcutViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice*(decimal)0.90; //yeni müşteriye teşvik
            model.IsDiscountedApplied = true;
        }

        public override ProdcutViewModel GetModel()
        {
            return model;
        }
    }


    class OldCustomerProductBuilder : ProductBuilder
    {
        ProdcutViewModel model = new ProdcutViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.IsDiscountedApplied = false;
        }

        public override ProdcutViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}


//ortaya bir nesne örneği çıkarmayı hedefler, bu nesne örneği birbiri ardına atanacak adımların sırasıyla işlenmesi sonucu oluşur
//iş katmanlarında ya da arayüz katmanlarında kodları iflemek yerine ilgili üreticinin enjekte edilmesi ve ona göre ortaya bir nesnenin çıkarılması
//sisteme yeni gelen bir kullanıcıya (daha önce hiç alışeriş yapmamış) gösterilen ürün bilgileri ile
//daha önce gelmiş birisine gösterilen bilgilerin farklı olması, nesnenin değiştirilmesi

//amaç bir model üretmek, o modeli de birbiri ardına gelecek işlemlere göre oluşturmak