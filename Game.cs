public class Game {
    
    Player player = new(0,0);
    
    // Kom ihåg skapa en lista som senare ska hålla alla pickups på kartan samt förklara varför den används

    public void Start(){
        // visa spelar instruktioner
    }

    public void Update(){
       while(!isGameOver()){
           DrawGrid(5, 5); 
           Console.Clear();
       }

    }

    void DrawGrid(int rows, int cols) {
        for (int x = 0; x < rows; x++) {
            for (int y = 0; y < cols; y++) {
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
}
