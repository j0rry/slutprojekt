

class Item {

    public string Name;
    public string Description;
    public int Price;
    
    public Item(string name, string description, int price){
        Name = name;
        Description = description;
        Price = price;
    }

    public virtual void Use(){
        Console.WriteLine($"Du använder {Name}");
    }

    public virtual void Show(){
        System.Console.WriteLine($"{Name}, {Description}, Price: {Price}");
    }
}
