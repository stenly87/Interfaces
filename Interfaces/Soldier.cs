using Interfaces;

internal class Soldier : ICreature
{
    public bool IsAlive => HP > 0 ;

    public int HP { get; set; } = 100;

    public string Name { get; private set; } = "Солдат";

    int dmg = 10;
    Random random = new Random();

    public void Attack(ICreature target)
    {
        ChatHelper.SendMessage(this, $"Атакую {target.Name}!");
        if (target.HasBlockFrom(this))
        {
            ChatHelper.SendMessage(this, "Что? Это что защита? Я так не играю!");
        }
        else
        {
            int val = random.Next(0, dmg);
            ChatHelper.SendMessage(this, $"Ты не уйдешь от возмездия, мерзкая тварина! Вот тебе {val} урона!");
            target.DecreaseHP(val);
        }
    }

    public void Block(ICreature target)
    {
        ChatHelper.SendMessage(this, $"Я не умею защищаться!");
        Attack(target);
    }

    public void RunAwayFrom(ICreature target)
    {
        ChatHelper.SendMessage(this, $"Солдат не убегает!");
        Attack(target);
    }

    public void TryHealSelf()
    {
        Console.WriteLine("Я сплю");
    }

    public bool HasBlockFrom(ICreature target)
    {
        return false;
    }

    public void DecreaseHP(int value)
    {
        ChatHelper.SendMessage(this, $"Терплю урон: {value}");
        HP -= value;
    }
}