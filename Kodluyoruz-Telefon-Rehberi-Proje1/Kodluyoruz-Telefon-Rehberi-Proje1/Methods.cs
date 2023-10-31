using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodluyoruz_Telefon_Rehberi_Proje1
{
    internal class Methods
    {
    
        public static void SavePhoneNumber() //1
        {
            Console.Write("\nLütfen isim giriniz             : ");
            string name = Console.ReadLine();
            Console.Write("Lütfen soyisim giriniz          : ");
            string surName = Console.ReadLine();
            Console.Write("Lütfen telefon numarası giriniz : ");
            string number = Console.ReadLine();
            Console.Write("\n");

            Program.phoneBook.Add(name + " " + surName, number);

            QueryAgain();
        }

        public static void DeletePhoneNumber() //2
        {
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string nameOrSurName = Console.ReadLine();

            bool found = false;

            foreach (var item in Program.phoneBook.Keys)
            {
                string[] nameAndSurname = item.Split(' ');

                if (nameOrSurName == nameAndSurname[0] || nameOrSurName == nameAndSurname[1])
                {
                    found = true;

                    Console.WriteLine($"{nameAndSurname[0] + "  " + nameAndSurname[1]} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                    string confirmation = Console.ReadLine();

                    if (confirmation == "y")
                    {
                        Program.phoneBook.Remove(item);
                        Console.WriteLine("Kişi başarıyla silindi.");
                        QueryAgain();
                    }
                    else if (confirmation == "n")
                    {
                        QueryAgain();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Yanlış Değer Girdiniz.");
                        DeletePhoneNumber();
                    }
                }
            }
            if (found == false)
                CommonCodes(2);
        }

        public static void UpdatePhoneNumber() //3
        {
            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string nameOrSurName = Console.ReadLine();

            bool found = false;

            foreach (var item in Program.phoneBook.Keys)
            {
                string[] nameAndSurname = item.Split(' ');

                if (nameOrSurName == nameAndSurname[0] || nameOrSurName == nameAndSurname[1])
                {
                    found = true;

                    Console.WriteLine($"Lütfen {nameAndSurname[0] + "  " + nameAndSurname[1]} isimli kişinin yeni telefon numarasını yazınız.");
                    string number = Console.ReadLine();

                    Program.phoneBook[nameAndSurname[0]+ " " + nameAndSurname[1]] = number;
     
                    QueryAgain();
                }
            }
            if( found == false)
                CommonCodes(3);
        }

        public static void ListContact() //4
        {
            //foreach (var item in Program.phoneBook)
            //    Console.WriteLine($"İsim soyisim: {item.Key}  /  Numara: {item.Value} ");

            Console.WriteLine($"Telefon Rehberi\n" +
                "**********************************************");
            foreach (var item in Program.phoneBook)
            {
                string[] nameAndSurname = item.Key.Split(' ');
                Console.WriteLine($"- isim: {nameAndSurname[0]} Soyisim: {nameAndSurname[1]} Telefon Numarası: {item.Value}");
            }
            
            QueryAgain();
        }

        public static void SearchingInContacts() //5
        {

            Console.WriteLine(" Arama yapmak istediğiniz tipi seçiniz.\n" +
                "**********************************************\n" +
                "İsim veya soyisime göre arama yapmak için: (1)\n" +
                "Telefon numarasına göre arama yapmak için: (2)");

            string confirmation = Console.ReadLine();

            if (confirmation == "1")
            {
                Console.Write("Lütfen numarasını aramak istediğiniz kişinin adını ya da soyadını giriniz: ");
                string nameOrSurName = Console.ReadLine();

                bool found = false;

                foreach (var item in Program.phoneBook)
                {
                    string[] nameAndSurname = item.Key.Split(' ');

                    if (nameOrSurName == nameAndSurname[0] || nameOrSurName == nameAndSurname[1])
                    {
                        found = true;

                        Console.WriteLine("Arama Sonuçlarınız:\n" +
                            "**********************************************\n" +
                            $"-isim: {nameAndSurname[0]} Soyisim: {nameAndSurname[1]} Telefon Numarası: {item.Value}");

                        QueryAgain();
                    }
                }
                if (found == false)
                    CommonCodes(5);
            }
            else if(confirmation == "2")
            {
                Console.Write("Lütfen ismini aramak istediğiniz kişinin numarasını giriniz: ");
                string number = Console.ReadLine();

                bool found = false;

                foreach (var item in Program.phoneBook)
                {
                    if (number ==  item.Value)
                    {
                        found = true;

                        string[] nameAndSurname = item.Key.Split(' ');

                        Console.WriteLine("Arama Sonuçlarınız:\n" +
                            "**********************************************\n" +
                            $"-isim: {nameAndSurname[0]} Soyisim: {nameAndSurname[1]} Telefon Numarası: {number}");

                        QueryAgain();
                    }
                }
                if (found == false)
                    CommonCodes(5);
            }
        }






        static void CommonCodes(sbyte number)
        {
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n " +
                " * İşlemi sonlandırmak için : (1)\n " +
                " * Yeniden denemek için     : (2)");

            string confirmation = Console.ReadLine();
            if (confirmation == "1")
                QueryAgain();
            else if (confirmation == "2")
            {
                switch (number)
                {
                    case 1:
                        SavePhoneNumber();
                        break;
                    case 2:
                        DeletePhoneNumber();
                        break;
                    case 3:
                        UpdatePhoneNumber();
                        break;
                    case 4:
                        ListContact();
                        break;
                    case 5:
                        SearchingInContacts();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Yanlış Değer Girdiniz.");
                CommonCodes(number);
            }
        }

        static void QueryAgain()
        {
            Console.Write("\nBaşka işlem yapacak mısınız?(y/n) ");

            string result = Console.ReadLine();
            if (result == "y")
                Program.PrintSelections();
            else if (result == "n")
                Environment.Exit(0);
            else
            {
                Console.Clear();
                Console.WriteLine("Yanlış Değer Girdiniz.");
                QueryAgain();
            }
        }
    }
}
