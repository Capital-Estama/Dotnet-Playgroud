using System;

namespace fundamentals
{
    public class Lib 
    {
        // Fields
        public Lib()
        {
            Console.WriteLine("");
        }
        public void PrintAll()
        {
            // Create a Loop that prints all values from 1-255
            Console.WriteLine("###########################");
            Console.WriteLine("Loop that prints all values from 1-255");
            Console.WriteLine("");
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);

            }

        }
        public void PrintByMod()
        {
            // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            Console.WriteLine("###########################");
            Console.WriteLine("all values from 1-100 that are divisible by 3 or 5, but not both");
            Console.WriteLine("");
            for (int i = 1; i <= 100; i++)
            {
                if( i % 3 == 0 && !(i % 5 == 0))
                {
                    Console.WriteLine("Divisible by 3:");
                    Console.WriteLine(i);
                }
                if(i % 5 == 0 && !(i % 3 == 0))
                {
                    Console.WriteLine("Divisible by 5:");
                    Console.WriteLine(i);
                }
                
            }

        }
        public void PrintFizzBuzz()
        {
            //Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
            Console.WriteLine("###########################");
            Console.WriteLine(" print Fizz for multiples of 3, Buzz for multiples of 5, and FizzBuzz for numbers that are multiples of both 3 and 5");
            Console.WriteLine("");
            for (int i = 1; i <= 100; i++)
            {
                if ( i % 3 == 0 && !(i % 5 == 0))
                {
                    Console.WriteLine("Buzz");
                }
                if (i % 5 == 0 && !(i % 3 == 0))
                {
                    Console.WriteLine("Fizz");
                }
                if ( i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
        }

    }
    
}