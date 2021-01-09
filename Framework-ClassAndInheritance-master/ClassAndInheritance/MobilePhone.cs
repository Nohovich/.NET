using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndInheritance
{
    abstract class MobilePhone
    {
        public string number;
        public string brand;


        public MobilePhone(string number)
        {
            this.number = number;
        }

        public MobilePhone(string number, string brand) : this(number)
        {
            this.brand = brand;
        }
    }
    class Samsung : MobilePhone
    {
        public string theme;

        public Samsung(string number, string brand, string theme) : base(number, brand)
        {
            this.theme = theme;
        }
    }
}
