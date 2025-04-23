

class Enemy {
    char enemySymbol = 'E';
    public int ID;
    
    public int HP{get; set;} = 100;

    public int Damage { get; set; } = 20;  
    
    public int X {get; set;}
    public int Y {get; set;}

    public Enemy(int x, int y, int id){
        X = x;
        Y = y;
        ID = id;
    }

    public void GiveDamage(Player player){
        player.hp -= Damage;
    }

    public void TakeDamage(int damage){
        if(!IsDead()){
            HP -= damage;
        }
    }

    public bool IsDead(){
        return HP <= 0;
    }

    public string WriteEnemy(){
        return $"{enemySymbol} ";
    }
}
