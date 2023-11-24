using System;
using System.Runtime.CompilerServices;

namespace FacadePattern
{
    
    public class Stock
    {
        public bool CheckItemStockByItemID(string itemid)
        {
            Console.WriteLine(string.Format("Item id: {0} cost is avaiable", itemid));
            return true;
        }

        public bool LockItemsTemporary(string itemid, int qty)
        {
            Console.WriteLine(string.Format("Item id: {0}, {1} items are locked!", itemid, qty));
            return true;
        }
    }

    class ItemCost
    {
        public string GetItemCostByItemID(string itemid)
        {
            Console.WriteLine(string.Format("Item id: {0} cost is $35", itemid));
            return "35";
        }


    }
    class Taxes
    {
        public string GetStateTax(string statecode)
        {
            return string.Format("{0} state tax is 10%", statecode);
        }
    }

    public class ShoppingItem
    {
        public bool AddItemToCart(string itemcode, int qty)
        {
            Stock stock = new Stock();
            stock.CheckItemStockByItemID(itemcode);
            stock.LockItemsTemporary(itemcode, qty);


            ItemCost item = new ItemCost();
            item.GetItemCostByItemID(itemcode);


            Taxes tx = new Taxes();
            tx.GetStateTax("PN");
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingItem shoppingitem = new ShoppingItem();
            shoppingitem.AddItemToCart("item123", 3);



            Console.ReadLine();
        }

    }


}
