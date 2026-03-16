namespace topologicke_usporadani
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static Dictionary<string, List<string>> graf = new Dictionary<string, List<string>>(); //priznavam se, takovou technologii mi poardil ai
        static Dictionary<string, string> stav = new Dictionary<string, string>();
        static List<string> vysledek = new List<string>();

        static void DFS(string u)
        {
            stav[u] = "otevreny";

            foreach (var v in graf[u]) //kontrolujeme sousedy prvku u
            {
                if (stav[v] == "otevreny")
                {
                    throw new Exception("ma cyklus");
                }

                if (stav[v] == "nenavstiveny")
                {
                    DFS(v);
                }
            }

            stav[u] = "hotovy";
            vysledek.Add(u);
        }

        static void AddEdge(string a, string b)
        {
            if (!graf.ContainsKey(a))
                graf[a] = new List<string>();

            if (!graf.ContainsKey(b))
                graf[b] = new List<string>();

            graf[a].Add(b);
        }

        static void Main()
        {
            string input = Console.ReadLine();

            string[] hrany = input.Split(' ');

            foreach (var e in hrany)
            {
                var casti = e.Split('<');
                AddEdge(casti[0], casti[1]);
            }

            foreach (var v in graf.Keys) // kontrolujeme stav kazdeho prvku v grafu
            {
                stav[v] = "nenavstiveny";
            }

            foreach (var v in graf.Keys)
            {
                if (stav[v] == "nenavstiveny")
                {
                    DFS(v);
                }
            }

            vysledek.Reverse();

            Console.WriteLine(string.Join(" ", vysledek));
        }
    }

    // ne, napriklad pro vstup b<a c<a mohou byt 2 odpovedi: c b a, b c a
    // c<b b<a a<c
}
