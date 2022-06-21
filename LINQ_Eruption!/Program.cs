List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Use LINQ to find the first eruption that is in Chile and print the result.

Eruption chileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile" );

//Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."

int? Hawaii = eruptions.FirstOrDefault( h => h.Location == "Hawaiian Is" )?.Year;

if (Hawaii != null)
{
    Console.WriteLine($"the first eruption from the Hawaiian Island was {Hawaii}");


}
else
{
    Console.WriteLine($"No Hawaiian Is Eruption found.");

}

//Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.

// Convert to FirstOrDefault 
Eruption firstZelandEruption = eruptions.FirstOrDefault( z => z.Year > 1900 && z.Location == "New Zealand");

Console.WriteLine(firstZelandEruption);

// Find all eruptions where the volcano's elevation is over 2000m and print them.

IEnumerable<Eruption> elevationOver2000 = eruptions.Where( b => b.ElevationInMeters > 2000);

Console.WriteLine("-----------------------------");
foreach (Eruption limit in elevationOver2000)
{

    Console.WriteLine(limit);
}

// Find all eruptions where the volcano's name starts with "Z" and print them. Also print the number of eruptions found.


IEnumerable<Eruption> zStart =  eruptions.Where(b => b.Volcano.StartsWith("Z"));
Console.WriteLine("Z Start \n-------------------------------------");
int zCount = 0;
foreach ( var e in zStart)
{
    Console.WriteLine(e);
    zCount += 1;
}
Console.WriteLine($"All eruptions where the volcano's name starts with Z Found: {zCount} ");

//Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
Console.WriteLine("\n-------------------------------------\n");

int HighestElevation = eruptions.Max(h => h.ElevationInMeters );

Console.WriteLine($"the Highest Elevation From the List {HighestElevation}m");

// Use the highest elevation variable to find a print the name of the Volcano with that elevation.

Console.WriteLine("\n-------------------------------------\nThe Volcano with the highest elevation");

Eruption tallestVolcano = eruptions.FirstOrDefault(t => t.ElevationInMeters == HighestElevation);
Console.WriteLine($"{tallestVolcano.Volcano} is the Volcano with the highest elevation of {HighestElevation}m ");


//Print all Volcano names alphabetically.

IEnumerable<Eruption> alphaVolcano = eruptions.OrderBy(a => a.Volcano);
Console.WriteLine("\n-------------------------------------");

Console.WriteLine("all Volcano names alphabetically\n");

foreach ( Eruption k in alphaVolcano)
{
    Console.WriteLine(k.Volcano);
}

// Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.

Console.WriteLine("-------------------------------------\n");
IEnumerable<Eruption> before1000CE = eruptions.Where(c => c.Year > 1000).OrderBy( x => x.Volcano);
Console.WriteLine("all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.");

foreach (Eruption bce in before1000CE)
{
    Console.WriteLine($"{bce.Volcano}");
}

//BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
//Console.WriteLine("-----------------Extra--------------------\n");
//var selectBefore1000CE = eruptions.Where(d => d.Year > 1000).Select(w => w.Volcano);
//Console.WriteLine("last query, but this time use LINQ to only select the volcano's name so that only the names are printed.");

//foreach (var q in selectBefore1000CE)
//{
//    Console.WriteLine($"{q}");
//}




// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
// static void PrintEach(IEnumerable<dynamic> items, string msg = "")
// {
//     Console.WriteLine("\n" + msg);
//     foreach (var item in items)
//     {
//         Console.WriteLine(item.ToString());
//     }
// }
