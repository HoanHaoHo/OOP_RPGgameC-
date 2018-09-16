using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }
        public Monster monster { get; set; }

        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;
           
            this.AddMonster("Squid", 9, 8, 20,15,15);
            this.AddMonster("Lizzard", 7, 10, 15,20,13);
            this.AddMonster("AcientTurtle", 10, 9, 19,25,8);
            this.AddMonster("Dragon", 12, 10, 25,30,13);
            // this.monster = Monsters.Where(x => x.Strength >= 11).FirstOrDefault();  // Monsters with a strength at least 11
            // this.monster = this.Monsters[0]; // first monster
            // this.monster = this.Monsters[1]; // second monster
            // this.monster = Monsters[Monsters.Count - 1]; // last monster;
            // this.monster = Monsters.Where(x=> x.CurrentHP <20).FirstOrDefault(); //Monsters with less than 20hp

             this.monster = this.Monsters[new Random().Next(this.Monsters.Count)]; // Choose random monster
           
        }

        public void AddMonster(string name, int strength, int defense, int hp, int gold, int speed) {
            //var monster = new Monster();
            //monster.Name = name;
            //monster.Strength = strength;
            //monster.Defense = defense;
            //monster.OriginalHP = hp;
            //monster.CurrentHP = hp;
            //monster.Gold = gold
            //this.Monsters.Add(monster);
            var monster = new Monster(name, strength, defense, hp, gold,speed);
            this.Monsters.Add(monster);
        }
        
        public void Start() {


            
            Console.WriteLine("You've encountered a " + monster.Name + "! " + monster.Strength + " Strength/" + monster.Defense + " Defense/" + 
            monster.CurrentHP + " HP/" + monster.Gold + "Gold . What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                if(hero.CurrentHP == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"You can't fight monster without HP {hero.CurrentHP}/{hero.OriginalHP}. You should go to shop and buy some Potion");
                    Console.WriteLine("1. If you want to reset game , press 1");
                    Console.WriteLine("2. If you want to continute , press 2");
                    var input2 = Console.ReadLine();
                   
                    if(input2 == "1")
                    {
                        var game = new Game();
                        game.Main();
                    }else if(input2 == "2")
                    {
                        this.HeroTurn();
                    }
                }
                else
                {
                    this.HeroTurn();
                }
                
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(){
           //var enemy = monster;
           var compare = hero.Strength - monster.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               monster.CurrentHP -= damage;
           }
           else{
               damage = compare;
               monster.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(monster.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){
           //var enemy = monster;
           int damage;
           var compare = monster.Strength - hero.Defense;
           if(compare <= 0) {
               damage = 1;
               hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               hero.CurrentHP -= damage;
           }
           Console.WriteLine(monster.Name + " does " + damage + " damage!");
            
           if(hero.CurrentHP <=0){
               if(hero.Speed > monster.Speed)
                {
                    Console.WriteLine("");
                    Console.WriteLine("you was save by God , hurry up ! use some potion to regen your HP");
                    game.Main();
                    
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You can't escape from the monster , you get killed by monster");
                    this.Lose();
                }
               
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {
            //var enemy = monster;
            Console.WriteLine(monster.Name + " has been defeated! You win the battle! You got: " + monster.Gold +"Gold . Check it in your inventory");
            hero.Gold += monster.Gold;
           
            game.Main();
            
        }
        
        public void Lose() {
            
            Console.WriteLine("");
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine($"What would you like to do?");
            Console.WriteLine($"1. Start a new game");
            
            var input = Console.ReadLine();
            if(input == "1")
            {
                var game = new Game();
                game.Main();
            }


        }

    }
    
}