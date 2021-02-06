using System;

namespace Lab1
{

    class Problem1108
    {
        public void DefangIPaddr(string address)
        {
            string s = "";
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == '.')
                {
                    s += "[.]";
                }
                else s += address[i];
            }
            Console.WriteLine(s);
        }


        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Problem1108 p = new Problem1108();
            p.DefangIPaddr(s);
        }
    }

}
