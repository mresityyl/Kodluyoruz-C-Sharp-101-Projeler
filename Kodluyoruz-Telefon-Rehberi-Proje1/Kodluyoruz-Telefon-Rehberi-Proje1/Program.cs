using System;
using System.Collections.Generic;


namespace Kodluyoruz_Telefon_Rehberi_Proje1
{
    internal class Program
    {
        public static Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            { "a l", "0 555" },
            { "b k", "0 666" },
            { "c j", "0 777" },
            { "d h", "0 888" },
            { "e g", "0 999" }
        };
 
        static void Main(string[] args)
        {
            PrintSelections();
                                                     
            Console.ReadKey();
        }

        public static void PrintSelections()
        {
            Console.WriteLine(
                "\nLütfen yapmak istediğiniz işlemi seçiniz :)\n" +
                "*******************************************\n" +
                "(1) Yeni Numara Kaydetmek\n" +
                "(2) Varolan Numarayı Silmek\n" +
                "(3) Varolan Numarayı Güncelleme\n" +
                "(4) Rehberi Listelemek\n" +
                "(5) Rehberde Arama Yapmak﻿\n" +
                "(6) Ekranı Temizle\n");

            //sbyte choice = sbyte.Parse(Console.ReadLine());

            if (sbyte.TryParse(Console.ReadLine(), out sbyte a))
            {
                switch (a)
                {
                    case 1:
                        Methods.SavePhoneNumber();
                        break;
                    case 2:
                        Methods.DeletePhoneNumber();
                        break;
                    case 3:
                        Methods.UpdatePhoneNumber();
                        break;
                    case 4:
                        Methods.ListContact();
                        break;
                    case 5:
                        Methods.SearchingInContacts();
                        break;
                    case 6:
                        Console.Clear();
                        PrintSelections();
                        break;
                    default:
                        WrongValue();
                        break;
                }
            }
            else {
                WrongValue();
            }
        }

        static void WrongValue()
        {
            Console.Clear();
            Console.WriteLine("Doğru Değeri Girmediniz!");
            PrintSelections();
        }
    }
}
