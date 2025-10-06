namespace Seřazení
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pole = { -20, 1, 0, 3465, -1, 2 };

            foreach (int cislo in pole)
                Console.WriteLine(cislo);

            SeřadPrvky(pole);
        }

        static void SeřadPrvky(int[] ciselnePole)
        {
            int n = ciselnePole.Length;
            while (n > 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (ciselnePole[i] < ciselnePole[i + 1])
                    {
                        (ciselnePole[i], ciselnePole[i + 1]) = (ciselnePole[i + 1], ciselnePole[i]);
                    }
                }

                n--;
            }

            Console.WriteLine(string.Join("; ", ciselnePole));
        }
    }
}
