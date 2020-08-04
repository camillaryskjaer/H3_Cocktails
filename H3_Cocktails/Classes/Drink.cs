using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Cocktails.Classes
{
    class Drink : Entity
    {
        public string Name { get; private set; }
        virtual public List<Item> Items { get; private set; }

        [NotMapped]
        public List<Item> AllAccessories { get { return Items.Where(x => x.ingridient is Accessory).ToList(); } }
        [NotMapped]
        public List<Item> AllLiqours { get { return Items.Where(x => x.ingridient is Liqour).ToList(); } }

        public Drink(string name, List<Item> items)
        {
            Name = name;
            Items = items;
        }
        public Drink()
        {
            //this.Items = new List<Item>();
        }
    }
}
