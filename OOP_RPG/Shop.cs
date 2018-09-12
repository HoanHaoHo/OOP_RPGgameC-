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
            
        }
    }
}
