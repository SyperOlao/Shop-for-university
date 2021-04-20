using System.Collections.Generic;
using System.IO;
using System.Linq;

/*Класс Store – набор объектов класса Product, экземпляры которого описывают
товары, предлагаемые к продаже. В числе полей класса Product должны
присутствовать уникальный код продукта, его категория и название, закупочная и
розничная цена, единица измерения (кг, штука, упаковка). Класс Product должен
включать метод вывода информации о конкретном продукте. Класс Store должен
включать поле объема имеющихся оборотных средств. Методы класса Store должны
обеспечивать выполнение операций по реализации товара с указанием даты
совершения операции, подсчета выручки за указанный период времени,
поступления повой партии товара, а также по формированию полного списка
имеющихся товаров с указанием их объема В этом списке предусмотреть
возможность группировки по товаров по категориям. Создать отдельные формы для
экземпляров класса Store и класса Product.*/

namespace task_8_3
{
    class Store
    {
        private List<Product> products = new List<Product>();
        private List<Date> date = new List<Date>(); 
        public int Money { set; get; }

        public void BuyNewProducts(Product product, string date)
        {
            int money = 0;
            products.Add(product);
            money -= product.WholesalePrice;
            Money -= product.WholesalePrice;
            this.date.Add(new Date(money, date));
        }

        public List<Product> SortByMarketPrice()
        {
            for (int i = 1; i < products.Count; i++)
            {
                for (int j = i; j > 0 && products[j - 1].MarketPrice < products[j].MarketPrice; j--)
                {
                    Product tmp = products[j - 1];
                    products[j - 1] = products[j];
                    products[j] = tmp;
                }
            }

            return products; 
        }

        public void SellProducts(string product, string date)
        {
            int money = 0;

            foreach (var pr in products.Where(pr => pr.Name.Equals(product)))
            {
                money += pr.MarketPrice;
                Money -= pr.WholesalePrice;
                products.Remove(pr);
                break;
            }

            this.date.Add(new Date(money, date));
        }

        //Выручка по периодам
        public int Revenue(string date1, string date2)
        {
            return date.Where(item => DateCalculation.IsInDates(DateCalculation.DateToNumber(date1),
                    DateCalculation.DateToNumber(item.DateOfOperation), DateCalculation.DateToNumber(date2)))
                .Sum(item => item.Money);
        }

        public Store(string path, int Money)
        {
            this.Money = Money;
            string[] file = File.ReadAllLines(path);
            for (int i = 0; i < file.Length; i += 7)
            {
                // int Id, string Name, int MarketPrice, int WholesalePrice, string Category, int Quantity, string Unit
                products.Add(new Product(int.Parse(file[i]), file[i + 1], int.Parse(file[i + 2]),
                    int.Parse(file[i + 3]), file[i + 4], int.Parse(file[i + 5]), file[i + 6]));
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}