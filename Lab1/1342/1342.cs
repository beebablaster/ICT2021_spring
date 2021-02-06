using System;

namespace _1342
{
    class Prob1342
    {
        public int NumberOfSteps(int num)
        {
            int steps = 0;
            while (num != 0)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                    steps++;
                }
                else if (num % 2 != 0)
                {
                    num = num - 1;
                    steps++;
                }
            }
            return steps;
        }

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int n = int.Parse(line);
            Prob1342 p = new Prob1342();
            Console.WriteLine(p.NumberOfSteps(n));
        }
    }
}
