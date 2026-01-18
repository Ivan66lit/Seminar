namespace graf_přátelství
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // získat počet lidí v síti
            int pocetLidi = Convert.ToInt32(Console.ReadLine());

            // matice sousednosti - defultně jsou v ní samé nuly
            int[,] graf = new int[pocetLidi, pocetLidi];

            // načteme graf
            string vstupniData = Console.ReadLine(); // 1-2 1-3 4-5 2-3 2-6 6-7
            string[] dvojice = vstupniData.Split(); // ["1-2", "1-3", "4-5", "2-3", "2-6", "6-7"]

            for (int i = 0; i < dvojice.Length; i++)
            {
                string[] casti = dvojice[i].Split("-");

                int vrchol1 = Convert.ToInt32(casti[0]) - 1;
                int vrchol2 = Convert.ToInt32(casti[1]) - 1;

                graf[vrchol1, vrchol2] = 1;
                graf[vrchol2, vrchol1] = 1;
            }

            string parVstup = Console.ReadLine();
            string[] par = parVstup.Split();
            int clovek1 = Convert.ToInt32(par[0]) - 1;
            int clovek2 = Convert.ToInt32(par[1]) - 1;

            bool[] navstiveno = new bool[graf.GetLength(0)];
            List<int> cesta = new List<int>();

            bool vysledek = ExistenceCesty(graf, clovek1, clovek2, navstiveno, cesta);
            if (vysledek)
                Console.WriteLine(string.Join("->", cesta));
            else
                Console.WriteLine("Neexistuje");
        }

        static bool ExistenceCesty(int[,] graf, int start, int cil, bool[] navstiveno, List<int> cesta)
        {
            cesta.Add(start + 1);
            navstiveno[start] = true;

            if (start == cil)
                return true;

            int n = graf.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                if (graf[start, i] == 1 && !navstiveno[i])
                {
                    if (ExistenceCesty(graf, i, cil, navstiveno, cesta))
                        return true;
                }
            }

            cesta.RemoveAt(cesta.Count - 1);
            return false;
        }
    }
}