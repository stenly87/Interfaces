internal interface ICreature
{
    int HP { get; }
    string Name { get; }
    bool IsAlive { get; }

    void TryHealSelf();
    void Attack(ICreature target);
    void Block(ICreature target);
    void RunAwayFrom(ICreature target);
    bool HasBlockFrom(ICreature target);
    void DecreaseHP(int value);
}