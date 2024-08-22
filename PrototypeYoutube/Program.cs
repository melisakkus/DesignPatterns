using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeYoutube
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public class Belge
        {
            private int id;
            private string ad;
            private BelgeTuru belgeTuru;
            private Kategori kategori;
            private string veri;

            public Belge(int id, string ad, BelgeTuru belgeTuru, Kategori kategori, string veri)
            {
                this.id = id;
                this.ad = ad;
                this.belgeTuru = belgeTuru;
                this.kategori = kategori;
                this.veri = veri;                
            }

            public Belge()
            {     
            }
        }

        public class BelgeTuru
        {
            public BelgeTuru()
            {                
            }
            private int id { get; set; }
            private string ad {  get; set; }
        }

        public class Kategori
        {
            public Kategori()
            {

            }
            private int id { get; set; }
            private string ad { get; set; }
        }


    }
}

//prototype design pattern ; bir nesneyi klonlayarak yeni bir ens oluşturmaya dayanır, new kullanmıyoruz ve bir nesneyi en baştan oluşturmuyoruz
//var olan nesneyi kopyalıyoruz, kopyalanan ilk nesne prototype, kopyalayarak elde ettiğimiz yeni nesne de klon.
