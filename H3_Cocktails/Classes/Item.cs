using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Cocktails.Classes
{
    enum Measurement
    {
        ml
    }

    class Item : Entity
    {
        public double Amount { get; private set; }
        public Measurement MeasureType { get; private set; }
        virtual public Ingridient ingridient { get; private set; }

        public Item(double amount, Measurement measureType, Ingridient ingridient)
        {
            Amount = amount;
            MeasureType = measureType;
            this.ingridient = ingridient;
        }
        public Item(Accessory accessory)
        {
            this.ingridient = accessory;
        }
        public Item()
        {

        }
    }
}
