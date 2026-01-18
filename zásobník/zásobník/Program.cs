namespace zásobník
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Uveď jaký řetězac chceš zkontrolovat");
            string s = Console.ReadLine();

            if (JeSpravneUzavorkovani(s))
                Console.WriteLine("Správně");
            else
                Console.WriteLine("Nejsou správně");
        }

        static bool JeSpravneUzavorkovani(string vstup)
        {
            Stack<char> zasobnik = new Stack<char>();

            char[] oteviraci = [ '[' , '(', '{' ];
            char[] zaviraci = [ ']', ')', '}' ];

            foreach (char c in vstup)
            {
                if (oteviraci.Contains(c))
                    zasobnik.Push(c);
                else
                {
                    if (zasobnik.Peek() == oteviraci[Array.IndexOf(zaviraci, c)])
                        zasobnik.Pop();
                }
            }

            if (zasobnik.Count()  == 0)
                return true;
            else
                return false;
        }
    }
}
