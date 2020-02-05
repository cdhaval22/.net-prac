using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int last = 0;
            string[] s = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            Console.WriteLine("\n ENTER DIGITS \n");
            string d1 = Console.ReadLine();
            string  c = new string(d1.Reverse().ToArray());
            int num = int.Parse(c);
            Console.WriteLine("\n words : ");
            do 
            {
                last = num % 10;
                Console.WriteLine(s[last] + "");
                num = num / 10;
            } while (num > 0);
            Console.WriteLine();
            Console.Read();
        }
    }
}
