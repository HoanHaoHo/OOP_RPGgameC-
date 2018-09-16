using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Potion> Potions { get; set; }
        public Game game { get; set; }
        public Hero Hero { get; set; }
        public Dictionary< string, object> NameItemList { get; set; }
        public Dictionary< string, object> HeroBox { get; set; }
        
        public Shop (Game game , Hero Hero)
        {
            this.game = game;
            this.Hero = Hero;
             this.Weapons = new List<Weapon>();
             this.Armors= new List<Armor>();
            this.Potions = new List<Potion>();
            this.NameItemList = new Dictionary<string, object>();
            this.HeroBox = new Dictionary<string, object>();
            

            this.AddWeapon("Sword", 3, 10, 2);
            this.AddWeapon("Axe", 4, 12, 3);
            this.AddWeapon("Longsword", 7, 20, 5);

            this.AddArmor("Wooden Armor", 3, 10, 2);
            this.AddArmor("Metal Armor", 7, 20, 5);

            this.AddPotion("Healing Potion", 5, 5, 2);

        }

        public void AddWeapon(string name, int strength, int originalValue, int resellValue)
        {

            var weapon = new Weapon(name, strength, originalValue, resellValue);
            this.Weapons.Add(weapon);
        }

        public void AddArmor(string name, int defense, int originalValue, int resellValue)
        {

            var armor = new Armor(name, defense, originalValue, resellValue);
            this.Armors.Add(armor);
        }

        public void AddPotion(string name, int hp, int originalValue, int resellValue)
        {

            var potion = new Potion(name, hp, originalValue, resellValue);
            this.Potions.Add(potion);
        }
        public void Menu()
        {
            
            Console.WriteLine("Welcome to 'The Shop'! What would you like to buy or sell anything?");
            Console.WriteLine("1. Buy some cool stuff");
            Console.WriteLine("2. Sell your things");
            Console.WriteLine("3. Return to main menu");

            Console.Write("Enter your selection:");
            var input = Console.ReadLine();

            if(input == "1")
            {
                ShowInventory();
                
            }
            else if (input == "2")
            {
                SellItem();
            }
            else
            {
                this.game.Main();
            }
        }
        public void ShowInventory()
        {
            NameItemList.Clear();
            Console.WriteLine("");
            Console.WriteLine("Here's all the stuff I have for sale.");

            Console.WriteLine("");
            Console.WriteLine("Weapons List");
            var countWeapon = 1;
            foreach (var W in this.Weapons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"W{countWeapon}: {W.Name} have {W.Strength} Strength sell for {W.OriginalValue} gold");
                NameItemList.Add($"W{countWeapon}", W);
                countWeapon++;
            }

            Console.WriteLine("");
            Console.WriteLine("Armors List");
            var countArmor = 1;
            foreach (var A in this.Armors.OrderBy(x => x.Name))
            {
                Console.WriteLine($"A{countArmor}: {A.Name} have {A.Defense} Defense sell for {A.OriginalValue} gold");
                NameItemList.Add($"A{countArmor}", A);
                countArmor++;
            }

            Console.WriteLine("");
            Console.WriteLine("Potions List");
            var countPotion = 1;
            foreach (var P in Potions.OrderBy(x => x.Name))
            {
                Console.WriteLine($"P{countPotion}: {P.Name} contain {P.HP} hp for {P.OriginalValue} gold");
                NameItemList.Add($"P{countPotion}", P);
                countPotion++;
            }
            Console.WriteLine("");
            BuyItem();

        }
        public void BuyItem()
        {
            
            var selection = "";
            
                Console.WriteLine("Enter the keyword of item you want to buy");
                selection = Console.ReadLine();
            
            if (NameItemList.ContainsKey(selection))
            {
                Pay(selection);

            }
            else if(!NameItemList.ContainsKey(selection))
            {
                Console.WriteLine("Your keyword item or number is wrong !!!");
                Menu();
            }
        }
        public void Pay(string selection)
        {
            if(selection.Substring(0,1) == "W")
            {
                
                var weapon = (Weapon)NameItemList[selection];
                if (Hero.Gold >= weapon.OriginalValue)
                {
                    Hero.Gold -= weapon.OriginalValue;
                    Weapons.Remove(weapon);
                    Hero.WeaponsBag.Add(weapon);
                    Console.WriteLine($"You spent {weapon.OriginalValue} gold for a {weapon.Name}");
                    Menu();
                }
                else
                {
                    Console.WriteLine($"NO gold , No sell");
                    Menu();
                }
            }
            else if (selection.Substring(0, 1) == "A")
            {
                var armor = (Armor)NameItemList[selection];
                if(Hero.Gold >= armor.OriginalValue)
                {
                    Hero.Gold -= armor.OriginalValue;
                    Armors.Remove(armor);
                    Hero.ArmorsBag.Add(armor);
                    Console.WriteLine($"You spent {armor.OriginalValue} gold for a {armor.Name}");
                    Menu();
                }
                else
                {
                    
                    Console.WriteLine($"NO gold , No sell");
                    Menu();
                }
            }
            else if (selection.Substring(0, 1) == "P")
            {
                var potion = (Potion)NameItemList[selection];
                if (Hero.Gold >= potion.OriginalValue)
                {
                    Hero.Gold -= potion.OriginalValue;
                    Potions.Remove(potion);
                    Hero.PotionsBag.Add(potion);
                    Console.WriteLine($"You spent {potion.OriginalValue} gold for a {potion.Name}");
                    Menu();
                }
                else
                {
                    Console.WriteLine($"NO gold , No sell");
                    Menu();
                }
            }
        }
        public void SellItem()
        {
            HeroBox.Clear();
            Console.WriteLine("");
            Console.WriteLine("Please make sure you have some item to sell");

            HeroBag();

            var input = "";
            Console.Write("Enter the code of the item you would like to sell.");

            input = Console.ReadLine();
            if (HeroBox.ContainsKey(input))
            {
                if (input.Substring(0, 1) == "A")
                {
                    var armor = (Armor)HeroBox[input];

                    Hero.Gold += armor.ResellValue;
                    Hero.ArmorsBag.Remove(armor);
                    this.Armors.Add(armor);
                    Console.WriteLine($"You get {armor.ResellValue} gold from {armor.Name}");
                    Menu();
                }
                else if (input.Substring(0, 1) == "W")
                {
                    var weapon = (Weapon)HeroBox[input];

                    Hero.Gold += weapon.ResellValue;
                    Hero.WeaponsBag.Remove(weapon);
                    this.Weapons.Add(weapon);
                    Console.WriteLine($"You get {weapon.ResellValue} gold from {weapon.Name}");
                    Menu();
                }
                else if (input.Substring(0, 1) == "P")
                {
                    var potion = (Potion)HeroBox[input];

                    Hero.Gold += potion.ResellValue;
                    Hero.PotionsBag.Remove(potion);
                    this.Potions.Add(potion);
                    Console.WriteLine($"You get {potion.ResellValue} gold from {potion.Name}");
                    Menu();
                }
            }
            else if (!NameItemList.ContainsKey(input))
            {
                Console.WriteLine("You don't have that items or item number is wrong");
                Menu();
            }
            


        }
       
        public void HeroBag()
        {
            Console.WriteLine("");
            Console.WriteLine("Weapons:");
            var countWeapon = 1;
            foreach (var weapon in Hero.WeaponsBag.OrderBy(W => W.OriginalValue))
            {
                Console.WriteLine($"W{countWeapon}. {weapon.Name} - Original Value: {weapon.OriginalValue}, Resell Value: {weapon.ResellValue}");
                HeroBox.Add($"W{countWeapon}", weapon);
                countWeapon++;
            }

            Console.WriteLine("");
            Console.WriteLine("Armors:");
            var countArmor = 1;
            foreach (var armor in Hero.ArmorsBag.OrderBy(A => A.OriginalValue))
            {
                Console.WriteLine($"A{countWeapon}. {armor.Name} - Original Value: {armor.OriginalValue}, Resell Value: {armor.ResellValue}");
                HeroBox.Add($"A{countArmor}", armor);
                countArmor++;
            }

            Console.WriteLine("");
            Console.WriteLine("Potions:");
            var countPotion = 1;
            foreach (var potion in Hero.PotionsBag.OrderBy(P => P.OriginalValue))
            {
                Console.WriteLine($"P{countPotion}. {potion.Name} - Original Value: {potion.OriginalValue}, Resell Value: {potion.ResellValue}");
                HeroBox.Add($"P{countArmor}", potion);
                countPotion++;
            }
        }




    }
}
