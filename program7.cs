using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Choose \n(1) Binary to Decimal \n(2) Decimal to hexadecimal \n(3) Decimal to Binary \n(4) Decimal to Ocatal");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int num, bin_val, dec_val = 0, base_val = 1, rem;
                        Console.WriteLine("Enter binary Number");
                        num = int.Parse(Console.ReadLine());
                        bin_val = num;
                        while (num > 0)
                        {
                            rem = num % 10;
                            dec_val = dec_val + rem * base_val;
                            num = num / 10;
                            base_val = base_val * 2;
                        }
                        Console.WriteLine(dec_val);
                        break;

                    case 2:
                        Console.WriteLine("Enter Decimal Number");
                        int input = int.Parse(Console.ReadLine());
                        string outputhex = Convert.ToString(input, 16);
                        Console.WriteLine(outputhex);
                        break;

                    case 3:
                        Console.WriteLine("Enter Decimal Number");
                        input = int.Parse(Console.ReadLine());
                        string outputbin = Convert.ToString(input, 2);
                        Console.WriteLine(outputbin);
                        break;

                    case 4:
                        Console.WriteLine("Enter Decimal Number");
                        input = int.Parse(Console.ReadLine());
                        string outputoct = Convert.ToString(input, 8);
                        Console.WriteLine(outputoct);
                        break;

                    case 5:

                        break;
                }
            } while (choice != 5);
            Console.ReadLine();
        }
    }
}