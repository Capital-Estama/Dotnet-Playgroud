// Create a Human class with four public fields: Name (string) , Strength (int), Intelligence (int), Dexterity (int)
public class Human 
{
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public int Health;

// Add a constructor method that takes a string to initialize Name - and that will initialize Strength, Intelligence, and Dexterity to a default value of 3, and health to default value of 100
    public Human(string s)
    {
        Name = s;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }
// Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
    public Human(string n, int s , int i, int d , int h)
    {
        Name = n;
        Strength = s;
        Intelligence = i;
        Dexterity = d;
        Health = h;
    }
// Now add a new method called Attack, which when invoked, should reduce the health of a Human object that is passed as a parameter. The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker). This method should return the remaining health of the target object.
    public int Attack(Human M)
    {
        int hitAmount = this.Strength * 5;
        M.Health = M.Health - hitAmount;
        Console.WriteLine($"{Name} Attacked {M.Name} for {hitAmount} dammage  ");
        return M.Health;

    }

    public int displayHealth(Human person)
    {
        Console.WriteLine(person.Health);
        return person.Health;
    }
}