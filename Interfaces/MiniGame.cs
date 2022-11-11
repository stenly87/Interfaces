internal class MiniGame
{
    private List<ICreature> creatures = new List<ICreature>();
    private int turn;
    private bool running;
    private Random rnd = new Random();

    internal void AddCreature(ICreature cre)
    {
        creatures.Add(cre);
    }

    internal void StartFight()
    {
        turn = 0;
        running = true;
        while (running)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Раунд {++turn}!");
            RunActions();
        }
    }

    private void RunActions()
    {
        foreach (var cre in creatures)
        {
            if (!cre.IsAlive)
                continue;
            var target = creatures[rnd.Next(0, creatures.Count)];
            if (target == cre)
                cre.TryHealSelf();
            else
            {
                int variant = rnd.Next(0, 3);
                switch (variant)
                {
                    case 0: cre.Attack(target); break;
                    case 1: cre.Block(); break;
                    case 2: cre.RunAwayFrom(target); break;
                }
            }
        }
    }

    internal void StopFight()
    {
        running = false;
    }
}