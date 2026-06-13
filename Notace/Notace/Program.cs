namespace Notace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chceš prefix / postfix?");
            string typ = Console.ReadLine();

            if (typ != "prefix" && typ != "postfix")
            {
                Console.WriteLine("Neplatný typ výrazu.");
                return;
            }

            Console.WriteLine("Zadej výraz:");
            string vyraz = Console.ReadLine();
            string[] znaky = vyraz.Split(' ');


            if (typ == "prefix")
                Console.WriteLine("Větev řešení pro prefix");
            else
                Console.WriteLine("Větev řešení pro postfix");
            foreach (string znak in znaky)
                Console.WriteLine(znak);
        }
    }
}
