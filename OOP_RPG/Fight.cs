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
           
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Lizzard", 7, 10, 15);
            this.AddMonster("AcientTurtle", 10, 9, 19);
            this.AddMonster("Dragon", 12, 10, 25);
            // this.monster = Monsters.Where(x => x.Strength >= 11).FirstOrDefault();  // Monsters with a strength at least 11
            // this.monster = this.Monsters[0]; // first monster
            // this.monster = this.Monsters[1]; // second monster
            // this.monster = Monsters[Monsters.Count - 1]; // last monster;
            // this.monster = Monsters.Where(x=> x.CurrentHP <20).FirstOrDefault(); //Monsters with less than 20hp

             this.monster = this.Monsters[new Random().Next(this.Monsters.Count-1)]; // Choose random monster
           
        }

        public void AddMonster(string name, int strength, int defense, int hp) {
            //var monster = new Monster();
            //monster.Name = name;
            //monster.Strength = strength;
            //monster.Defense = defense;
            //monster.OriginalHP = hp;
            //monster.CurrentHP = hp;
            //this.Monsters.Add(monster);
            var monster = new Monster(name, strength, defense, hp);
            this.Monsters.Add(monster);
        }
        
        public void Start() {


            
            Console.WriteLine("You've encountered a " + monster.Name + "! " + monster.Strength + " Strength/" + monster.Defense + " Defense/" + 
            monster.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn();
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
           if(hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {
            //var enemy = monster;
            Console.WriteLine(monster.Name + " has been defeated! You win the battle!");
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}