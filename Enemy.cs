

class Enemy {
    char enemySymbol = 'E';
    public int ID;
    
    public int HP = 100;

    public int Damage = 20;  
    
    public int X;
    public int Y; 

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
