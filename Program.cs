class Program
{
    static void Main()
    {
        Console.CursorVisible = false; // sätter cursor till ej synlig
        Utility.WriteLine("Hur stor spelplan?"); // skriver ut med utility 
        int size = Utility.TryParse(5, 20); // frågar hur stor planen ska vara 5-20
        Game game = new(size); // init spel
        game.Start(); // kör start metoden 
        game.Update(); // update metoden
        Console.CursorVisible = true; // gör muspekaren synlig efter spelet är slut
    }
}
