

class Enemy {
    char enemySymbol = 'E'; // vilken symbol enemy ska ha
    public int ID; // ID för att kunna kontrollera vilken som är vem. (Har inte behövt andvända denn)
    
    public int HP = 100; // liv

    public int Damage = 20;  // skada
    
    // Position
    public int X; 
    public int Y; 

    public Enemy(int x, int y, int id){
        // ger start position och id
        X = x;
        Y = y;
        ID = id;
    }

    public void GiveDamage(Player player){ // Funktion för att kalla om man ska skada spelare
        player.hp -= Damage;
    }

    public void TakeDamage(int damage){ // funktion för att skada enemy
        if(!IsDead()){ // Kollar så att motståndaren lever innan skadar den
            HP -= damage;
        }
    }

    public bool IsDead(){ // användbar metod som returnerar om motståndaren är vid liv
        return HP <= 0;
    }

    public string WriteEnemy(){ // formatet för utskrift på spelplanen/grid
        return $"{enemySymbol} ";
    }
}
