using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8_3
{
    class Product
    {
        public string Name { set; get; }

        public int MarketPrice { set; get; } // Рыночная цена
        public int WholesalePrice { set; get; } // Цена закупки
        public string PurchaseDate { set; get; } //Дата покупки
        public string SellingDate { set; get; } //Дата продажи
    
    }
}
