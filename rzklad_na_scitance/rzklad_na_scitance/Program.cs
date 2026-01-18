namespace rzklad_na_scitance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Stack<(List<int> posloupnost, int soucet, int min)> zasobnik = new Stack<(List<int>, int, int)>();

            zasobnik.Push((new List<int>(), 0, 1));

            while (zasobnik.Count > 0)
            {
                var (posloupnost, soucet, min) = zasobnik.Pop();

                if (soucet == n)
                    Console.WriteLine(string.Join("+", posloupnost));
                else
                {
                    for (int i = n - soucet; i >= min; i--)
                    {
                        List<int> novaPosloupnost = new List<int>(posloupnost);
                        novaPosloupnost.Add(i);
                        zasobnik.Push((novaPosloupnost, soucet + i, i));
                    }
                }
            }
        }
    }
}