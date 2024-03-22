using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class InventoryDB

    {
        private static readonly string Path = @"C:\Users\DARSHAN\Downloads\grocery_inventory_items.txt";
        private const string Delimiter = "|";


        public static List<Inventory> GetItems()
        {
            List<Inventory> items = new List<Inventory>();


            using (StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                string row;
                while ((row = textIn.ReadLine()) != null)
                {
                    string[] columns = row.Split(Delimiter[0]);


                    if (columns.Length == 3)
                    {
                        Inventory item = new Inventory
                        {
                            Itemno = Convert.ToInt32(columns[0]),
                            Desc = columns[1],
                            Price = Convert.ToDecimal(columns[2])
                        };
                        items.Add(item);
                    }
                }
            }
            return items;
        }


        public static void SaveItems(List<Inventory> items)
        {
            using (StreamWriter textOut = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.Write)))
            {
                foreach (Inventory item in items)
                {
                    textOut.Write(item.Itemno + Delimiter);
                    textOut.Write(item.Desc + Delimiter);
                    textOut.WriteLine(item.Price);
                }
            }
        }
    }
}
