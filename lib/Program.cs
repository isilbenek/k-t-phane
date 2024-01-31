using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    internal class Program
    {


        class Book
        {
            public string ad { get; set; }
            public string yazar { get; set; }
            public int kopya { get; set; }
            public bool ödünç;
        }

        class Kütüphane
        {
            private const int maxKitap = 200;
            private Book[] books;
            private int kitapSayaç;



            public Kütüphane()
            {
                books = new Book[maxKitap];
                kitapSayaç = 0;
            }

            public void kitapEkle(string ad, string yazar, int kopya)
            {
                if (kitapSayaç < maxKitap)
                {
                    Book newBook = new Book { ad = ad, yazar = yazar, kopya = kopya, ödünç = false };
                    books[kitapSayaç] = newBook;
                    kitapSayaç++;
                    Console.WriteLine("Kitap eklendi: ");
                }
                else
                {
                    Console.WriteLine("Kütüphane dolu, yeni kitap eklenemiyor.");
                }
            }

            public void kitaplarıGöster()
            {
                Console.WriteLine("Kütüphanedeki Tüm Kitaplar:");
                for (int i = 0; i < kitapSayaç; i++)
                {
                    Console.WriteLine($"Başlık: {books[i].ad}, Yazar: {books[i].yazar}, Kopya Sayısı: {books[i].kopya}");
                }
            }

            public void kitapAra(string ara)
            {
                Console.WriteLine($"\"{ara}\" ile eşleşen kitaplar:");
                for (int i = 0; i < kitapSayaç; i++)
                {
                    if (books[i].ad.Contains(ara) || books[i].yazar.Contains(ara))
                    {
                        Console.WriteLine($"Başlık: {books[i].ad}, Yazar: {books[i].yazar}, Kopya Sayısı: {books[i].kopya}");
                    }
                }
            }

            public void ödünçAl(string ad)
            {
                for (int i = 0; i < kitapSayaç; i++)
                {
                    if (books[i].ad == ad && books[i].kopya > 0 && !books[i].ödünç)
                    {
                        books[i].kopya--;
                        books[i].ödünç = true;
                        Console.WriteLine($"{ad} ödünç alındı.");
                        return;
                    }
                }
                Console.WriteLine("Kitap kütüphanede bulunmuyor.");
            }

            public void kitapİade(string ad)
            {
                for (int i = 0; i < kitapSayaç; i++)
                {
                    if (books[i].ad == ad && books[i].ödünç)
                    {
                        books[i].kopya++;
                        books[i].ödünç = false;
                        Console.WriteLine($"{ad} iade edildi.");
                        return;
                    }
                }
                Console.WriteLine("Kitap iade edilemedi.");
            }
        }


        static void Main(string[] args)
        {
            Kütüphane library = new Kütüphane();

            while (true)
            {
                Console.WriteLine("*******************");
                Console.WriteLine("Kütüphane Yönetim Sistemi");
                Console.WriteLine("1. Yeni Kitap Ekle");
                Console.WriteLine("2. Tüm Kitapları Listele");
                Console.WriteLine("3. Kitap Ara");
                Console.WriteLine("4. Kitap Ödünç Al");
                Console.WriteLine("5. Kitap İade Et");
                Console.WriteLine("6. Çıkış");
                Console.WriteLine("*******************");

                Console.Write("Seçiminiz: ");
                int seçim = Convert.ToInt32(Console.ReadLine());

                switch (seçim)
                {
                    case 1:
                        Console.Write("Kitap Başlığı: ");
                        string ad = Console.ReadLine();
                        Console.Write("Yazar: ");
                        string yazar = Console.ReadLine();
                        Console.Write("Kopya Sayısı: ");
                        int kopya = Convert.ToInt32(Console.ReadLine());
                        library.kitapEkle(ad, yazar, kopya);
                        break;
                    case 2:
                        library.kitaplarıGöster();
                        break;
                    case 3:
                        Console.Write("Aranacak Kelime: ");
                        string ara = Console.ReadLine();
                        library.kitapAra(ara);
                        break;
                    case 4:
                        Console.Write("Ödünç Alınacak Kitabın Başlığı: ");
                        string borrowTitle = Console.ReadLine();
                        library.ödünçAl(borrowTitle);
                        break;
                    case 5:
                        Console.Write("İade Edilecek Kitabın Başlığı: ");
                        string iadeAd = Console.ReadLine();
                        library.kitapİade(iadeAd);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir sayı girin:");
                        break;
                }
            }
        }
    }
}



