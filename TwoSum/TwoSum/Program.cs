namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cisla = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
            int soucet = Convert.ToInt16(Console.ReadLine());
            NajdiDvojici(cisla, soucet);
        }

        static void NajdiDvojici(int[] cisla, int soucet)
        {
            Dictionary<int, int> umisteni = new Dictionary<int, int>();

            for (int i = 0; i < cisla.Length; i++)
            {

                umisteni.Add(cisla[i], i);
            }
            List<int> ret = new List<int>();

            int x = 0;

            for (int i = 0; i < cisla.Length; i++)
            {
                if (umisteni.ContainsKey(soucet - cisla[i]) && umisteni[soucet - cisla[i]] != i)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(umisteni[soucet - cisla[i]]);
                    x = 1;
                    break;
                }
            }

            if (x == 0)
            {
                Console.WriteLine(-1);
            }
        }
    }
}