

class Item {

    // item variabler
    public string Name;
    public string Description;
    public int Price;
    
    public Item(string name, string description, int price){
        // sätt items variabler
        Name = name;
        Description = description;
        Price = price;
    }

    public virtual void Use(){ // funktion för att använda items (inte klar)
        Console.WriteLine($"Du använder {Name}");
    }

    public virtual void Show(){ // funktion för att visa information om item.
        System.Console.WriteLine($"{Name}, {Description}, Price: {Price}");
    }
}
