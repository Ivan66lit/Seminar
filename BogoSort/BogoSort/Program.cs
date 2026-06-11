namespace BogoSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> seznam = new List<int> { 90, -23, -7, 78 };
            seznam = BogoSort(seznam);
            for (int i = 0; i < seznam.Count; i++)
                Console.WriteLine(seznam[i]);
        }

        public static List<int> BogoSort(List<int> seznam)
        {
            int a = 0;

            for (int i = 1; i < seznam.Count; i++)
            {
                if (seznam[i] < seznam[i - 1])
                {
                    i = 0;
                    a++;
                    seznam = seznam.Shuffle().ToList();     //funkce pro přehazování hodnot a převod na seznam(jak jsem pochopil, že Shuffle() je nová metoda, která zjednošuje ten proces)
                }
            }

            Console.WriteLine(a);
            Console.WriteLine("seznam je");
            return seznam;
        }
    }
}
