using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vasmegye
{
    class Program
    {

        static List<SzemelyiSzam> szemelyiSzamok = new List<SzemelyiSzam>();

        static void Main(string[] args)
        {
            Console.WriteLine("\n2. feladat: Adatok beolvasása, tárolása");
            adatokBeolvasasa("vas.txt");
            Console.WriteLine("\n4. feladat: Ellenőrzés");
            feladat04();
            Console.WriteLine("\n5. feladat: Vizsgált évek alatt {0} csecsemő született.",szemelyiSzamok.Count);
           //Console.WriteLine("\n6. feladat: Fiúk száma: {0}.",szemelyiSzamok.FindAll(a => ));
            
            Console.WriteLine("Program vége");
            Console.ReadKey();
            

        }

        private static void feladat04()
        {

            List<SzemelyiSzam> hibasSzam = szemelyiSzamok.FindAll(a => !CdvEll(a.Szam));
            foreach (SzemelyiSzam item in hibasSzam)
            {
                Console.WriteLine($"Hibás a {item.Szam} személyi azonosító");
                szemelyiSzamok.Remove(item);
            }

        }

        public static bool CdvEll(string szam )
        {
            string szamNumeric = new string(szam.Where(a => char.IsDigit(a)).ToArray());
            if (szamNumeric.Length != 11)
            {
                 return false;
            }
            double sum = 0;
            for (int i = 0; i < szamNumeric.Length - 1; i++)
            {
                sum += char.GetNumericValue(szamNumeric[i])* (10- i);
            }
            return char.GetNumericValue(szamNumeric[10]) == sum % 11;
           
        }

        private static void adatokBeolvasasa(string adatFile)
        {
            if (!File.Exists(adatFile))
            {
                Console.WriteLine("A forrásadatok hiányoznak");
                Console.WriteLine();
                Environment.Exit(0);
            }
            using (StreamReader sr = new StreamReader(adatFile))
            {
                while (!sr.EndOfStream)
                {
                    szemelyiSzamok.Add(new SzemelyiSzam(sr.ReadLine()));
                }
               
            }
        }
    }
}
