using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Cocktails.Classes
{
    enum Color
    {
        Red,
        Blue,
        Black,
        Yellow,
        Pink,
        Orange,
        Green,
        White
    }
    class Liqour : Ingridient
    {
        public Color LiqourColor  { get; private set; }

        public Liqour(string Name, Color liqourColor) : base(Name)
        {
            this.LiqourColor = liqourColor;
        }
        public Liqour()
        {

        }
    }
}
