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
        blockFrom = null;
        ChatHelper.SendMessage(this, $"шипит!");
        if (target.HasBlockFrom(this))
            return;

        ChatHelper.SendMessage(this, $"царапает {target.Name}!");
        int dmg = rnd.Next(minDmg, maxDmg);
        target.DecreaseHP(dmg, this);
    }
    ICreature blockFrom;
    public void Block(ICreature target)
    {
        blockFrom = target;
        ChatHelper.SendMessage(this, $"следит за {target.Name}!");
    }

    public void DecreaseHP(int value, ICreature damager)
    {
        if (rnd.Next(0, 10) < 2)
            Attack(damager);
        HP -= value;
        ChatHelper.SendMessage(this, $"Кошке нанесен урон. Осталось {HP} здоровья");
        if (HP < 0 && lives > 0)
        {
            HP = 20;
            lives--;
            ChatHelper.SendMessage(this, $"Кошка воскресает! Осталось {lives} жизней");
        }
    }

    public bool HasBlockFrom(ICreature target)
    {
        return blockFrom == target;
    }

    public void RunAwayFrom(ICreature target)
    {
        ChatHelper.SendMessage(this, $"Кошка запрыгивает на шкаф, спасаясь от {target.Name}");
    }

    public void TryHealSelf()
    {
        ChatHelper.SendMessage(this, "Кошка зализывает свои раны");
        HP = 20;
    }
}