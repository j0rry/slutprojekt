
public static class Utility {
    
    public static void WriteLine(string text){
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]); 
            Thread.Sleep(60);
        }
        Console.WriteLine();
    } 

    public static void WriteColor(string text){
        
        ConsoleColor[] colors = new ConsoleColor[]{
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
        };
        

        for(int i = 0; i < text.Length; i++){
            Console.ForegroundColor = colors[i % colors.Length];
            Console.Write(text[i]);
        }

        Console.ResetColor();
        Console.WriteLine();
    }


    public static int TryParse(int min, int max)
    {
        int num;
        while (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
        {
            Console.WriteLine($"Skriv ett nummer mellan {min} och {max}!");
        }
        return num;
    }
}
