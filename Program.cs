using System.Net;
using System.Runtime.InteropServices;

namespace Testik2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] spojeni = new int[n , n];

            int i = 0;
            int zacatek = 0;

            while (i == 0)
            {
                string vstup = Console.ReadLine();

                if (vstup.Length > 2)
                {
                    int[] b = Array.ConvertAll(vstup.Split(), int.Parse);

                    int x1 = b[0];
                    int x2 = b[1];

                    // Console.WriteLine(x1 + " " + x2);

                    spojeni[x1 - 1, x2 - 1] = 1;
                    spojeni[x2 - 1, x1 - 1] = 1;
                }

                else
                {
                    i++;
                    zacatek = Convert.ToInt32(Console.ReadLine());
                }
            }

            int konec = Convert.ToInt32(Console.ReadLine());

            UvedNejkratsiCestu(zacatek, konec, spojeni);
        }

        static void UvedNejkratsiCestu(int zacatek, int konec, int[,] spojeni)
        {
            List<int> vysledek = new List<int>();
            List<int> trat = new List<int>();

            // Queue<int> fronta = new Queue<int>(); 

            // fronta.(zacatek);

            trat.Add(zacatek);

            // while (fronta.Count > 0)

            int pocet = 0;
            
            for (int i = 0; i < spojeni.GetLength(0); i++)
            {
                if (spojeni[zacatek - 1, i] == 1)
                    pocet++;
            }

            if (spojeni[zacatek - 1, konec - 1] == 1)
            {
                trat.Add(konec);
                //foreach (int cislo in trat)
                //prepsat trat na spojene cislo
                //vysledek.Add(cesta);   pridat to do seznamu, kde jsou vsechny vasledky
            }
            else if (pocet == 0)
            {
                Console.WriteLine("cesta neexistuje");
            }
            else
            {
                for (int i = 0; i < spojeni.GetLength(0); i++)
                {
                    if (spojeni[zacatek - 1, i] == 1)
                    {
                        zacatek = spojeni[i, i];
                        for (int j = 0; j < spojeni.GetLength(0); j++)
                        {
                            spojeni[j, zacatek-1] = 0;
                            //zmenit hodnotu u radku a sloupce, kde jsme meli nas zacatek
                        }
                        UvedNejkratsiCestu(zacatek, konec, spojeni);
                    }
                }
            }
        }
    }
}
