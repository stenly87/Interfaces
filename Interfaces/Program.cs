public class Program
{
    public static void Main()
    {
        MiniGame game = new MiniGame();
         
        game.AddCreature(new Soldier());
        game.AddCreature(new Cat());
        game.AddCreature(new Pig());
        game.AddCreature(new Lol());
        game.StartFight();
        Console.ReadLine();
        game.StopFight();
    }
}