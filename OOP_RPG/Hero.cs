using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero() {
            
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionsBag = new List<Potion>();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 0;
            this.Speed = 12;
            MakeYouStrong = new Dictionary<string, object>();
            
        }
        
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        
        public Dictionary<string, object> MakeYouStrong { get; set; }
        public int Gold { get; set; }
        public int Speed { get; set; }

        public List<Armor> ArmorsBag { get; set;}
        public List <Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionsBag { get; set; }

        
        public Shop Shop { get; set; }


        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("*****" + this.Name + "Stats *****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine($"Speed : {Speed}");
        }
        
        public void ShowInventory() {
            Console.WriteLine("*****  INVENTORY ******");

            Console.WriteLine("Weapons: ");
            foreach(var w in this.WeaponsBag){
                Console.WriteLine(w.Name + " of " + w.Strength + " Strength");
            }

            Console.WriteLine("Armor: ");
            foreach(var a in this.ArmorsBag){
                Console.WriteLine(a.Name + " of " + a.Defense + " Defense");
            }

            Console.WriteLine("Potions: ");
            foreach(var p in this.PotionsBag)
            {
                Console.WriteLine(p.Name + "of" + p.HP + "HP");
            }

            Console.WriteLine("Gold:" +this.Gold );

            Console.WriteLine("");
            Console.WriteLine("**Equipped**");
            if (EquippedArmor != null)
            {
                Console.WriteLine($"Armor: {EquippedArmor.Name}");
            }
            else
            {
                Console.WriteLine($"Armor:");
            }

            if (EquippedWeapon != null)
            {
                Console.WriteLine($"Weapon: {EquippedWeapon.Name}");
            }
            else
            {
                Console.WriteLine($"Weapon:");
            }

            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Equip Weapon");
            Console.WriteLine("2. Equip Armor");
            Console.WriteLine("3. Use a potion to regen your HP");
            Console.WriteLine("4. Return to main menu");
            var input = Console.ReadLine();
            if(input == "1")
            {
                EquipWeapon();
                
                ShowStats();
            }
            else if (input == "2")
            {
                EquipArmor();
                ShowStats();
            }
            else if (input == "3")
            {
                UsePotion();
                ShowStats();
            }
            else
            {
                return;
            }

        }

        public void EquipWeapon() {
            if(EquippedWeapon != null) {
                Console.WriteLine("You're already equip a weapon");
                Console.ReadKey();
                ShowInventory();
            }
            MakeYouStrong.Clear();
            Console.WriteLine("");
            Console.WriteLine("*****Weapons*****");
            var countWeapon = 1;
            foreach (var w in this.WeaponsBag)
            {
                Console.WriteLine($"{countWeapon}: {w.Name} with {w.Strength} strength");
                MakeYouStrong.Add($"{countWeapon}", w);
                countWeapon++;
                Console.WriteLine("Do you like to equip this weapon ? Press 1. to equip");
            }

            if (MakeYouStrong.Count == 0)
            {
                Console.WriteLine("You don't any weapons to equip");
            }
            else
            {
                var selection = Console.ReadLine();
                var weapon = (Weapon)MakeYouStrong[selection];
                WeaponsBag.Remove(weapon);
                EquippedWeapon = weapon;
                Strength += weapon.Strength;
                Console.WriteLine("");
                Console.WriteLine("You are successful to equip this weapon");
            }
        }
        
        public void EquipArmor() {
            if (EquippedArmor != null)
            {
                Console.WriteLine("You don't have any armor");
                Console.ReadKey();
                ShowInventory();
            }
            MakeYouStrong.Clear();
            Console.WriteLine("");
            Console.WriteLine("*****Armor*****");
            
            var countArmor = 1;
            foreach (var a in this.ArmorsBag)
            {
                Console.WriteLine($"{countArmor}: {a.Name} with {a.Defense} strength");
                MakeYouStrong.Add($"{countArmor}", a);
                countArmor++;
                Console.WriteLine("Do you like to equip this armor ? Press 1. to equip");
            }

            if (MakeYouStrong.Count == 0)
            {
                Console.WriteLine("You don't have any armor to equip");
                ShowInventory();
            }
            else
            {
                var selection = Console.ReadLine();
                var armor = (Armor)MakeYouStrong[selection];
                ArmorsBag.Remove(armor);
                EquippedArmor = armor;
                Defense += armor.Defense;
                Console.WriteLine("");
                Console.WriteLine("You are successful to equip this armor");

            }
        }

        public void UsePotion()
        {
            MakeYouStrong.Clear();
            Console.WriteLine("");
            Console.WriteLine("*****Potions*****");
            var countPotion = 1;
            foreach (var p in this.PotionsBag)
            {
                Console.WriteLine($"{countPotion}: {p.Name} that will give you {p.HP} HP");
                MakeYouStrong.Add($"{countPotion}", p);
                countPotion++;
                Console.WriteLine("Do you like to use Potion ? Press 1. to use");
            }

            if (MakeYouStrong.Count == 0)
            {
                Console.WriteLine("You have no potions to drink");
                ShowInventory();
            }
            else
            {
                var selection = Console.ReadLine();
                var potion = (Potion)MakeYouStrong[selection];
                PotionsBag.Remove(potion);
                CurrentHP += potion.HP;
                Console.WriteLine("");
                Console.WriteLine("You are successful to use Potion your HP regen some");
            }

        }


    }
}