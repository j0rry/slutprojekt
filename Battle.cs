
class Battle {
    
    public Battle(Player p, Enemy e){
        Fight(p,e);
    }

    void Fight(Player player, Enemy enemy){
        while(player.hp > 0 && enemy.HP > 0){
            Instructions();
            Console.ReadKey(true);
            enemy.TakeDamage(100);
            System.Console.WriteLine($"Du skadade enemy med {player.damage}");
        }        
    }

    void Instructions(){
        System.Console.WriteLine("Clicka space för att attackera enemy");
    }
}
