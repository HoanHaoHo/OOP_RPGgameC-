using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Potion
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public Potion ( string name , int hp)
        {
            this.Name = name;
            this.HP = hp;
        }
    }
}
