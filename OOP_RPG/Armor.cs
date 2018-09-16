using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Armor : IItem
    {
        public string Name { get; set; }
        public int Defense { get; set; }
        public int OriginalValue { get; set;  }
        public int ResellValue { get; set; }
        public Armor(string name, int defense, int originalValue , int resellValue) {
            this.Name = name;
            this.Defense = defense;
            this.OriginalValue = originalValue;
            this.ResellValue = resellValue;
        }

        internal static IEnumerable<object> OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}