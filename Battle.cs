

class Battle {

    const int Width = 30;
    const int InitialSpeed = 120;
    const int TimingRow = 4;
    const int CenterHitRange = 1;

    int speed; // hastighet / delay på visaren.
    int position = 0;
    bool goingRight = true;
    int middle;
    bool attacking = true;
    
    public Battle(Player p, Enemy e){
        middle = Width / 2;
        speed = InitialSpeed;
        Instructions();
        Fight(p, e);
    }

    void Fight(Player player, Enemy enemy){
        while(player.hp > 0 && enemy.HP > 0){
            PrepareAttack();
            Console.Clear();
            while(attacking){
                DrawFightScene(player, enemy);
                if(Console.KeyAvailable){
                    HandleInput(player, enemy);
                    break;
                }

                Thread.Sleep(speed); // lägger till delayn, här ändras speeden för visaren
                MoveMarker();
                
            }
        }        
    }

    void PrepareAttack(){
        attacking = true; // sätter attacking på, gör så att man kan fortsätta att attakera om det finns hp kvar på motståndaren.
        position = 0; // sätter tillbaka visaren i början på timings banan
        goingRight = true; // riktning
    }

    void DrawFightScene(Player player, Enemy enemy){
        Console.SetCursorPosition(0,0);
        Utility.WriteColoredText($"Health: {player.hp}", ConsoleColor.Green, true);
        Utility.WriteColoredText($"Enemy Health: {enemy.HP}", ConsoleColor.Red, true);
        Console.SetCursorPosition(0,TimingRow); // sätter cursor i början
        Console.Write(new string('-', Width)); // skriver ut timing banan
        Console.SetCursorPosition(middle, TimingRow); // går till mitten med cursor
        Utility.WriteColoredText("█", ConsoleColor.Green, false); // skriver ut mitten

        Console.SetCursorPosition(position, TimingRow); // sätter cursor i början
        Console.Write("|"); // ritar visaren
    }

    void HandleInput(Player player, Enemy enemy){
        var key = Console.ReadKey(true).Key;
        if(key == ConsoleKey.Spacebar){ // om man trycker ner space knappen
            attacking = false; // sätter attacking false
            Console.SetCursorPosition(0,5); // sätter cursor nedanför för att skriva ut resultat
            if(Math.Abs(position - middle) <= CenterHitRange){ // om positionen av visaren är i mitten 
                enemy.TakeDamage(player.damage); // ta damage
                Utility.WriteColoredText("🎯 hit!", ConsoleColor.Green, true); // skriver ut träff
                speed = Math.Max(20, speed - 10); // gör visaren snabbare men stoppar från att bli för snabbt
            }
            else {
                Console.SetCursorPosition(0,5); //sätter cursor under
                player.TakeDamage(enemy.Damage); // ta damage på spelaren med motståndarens damage
                Utility.WriteColoredText($"Enemy skadade dig med {enemy.Damage} damage", ConsoleColor.Red, true); // skriv ut 
            }
            Thread.Sleep(120);
        }
    }

    void MoveMarker(){
        position += goingRight ? 1 : -1;
        if (position >= Width - 1 || position <= 0)
            goingRight = !goingRight;
    }

    void Instructions(){
        System.Console.WriteLine("Klicka space när | är i mitten för att attackera!");
        System.Console.WriteLine("Klicka valfri knapp för att starta fighten!");
        Console.ReadKey();
    }
}
