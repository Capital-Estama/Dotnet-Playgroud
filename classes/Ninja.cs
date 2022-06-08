class Ninja : Human 
{
    public Ninja(string name , int strength, int intelligence, int health) : base(name,strength, intelligence, 175, health )
    {
        
    }

    public  override int Attack(Human target)
        {
        int damage = this.Dexterity * 5 ;
        // 20% damage boost!
        Random rnd = new Random();
        if (rnd.Next(0,100) < 21)
        {
            damage += 10;
        }
            //  Decrement 
            target.Health -=damage;
            return target.Health;
        }
    // incomplete 
    public void Steal(Human target) 
    {
        target.Health -= 5;
        this.Health += 5;

    }

    
}