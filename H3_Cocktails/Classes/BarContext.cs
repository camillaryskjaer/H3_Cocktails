using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Cocktails.Classes
{
    class BarContext : DbContext
    {
        public BarContext() : base("BarDB-v02")
        {
            
            this.Configuration.LazyLoadingEnabled = true;
            //Console.WriteLine(Database.Connection.ConnectionString);
        }

        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Item> Items { get; set; }


        public void RemoveDrink(Drink drinkToRemove)
        {
            this.Drinks.Remove(drinkToRemove);
            this.SaveChanges();
        }
    }
}
