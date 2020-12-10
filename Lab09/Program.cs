using System;
using System.Collections.Generic;
using System.IO;

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
            if (number > 0 && number <= prezenty.Count)
                prezenty.RemoveAt(number - 1);
            else Console.WriteLine("Wrong input");
        }

        public string getListDoMikolaja()
        {
            string result = "\nDo: Swiety Mikolaj\n";
            result += "Laponia";
            result += "\n\nOd: " + imie_nazwisko;
            result += "\nUl." + adres;
            result += "\n\n" + list + "\n";
            result += getListaPrezentow();
            return result;
        }

        public string getListaPrezentow()
        {
            string result = "";
            int count = 0;
            foreach (string prezent in prezenty)
            {
                count++;
                result += count + ". " + prezent + "\n";
            }
            return result;
        }

    }
        class Program
        {

        public static void saveStringToFile(string input, string fileName)
        {
            string path = @"E:\temp\";
            path += fileName + ".txt";

            File.WriteAllText(path, input);
        }

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
                    Console.WriteLine("3. Zapisz w pliku");
                    Console.WriteLine("4. Zakoncz");

                    string operationNumber = Scanner("->");
                    if (programLoop && operationNumber.Equals("1"))
                    {
                        listDoMikolaja.addToPrezentyList(Scanner("Add->"));
                        Console.Clear();
                        Console.WriteLine(listDoMikolaja.getListaPrezentow());
                    }
                    else if (programLoop && operationNumber.Equals("2"))
                    {
                        listDoMikolaja.deleteFromPrezentyList(int.Parse(Scanner("Remove->")));
                        Console.Clear();
                        Console.WriteLine(listDoMikolaja.getListaPrezentow());
                    }
                    else if (programLoop && operationNumber.Equals("3"))
                    {
                        saveStringToFile(listDoMikolaja.getListDoMikolaja(), Scanner("File namme: "));
                        Console.Clear();
                        Console.WriteLine(listDoMikolaja.getListaPrezentow());
                    }
                    else if (programLoop && operationNumber.Equals("4"))
                    {
                        Console.Clear();
                        Console.WriteLine(listDoMikolaja.getListDoMikolaja());
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
