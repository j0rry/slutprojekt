public class Game {
    
    Player player = new(0,0); // lägger till en spelare vid 0, 0

    // Kom ihåg skapa en lista som senare ska hålla alla pickups på kartan samt förklara varför den används
    int Rows;
    int Cols;

    public Game(int size){
       Rows = size;
       Cols = size;
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
        Console.ReadLine();
    }
}
