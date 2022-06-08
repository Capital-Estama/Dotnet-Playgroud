//    Random Array
        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array
        // Print the sum of all the values

        
        var rnd = new Random();
        int[] RandomArray()
        {
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(5,25);
                Console.WriteLine(arr[i]);

            }
            int len = arr.Length;
            int pHolder = arr[0];
            int lHolder = arr[0];

            foreach (var item in arr)
            {
                
                
                if (item >= pHolder)
                {
                    pHolder = item;

                }
                else if (item <= lHolder)
                {
                    lHolder = item;
                }
            
            }
            int ave = (pHolder + lHolder) / len;

                Console.WriteLine($"the AVE is{ave} the Min is: {lHolder} the Max is: {pHolder}");

            return arr ;
        }
        RandomArray();

        






        // Coin Flip
        // Create a function called TossCoin() that returns a string

        // Have the function print "Tossing a Coin!"
        // Randomize a coin toss with a result signaling either side of the coin 
        // Have the function print either "Heads" or "Tails"
        static string TossCoin()
        {
            var rnd = new Random();
            string result = "";
            string[] coin = new string[2] {"Heads","Tails"};
            
            if (rnd.Next() % 2 == 1) 
            {
                Console.WriteLine(coin[1]);
                return result = coin[1];
            }
            else
            {
                Console.WriteLine(coin[0]);
                return result = coin[0];
            }

        }
        // Finally, return the result
        Console.WriteLine("Tossing a Coin!");

        TossCoin();


        



        // Create another function called TossMultipleCoins(int num) that returns a Double

        // Have the function call the tossCoin function multiple times based on num value

        // Have the function return a Double that reflects the ratio of head toss to total toss
        static double TossMultipleCoins(int num)
        {
            // double ratio = 0.0;
            double hCount = 0, tCount = 0;
            for (int i = 0; i < num; i++  )
            {
                string coin = TossCoin();
                if (coin == "Heads")
                {
                    hCount++;

                }
                else
                {
                    tCount++;


                }
            }
            
            double ratio = hCount / num;
            Console.WriteLine(ratio);
            return ratio;   
        }
        double multires = TossMultipleCoins(5);
        Console.WriteLine(multires);

        // Names
        // Build a function Names that returns a list of strings.  In this function:
        static string[] Names()
        { 
        // Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        string[] name = new string[] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
        // Shuffle the list and print the values in the new order
        string[] nOrder = new string[name.Length];


        var rnd = new Random();
        var idx = new Random();
        int[] rNums = new int[name.Length];
        // refactor this 
        for (int i = 0; i < name.Length -1 ; i++)
        {
            
            // if (!nOrder[i].Contains(name[idx.Next(0,4)]))
            // {
                nOrder[i] = name[rnd.Next(0,4)];

            // }
            
        }
        return nOrder;
        
        }

        var x = Names();
        foreach (var y in x)
        {
            Console.WriteLine(y);
        }
        



        // Return a list that only includes names longer than 5 characters
        