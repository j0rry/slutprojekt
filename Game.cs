public class Game {
    
    Player player = new(0,0); // lägger till en spelare vid 0, 0
    List<Enemy> enemies; // Lista med alla fienden i spelet. Använder List för att kunna enkelt ta bort fienden om de dör!
    // lägga till pickups senare!
    
    int money = 0;

    int Rows;
    int Cols;

    public Game(int size){
        // sätter grid size
        Rows = size;
        Cols = size;

        // Lägger till 10 enemies med random koordinat i en lista 
        enemies = Enumerable.Range(0, 10).Select(i => new Enemy(Random.Shared.Next(size),Random.Shared.Next(size), i)).ToList();
    }

    public void Start(){ // Körs engång. det ska vara när spelet börjar
        Utility.WriteColor("Welcome");
        Instructions();
    }

    public void Update(){ // Game Loop
        while(!IsGameOver() && enemies.Count > 0){
            if(!IsFighting()){
                HandleGridScene();
            } else {
                HandleBattle();
            }
        }
    }

    void HandleBattle(){
        Enemy? currentEnemy = GetCurrentEnemy();

        if(currentEnemy != null && !IsGameOver()){
            Battle battle = new(player, currentEnemy);
            if(currentEnemy.IsDead()){
                enemies.Remove(currentEnemy);
                Update();
            }
        }
    }

    void HandleGridScene(){
        DrawGrid(Rows, Cols); 
        player.Input();
        Console.Clear();
    }

    void DrawGrid(int rows, int cols) {
        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < cols; x++) {
                if(player.X == x && player.Y == y)
                    Console.Write(player.WritePlayer());
                else if (CheckEnemyPos(x, y)){
                    Console.Write("E ");
                }
                else Console.Write(". "); 
            }
            Console.WriteLine(); 
        }
    }

    bool IsGameOver(){
        if(player.hp <= 0) return true;
        else return false;
    }

    void Instructions(){
        Console.WriteLine("Använd WASD för att gå runt"); 
        Console.WriteLine("ställ dig på fienden för att börja slåss"); 
        if(!Utility.AskProceed())
            Environment.Exit(0);
    }
    bool IsFighting(){
        if(enemies.Any(enemy => enemy.X == player.X && enemy.Y == player.Y)) 
            return true;
        else return false;
    }

    bool CheckEnemyPos(int x, int y){
        return enemies.Any(enemy => enemy.X == x && enemy.Y == y);
    }

    Enemy? GetCurrentEnemy(){
        return enemies.FirstOrDefault(enemy => enemy.X == player.X && enemy.Y == player.Y);
    }
}

