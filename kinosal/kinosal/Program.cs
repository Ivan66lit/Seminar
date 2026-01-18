namespace kinosal
{
    internal class Program
    {
        static bool[,] kinosal;
        const int Rady = 8;
        const int Sedadla = 10;
        const int VipRada = 7;
        const int Cena = 180;
        const int VipPriplatek = 70;

        static void Main(string[] args)
        {
            kinosal = new bool[Rady, Sedadla];

            ZobrazKinosal(Rady, Sedadla);

            ZarezervujSedadlo(4, 4);

            if (JeSedadloVolne(3, 4))
                Console.WriteLine("Volné");
            else
                Console.WriteLine("Není volné");

            if (SpocitejCenuListku(7, 4) == -1)
                Console.WriteLine("Místo je obsazené");
            else
                Console.WriteLine(SpocitejCenuListku(7, 4));
        }

        static void ZobrazKinosal(int rady, int sedadla)
        {
            Console.Write(" ");

            for (int j = 0; j < sedadla; j++)
                Console.Write(" " + (j + 1).ToString());
            Console.WriteLine();

            for (int i = 0; i < rady; i++)
            {
                Console.Write((i + 1).ToString());

                for (int j = 0; j < sedadla; j++)
                {
                    Console.Write(" ");

                    if (kinosal[i, j])
                        Console.Write("X");
                    else
                        Console.Write("O");
                }
                Console.WriteLine();
            }
        }

        static void ZarezervujSedadlo(int rada,  int sedadlo)
        {
            kinosal[rada, sedadlo] = true;
        }

        static bool JeSedadloVolne(int rada, int sedadlo)
        {
            if (kinosal[rada, sedadlo])
                return false;
            else
                return true;
        }

        static int SpocitejCenuListku(int rada, int sedadlo)
        {
            if (JeSedadloVolne(rada, sedadlo) && 0 < rada && rada < (Rady + 1) && 0 < sedadlo && sedadlo < (Sedadla + 1))
            {
                if (rada < VipRada)
                    return Cena;
                else
                    return (Cena + VipPriplatek);
            }

            else
                return -1;
        }
    }
}