using System;
using System.Collections.Generic;

namespace Lab09
{
    class ListDoMikolaja
    {
        string imie_nazwisko, adres, list;
        List<string> prezenty;
        public ListDoMikolaja(string _imie_nazwisko, string _adres, string _list)
        {
            prezenty = new List<string>();
            imie_nazwisko = _imie_nazwisko;
            adres = _adres;
            list = _list;
        }

        public void addToPrezentyList(string prezent)
        {
            prezenty.Add(prezent);
        }

        public void deleteFromPrezentyList(int number)
        {
            if(number > 0 && number <= prezenty.Count)
                prezenty.RemoveAt(number - 1);
            else Console.WriteLine("Wrong input");
        }

        public void showListDoMikolaja()
        {
            Console.WriteLine("\nDo: Swiety Mikolaj");
            Console.WriteLine("Laponia");

            Console.WriteLine("\nOd: " + imie_nazwisko);
            Console.WriteLine("Ul." + adres);

            Console.WriteLine("\n" + list);

            showListaPrezentow();
        }

        public void showListaPrezentow()
        {
            int count = 0;
            foreach (string prezent in prezenty)
            {
                count++;
                Console.WriteLine(count + ". " + prezent);
            }
        }

        class Program
        {

            public static string Scanner(string infoScanner)
            {
                Console.Write(infoScanner);
                return Console.ReadLine();
            }

            static void Main(string[] args)
            {
                ListDoMikolaja listDoMikolaja = new ListDoMikolaja(Scanner("Podaj imie i nazwisko: "),
                    Scanner("Podaj adres: "),
                    Scanner("Podaj tresc listu: "));

                bool programLoop = true;
                while (programLoop)
                {
                    Console.WriteLine("\nWybierz akcje: ");
                    Console.WriteLine("1. Dodaj pozycje listy");
                    Console.WriteLine("2. Usun pozycje listy");
                    Console.WriteLine("3. Zakoncz");

                    string operationNumber = Scanner("->");
                    if (programLoop && operationNumber.Equals("1"))
                    {
                        listDoMikolaja.addToPrezentyList(Scanner("Add->"));
                        Console.Clear();
                        listDoMikolaja.showListaPrezentow();
                    }
                    else if (programLoop && operationNumber.Equals("2"))
                    {
                        listDoMikolaja.deleteFromPrezentyList(int.Parse(Scanner("Remove->")));
                        Console.Clear();
                        listDoMikolaja.showListaPrezentow();
                    }
                    else if (programLoop && operationNumber.Equals("3"))
                    {
                        Console.Clear();
                        listDoMikolaja.showListDoMikolaja();
                        programLoop = false;
                    }
                    else
                    {
                        programLoop = false;
                    }
                }
            }
        }
    }
}
