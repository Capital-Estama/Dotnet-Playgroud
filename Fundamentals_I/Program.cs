using System;

namespace  fundamentals 
{
    class Program 
    {
        static void Main()
        {
            Lib fizzBuzz = new Lib();
            // Create a Loop that prints all values from 1-255
            fizzBuzz.PrintAll();
            // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            fizzBuzz.PrintByMod();
            
            //Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
            fizzBuzz.PrintFizzBuzz();
            
        }
    }
}

