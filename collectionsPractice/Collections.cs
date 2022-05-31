using System;
using System.Collections;

namespace collectionsPractice
{
    public class Collections
    {
        // Fields
        public int[] simpleIntArr;
        public string[] names;
        public string[] truth;
        public List<string> iceCream ;
        public Collections()
        {
            // constructor
            simpleIntArr = new int[] {0,1,2,3,4,5,6,7,8,9};
            names = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            truth = new string[10];
            iceCream = new List<string>();

        }
        //Three Basic Arrays
        // Create an array to hold integer values 0 through 9
        public void PrintSmallIntArr()
        {
            Console.WriteLine("array to hold integer values 0 through 9");
            foreach ( int idx in simpleIntArr )
            {
                Console.WriteLine(idx);
            }
            Console.WriteLine("####################################");
        }
        // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"

        public void PrintStringArr()
        {
            Console.WriteLine(" array of the names Tim, Martin, Nikki, & Sara \n");
            foreach (string name in names)
            {
                Console.WriteLine("Hello" + " " + name);
            }
            Console.WriteLine("###########################");


        }
        // Create an array of length 10 that alternates between true and false values, starting with true
        public void PrintTruth()
        {
            for (int i = 1; i <= 10; i++)
            {
                if ( i % 2 == 1)
                {
                    truth[i -1] = "true";
                }
                else
                {
                    truth[i -1] = "false";
                }
            }
            // print array
            foreach (string status in truth)
            {
                Console.WriteLine(status);
            }
        }
        public void Flavors()
        {
            
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("\nAdd ONE Ice cream flavor \n then Press [Enter].. ");
                string? line = Console.ReadLine();
                iceCream.Add(line); 
                Console.Clear();
            }
            foreach(string flav in iceCream)
            {
                Console.WriteLine(flav);
            }
            // Output the length of this list after building it
            Console.WriteLine("the Length of Ice Cream list is: " + iceCream.Count());
            // Console.WriteLine("Enter number Between 0-5");
            // int? index = (int)Console.ReadKey();
            // int Bowl; // Variable to hold number

            // ConsoleKeyIfnfo UserInput = Console.ReadKey(); // Get user input

            // // We check input for a Digit
            // if (char.IsDigit(UserInput.KeyChar))
            // {
            //     Bowl = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
            // }
            // else
            // {
            //     Bowl = -1;  // Else we assign a default value

            Console.WriteLine($"the third flavor in the list {iceCream[2]} has been removed." );
            // Output the third flavor in the list, then remove this value
            iceCream.RemoveAt(2);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("the new Length of Ice Cream list is: " + iceCream.Count());

        }
        
        //User Info Dictionary

        // Create a dictionary that will store both string keys as well as string values
        // Add key/value pairs to this dictionary where:
        // each key is a name from your names array
        // each value is a randomly elected flavor from your flavors list.
        // Loop through the dictionary and print out each user's name and their associated ice cream flavor
    }
}