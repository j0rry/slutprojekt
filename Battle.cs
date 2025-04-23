

class Battle {

    int width = 30;
    int position = 0;
    bool goingRight = true;
    int middle;
    bool attacking = true;
    int speed = 120; // hastighet / delay på visaren.
    
    public Battle(Player p, Enemy e){
        middle = width /2; // räkna ut vart mitten är
        Fight(p,e);
    }

    void Fight(Player player, Enemy enemy){
        while(player.hp > 0 && enemy.HP > 0){
            attacking = true; // sätter attacking på, gör så att man kan fortsätta att attakera om det finns hp kvar på motståndaren.
            position = 0; // sätter tillbaka visaren i början på timings banan
            goingRight = true; // riktning
            Console.Clear();
            while(attacking){
                Console.SetCursorPosition(0,0);
                Utility.WriteColoredText($"Health: {player.hp}", ConsoleColor.Green, true);
                Utility.WriteColoredText($"Enemy Health: {enemy.HP}", ConsoleColor.Red, true);
                Console.SetCursorPosition(0,4); // sätter cursor i början
                Console.Write(new string('-', width)); // skriver ut timing banan
                Console.SetCursorPosition(middle, 4); // går till mitten med cursor
                Utility.WriteColoredText("█", ConsoleColor.Green, false); // skriver ut mitten

                Console.SetCursorPosition(position, 4); // sätter cursor i början
                Console.Write("|"); // ritar visaren

                if(Console.KeyAvailable){
                    var key = Console.ReadKey(true).Key;
                    if(key == ConsoleKey.Spacebar){ // om man trycker ner space knappen
                        attacking = false; // sätter attacking false
                        Console.SetCursorPosition(0,5); // sätter cursor nedanför för att skriva ut resultat
                        if(position == middle || position == middle + 1 || position == middle -1){ // om positionen av visaren är i mitten 
                            enemy.TakeDamage(player.damage); // ta damage
                            Utility.WriteColoredText("🎯 hit!", ConsoleColor.Green, true); // skriver ut träff
                            speed -= 10; // Ändrar speed för varje hit, gör det snabbare
                            Thread.Sleep(120);
                        }
                        else {
                            Console.SetCursorPosition(0,5); //sätter cursor under
                            player.TakeDamage(enemy.Damage); // ta damage på spelaren med motståndarens damage
                            Utility.WriteColoredText($"Enemy skadade dig med {enemy.Damage} damage", ConsoleColor.Red, true); // skriv ut 
                            Thread.Sleep(120);
                        }
                        break; // avslutar attack loop
                    }
                }

                Thread.Sleep(speed); // lägger till delayn, här ändras speeden för visaren
                
                // Förflyttar visaren i rätt rikting. Kollar om den går höger eller inte
                if(goingRight) 
                    position++;
                else
                    position--;

                // ändrar riktning om den har nått till andra sidan.
                if (position >= width - 1)
                    goingRight = false;
                else if (position <= 0)
                    goingRight = true;
            }
            
            Console.SetCursorPosition(0, 4); // lägger cursor
        }        
    }

    void Instructions(){
        System.Console.WriteLine("Clicka space när | är i mitten för att attackera!");
    }



}
