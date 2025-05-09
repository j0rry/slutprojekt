class Player
{
    char  symbol = '@';
    public int X; 
    public int Y; 
    public int damage;
    public int hp; 

    public List<Item> inventory  = new();

    public Player(int startX, int startY, int damage = 10, int hp = 100)
    {
        this.damage = damage;
        this.hp = hp;
        X = startX;
        Y = startY;
    }

    public string WritePlayer(){
        return $"{symbol} ";
    }

    public void Input(){
        ConsoleKeyInfo key = Console.ReadKey(true);

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

    public void TakeDamage(int damage){
        hp -= damage;
    }
}
