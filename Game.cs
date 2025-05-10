public class Game {
    
    Player player = new(0,0); // lägger till en spelare vid 0, 0
    List<Enemy> enemies; // Lista med alla fienden i spelet. Använder List för att kunna enkelt ta bort fienden om de dör!
    // lägga till pickups senare!
    
    int money = 6;
    
    // Storleken på spelplannen / grid
    int Rows;
    int Cols;

    public Game(int size){
        // sätter grid size
        Rows = size;
        Cols = size;

        // Lägger till 10 enemies med random koordinat i en lista 
        enemies = Enumerable.Range(0, 2).Select(i => new Enemy(Random.Shared.Next(size),Random.Shared.Next(size), i)).ToList();
    }

    public void Start(){ // Körs engång. det ska vara när spelet börjar
        Utility.RainbowText("Welcome"); // skriv welcome message
        Instructions(); // visa instruktioner
    }

    public void Update(){ // Game Loop
        while(!IsGameOver() && enemies.Count > 0){ // om det finns fortfarande motståndare då fortsätter speletsgång
            if(!IsFighting()){ // Om man inte slåss mot en motståndare 
                HandleGridScene(); // visa spelplannen / grid
            } else {
                HandleBattle(); // annars hantera fight mot motståndare
            }
        }
    }

    void HandleBattle(){
        Enemy? currentEnemy = GetCurrentEnemy(); // Få tag på motståndaren som spelaren står på

        if(currentEnemy != null && !IsGameOver()){ // Om spelaren inte är null och spelet är inte över då
            Battle battle = new(player, currentEnemy); // slåss mot enemy som spelaren står på (currentEnemy)
            if(currentEnemy.IsDead()){ // kollar om enemy som spelaren står på är död
                enemies.Remove(currentEnemy); // ta bort om död
            }
        }
    }

    void HandleGridScene(){
        // Skriver ut liv och pengar spelaren har. Med färg
        Utility.WriteColoredText($"Health: {player.hp}", ConsoleColor.Green, true);
        Utility.WriteColoredText($"Gold: {money}", ConsoleColor.Yellow, true);

        DrawGrid(Rows, Cols);  // Rita grid / spelplan
        player.Input(); // kör så att spelaren kan förflytta sig
        Console.Clear(); // refresh screen 
    }

    // Går igenom varje ruta i ett rutnät och ritar spelaren (grön), fiender (röd) och tomma rutor (.)
    void DrawGrid(int rows, int cols) {
        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < cols; x++) {
                if(player.X == x && player.Y == y)
                    Utility.WriteColoredText(player.WritePlayer(), ConsoleColor.Green, false);
                else if (CheckEnemyPos(x, y)){
                    Utility.WriteColoredText("E ", ConsoleColor.Red, false);
                }
                else Console.Write(". "); 
            }
            Console.WriteLine(); 
        }
    }

    bool IsGameOver(){ // kollar om spelaren lever
        if(player.hp <= 0) return true;
        else return false;
    }

    void Instructions(){
        // instruktioner
        Console.WriteLine("Använd WASD för att gå runt"); 
        Console.WriteLine("ställ dig på fienden för att börja slåss"); 

        // om väljaren väljer att inte fortsätta så stång av spelet
        if(!Utility.AskProceed())
            Environment.Exit(0);
    }
    bool IsFighting(){ // kollar om spelaren står på enemy isåfall sät det true att de slåss
        if(enemies.Any(enemy => enemy.X == player.X && enemy.Y == player.Y)) 
            return true;
        else return false;
    }

    bool CheckEnemyPos(int x, int y){ // en användbar metod för att kolla om enemy befinner sig på en viss koordinat pos
        return enemies.Any(enemy => enemy.X == x && enemy.Y == y);
    }

    Enemy? GetCurrentEnemy(){ // Får tag i den första enemy som spelaren står på.
        return enemies.FirstOrDefault(enemy => enemy.X == player.X && enemy.Y == player.Y);
    }
}

