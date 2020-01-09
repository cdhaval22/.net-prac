using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_6
{
    class Program
    {
        static void Main(string[] args)
        {
            String name, country;
            Console.WriteLine("Enter Your Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter Your Country");
            country = Console.ReadLine();
            Console.WriteLine("Hello " + name + " from Country " + country);
            Console.ReadLine();
        }
    }
}
