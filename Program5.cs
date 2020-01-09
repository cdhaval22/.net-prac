using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            for(i=0;i<=4;i++)
            {
                for(j=0;j<=5;j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        } 
    }
}
