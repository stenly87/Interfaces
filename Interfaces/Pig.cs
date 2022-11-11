using Interfaces;

internal class Pig : ICreature
{
    public bool IsAlive => HP > 0;

    public int HP { get; set; } = 500;

    public string Name { get; private set; } = "Свин";

    ICreature blockFrom;

    public void Attack(ICreature target)
    {
        ChatHelper.SendMessage(this, $"Хрю, {target.Name}!");
        target.DecreaseHP(1);
    }

    public void Block(ICreature target)
    {
        blockFrom = target;
        ChatHelper.SendMessage(this, $"Свин повернулся к {target.Name} самой защищенной частью!");
    }

    public void DecreaseHP(int value)
    {
        HP -= value / 2;
        ChatHelper.SendMessage(this, $"Толстокожая свинья уменьшает урон наполовину! Текущее ХП: {HP}");
    }

    public bool HasBlockFrom(ICreature target)
    {
        return blockFrom == target;
    }

    public void RunAwayFrom(ICreature target)
    {
        ChatHelper.SendMessage(this, $"Свинья убегает от {target.Name}!");
    }

    public void TryHealSelf()
    {
        ChatHelper.SendMessage(this, "Хрю");
    }
}