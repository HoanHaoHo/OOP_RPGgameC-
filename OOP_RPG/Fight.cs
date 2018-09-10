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
        

        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Lizzard", 7, 10, 15);
            this.AddMonster("AcientTurtle", 10, 9, 19);
            this.AddMonster("Dragon", 12, 10, 25);
        }
        
        public void AddMonster(string name, int strength, int defense, int hp) {
            //var monster = new Monster();
            //monster.Name = name;
            //monster.Strength = strength;
            //monster.Defense = defense;
            //monster.OriginalHP = hp;
            //monster.CurrentHP = hp;
            //this.Monsters.Add(monster);
            var monster = new Monster(name, strength, defense, hp, hp);
            this.Monsters.Add(monster);
        }
        
        public void Start() {

            // var enemy = this.Monsters[0]; // first monster
            // var enemy = this.Monsters[1]; // second monster
            // var enemy = Monsters[Monsters.Count-1] // last monster;
            // var enemy = Monsters.Where(x=> x.CurrentHP <20).FirstOrDefault(); //Monsters with less than 20hp
            // var enemy = Monsters.Where(x=> x.Strength  >=1).FirstOrDefault(); // Monsters with a strength at least 11
            var rdMonster = this.Monsters[new Random().Next(this.Monsters.Count-1)]; // Choose random monster
            var enemy = rdMonster;
            Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" + 
            enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn(enemy);
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(Monster monster){
           var enemy = monster;
           var compare = hero.Strength - enemy.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               enemy.CurrentHP -= damage;
           }
           else{
               damage = compare;
               enemy.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(enemy.CurrentHP <= 0){
               this.Win(enemy);
           }
           else
           {
               this.MonsterTurn(enemy);
           }
           
        }
        
        public void MonsterTurn(Monster monster){
           var enemy = monster;
           int damage;
           var compare = enemy.Strength - hero.Defense;
           if(compare <= 0) {
               damage = 1;
               hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               hero.CurrentHP -= damage;
           }
           Console.WriteLine(enemy.Name + " does " + damage + " damage!");
           if(hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win(Monster monster) {
            var enemy = monster;
            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}