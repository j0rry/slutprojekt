class Player
{
    char symbol = '@';
    public int X { get; set; }
    public int Y { get; set; }
    int damage;
    public int hp;

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
}
