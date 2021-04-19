﻿using System.Collections.Generic;
using System.IO;

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
            for (int i = 0; i < file.Length; i += 3)
            {
                // int Id, string Name, int MarketPrice, int WholesalePrice, string Category, int Quantity, string Unit
                products.Add(new Product(int.Parse(file[i]), file[i + 1], int.Parse(file[i + 2]), int.Parse(file[i + 3]), file[i + 4], int.Parse(file[i + 5]), file[i + 6]));
            }
        }

        public List<Product> GetProducts()
        {
            return products; 
        }
    }
}
