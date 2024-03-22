using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Inventory

    {
        public int Itemno;

        public string Desc;

        public Decimal Price;

        public Inventory()
        {

        }
        public Inventory(int Itemno, string Desc, Decimal Price)
        {
            this.Itemno = Itemno;
            this.Desc = Desc;
            this.Price = Price;

        }
        public override string ToString()
        {
            return $"{Itemno} | {Desc} | {Price}";
        }
    }
}
