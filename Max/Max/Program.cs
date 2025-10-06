namespace Max
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pole = { 1000, -10000, 3, 4,576 };
            Console.WriteLine("Max číslo je " + HledejMaximum(pole));

            foreach (int čislo in pole)
            {
                Console.WriteLine(čislo);
            }
        }

        static int HledejMaximum(int[] ciselnePole)
        {
            int max = 0;
            foreach (int cislo in ciselnePole)
            {
                if (cislo > max)
                {
                    max = cislo;
                }
            }
            return max;
        }
    }
}
