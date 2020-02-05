using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fercel
{
    class Program
    {
        static void Main(string[] args)
        {
            double f, c;
            int ch;
            do
            {
                Console.WriteLine("\n 1.celcious to fehranhit \n2. fehranhit to celcious \n 3. exit\n enter choce");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("\n enter celcious :");
                        c = double.Parse(Console.ReadLine());
                        f = c * 9 / 5 + 32;
                        Console.WriteLine(c + "c to " + f + "f");
                        break;
                    case 2:
                        Console.WriteLine("\n enter fehranhit :");
                        f = double.Parse(Console.ReadLine());
                        c = f * 5 / 9 - 32;
                        Console.WriteLine(f + "f to " + c + "c");
                        break;
                    default:
                        break;

                }
            } while (ch != 3);
        }
    }
}
