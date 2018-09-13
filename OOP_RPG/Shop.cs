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
        public Shop ()
        {
             this.Weapons = new List<Weapon>();
             this.Armors= new List<Armor>();
            this.Potions = new List<Potion>();

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
    }
}
