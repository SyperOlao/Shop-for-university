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
        private Dictionary<int, int> dateOfOperations = new Dictionary<int, int>(); 

        public void AddNewProducts(List<Product> products)
        {

            foreach (var item in products)
            {
                this.products.Add(item);
            }
        }

    }
}
