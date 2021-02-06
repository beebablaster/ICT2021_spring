using System;

namespace _1662
{
    class Prob1662
    {
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string s1 = "";
            string s2 = "";
            for (int i = 0; i < word1.Length; i++)
            {
                s1 += word1[i];
            }

            for (int i = 0; i < word2.Length; i++)
            {
                s2 += word2[i];
            }
            if (s1 == s2) return true;
            else return false;
        }


        static void Main(string[] args)
        {
            string l = Console.ReadLine();
            int a = int.Parse(l);
            string[] word1 = new string[a];
            l = Console.ReadLine();
            int b = int.Parse(l);
            string[] word2 = new string[b];
            for (int i = 0; i < a; i++)
            {
                word1[i] = Console.ReadLine();
            }

            for (int i = 0; i < b; i++)
            {
                word2[i] = Console.ReadLine();
            }
            Prob1662 p = new Prob1662();
            Console.WriteLine(p.ArrayStringsAreEqual(word1, word2));
        }
    }
}
