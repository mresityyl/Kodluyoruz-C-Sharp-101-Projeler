using System;
using System.Collections.Generic;

namespace Kodluyoruz_Console_ToDo_Uygulaması_Proje2
{
    internal class Program
    {      
        static void Main(string[] args)
        {
            Board board = new Board();
            TakimUyeleri takimUyeleri = new TakimUyeleri();

            // Varsayılan kartlar
            board.TodoKartlar.Add(new Kart("Veri Tabanı", "Veri tabanı çalış", KartBuyuklukleri.M, 1));
            board.InProgressKartlar.Add(new Kart("Web Tasarım", "Web tasarımı çalış", KartBuyuklukleri.XL, 2));
            board.DoneKartlar.Add(new Kart("Konsol Programlama", "Konsol programlama çalış", KartBuyuklukleri.L, 3));
            board.InProgressKartlar[0].Line = "IN PROGRESS";
            board.DoneKartlar[0].Line = "DONE";

            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)\n" +
                "*******************************************\n" +
                "(1) Board Listelemek\n" +
                "(2) Board'a Kart Eklemek\n" +
                "(3) Board'dan Kart Silmek\n" +
                "(4) Kart Taşımak\n"+
                "(5) Çıkış");

                int secim;
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        case 1:
                            ListeleBoard(board, takimUyeleri);
                            break;
                        case 2:
                            KartEkle(board, takimUyeleri);
                            break;
                        case 3:
                            KartSil(board);
                            break;
                        case 4:
                            KartTasi(board, takimUyeleri);
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nGeçersiz bir seçim yaptınız. Lütfen tekrar deneyin.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen tekrar deneyin.");
                }
            }
        }


        static void ListeleBoard(Board board, TakimUyeleri takimUyeleri)
        {
            // Board listeleme işlemi
            Console.WriteLine($"TODO Line [{board.TodoKartlar.Count} Kart]\n"+
            "*****************************");
            ListeleKartlar(board.TodoKartlar, takimUyeleri);

            Console.WriteLine($"IN PROGRESS Line [{board.InProgressKartlar.Count} Kart]\n" +
            "*****************************");
            ListeleKartlar(board.InProgressKartlar, takimUyeleri);

            Console.WriteLine($"DONE Line [{board.DoneKartlar.Count} Kart]\n" +
            "*****************************");
            ListeleKartlar(board.DoneKartlar, takimUyeleri);
        }

        static void ListeleKartlar(List<Kart> kartlar, TakimUyeleri takimUyeleri)
        {
            foreach (var kart in kartlar)
            {
                Console.WriteLine(
                    $"Başlık      : {kart.Baslik}\n"+
                    $"İçerik      : {kart.Icerik}\n" +
                    $"Atanan Kişi : {takimUyeleri.Uyeler[kart.AtananKisiID]}\n" +
                    $"Büyüklük    : {kart.Buyukluk}\n" +
                    "-");
            }
        }

        static void KartEkle(Board board, TakimUyeleri takimUyeleri)
        {
            Console.Write("Başlık Giriniz                                  : ");
            string baslik = Console.ReadLine();

            Console.Write("İçerik Giriniz                                  : ");
            string icerik = Console.ReadLine();

            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            int buyukluk;
            KartBuyuklukleri buyuklukDegeri = KartBuyuklukleri.XS;

            if (!int.TryParse(Console.ReadLine(), out buyukluk) || buyukluk < 1 || buyukluk > 5)
            {
                Console.WriteLine("Geçersiz bir büyüklük seçimi yaptınız. İşlem iptal edildi.");
                return;
            }
            else
            {
                switch (buyukluk)
                {
                    case 1:
                        buyuklukDegeri = KartBuyuklukleri.XS;
                        break;
                    case 2:
                        buyuklukDegeri = KartBuyuklukleri.S;
                        break; 
                    case 3:
                        buyuklukDegeri = KartBuyuklukleri.M;
                        break;
                    case 4:
                        buyuklukDegeri = KartBuyuklukleri.L;
                        break;
                    case 5:
                        buyuklukDegeri = KartBuyuklukleri.XL;
                        break;
                    default:
                        break;
                }
            }

            Console.Write("Kişi Seçiniz                                    : ");
            int atananKisiID;
            if (!int.TryParse(Console.ReadLine(), out atananKisiID) || !takimUyeleri.Uyeler.ContainsKey(atananKisiID))
            {
                Console.WriteLine("Hatalı giriş yaptınız!");
                return;
            }

            Kart kart = new Kart(baslik, icerik, buyuklukDegeri, atananKisiID);

            board.TodoKartlar.Add(kart);

            Console.WriteLine("Kart başarıyla eklendi.");
        }

        static void KartSil(Board board)
        {
            Console.Write(" Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\n " +
                "Lütfen kart başlığını yazınız: ");

            string kartBaslik = Console.ReadLine();

            bool kartSilindi = false;

            for (int i = board.TodoKartlar.Count - 1; i >= 0; i--)//Todo Kartlarda arar
            {
                Kart kart = board.TodoKartlar[i];

                if (kart.Baslik == kartBaslik)
                {
                    board.TodoKartlar.Remove(kart);
                    kartSilindi = true;
                    Console.WriteLine("Kart Silindi");
                }
            }
            for (int i = board.InProgressKartlar.Count - 1; i >= 0; i--)//InProgress Kartlarda arar
            {
                Kart kart = board.InProgressKartlar[i];

                if (kart.Baslik == kartBaslik)
                {
                    board.InProgressKartlar.Remove(kart);
                    kartSilindi = true;
                    Console.WriteLine("Kart Silindi");
                }
            }
            for (int i = board.DoneKartlar.Count - 1; i >= 0; i--)//Done Kartlarda arar
            {
                Kart kart = board.DoneKartlar[i];

                if (kart.Baslik == kartBaslik)
                {
                    board.DoneKartlar.Remove(kart);
                    kartSilindi = true;
                    Console.WriteLine("Kart Silindi");
                }
            }

            if (kartSilindi == false)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n" +
                    "* Silmeyi sonlandırmak için : (1)\n" +
                    "* Yeniden denemek için : (2)");

                sbyte yanit;

                if (!sbyte.TryParse(Console.ReadLine(), out yanit) || yanit < 1 || yanit > 2)
                {
                    Console.WriteLine("Hatalı Giriş Yaptınız...");
                }
                else
                {
                    if (yanit == 1)
                    {
                        return;
                    }
                    else
                    {
                        KartSil(board);
                    }
                }
            }           
        }

        static void KartTasi(Board board, TakimUyeleri takimUyeleri)
        {
            Console.Write("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\n" +
                "Lütfen kart başlığını yazınız: ");
            string kartBaslik = Console.ReadLine();

            Kart secilenKart = null;

            //TODO
            foreach (var kart in board.TodoKartlar)
            {
                if (kart.Baslik == kartBaslik)
                {
                    secilenKart = kart;
                    break;
                }
            }
            //IN PROGRESS
            if (secilenKart == null)
            {           
                foreach (var kart in board.InProgressKartlar)
                {
                    if (kart.Baslik == kartBaslik)
                    {
                        secilenKart = kart;
                        break;
                    }          
                }
            }
            //DONE
            if (secilenKart == null)
            {
                foreach (var kart in board.DoneKartlar)
                {
                    if (kart.Baslik == kartBaslik)
                    {
                        secilenKart = kart;
                        break;
                    }
                }
            }

            if (secilenKart != null)
            {
                Console.Write("Bulunan Kart Bilgileri:\n" +
                        "**************************************\n" +
                        $"Başlık : {secilenKart.Baslik}\n" +
                        $"İçerik : {secilenKart.Icerik}\n" +
                        $"Atanan Kişi : {takimUyeleri.Uyeler[secilenKart.AtananKisiID]}\n" +
                        $"Büyüklük : {secilenKart.Buyukluk}\n" +
                        $"Line : {secilenKart.Line}\n" +
                        "Lütfen taşımak istediğiniz Line'ı seçiniz (1) TODO (2) IN PROGRESS (3) DONE : ");

                sbyte sayi;
                if (sbyte.TryParse(Console.ReadLine(), out sayi))
                {
                    string hedefLine;
                    switch (sayi)
                    {
                        case 1:
                            hedefLine = "TODO";
                            break;
                        case 2:
                            hedefLine = "IN PROGRESS";
                            break;
                        case 3:
                            hedefLine = "DONE";
                            break;
                        default:
                            hedefLine = "TODO";
                            break;
                    }

                    // Mevcut line'dan kaldır
                    switch (secilenKart.Line)
                    {
                        case "TODO":
                            board.TodoKartlar.Remove(secilenKart);
                            break;
                        case "IN PROGRESS":
                            board.InProgressKartlar.Remove(secilenKart);
                            break;
                        case "DONE":
                            board.DoneKartlar.Remove(secilenKart);
                            break;
                    }

                    // Kartı mevcut line'dan hedef line'a taşı
                    secilenKart.Line = hedefLine;

                    // Hedef line'a ekle
                    switch (hedefLine)
                    {
                        case "TODO":
                            board.TodoKartlar.Add(secilenKart);
                            break;
                        case "IN PROGRESS":
                            board.InProgressKartlar.Add(secilenKart);
                            break;
                        case "DONE":
                            board.DoneKartlar.Add(secilenKart);
                            break;
                    }

                    Console.WriteLine("\nKart başarıyla taşındı.\n");

                }
                else
                {
                    Console.WriteLine("\nHatalı bir seçim yaptınız. İşlem sonlandırıldı.\n");
                }
            }
            else
            {
                Console.WriteLine("\nAradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n");
            }

        }
    }
}
