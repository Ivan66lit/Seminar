namespace Bankovni_ucet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PostovniAdresa adresa1 = new PostovniAdresa("Vinohradská", 12, "Praha", 12000);
            PostovniAdresa adresa2 = new PostovniAdresa("Masarykova", 5, "Brno", 60200);

            BankovniUcet ucet1 = new BankovniUcet("1234/0800", adresa1, 15000);
            BankovniUcet ucet2 = new BankovniUcet("5678/0100", adresa2);

            Console.WriteLine(ucet1);
            Console.WriteLine(ucet2);

            ucet2.Vlozit(5000);
            Console.WriteLine("\nPo vkladu 5000 Kč na účet 2:");
            Console.WriteLine(ucet2);

            bool vysledek1 = ucet2.Vybrat(100000); // neplatný výběr
            Console.WriteLine($"\nVýběr 100000 Kč: {(vysledek1 ? "povolen" : "zamítnut")}");

            bool vysledek2 = ucet2.Vybrat(2000); // platný výběr
            Console.WriteLine($"Výběr 2000 Kč: {(vysledek2 ? "povolen" : "zamítnut")}");
            Console.WriteLine(ucet2);

            ucet1.UrokovaSazba = 20;   // neplatné -> varování a 0 %
            ucet1.UrokovaSazba = 3.5f; // platné

            Console.WriteLine();
            BankovniUcet.ZobrazPocetAktivnichUctu();
        }

        public struct PostovniAdresa
        {
            public string Ulice { get; set; }
            public int CisloPopisne { get; set; }
            public string Mesto { get; set; }
            public int PSC { get; set; }

            public PostovniAdresa(string ulice, int cisloPopisne, string mesto, int pSC)
            {
                Ulice = ulice;
                CisloPopisne = cisloPopisne;
                Mesto = mesto;
                PSC = pSC;
            }
        }

        public class BankovniUcet
        {
            private string _cisloUctu;
            private decimal _zustatek;
            private PostovniAdresa _adresaMajitele;
            private static int _celkovyPocetUctu;

            public string CisloUctu { get { return _cisloUctu; } }
            public decimal Zustatek { get { return _zustatek; } private set { _zustatek = value; } }

            private float _urokovaSazba;
            public float UrokovaSazba
            {
                get { return _urokovaSazba; }
                set
                {
                    if (value < 0 || value > 15)
                    {
                        Console.WriteLine("Varování: Úroková sazba musí být 0–15 %");
                        _urokovaSazba = 0;
                    }
                    else
                        _urokovaSazba = value;
                }
            }
            public BankovniUcet(string cisloUctu, PostovniAdresa adresaMajitele, decimal pocatecniVklad)
            {
                _cisloUctu = cisloUctu;
                _adresaMajitele = adresaMajitele;
                if (pocatecniVklad < 0)
                    _zustatek = 0;
                else
                    _zustatek = pocatecniVklad;

                _celkovyPocetUctu++;
            }

            public BankovniUcet(string cisloUctu, PostovniAdresa adresaMajitele)
                : this(cisloUctu, adresaMajitele, 0) { }

            public void Vlozit(decimal castka)
            {
                if (castka > 0)
                    _zustatek += castka;
            }

            public bool Vybrat(decimal castka)
            {
                if (castka > 0 && _zustatek >= castka)
                {
                    _zustatek -= castka;
                    return true;
                }
                else
                    return false;
            }

            public static void ZobrazPocetAktivnichUctu()
            {
                Console.WriteLine(_celkovyPocetUctu);
            }

            public override string ToString()
            {
                return $"Ucet {_cisloUctu} | Mesto: {_adresaMajitele.Mesto} | Zustatek: {_zustatek:N0} Kc";
            }
        }

    }
}