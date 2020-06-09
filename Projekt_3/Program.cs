using Projekt_3;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projekt_3
{
    class Program
    {
        // projekt 3
        // tworzenie tablic
        public static Stopwatch stoperek = new Stopwatch();
        private static int[] Randomowa(int size)
        {
            Random rnd = new Random();
            int[] tab = new int[size];
            for (int i = 0; i < tab.Length; i++)
                tab[i] = rnd.Next();
            return tab;
        }

        private static int[] Stala(int size)
        {
            return new int[size];
        }

        private static int[] Rosnaco(int size)
        {
            int[] tab = new int[size];
            for (int i = 0; i < tab.Length; i++)
                tab[i] = i;
            return tab;
        }

        private static int[] Malejaco(int size)
        {
            int[] tab = new int[size];
            for (int i = 0; i < tab.Length; i++)
                tab[tab.Length-1-i] = i;
            return tab;
        }

        private static int[] Vshaped(int size)
        {
            int[] array = new int[size];
            int Vsh = size / 2;

            for(int i = 0; i < size; i++)
            {
                if (i < size / 2)
                    array[i] = Vsh--;
                else
                    array[i] = Vsh++;
            }

            return array;
        }

        // sortowanko

        static void SortowankoHeap(int[] tab)
        {
            int left = tab.Length / 2;
            int right = tab.Length - 1;
            while (left > 0)
            {
                left--;
                heapSort(ref tab, left, right);
            }

            while (right > 0)
            {
                int temp = tab[left];
                tab[left] = tab[right];
                tab[right] = temp;
                right--;
                heapSort(ref tab, left, right);
            }
        }

        static void heapSort(ref int[] tab, int left, int right)
        {
            int i = left,
                j = 2 * i + 1;
            int temp = tab[i];
            while (j <= right)
            {
                if (j < right)
                    if (tab[j] < tab[j + 1])
                        j++;
                if (temp >= tab[j]) break;
                tab[i] = tab[j];
                i = j;
                j = 2 * i + 1;
            }

            tab[i] = temp;
        }

        static void Koktajlowe(int[] tab)
        {
            int left = 1, right = tab.Length - 1, k = tab.Length - 1;
            do
            {
                for (int j = right; j >= left; j--)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                left = k + 1;
                for (int j = left; j <= right; j++)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                right = k - 1;
            } while (left <= right);
        }

        static void Wstawianie(int[] tab)
        {
            for (uint i = 1; i < tab.Length; i++)
            {
                uint j = i;
                int temp = tab[j];
                while ((j > 0) && (tab[j - 1] > temp))
                {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = temp;
            }

        }

        static void PrzezWybieranie(int[] tablica)
        {
            uint x;
            for(uint i = 0; i < (tablica.Length - 1); i++)
            {
                int temp = tablica[i];
                x = i;
                for (uint j = i + 1; j < tablica.Length; j++)
                {
                    
                    if (tablica[j] < temp)
                    {
                        x = j;
                        temp = tablica[j];
                    }
                }
                tablica[x] = tablica[i];
                tablica[i] = temp;
            }
        }




        static void Main(string[] args)
        {
            stoperek.Restart();
            stoperek.Start();
            for (int i = 50_000; i <= 200_000; i += 5_000)
            {
                Koktajlowe(Vshaped(i));
                Console.WriteLine($"{i};{stoperek.ElapsedMilliseconds}");
            }
            stoperek.Stop();
        }
    }
}
