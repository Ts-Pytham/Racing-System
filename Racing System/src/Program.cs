namespace Racing_System;

public class Program
{
    public static void Main(string[] args)
    {
        new GameModeBuilder()
            .Use<GameMode>()
            .Run();
    }
}
