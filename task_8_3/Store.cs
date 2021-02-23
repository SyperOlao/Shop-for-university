using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Предусмотреть возможность
выполнения следующих операций: реализация товара(партии товаров) с указанием
даты совершения операции, подсчета выручки за указанный период времени,
поступления новой партии товара.*/

namespace task_8_3
{
    class Store
    {
        private List<Product> products = new List<Product>();
        public int Money { set; get; }

        public void BuyNewProducts(List<Product> products, string date)
        {
            foreach (var item in products)
            {
                item.PurchaseDate = date; 
                this.products.Add(item);
            }
        }
        public void SellProducts(List<Product> products, string date)
        {

        }

    }
}
