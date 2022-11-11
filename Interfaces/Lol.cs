using Interfaces;

internal class Lol : ICreature
{
    public int HP => 1;

    public string Name => "С#";

    public bool IsAlive => true;
    Random rnd = new Random();
    public void Attack(ICreature target)
    {
        int val = rnd.Next(0, 3);
        switch (val)
        {
            case 0: ChatHelper.SendMessage(this, $"делает больно {target.Name}"); break;
            case 1: ChatHelper.SendMessage(this, $"декомпилирует {target.Name}"); break;
            case 2: ChatHelper.SendMessage(this, $"причиняет больно иначе {target.Name}"); break;
        }
        target.DecreaseHP(100, this);
    }

    public void Block(ICreature target)
    {
        Attack(target);
    }

    public void DecreaseHP(int value, ICreature damager)
    {
        Attack(damager);
    }

    public bool HasBlockFrom(ICreature target)
    {
        Attack(target);
        return true;
    }

    public void RunAwayFrom(ICreature target)
    {
        Attack(target);
    }

    public void TryHealSelf()
    {
    }
}