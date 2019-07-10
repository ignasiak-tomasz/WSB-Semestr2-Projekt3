using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt3
{
    class Program
    {
        public const int LiczbaPunktKontrony = 15;
        public static int LiczbaPorworzen = 10; // Dokładność czasu mierzonego
        static double CzasZapytaniaWSekundach = 0; // Zmienna globalna do każdego zadania
        static string sciezka = "C:/Users/" + Environment.UserName + "/Desktop/Projekt_3/" + DateTime.Now.ToString("MM-dd-yyyy--HH-mm") + "/"; // Ścieżka opatentowana na miejsce zapisu
        static string mediana = ""; // Zadanie trzecie
        static int WielkoscTablic = 60000; // Liczba wybrana z zadania
        static int[] TablicaStala = new int[WielkoscTablic],// Zadanie pierwsze i drugie
                TablicaLosowa = new int[WielkoscTablic],// Każde zadanie 
                TablicaRosnaca = new int[WielkoscTablic],// Zadanie pierwsze i drugie
                TablicaMalejaca = new int[WielkoscTablic],// Zadanie pierwsze i drugie
                TablicaVKształtna = new int[WielkoscTablic],// Zadanie pierwsze i drugie
                TablicaAKształtna = new int[WielkoscTablic];// Zadanie trzecie

        static List<string> CzasyDoTabeli = new List<string>(),
                CzasyDoTabeliLosowej = new List<string>(),
                CzasyDoTabeliRosnacej = new List<string>(),
                CzasyDoTabeliMalejacej = new List<string>(),
                CzasyDoTabeliStalej = new List<string>(),
                CzasyDoTabeliVksztaltnej = new List<string>();

        static Random rnd = new Random(Guid.NewGuid().GetHashCode());


        static void Main(string[] args)
        {
            Console.WriteLine("Będziemy robić zadanie\nNaciśnij objętnie który przycisk, aby rozpocząć zabawę xD");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Aktualna ścieżka do odpowiedzi to:\n {0}", sciezka);
            CzySciezkaIstnieje(sciezka + "/test.txt");

            Console.WriteLine("Czy jesteś gotowy? Wciśnij");
            Console.ReadKey();
            //Napisanie zmiany ścieżki !!!

            /*
             * 
             * Dział Pierwszy 
             * Dział Drugi
             */
           
            WypelniamyTablice();
            
            CzasyDoTabeli.Add("Losowo");
            CzasyDoTabeli.Add("Rosnaco");
            CzasyDoTabeli.Add("Malejaco");
            CzasyDoTabeli.Add("Stala");
            CzasyDoTabeli.Add("V-ksztaltna");
            CzasyDoTabeli.Add("Wielkosc Tabeli");

            Zapisz(sciezka + "/Zad1_InsertionSort.csv", CzasyDoTabeli);
            Zapisz(sciezka + "/Zad1_SelectionSort.csv", CzasyDoTabeli);
            Zapisz(sciezka + "/Zad1_HeapSort.csv", CzasyDoTabeli);
            Zapisz(sciezka + "/Zad1_CocktailSort.csv", CzasyDoTabeli);
            CzasyDoTabeli.Clear();


            /*Część Zadania 2 Nadajemy Nagłówek w pierwszym wierszu*/
            CzasyDoTabeli.Add("InsertionSort");
            CzasyDoTabeli.Add("SelectionSort");
            CzasyDoTabeli.Add("HeapSort");
            CzasyDoTabeli.Add("CocktailSort");
            CzasyDoTabeli.Add("Wielkosc Tabeli");

            Zapisz(sciezka + "/Zad2_Losowo.csv", CzasyDoTabeli);
            Zapisz(sciezka + "/Zad2_Rosnaco.csv", CzasyDoTabeli);
            Zapisz(sciezka + "/Zad2_Malejaco.csv", CzasyDoTabeli);
            Zapisz(sciezka + "/Zad2_Stalo.csv", CzasyDoTabeli);
            Zapisz(sciezka + "/Zad2_Vksztaltnie.csv", CzasyDoTabeli);
            CzasyDoTabeli.Clear();

            /*Część Zadania 2 END*/
            Console.WriteLine();

            Console.Write("Podejście x");
            for (int j = 1; j <= 24; j++)
            {
                if (j % 6 == 0) Console.Write("* ");
                else Console.Write(". ");
            }
            
            Console.WriteLine();
            for (int i = 1; i <= LiczbaPunktKontrony; i++)
            {
                Console.Write("Podejście {0}", i);

                int wielkoscTablicy = WielkoscTablic / LiczbaPunktKontrony * i;

                Losowo(InsertionSort, i);
                Rosnaco(InsertionSort, i);
                Malejaco(InsertionSort, i);
                Stala(InsertionSort, i);
                VKsztaltna(InsertionSort, i);
                CzasyDoTabeli.Add(wielkoscTablicy.ToString());
                Zapisz(sciezka + "/Zad1_InsertionSort.csv", CzasyDoTabeli);
                CzasyDoTabeli.Clear();

                Losowo(SelectionSort, i);
                Rosnaco(SelectionSort, i);
                Malejaco(SelectionSort, i);
                Stala(SelectionSort, i);
                VKsztaltna(SelectionSort, i);
                CzasyDoTabeli.Add(wielkoscTablicy.ToString());
                Zapisz(sciezka + "/Zad1_SelectionSort.csv", CzasyDoTabeli);
                CzasyDoTabeli.Clear();

                Losowo(HeapSort, i);
                Rosnaco(HeapSort, i);
                Malejaco(HeapSort, i);
                Stala(HeapSort, i);
                VKsztaltna(HeapSort, i);
                CzasyDoTabeli.Add(wielkoscTablicy.ToString());
                Zapisz(sciezka + "/Zad1_HeapSort.csv", CzasyDoTabeli);
                CzasyDoTabeli.Clear();

                Losowo(CocktailSort, i);
                Rosnaco(CocktailSort, i);
                Malejaco(CocktailSort, i);
                Stala(CocktailSort, i);
                VKsztaltna(CocktailSort, i);
                CzasyDoTabeli.Add(wielkoscTablicy.ToString());
                Zapisz(sciezka + "/Zad1_CocktailSort.csv", CzasyDoTabeli);
                CzasyDoTabeli.Clear();

                /*Część Zadania 2*/
                CzasyDoTabeliLosowej.Add(wielkoscTablicy.ToString());
                CzasyDoTabeliRosnacej.Add(wielkoscTablicy.ToString());
                CzasyDoTabeliMalejacej.Add(wielkoscTablicy.ToString());
                CzasyDoTabeliStalej.Add(wielkoscTablicy.ToString());
                CzasyDoTabeliVksztaltnej.Add(wielkoscTablicy.ToString());

                Zapisz(sciezka + "/Zad2_Losowo.csv", CzasyDoTabeliLosowej);
                Zapisz(sciezka + "/Zad2_Rosnaco.csv", CzasyDoTabeliRosnacej);
                Zapisz(sciezka + "/Zad2_Malejaco.csv", CzasyDoTabeliMalejacej);
                Zapisz(sciezka + "/Zad2_Stalo.csv", CzasyDoTabeliStalej);
                Zapisz(sciezka + "/Zad2_Vksztaltnie.csv", CzasyDoTabeliVksztaltnej);

                CzasyDoTabeliLosowej.Clear();
                CzasyDoTabeliRosnacej.Clear();
                CzasyDoTabeliMalejacej.Clear();
                CzasyDoTabeliStalej.Clear();
                CzasyDoTabeliVksztaltnej.Clear();
                /*Część Zadania 2 END*/
                Console.WriteLine();
            }

            Console.WriteLine("Koniec Zadania pierwszego i drugiego");
            /*
             * 
             * Zadanie Trzecie     
             *          
             */


            //Podpunkt 1 Czyli sprawdzenie co lepsze: iteracyjnie czy Rekurencyjnie
            
            CzasyDoTabeli.Add("Rekurencyjnie");
            CzasyDoTabeli.Add("Iteracyjnie");
            CzasyDoTabeli.Add("Wielkosc Tabeli");

            Zapisz(sciezka + "/Zad3_Rek_VS_Itera.csv", CzasyDoTabeli);
            CzasyDoTabeli.Clear();

            Console.WriteLine("\nZadanie 3 podpunkt 1\n\n");

            mediana = "center";//Ustawiamy na standardową medianę czyli środkową
            for (int i = 1; i <= LiczbaPunktKontrony; i++)
            {
                int wielkoscTablicy = WielkoscTablic / LiczbaPunktKontrony * i;

                Console.Write("Podejście {0}", i);

                Losowo(qsortRekWywołanie, i);
                Losowo(qsortIte, i);
                CzasyDoTabeli.Add(wielkoscTablicy.ToString());

                Zapisz(sciezka + "/Zad3_Rek_VS_Itera.csv", CzasyDoTabeli);

                CzasyDoTabeli.Clear();
                Console.WriteLine();
            }

            //Podpunkt 2 Czyli sprawdzenie jak się miewa odpowiednie dobranie mediany
            // Wybór na qsort iteracyjnie to tylko przypadek (żut monetą)

            CzasyDoTabeli.Add("Skrajnie prawa");
            CzasyDoTabeli.Add("Srodkowe");
            CzasyDoTabeli.Add("Losowe");
            CzasyDoTabeli.Add("Wielkosc Tabeli");

            Zapisz(sciezka + "/Zad3_InsertionSort.csv", CzasyDoTabeli);

            CzasyDoTabeli.Clear();
            Console.WriteLine("\nZadanie 3 podpunkt 2\n\n");

            
            for (int i = 1; i <= LiczbaPunktKontrony; i++)
            {
                int wielkoscTablicy = WielkoscTablic / LiczbaPunktKontrony * i;
                Console.Write("Podejście {0}", i);

                mediana = "right";
                AKsztaltna(qsortIte, i);
                mediana = "center";
                AKsztaltna(qsortIte, i);
                mediana = "rand";
                AKsztaltna(qsortIte, i);

                CzasyDoTabeli.Add(wielkoscTablicy.ToString());
                Zapisz(sciezka + "/Zad3_InsertionSort.csv", CzasyDoTabeli);

                CzasyDoTabeli.Clear();
                Console.WriteLine();
            }





            Console.WriteLine("Koniec Zadania trzeciego");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Koniec Projektu 3");
            Console.ReadKey();

        }

        static void CzySciezkaIstnieje(string SciezkaMetody)
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(SciezkaMetody))
                {
                    Console.WriteLine("Ta ścieżka jest już dostępna.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(SciezkaMetody);
                Console.WriteLine("Sukces! Storzono folder z datą: {0}.", Directory.GetCreationTime(SciezkaMetody));

                // Delete the directory.
                di.Delete();
                Console.WriteLine("Directory sprawnie usunięte.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        static void WypelniamyTablice()
        {
            Console.WriteLine("Wypełniamy Tablice:");
            int z;
            int pom = WielkoscTablic / 2, min = int.MinValue, max = int.MaxValue, x = rnd.Next(TablicaLosowa.Length);

            Console.Write("Tablica Stała:");
            for (int i = 0; i < WielkoscTablic; i++)
                TablicaStala[i] = x;
            Console.WriteLine("Zrobione !");

            Console.Write("Tablica Rosnąca:");
            for (int i = 0; i < WielkoscTablic; i++, min++)
                TablicaRosnaca[i] = min;
            Console.WriteLine("Zrobione !");

            Console.Write("Tablica Malejąca:");
            for (int i = 0; i < WielkoscTablic; i++, max--)
                TablicaMalejaca[i] = max;
            Console.WriteLine("Zrobione !");

            Console.Write("Tablica Losowa:");
            for (int i = 0; i < WielkoscTablic; i++)
                TablicaLosowa[i] = rnd.Next(TablicaLosowa.Length);
            Console.WriteLine("Zrobione !");

            Console.Write("Tablica V-kształtna:");
            for (z = 0; z < Math.Ceiling((double)WielkoscTablic / 2); z++, pom -= 2)
                TablicaVKształtna[z] = pom;
            pom += 3;
            do
            {
                TablicaVKształtna[z] = pom;
                z++; pom += 2;
            } while (z < WielkoscTablic);
            Console.WriteLine("Zrobione !");


            pom = WielkoscTablic / 2;
            Console.Write("Tablica A-kształtna:");
            for (z = 0; z < Math.Ceiling((double)WielkoscTablic / 2); z++, pom += 2)
                TablicaAKształtna[z] = pom;
            pom -= 3;
            do
            {
                TablicaVKształtna[z] = pom;
                z++; pom -= 2;
            } while (z < WielkoscTablic);
            Console.WriteLine("Zrobione !");
        }

        static void Czas(Func<int[], bool> MyMethodName, int[] NieposortowanaTablica)
        {
            CzasZapytaniaWSekundach = 0;
            int powtorzenia = LiczbaPorworzen;
            ulong SumaCzasuKomputera = 0, PojedynczyCzasKomputera, MinimalnyCzasZapytania = ulong.MaxValue, MaksymalnyCzasZapytania = ulong.MinValue;
            for (int l = 0; l < powtorzenia + 2; l++)
            {
                ulong StartCzasSystemowy = (ulong)Stopwatch.GetTimestamp();
                MyMethodName(NieposortowanaTablica);
                ulong StopCzasSystemowy = (ulong)Stopwatch.GetTimestamp();

                PojedynczyCzasKomputera = StopCzasSystemowy - StartCzasSystemowy;
                SumaCzasuKomputera += PojedynczyCzasKomputera;
                if (PojedynczyCzasKomputera < MinimalnyCzasZapytania) MinimalnyCzasZapytania = PojedynczyCzasKomputera;
                if (PojedynczyCzasKomputera > MaksymalnyCzasZapytania) MaksymalnyCzasZapytania = PojedynczyCzasKomputera;
            }
            SumaCzasuKomputera -= (MinimalnyCzasZapytania + MaksymalnyCzasZapytania);
            CzasZapytaniaWSekundach = SumaCzasuKomputera * (1.0 / (powtorzenia * Stopwatch.Frequency));
            CzasyDoTabeli.Add(CzasZapytaniaWSekundach.ToString());
        }

        static void Losowo(Func<int[], bool> MyMethodName, int i)
        {
            InformacjaKropka();

            int[] KopiaTablicy = new int[WielkoscTablic];
            TablicaLosowa.CopyTo(KopiaTablicy, 0);

            Array.Resize(ref KopiaTablicy, (WielkoscTablic / LiczbaPunktKontrony * i));
            Czas(MyMethodName, KopiaTablicy);

            /*Zadanie Drugie*/
            CzasyDoTabeliLosowej.Add(CzasZapytaniaWSekundach.ToString());
        }

        static void Rosnaco(Func<int[], bool> MyMethodName, int i)
        {
            InformacjaKropka();

            int[] KopiaTablicy = new int[WielkoscTablic];
            TablicaRosnaca.CopyTo(KopiaTablicy, 0);

            Array.Resize(ref KopiaTablicy, (WielkoscTablic / LiczbaPunktKontrony * i));
            Czas(MyMethodName, KopiaTablicy);

            /*Zadanie Drugie*/
            CzasyDoTabeliRosnacej.Add(CzasZapytaniaWSekundach.ToString());
        }

        static void Malejaco(Func<int[], bool> MyMethodName, int i)
        {
            InformacjaKropka();

            int[] KopiaTablicy = new int[WielkoscTablic];
            TablicaMalejaca.CopyTo(KopiaTablicy, 0);

            Array.Resize(ref KopiaTablicy, (WielkoscTablic / LiczbaPunktKontrony * i));
            Czas(MyMethodName, KopiaTablicy);

            /*Zadanie Drugie*/
            CzasyDoTabeliMalejacej.Add(CzasZapytaniaWSekundach.ToString());
        }

        static void Stala(Func<int[], bool> MyMethodName, int i)
        {
            InformacjaKropka();

            int[] KopiaTablicy = new int[WielkoscTablic];
            TablicaStala.CopyTo(KopiaTablicy, 0);

            Array.Resize(ref KopiaTablicy, (WielkoscTablic / LiczbaPunktKontrony * i));
            Czas(MyMethodName, KopiaTablicy);

            /*Zadanie Drugie*/
            CzasyDoTabeliStalej.Add(CzasZapytaniaWSekundach.ToString());
        }

        static void VKsztaltna(Func<int[], bool> MyMethodName, int i)
        {
            InformacjaKropka();

            int[] KopiaTablicy = new int[WielkoscTablic];
            TablicaVKształtna.CopyTo(KopiaTablicy, 0);

            int PomocLiczba = (WielkoscTablic - (WielkoscTablic / LiczbaPunktKontrony * i));

            Array.Resize(ref KopiaTablicy, (PomocLiczba + (WielkoscTablic / LiczbaPunktKontrony * i)));
            Array.Reverse(KopiaTablicy);
            Array.Resize(ref KopiaTablicy, (WielkoscTablic / LiczbaPunktKontrony * i));
            Array.Reverse(KopiaTablicy);
            Czas(MyMethodName, KopiaTablicy);

            /*Zadanie Drugie*/
            CzasyDoTabeliVksztaltnej.Add(CzasZapytaniaWSekundach.ToString());
        }

        static void AKsztaltna(Func<int[], bool> MyMethodName, int i)
        {
            InformacjaKropka();

            int[] KopiaTablicy = new int[WielkoscTablic];
            TablicaAKształtna.CopyTo(KopiaTablicy, 0);

            int PomocLiczba = (WielkoscTablic - (WielkoscTablic / LiczbaPunktKontrony * i));

            Array.Resize(ref KopiaTablicy, (PomocLiczba + (WielkoscTablic / LiczbaPunktKontrony * i)));
            Array.Reverse(KopiaTablicy);
            Array.Resize(ref KopiaTablicy, (WielkoscTablic / LiczbaPunktKontrony * i));
            Array.Reverse(KopiaTablicy);
            Czas(MyMethodName, KopiaTablicy);

            /*Zadanie Drugie*/
            CzasyDoTabeliVksztaltnej.Add(CzasZapytaniaWSekundach.ToString());
        }

        static void InformacjaKropka()
        {
            Console.Write(". ");
        }

        /// <summary>
        /// Sortowanie przez Proste Wstawianie
        /// </summary>
        static bool InsertionSort(int[] TablicaMetody)
        {
            for (int i = 1; i < TablicaMetody.Length; i++)
            {
                int j = i;
                int Bufor = TablicaMetody[j]; // Zapamiętujemy aktualną liczbę
                while ((j > 0) && (TablicaMetody[j - 1]) > Bufor) // Przesówamy wszytkie liczby na prawo od Bufora
                {
                    TablicaMetody[j] = TablicaMetody[j - 1];
                    j--;
                }
                TablicaMetody[j] = Bufor;//Już przed przesunięte liczby wstawiamy Bufor
            }
            return true;
        }

        /// <summary>
        /// Sortowanie przez Proste Wybieranie
        /// </summary>
        static bool SelectionSort(int[] TablicaMetody)
        {
            for (int i = 0; i < TablicaMetody.Length - 1; i++)
            {
                int Bufor = TablicaMetody[i];//Zapamiętujemy aktualną liczbę
                int k = i;//Przypisujemy pozycje (indeks) aktualnej liczby
                for (int j = i + 1; j < TablicaMetody.Length; j++)//Szukamy najmniejszej liczby na prawo tablicy
                    if (TablicaMetody[j] < Bufor)
                    {
                        k = j;
                        Bufor = TablicaMetody[j];
                    }
                TablicaMetody[k] = TablicaMetody[i];
                TablicaMetody[i] = Bufor;
            }
            return true;
        }

        /// <summary>
        /// Naprawianie Kopca
        /// </summary>
        /// <param name="lewa"></param>
        /// <param name="prawa"></param>
        static bool Heapify(int[] TablicaMetody, int Lewa, int Prawa)
        {
            int i = Lewa,
            j = 2 * i + 1;
            int Bufor = TablicaMetody[i]; // ojciec
            while (j <= Prawa) // przesiewamy do dna stogu
            {
                if (j < Prawa) // wybieramy większego syna
                    if (TablicaMetody[j] < TablicaMetody[j + 1]) j++;
                if (Bufor >= TablicaMetody[j]) break;
                TablicaMetody[i] = TablicaMetody[j];
                i = j;
                j = 2 * i + 1; // przechodzimy do dzieci syna
            }
            TablicaMetody[i] = Bufor;
            return true;
        }

        /// <summary>
        /// Sortowanie Stogowe
        /// </summary>
        static bool HeapSort(int[] TablicaMetody)
        {
            int lewa = TablicaMetody.Length / 2,
                prawa = TablicaMetody.Length - 1;
            while (lewa > 0)
            {
                lewa--;
                Heapify(TablicaMetody, lewa, prawa);
            }
            while (prawa > 0)
            {
                int Bufor = TablicaMetody[lewa];
                TablicaMetody[lewa] = TablicaMetody[prawa];
                TablicaMetody[prawa] = Bufor;
                prawa--;
                Heapify(TablicaMetody, lewa, prawa);
            }
            return true;
        }

        /// <summary>
        /// Sortowanie Koklailowe 
        /// </summary>
        static bool CocktailSort(int[] TablicaMetody)
        {
            int lewa = 1, prawa = TablicaMetody.Length - 1, k = TablicaMetody.Length - 1;
            do
            {
                for (int j = prawa; j >= lewa; j--)
                    if (TablicaMetody[j - 1] > TablicaMetody[j])
                    {
                        int Bufor = TablicaMetody[j - 1]; TablicaMetody[j - 1] = TablicaMetody[j]; TablicaMetody[j] = Bufor;
                        k = j;
                    }
                lewa = k + 1;
                for (int j = lewa; j <= prawa; j++)
                    if (TablicaMetody[j - 1] > TablicaMetody[j])
                    {
                        int Bufor = TablicaMetody[j - 1]; TablicaMetody[j - 1] = TablicaMetody[j]; TablicaMetody[j] = Bufor;
                        k = j;
                    }
                prawa = k - 1;
            }
            while (lewa <= prawa);
            return true;
        }

        /// <summary>
        /// Metoda która pozwoli ujednolicić wywołanie obydwóch qsort
        /// </summary>
        /// <param name="TablicaMetody"></param>
        /// <param name="mediana"></param>
        /// <returns></returns>
        static bool qsortRekWywołanie(int[] TablicaMetody)
        {
            qsortRek(TablicaMetody, 0, TablicaMetody.GetUpperBound(0));
            return true;
        }

        /// <summary>
        /// Sortowanie szybkie Rekurencyjne
        /// </summary>
        /// <param name="TablicaMetody"></param>
        /// <param name="l"></param>
        /// <param name="p"></param>
        static bool qsortRek(int[] TablicaMetody, int l, int p)
        {

            int i, j;
            int x = 0;//Muszę coś przypisać
            i = l;
            j = p;
            switch (mediana)
            {
                case "right":
                    x = TablicaMetody[p]; // (pseudo)mediana
                    break;
                case "center":
                    x = TablicaMetody[(l + p) / 2]; // (pseudo)mediana
                    break;
                case "rand":
                    x = TablicaMetody[rnd.Next(l, p)]; // (pseudo)mediana
                    break;
            }

            do
            {
                while (TablicaMetody[i] < x) i++; // przesuwamy indeksy z lewej
                while (x < TablicaMetody[j]) j--; // przesuwamy indeksy z prawej
                if (i <= j) // jeśli nie minęliśmy się indeksami (koniec kroku)
                { // zamieniamy elementy
                    int Bufor = TablicaMetody[i]; TablicaMetody[i] = TablicaMetody[j]; TablicaMetody[j] = Bufor;
                    i++; j--;
                }
            }
            while (i <= j);
            if (l < j) qsortRek(TablicaMetody, l, j); // sortujemy lewą część (jeśli jest)
            if (i < p) qsortRek(TablicaMetody, i, p); // sortujemy prawą część (jeśli jest)
            return true;
        } /* qsort() requrent*/

        /// <summary>
        /// Sortowanie szybkie Iteracyjnie
        /// </summary>
        /// <param name="TablicaMetody"></param>
        static bool qsortIte(int[] TablicaMetody)
        {
            int i, j, l, p, sp;
            int[] stos_l = new int[TablicaMetody.Length],
            stos_p = new int[TablicaMetody.Length]; // przechowywanie żądań podziału
            sp = 0; stos_l[sp] = 0; stos_p[sp] = TablicaMetody.Length - 1; // rozpoczynamy od całej tablicy
            do
            {
                l = stos_l[sp]; p = stos_p[sp]; sp--; // pobieramy żądanie podziału
                do
                {
                    int x = 0; // Również na siłę muszę przypisać
                    switch (mediana)
                    {
                        case "right":
                            x = TablicaMetody[p]; // analogicznie do wersji rekurencyjnej
                            break;
                        case "center":
                            x = TablicaMetody[(l + p) / 2]; // analogicznie do wersji rekurencyjnej
                            break;
                        case "rand":
                            x = TablicaMetody[rnd.Next(l, p)]; // analogicznie do wersji rekurencyjnej
                            break;
                    }
                    i = l; j = p;
                    do
                    {
                        while (TablicaMetody[i] < x) i++;
                        while (x < TablicaMetody[j]) j--;
                        if (i <= j)
                        {
                            int Bufor = TablicaMetody[i]; TablicaMetody[i] = TablicaMetody[j]; TablicaMetody[j] = Bufor;
                            i++; j--;
                        }
                    } while (i <= j);
                    if (i < p) { sp++; stos_l[sp] = i; stos_p[sp] = p; } // ewentualnie dodajemy żądanie podziału
                    p = j;
                } while (l < p);
            } while (sp >= 0); // dopóki stos żądań nie będzie pusty
            return true;
        } /* qsort() iteral */

        static void Zapisz(string SciezkaMetody, List<string> ListaCzasow)
        {
            Console.Write("* ");
            using (StreamWriter ObjektZapis = new StreamWriter(SciezkaMetody, true))
            {
                if (ListaCzasow.Count > 5)//Źlie na sztywno wpisane
                {
                    ObjektZapis.WriteLine("{0};{1};{2};{3};{4};{5}", ListaCzasow[0], ListaCzasow[1], ListaCzasow[2], ListaCzasow[3], ListaCzasow[4], ListaCzasow[5]);
                }
                else if (ListaCzasow.Count == 4)//Zadanie Trzecie podpunkt 2
                {
                    ObjektZapis.WriteLine("{0};{1};{2};{3}", ListaCzasow[0], ListaCzasow[1], ListaCzasow[2], ListaCzasow[3]);
                }
                else if (ListaCzasow.Count == 3)//Zadanie Trzecie podpunkt 1
                {
                    ObjektZapis.WriteLine("{0};{1};{2}", ListaCzasow[0], ListaCzasow[1], ListaCzasow[2]);
                }
                else//Zadnaie drugie
                {
                    ObjektZapis.WriteLine("{0};{1};{2};{3};{4}", ListaCzasow[0], ListaCzasow[1], ListaCzasow[2], ListaCzasow[3], ListaCzasow[4]);
                }

            }
        }
    }

}
