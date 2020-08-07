using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3_Cocktails.Classes;
using System.Data.Entity;

namespace H3_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {

            //Liquors 
            Liqour limeJuice = new Liqour("LIME JUICE", Color.Green);
            Liqour tripleSec = new Liqour("TRIPLE SEC", Color.White);
            Liqour tequila = new Liqour("TEQUILA", Color.Yellow);
            Liqour darkRum = new Liqour("DARK RUM", Color.Orange);
            Liqour orangeCuracao = new Liqour("ORANGE CURACAO", Color.Orange);
            Liqour almondSyrup = new Liqour("ALMOND SYRUP", Color.Green);

            //Accessories
            Accessory saltRim = new Accessory("salt rim");
            Accessory crushedIce = new Accessory("crushed ice");
            Accessory limeSegment = new Accessory("lime segment");
            Accessory limeSection = new Accessory("lime section");
            Accessory marachinoCherry = new Accessory("marachino cherry");


            //Drinks
            Drink margarita = new Drink("MARGARITA", new List<Item>()
            {
                new Item(60, Measurement.ml, limeJuice),
                new Item(30, Measurement.ml, tripleSec),
                new Item(60, Measurement.ml, tequila),
                new Item(saltRim),
                new Item(crushedIce),
                new Item(limeSegment),
            });
            Drink maiTai = new Drink("MAI TAI", new List<Item>()
            {
                new Item(50, Measurement.ml, darkRum),
                new Item(15, Measurement.ml, orangeCuracao),
                new Item(10, Measurement.ml, limeJuice),
                new Item(60, Measurement.ml, almondSyrup),
                new Item(limeSection),
                new Item(marachinoCherry),
                new Item(limeSegment),
            });

            List<Drink> availableDrinks = new List<Drink>()
            {
                margarita,
                maiTai
            };

            
            //Bør DB ligge her? I såfald bryder du med 3-lags modellen!!!! Du har også GUI placeret i denne klasse - det er no-go
            //Her kunne du godt have lavet en controller og ladet dit program.cs være GUI!
            using (var db = new BarContext())
            {

                db.Configuration.LazyLoadingEnabled = true;

                foreach (Drink drinkToAdd in availableDrinks)
                {
                    db.Drinks.Add(drinkToAdd);
                }
                db.SaveChanges();


                var query = db.Drinks.Include(x => x.Items.Select(xx => xx.ingridient));
                Console.WriteLine("All Drinks in the database:");
                Console.WriteLine();
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine("---Ingridients");

                    if (item.AllLiqours.Any())
                    {
                        Console.WriteLine("-------Liqours:");
                        foreach (Item liqourItem in item.AllLiqours)
                        {
                            Liqour liqour = (Liqour)liqourItem.ingridient; 
                            Console.WriteLine($"----------{liqourItem.Amount}{liqourItem.MeasureType} {liqourItem.ingridient.Name} with color: {liqour.LiqourColor}");
                        }
                    }

                    if (item.AllAccessories.Any())
                    {
                        Console.WriteLine("-------Accesories:");
                        foreach (Item accessory in item.AllAccessories)
                        {
                            Console.WriteLine($"----------{accessory.ingridient.Name}");
                        }
                    }

                    //db.RemoveDrink(item);

                    Console.WriteLine();
                }


            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
