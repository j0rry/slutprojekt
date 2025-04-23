
public static class Utility {
    
    public static void WriteLine(string text){
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]); 
            Thread.Sleep(60);
        }
        Console.WriteLine();
    } 

    public static void RainbowText(string text){
        
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


    public static void WriteColoredText(string text, ConsoleColor color, bool isWriteLine){
        Console.ForegroundColor = color;
        if(isWriteLine)
            Console.WriteLine(text);
        else
            Console.Write(text);
        Console.ResetColor(); 
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

    public static bool AskProceed(){
        Console.WriteLine("Vill du fortsätta?");
        string answer = Console.ReadLine() ?? string.Empty;
        switch (answer.ToLower())
        {
            case "true":
                return true;
            case "false":
                return false;
            default:
                Console.WriteLine("Fel svar ange 'true' eller 'false'");
                return AskProceed(); 
        }
    }

}
