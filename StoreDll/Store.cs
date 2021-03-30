using System.Collections.Generic;
using System.IO;


namespace StoreDll
{
    public class Store
    {
        private List<Product> products = new List<Product>();
        private List<Date> date = new List<Date>();

        public void BuyNewProducts(Product product, string date)
        {
            int money = 0;
            products.Add(product);
            money -= product.WholesalePrice; 
            this.date.Add(new Date(money, date)); 
        }

        public void SellProducts(string product, string date)
        {
            int money = 0; 
            
            foreach (var pr in products)
            {
                if (pr.Name.Equals(product))
                {
                    money += pr.MarketPrice;
                    products.Remove(pr);
                    break;
                }
            }
            this.date.Add(new Date(money, date)); 
        }

        //Выручка по периодам
        public int Revenue(string date1, string date2)  
        {
            int revenue = 0;
            foreach (Date item in date)
            {
                if (DateCalculation.IsInDates(DateCalculation.DateToNumber(date1), DateCalculation.DateToNumber(item.DateOfOperation), DateCalculation.DateToNumber(date2))){
                    revenue += item.Money;
                }
            }
            return revenue;
        }
        
        public Store(string path)
        {
            string[] file = File.ReadAllLines(path);
            for (int i = 0; i < file.Length; i+=3)
            {
                products.Add(new Product(file[i], int.Parse(file[i+1]), int.Parse(file[i+2])));
            }
        }

        public List<Product> GetProducts()
        {
            return products; 
        }
    }
}
