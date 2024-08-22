using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logging();
            Console.ReadLine();
        }

        private static void Logging()
        {
            try
            {
                Console.WriteLine("Bir sayı giriniz: ");
                int sayi = Convert.ToInt32(Console.ReadLine()); //ekrandan aldığm değer yani Console.ReadLine() string, 

                if (sayi == 3)
                {
                    throw new Exception("Geçersiz sayı");
                }
            }
            catch (Exception hata) // hatanın bilgilerine ulaşmak için Exception kullanacağız.
            {
                File.AppendAllText("log.txt",Environment.UserName); // bir dosya açar, bu yola ekleme yapar ve kapatır, bu dosya yoksa dosyayı yaratır ekleme yapar ve kapatır
                //log.txt dosyası yok bunu oluşturacak ve üzerine Environment.UserName : bilgisayar ismini ekleme yapacak
                File.AppendAllText("log.txt", Environment.NewLine);
                File.AppendAllText("log.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                //kullanıcı ismini yazdı, yeni satıra geçti,tarih ve saat girdi
                File.AppendAllText("log.txt", "\r\n"); // yeni satır için
                File.AppendAllText("log.txt", hata.Message);
                File.AppendAllText("log.txt", "@");
                File.AppendAllText("log.txt", hata.StackTrace); // hatanın hangi dosyada tam nerede olduğunu yazdırıyorum 
                File.AppendAllText("log.txt", Environment.NewLine + "**********" + Environment.NewLine);

            }

        }
    }
}

// try - catch : olması gereken yapıdaysa try, hata verdiyse catch

// Loglama ; hatayı bir dosya olarak nasıl kaydetmek isterim? 
// Ekrandan bir sayı alalım, bu sayı bir değere eşit olduğunda bir hata oluştursun ve bu hatayı benim proje dosyama kaydetsin