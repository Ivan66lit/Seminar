namespace rozklad_na_prvočísla
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jaké číslo chceš rozložit na prvočísla?");
            string s = Console.ReadLine();
            int x = Convert.ToInt32(s);

            int i = 2;
            List<int> cisla = new List<int>();

            if (x < 2)
                Console.WriteLine("nemá prvočíselný rozklad");

            else
            {
                while (x > 1)
                {
                    if (x % i == 0)
                    {
                        cisla.Add(i);
                        x = x / i;
                    }
                    else
                        i++;
                }

                Console.WriteLine(s + " = " + string.Join(" * ", cisla));
            }
        }
    }
}
