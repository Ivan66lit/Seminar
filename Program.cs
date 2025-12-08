using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace testik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                list.Add(n);

                if (n == 0)
                    break;
            }

            Console.WriteLine();

            for (int j = 0; j < list.Count; j++)
            {
                Prvocislo number = new Prvocislo(j);
                
                if (number.JePrvocislo())
                {
                    Console.WriteLine(list[j]);
                }
            }
        }
    }

    class Prvocislo
    {
        int x;

        public Prvocislo(int x)
        {
            this.x = x;
        }

        public bool JePrvocislo()
        {
            int a = x;
            for (int i = 2; i < Math.Pow(x, 2) + 1; i++)
            {
                if (x % i == 0)
                    a = x / i;
            }

            if (x != a & x == 1)
                return false;
            else
                return true;
        }
    }
}
