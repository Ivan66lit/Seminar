namespace Seznam_studentů_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolik studentů chceš načíst?");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            List<string> jmena = new List<string>();
            List<int> věk = new List<int>();
            List<float> známka = new List<float>();

            int w = n;
            int p = 1;

            while (w > 0)
            {
                Console.WriteLine($"{p}. student:");

                Console.WriteLine("Jmeno?");
                string j = Console.ReadLine();
                jmena.Add(j);

                Console.WriteLine("Věk?");
                int v = Convert.ToInt32(Console.ReadLine());
                věk.Add(v);

                Console.WriteLine("Průměrná známka?");
                float z = float.Parse(Console.ReadLine());
                známka.Add(z);

                Console.WriteLine();

                w--;
                p++;
            }

            Console.WriteLine("Vypiš, co chceš, abych ti udělal a/b/c/d");
            string f = Console.ReadLine();

            while (f != "d")
            {
                if (f == "a")
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"{jmena[i]}({věk[i]}):{známka[i]}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Vypiš, co chceš, abych ti udělal a/b/c/d");
                    f = Console.ReadLine();
                }

                else if (f == "b")
                {
                    List<string> jmena2 = new List<string>();
                    List<int> věk2 = new List<int>();
                    List<float> známka2 = new List<float>();

                    for (int j = 0; j < n; j++)
                    {
                        if (známka[j] > 2)
                        {
                            jmena2.Add(jmena[j]);
                            věk2.Add(věk[j]);
                            známka2.Add(známka[j]);
                        }
                    }

                    int delka = jmena2.Count;

                    for (int i = 0; i < delka; i++)
                    {
                        Console.WriteLine($"{jmena2[i]}({věk2[i]}):{známka2[i]}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Vypiš, co chceš, abych ti udělal a/b/c/d");
                    f = Console.ReadLine();
                }

                else if (f == "c")
                {
                    int g = 0;

                    foreach (int m in věk)
                    {
                        g += m;
                    }

                    float l = (float)g / n;
                    string h = Convert.ToString(l);
                    Console.Write("Průměrný věk je ");
                    Console.WriteLine(h);

                    Console.WriteLine();
                    Console.WriteLine("Vypiš, co chceš, abych ti udělal a/b/c/d");
                    f = Console.ReadLine();
                }
            }
        }
    }
}