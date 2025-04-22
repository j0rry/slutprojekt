class Program
{
    static void Main()
    {

        Utility.WriteLine("Hur stor spelplan?");
        int size = Utility.TryParse(5, 20);
        Game game = new(size);
        game.Start();
        game.Update();
    }
}
