using System.Security.Cryptography;

namespace prvočíslo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jaké prvočíslo chceš ověřit?");
            int x = Convert.ToInt32(Console.ReadLine());
            int n = x;

            double v = Math.Floor(Math.Sqrt(x));
            for (int i = 1; i < v + 1; i++)
            {
                if (x % i == 0)
                    n = n / i;
            }

            if (x == 1)
                Console.WriteLine("to není prvočíslo");
            else if (x == n)
                Console.WriteLine("to je prvočíslo");
            else
                Console.WriteLine("to není prvočíslo");
        }
    }
}