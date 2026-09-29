using System;
using System.Collections.Generic;

namespace TelebeQeydiyyatSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<int, string> telebeler = new Dictionary<int, string>
            {
                { 101, "Aqsin Elekberov" },
                { 102, "Abibas Ebusetdereov" },
                { 103, "Efsan Setiyrv" },
                { 104, "Nihad Elimmedov" },
                { 105, "Rəşad İsmayilov" }
            };

            bool davam = true;

            
            while (davam)
            {
                Console.WriteLine("\n===== TƏLƏBƏ QEYDİYYAT SİSTEMİ =====");
                Console.WriteLine("1) Tələbə əlavə et");
                Console.WriteLine("2) Tələbəni ID ilə axtar");
                Console.WriteLine("3) Bütün tələbələri göstər");
                Console.WriteLine("4) Çixiş");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                
                switch (secim)
                {
                    case "1":
                        TelebeElaveEt(telebeler);
                        break;

                    case "2":
                        TelebeAxtar(telebeler);
                        break;

                    case "3":
                        ButunTelebeleriGoster(telebeler);
                        break;

                    case "4":
                        Console.WriteLine("Proqram bağlanir. Sağ olun!");
                        davam = false;      // while dövrünü dayandırır
                        break;

                    default:
                        Console.WriteLine("Yanliş seçim! 1-4 arasinda rəqəm daxil edin.");
                        break;
                }
            }
        }

        
        static void TelebeElaveEt(Dictionary<int, string> telebeler)
        {
            Console.Write("Tələbə ID: ");

            
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Xəta: ID yalniz rəqəm olmalidir.");
                return;
            }


            if (telebeler.ContainsKey(id))
            {
                Console.WriteLine($"Xəta: {id} ID-li tələbə artiq mövcuddur ({telebeler[id]}).");
                return;
            }

            Console.Write("Tələbənin adi: ");
            string ad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ad))
            {
                Console.WriteLine("Xəta: Ad boş ola bilməz.");
                return;
            }

            telebeler.Add(id, ad.Trim());
            Console.WriteLine($"Tələbə əlavə olundu: {id} - {ad.Trim()}");
        }

        static void TelebeAxtar(Dictionary<int, string> telebeler)
        {
            Console.Write("Axtarilan ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Xəta: ID yalniz rəqəm olmalidir.");
                return;
            }

            
            if (telebeler.TryGetValue(id, out string ad))
                Console.WriteLine($"Tapildi: {id} - {ad}");
            else
                Console.WriteLine($"{id} ID-li tələbə tapilmadi.");
        }

        
        static void ButunTelebeleriGoster(Dictionary<int, string> telebeler)
        {
            if (telebeler.Count == 0)
            {
                Console.WriteLine("Siyahi boşdur.");
                return;
            }

          
            List<int> idler = new List<int>(telebeler.Keys);
            idler.Sort();

            Console.WriteLine($"\nÜmumi tələbə sayi: {telebeler.Count}");
            Console.WriteLine("ID     Ad");
            Console.WriteLine("----------------------------");

            foreach (int id in idler)
                Console.WriteLine($"{id,-6} {telebeler[id]}");
        }
    }
}
