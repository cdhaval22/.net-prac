using System;

namespace mp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string n, dec, y,hex, bin1,oct;
            int k,   bin,x, dec1,dec2,dec3;
            do
            {
                
                Console.WriteLine("\n 1.convert binary to dacimal\n 2. convert decimal to hexadecimal \n 3.convert decimal to binary \n 4. convert decimal to octal \n enter any no ");
                n = Console.ReadLine(); 
                k = Convert.ToInt32(n);
               
                switch (k)
                {
                    case 1:
                        Console.WriteLine("\n enter binary number");
                        bin = Convert.ToInt16(Console.ReadLine());
                        dec = Convert.ToString(bin, 10);
                        Console.WriteLine("\n decimal value is :" + dec);
                        break;
                    case 2:
                        Console.WriteLine("\n enter decimal number");
                        dec1 = Convert.ToInt32(Console.ReadLine());
                        hex = Convert.ToString(dec1, 16);
                        Console.WriteLine("\n hexa value is :" +hex);
                        break;
                    case 3:
                        Console.WriteLine("\n enter decimal number");
                        dec2 = Convert.ToInt32(Console.ReadLine());
                        bin1= Convert.ToString(dec2, 2);
                        Console.WriteLine("\n binary value is :" + bin1);
                        break;
                    case 4:
                        Console.WriteLine("\n enter decimal number");
                        dec3 = Convert.ToInt32(Console.ReadLine());
                        oct = Convert.ToString(dec3,8);
                        Console.WriteLine("\n octal value is :" + oct);
                        break;
                    default:
                        break;
                }
            } while ( k != 5);

        }
    }
}
