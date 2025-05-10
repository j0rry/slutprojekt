
class Shop {

    List<Item> ShopListings = new(){ // lista med items som ska visas i shop. 
        new Item("Shield", "Shield that absorbs number of hits", 100),
        new Weapon("Axe", "Sharp axe, high damage but hard to hit", 50, 20),
        new Weapon("Sword", "Sharp sword cuts stone", 25, 10)
    };

    // Visa shoppen och fråga om vad spelaren ska ha
    public Shop(List<Item> inventory){
        ShopListings.ForEach(item => item.Show()); 
        inventory.Add(ShopListings[Utility.TryParse(0, ShopListings.Count -1)]); 
    }
}
