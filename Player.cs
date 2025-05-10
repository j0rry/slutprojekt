class Player
{
    char  symbol = '@'; // Vad spelarens symbol ska vara och som skrivs ut på spelplannen

    // Position
    public int X; 
    public int Y; 

    // Skada och liv
    public int damage;
    public int hp; 

    public List<Item> inventory  = new(); // inventory som håller items. använder list för att enkelt kunna ta bort och sätta dit nya items

    public Player(int startX, int startY, int damage = 10, int hp = 100)
    {
        // spelarens start värden
        this.damage = damage;
        this.hp = hp;
        X = startX;
        Y = startY;
    }

    public string WritePlayer(){ // returnerar spelplans formatet för spelarens symbol
        return $"{symbol} ";
    }

    public void Input(){
        // läser efter ett knapp tryck
        ConsoleKeyInfo key = Console.ReadKey(true);

        // Kollar ifall det är WASD knapparna då förflytta
        // Samt knappar för att öppna shoppen som inte är rikgtig färdig med 
        // och skriver ut inventory 
        switch(key.Key){
            case ConsoleKey.W:
                Y--;
            break;
            case ConsoleKey.S:
                Y++;
            break;
            case ConsoleKey.D:
                X++;
            break;
            case ConsoleKey.A:
                X--;
            break;
            case ConsoleKey.P:
                Shop shop = new(inventory);
            break;
            case ConsoleKey.I:
                Console.SetCursorPosition(50, 4);
                Console.Write("Inventory:");
            break;
        }

    }

    public void TakeDamage(int damage){ // funktion att kalla om man ska skada spelaren
        hp -= damage;
    }
}
