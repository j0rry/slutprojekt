
class Shop {

    List<Item> ShopListings = new(){
        new Item("Shield", "Shield that absorbs number of hits", 100),
        new Weapon("Axe", "Sharp axe, high damage but hard to hit", 50, 20),
        new Weapon("Sword", "Sharp sword cuts stone", 25, 10)
    };

    public Shop(List<Item> inventory){
        ShopListings.ForEach(item => item.Show()); 
        inventory.Add(ShopListings[Utility.TryParse(0, ShopListings.Count -1)]); 
    }
}
