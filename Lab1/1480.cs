using System;

namespace Lab1
{ 
    
    class Program
    {
        public void RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; ++i)
            {
                nums[i] += nums[i - 1];
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                Console.WriteLine(nums[i]);
            }

        }
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int n = int.Parse(line);
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                a[i] = int.Parse(line);
            }
            Program p = new Program();
            p.RunningSum(a);
        }
    }

}
