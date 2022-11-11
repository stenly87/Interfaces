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
            var deads = creatures.Where(s => !s.IsAlive);
            foreach (var dead in deads)
            {
                Console.WriteLine($"{dead.Name} погиб/ла.");
                creatures.Remove(dead);
            }
            if (creatures.Count <= 1)
                break;
        }
        Console.WriteLine("Игра окончена");
        if (creatures.Count > 0)
            Console.WriteLine("Выжил только " + creatures.First().Name);
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
                    case 1: cre.Block(target); break;
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