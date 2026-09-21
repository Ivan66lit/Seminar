namespace Bludiste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] bludiste = ZpracujVstup();
            Prisera prisera = NajdiPolohuPrisery(bludiste);
            ProjdiTrat(prisera, bludiste);
        }

        static char[,] ZpracujVstup()
        {
            int sirka = Convert.ToInt32(Console.ReadLine());
            int vyska = Convert.ToInt32(Console.ReadLine());
            char[,] bludiste = new char[vyska, sirka];
            for (int i = 0; i < vyska; i++)
            {
                string radek = Console.ReadLine();
                for (int j = 0; j < sirka; j++)
                {
                    bludiste[i, j] = radek[j];
                }
            }
            return bludiste;
        }

        static Prisera NajdiPolohuPrisery(char[,] bludiste)
        {
            Prisera prisera = new Prisera();
            for (int i = 0; i < bludiste.GetLength(0); i++)
            {
                string radek = Console.ReadLine();
                for (int j = 0; j < bludiste.GetLength(1); j++)
                {
                    if (bludiste[i, j] == '>')
                    {
                        prisera.Vyska = i;
                        prisera.Sirka = j;
                        prisera.Smer = '>';
                    }
                    else if (bludiste[i, j] == '<')
                    {
                        prisera.Vyska = i;
                        prisera.Sirka = j;
                        prisera.Smer = '<';
                    }
                    else if (bludiste[i, j] == '^')
                    {
                        prisera.Vyska = i;
                        prisera.Sirka = j;
                        prisera.Smer = '^';
                    }
                    else if (bludiste[i, j] == 'v')
                    {
                        prisera.Vyska = i;
                        prisera.Sirka = j;
                        prisera.Smer = 'v';
                    }
                }
            }
            return prisera;
        }

        static void ProjdiTrat(Prisera prisera, char[,] bludiste)
        {
            UdelejKrok(prisera, 20, bludiste);
        }

        static void UdelejKrok(Prisera prisera, int pocetTahu, char[,] bludiste)
        {
            if (pocetTahu > 0)
            {
                if (prisera.Smer == '>')
                {
                    if (bludiste[prisera.Vyska, prisera.Sirka + 1] == '.')
                    {
                        if (bludiste[prisera.Vyska + 1, prisera.Sirka] == '.')
                        {
                            bludiste[prisera.Vyska, prisera.Sirka] = 'v';
                            if (pocetTahu > 1)
                            {
                                NakresliBludiste(bludiste);
                                bludiste[prisera.Vyska, prisera.Sirka] = '.';
                                bludiste[prisera.Vyska + 1, prisera.Sirka] = 'v';
                                pocetTahu--;
                            }
                            prisera.Smer = 'v';
                        }
                        else
                        {
                            bludiste[prisera.Vyska, prisera.Sirka] = '.';
                            bludiste[prisera.Vyska, prisera.Sirka + 1] = '>';
                        }
                        pocetTahu--;
                        NakresliBludiste(bludiste);
                        UdelejKrok(prisera, pocetTahu, bludiste);
                    }
                    else
                    {
                        if (bludiste[prisera.Vyska + 1, prisera.Sirka] == '.')
                        {
                            bludiste[prisera.Vyska, prisera.Sirka] = 'v';
                            prisera.Smer = 'v';
                        }
                        else
                        {
                            bludiste[prisera.Vyska, prisera.Sirka] = '^';
                            prisera.Smer = '^';
                        }
                        pocetTahu--;
                        NakresliBludiste(bludiste);
                        UdelejKrok(prisera, pocetTahu, bludiste);
                    }
                }
                else if (prisera.Smer == '<')
                {

                }
                else if (prisera.Smer == '^')
                {

                }
                else if (prisera.Smer == 'v')
                {

                }
            }

            static void NakresliBludiste(char[,] bludiste)
            {
                for (int i = 0; i < bludiste.GetLength(0); i++)
                {
                    for (int j = 0; j < bludiste.GetLength(1); j++)
                    {
                        Console.Write(bludiste[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }

    class Prisera
    {
        public int Vyska;
        public int Sirka;
        public char Smer;
    }
}