using System;
using Binary;
using Bin = Binary.Binary;

namespace B2D
{
    class Program
    {
        static void Main(string[] args)
        {
            //get binary number
            try
            {
                Console.WriteLine("Input a binary number:");
                Console.Write(">");
                Bin binary = new(Console.ReadLine());
                
                if (binary.Value != null) //Required for null input to not error
                {
                    //converts to decimal
                    decimal decoutput = binary.ToDecimal();
                    Console.WriteLine();
                    Console.Write("Converted to decimal: ");
                    Console.WriteLine(decoutput);

                    //converts back to binary
                    Bin binoutput = Bin.ToBinary(decoutput);
                    Console.Write("Converted back to binary: ");
                    Console.WriteLine(binoutput.Value);
                }
                else { throw new Exception(); }
            }
            catch { Console.WriteLine("Input was not a binary number"); }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit . . .");
            Console.ReadLine();
        }
    }
}
