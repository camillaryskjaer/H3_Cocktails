using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Cocktails.Classes
{
    class Ingridient : Entity
    {
        public string Name { get; private set; }

        public Ingridient(string Name)
        {
            this.Name = Name;
        }
        public Ingridient()
        {

        }
    }
}
