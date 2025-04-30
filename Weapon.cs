

class Weapon : Item {
    
    int Damage;
    
    public Weapon(string name, string description, int price, int damage) : base(name, description, price){
       Damage = damage; 
    }

    public override void Use(){
        System.Console.WriteLine($"du slår med damage: {Damage}");
    }

    public override void Show(){
        System.Console.WriteLine($"{Name}, {Description}, Price: {Price}, Damage: {Damage}");
    }
}
