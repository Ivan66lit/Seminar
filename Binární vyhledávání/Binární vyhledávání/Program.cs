namespace Binární_vyhledávání
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pole = { -1, -2, -3, -4, -6, -7, -8 };
            int c = -6;
            int m = 0;
            int n = pole.Length;

            Console.WriteLine(string.Join("; ", pole));
            Console.WriteLine(c);

            VyhledejMisto(c, pole, m, n);
        }

        static void VyhledejMisto(int cislo, int[] ciselnePole, int zacatek, int konec)
        {
            int x = (zacatek + konec) / 2;
            int y = (konec - zacatek) / 2;

            if (y == 0)
            {
                if (cislo == ciselnePole[0])
                    Console.WriteLine(1);
                else
                    Console.WriteLine(-1);
            }
            else if (cislo == ciselnePole[x])
                Console.WriteLine(x + 1);
            else if (cislo > ciselnePole[x])
            {
                konec = x;
                VyhledejMisto(cislo, ciselnePole, zacatek, konec);
            }
            else
            {
                zacatek = x;
                VyhledejMisto(cislo, ciselnePole, zacatek, konec);
            }
        }
    }
}
