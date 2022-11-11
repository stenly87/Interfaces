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
        string message = null;
        switch (val)
        {
            case 0: message = $"делает больно {target.Name}"; break;
            case 1: message = $"декомпилирует {target.Name}"; break;
            case 2: message = $"причиняет больно иначе {target.Name}"; break;
        }
        ChatHelper.SendMessage(this, message);
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