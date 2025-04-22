public class Game {
    
    Player player = new(0,0); // lägger till en spelare vid 0, 0
    List<Enemy> enemies; // Lista med alla fienden i spelet. Använder List för att kunna enkelt ta bort fienden om de dör!
    // lägga till pickups senare!
    
    int money = 0;

    int Rows;
    int Cols;

    public Game(int size){
       Rows = size;
       Cols = size;

       enemies = Enumerable.Range(0, 10).Select(i => new Enemy(Random.Shared.Next(size),Random.Shared.Next(size))).ToList();
    }

    public void Start(){
        Utility.WriteColor("Welcome to jorry's game");
        Instructions();

    }

    public void Update(){
        while(!isGameOver()){
            DrawGrid(Rows, Cols); 
            player.Input();
            Console.Clear();
        }

    }

    void DrawGrid(int rows, int cols) {
        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < cols; x++) {
                if(player.X == x && player.Y == y)
                    Console.Write(player.WritePlayer());
                else if (enemies.Any(enemy => enemy.X == x && enemy.Y == y)){
                    Console.Write("E ");
                }
                else Console.Write(". "); 
            }
            Console.WriteLine(); 
        }
    }

    bool isGameOver(){
        if(player.hp <= 0) return true;
        else return false;
    }

    void Instructions(){
        Console.WriteLine("Använd WASD för att gå runt"); 
        Console.WriteLine("ställ dig på fienden för att börja slåss"); 
        if(!Utility.AskProceed())
            Environment.Exit(0);
    }
}
