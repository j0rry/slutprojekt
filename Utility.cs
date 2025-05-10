
public static class Utility {
    
    // egen writeline som ger en typing animation
    public static void WriteLine(string text){
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]); 
            Thread.Sleep(60);
        }
        Console.WriteLine();
    } 

    // Skriver text i en regnbåge
    public static void RainbowText(string text){
        
        // färger
        ConsoleColor[] colors = new ConsoleColor[]{
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
        };
        
        // loopa igenom och cyle colors samt skriv ut
        for(int i = 0; i < text.Length; i++){
            Console.ForegroundColor = colors[i % colors.Length];
            Console.Write(text[i]);
        }

        Console.ResetColor();
        Console.WriteLine();
    }


    // Funktion för att skriva text med enbar en färg. man kan välja om man vill ha writeline eller bara write
    public static void WriteColoredText(string text, ConsoleColor color, bool isWriteLine){
        Console.ForegroundColor = color;
        if(isWriteLine)
            Console.WriteLine(text);
        else
            Console.Write(text);
        Console.ResetColor(); 
    }


    // Användbar tryparse som använder sig av min och max. alltså man konverterar en string till int och det måste vara mellan min och max
    public static int TryParse(int min, int max)
    {
        int num;
        while (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
        {
            Console.WriteLine($"Skriv ett nummer mellan {min} och {max}!");
        }
        return num;
    }

    // Prooced cunktion som man kan ha användbarhet senare i projektet / frågar bara användaren om man vill fortsätta
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
