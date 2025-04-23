class Player
{
    char  symbol = '@';
    public int X { get; set; }
    public int Y { get; set; }
    public int damage;
    public int hp {get; set;}

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
        }

    }

    public void TakeDamage(int damage){
        hp -= damage;
    }
}
