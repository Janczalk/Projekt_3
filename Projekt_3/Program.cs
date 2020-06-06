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

        static void Koktajlowe (int[] tablica)
        {
            bool swapped = true;
            uint start = 0;
            int end = tablica.Length;

            while (swapped == true)
            {
                swapped = false;
                for (uint i = start; i < end - 1; ++i )
                {
                    if(tablica[i] > tablica [i+1])
                    {
                        int temp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;

                swapped = false;
                end = end - 1;

                for(int i = end - 1; i >= start; i--)
                {
                    if(tablica[i]>tablica[i+1])
                    {
                        int temp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = temp;
                        swapped = true;
                    }
                }

                start = start + 1;
            }
        }

        static void PrzezWstawianie(int[] tablica)
        {
            for(uint i = 1; i < tablica.Length; i++)
            {
                uint j = i;
                int temp = tablica[j];

                while((j>0)&&(tablica[j-1]>temp))
                {
                    tablica[j] = tablica[j - 1];
                    j--;
                }
                tablica[j] = temp;
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
                PrzezWstawianie(Malejaco(i));
                Console.WriteLine($"{i};{stoperek.ElapsedMilliseconds}");
            }
            stoperek.Stop();
            Console.ReadKey();
        }
    }
}
