using Interfaces;

internal class Cat : ICreature
{
    public int HP { get; private set; } = 20;

    public string Name => "Котэ";

    int lives = 9;
    Random rnd = new Random();
    public bool IsAlive => lives > 0;
    int maxDmg = 15;
    int minDmg = 5;

    public void Attack(ICreature target)
    {
        ChatHelper.SendMessage(this, $"шипит!");
        if (target.HasBlockFrom(this))
            return;

        ChatHelper.SendMessage(this, $"царапает {target.Name}!");
        int dmg = rnd.Next(minDmg, maxDmg);
        target.DecreaseHP(dmg);
    }
    ICreature blockFrom;
    public void Block(ICreature target)
    {
        blockFrom = target;
        ChatHelper.SendMessage(this, $"следит {target.Name}!");
    }

    public void DecreaseHP(int value)
    {
        HP -= value;
        ChatHelper.SendMessage(this, $"Кошке нанесен урон ");
        if (HP > 0 && lives > 0)
        {
            HP = 20;
            lives--;
            ChatHelper.SendMessage(this, $"Кошка воскресает! Осталось {lives} жизней");
        }
    }

    public bool HasBlockFrom(ICreature target)
    {
        throw new NotImplementedException();
    }

    public void RunAwayFrom(ICreature target)
    {
        throw new NotImplementedException();
    }

    public void TryHealSelf()
    {
        throw new NotImplementedException();
    }
}