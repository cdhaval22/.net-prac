using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dollar
{
    class Program
    {
        static void Main(string[] args)
        {
            double d_rate, e_rate, f_rate;
            int ch;
            d_rate = double.Parse(Console.ReadLine());
            Console.WriteLine("\n take 1 dollar =" +d_rate+"Rs");
            e_rate = double.Parse(Console.ReadLine());
            Console.WriteLine("\n take 1 euro =" + e_rate + "Rs");
            f_rate = double.Parse(Console.ReadLine());
            Console.WriteLine("\n take 1 frank =" + f_rate + "Rs");
            do
            {
                Console.WriteLine("\n1. dollar to rupee \n 2. euro to rupee\n 3.frank to rupee\n enter choice");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("\n enter dollar :");
                        int x = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n rupees:"+x * d_rate);
                        break;
                    case 2:
                        Console.WriteLine("\n enter euro :");
                        int y = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n rupees:"+y * d_rate);
                        break;
                    case 3:
                        Console.WriteLine("\n enter frank :");
                        int z = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n rupees:"+z * d_rate);
                        break;
                    default:
                        break;



                }
            } while (ch!=4);
        }
    }
}
