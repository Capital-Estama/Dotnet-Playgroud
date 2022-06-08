class Samurai : Human
{
    Samurai(string name, int strength, int intelligence,int dexterity) : base(name, strength, intelligence , dexterity, 200)
    {

    }

    public override int Attack(Human target)
    {
        if (target.Health < 50)
        {
            //Death
            target.Health = 0;
        } 
        else
        {
            target.Health -= Dexterity / 5;
        }
        return target.Health;
    }

    public void Meditate()
    {
        Health = 200;
    }
}