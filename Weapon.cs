

class Weapon : Item {
    
    int Damage; // item damage
    
    public Weapon(string name, string description, int price, int damage) : base(name, description, price){
        // sätt item damage
       Damage = damage; 
    }

    public override void Use(){ // override item use med weapon use så att den slår (inte klar)
        System.Console.WriteLine($"du slår med damage: {Damage}");
    }

    public override void Show(){ // visa item information
        System.Console.WriteLine($"{Name}, {Description}, Price: {Price}, Damage: {Damage}");
    }
}
