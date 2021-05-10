using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/*Класс Store – набор объектов класса Product, экземпляры которого описывают
товары, предлагаемые к продаже. В числе полей класса Product должны
присутствовать уникальный код продукта, его категория и название, закупочная и
розничная цена, единица измерения (кг, штука, упаковка). Класс Product должен
включать метод вывода информации о конкретном продукте. Класс Store должен
включать поле объема имеющихся оборотных средств. Методы класса Store должны
обеспечивать выполнение операций по реализации товара с указанием даты
совершения операции, подсчета выручки за указанный период времени,
поступления повой партии товара, а также по формированию полного списка
имеющихся товаров с указанием их объема  В этом списке предусмотреть возможность
группировки товаров по категориям. Создать отдельные формы для экземпляров
класса Store и класса Product*/

/*Реализация товара должна
сопровождаться генерацией события, результатом обработки которого должен
быть отчет о сделанной покупке*/


namespace task_8_3.Classes 
{
    public class Store
    {
        private List<Product> _products = new List<Product>();
        private List<Date> _date = new List<Date>();
        private Dictionary<Date, Product> _purchase = new Dictionary<Date, Product>();
        public int id { set; get; }
        public int Money { set; get; }
        
        public void BuyNewProducts(Product product, string date)
        {
            int money = 0;
            _products.Add(product);
            money -= product.WholesalePrice;
            Money -= product.WholesalePrice;
            _date.Add(new Date(money, date));
            _purchase.Add(_date[_date.Count-1], product);
        }

        public IOrderedEnumerable<Product> SortByMarketPrice()
        {
            var query = from prod in _products
                orderby prod.MarketPrice
                select prod;
            return query;
        }

        public IOrderedEnumerable<Product> SortByAlphabet()
        {
            var query = from prod in _products
                orderby prod.Name.Substring(0, 1)
                select prod;
            return query;
        }

        public IOrderedEnumerable<Product> SortByCategory()
        {
            var query = from prod in _products
                orderby prod.Category.Substring(0, 1)
                select prod;
            return query;
        }

        public void SellAllProducts(string product, string date)
        {
            int money = 0;
            Product tempProduct = new Product();
            foreach (var pr in _products.Where(pr => pr.Name.Equals(product)))
            {
                money += pr.MarketPrice * pr.Quantity;
                Money += pr.MarketPrice * pr.Quantity;
                tempProduct = pr;
                _products.Remove(pr);
                break;
            }
            _date.Add(new Date(money, date));
            _purchase.Add(_date[_date.Count-1], tempProduct);

        }

        public void SellProducts(string product, string date, int amount, Label label)
        {
            int money = 0;
            Product tempProduct = new Product();
            foreach (var pr in _products.Where(pr => pr.Name.Equals(product)))
            {
                if (pr.Quantity < amount)
                {
                    SellAllProducts(product, date);
                    label.Text = "Вы выкупили весь товар, больше нет ";
                    return;
                }

                money += pr.MarketPrice * amount;
                Money += pr.MarketPrice * amount;
                pr.Quantity -= amount;
                tempProduct = pr;
                tempProduct.Quantity = amount;

            }
            _date.Add(new Date(money, date));
            _purchase.Add(_date[_date.Count-1], tempProduct);
        }

        //Выручка по периодам
        public int Revenue(string date1, string date2)
        {
            return _date.Where(item => DateCalculation.IsInDates(DateCalculation.DateToNumber(date1),
                    DateCalculation.DateToNumber(item.DateOfOperation), DateCalculation.DateToNumber(date2)))
                .Sum(item => item.Money);
        }

        public Store(string path, int Money)
        {
            this.Money = Money;
            string[] file = File.ReadAllLines(path);
            for (int i = 0; i < file.Length; i += 6)
            {
                _products.Add(new Product(++id, file[i], int.Parse(file[i + 1]),
                    int.Parse(file[i + 2]), file[i + 3], int.Parse(file[i + 4]), file[i + 5]));
            }
        }

        public Dictionary<Date, Product> GetPurchase()
        {
            return _purchase;
        }

        public List<Product> GetProductsList()
        {
            return _products;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}