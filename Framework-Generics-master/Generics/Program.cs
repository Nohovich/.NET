using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Knight aglovale = new Knight("Aglovale", "England", "Night");
            Knight agravain = new Knight("Agravain", "England", "Night");
            Knight arthur = new Knight("Arthur", "England", "Night");
            RoundTable<Knight> rundTableKnight = new RoundTable<Knight>();
            RoundTable<Magician> rundTableMagician = new RoundTable<Magician>();
        }
    }
    
}
