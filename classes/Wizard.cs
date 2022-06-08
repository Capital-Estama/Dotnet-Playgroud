class Wizard : Human
{
    public Wizard(string name, int strength, int intelligence,int dexterity) : base(name, strength, 25, dexterity,50)
    {

    }

    public override int Attack(Human target)
    {
        int damage = Intelligence * 5;
        target.Health -= damage;
        this.Health += damage;
        return target.Health;
    }
    
    public void Heal(Human target)
    {
        target.Health += Intelligence * 10;
    }

    
}