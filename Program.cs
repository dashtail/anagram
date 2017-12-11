using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace anagram {
    class Program {
        private static List<string> anagram = new List<string> ();
        private static string chars;

        static void Main (string[] args) {
            while (!int.TryParse (chars, out var x)) {
                Console.WriteLine ("Entre com um valor numerico");
                chars = Console.ReadLine ();
            }

            List<char> charsUsed = new List<char> ();
            List<char> charsLeft = new List<char> (chars);
            RecursiveCount (charsUsed, charsLeft);

            List<int> anagramInt = anagram.Select (int.Parse).ToList ();
            anagram.ForEach (Console.WriteLine);

            int maxNumber = anagramInt.Max () >= 100000000 ? -1 : anagramInt.Max ();

            Console.WriteLine ("maior numero é: " + maxNumber);

            Console.ReadLine ();
        }
        static void RecursiveCount (List<char> charsUsed, List<char> charsLeft) {
            var result = new string (charsUsed.ToArray ());

            if (charsUsed.Count == chars.Length && result != chars) {
                anagram.Add (result);
            }

            if (charsLeft.Count () > 0) {
                for (int i = 0; i < charsLeft.Count (); i++) {
                    List<char> newcharsUsed = new List<char> (charsUsed);
                    newcharsUsed.Add (charsLeft[i]);

                    List<char> newcharsLeft = new List<char> (charsLeft);
                    newcharsLeft.RemoveAt (i);
                    RecursiveCount (newcharsUsed, newcharsLeft);
                }
            }
        }
    }
}