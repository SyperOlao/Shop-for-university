namespace task_8_3
{
    public class Product
    {
        public int id { get; } // Уникальный код
        public string Category { get; } // Категория
        public int Quantity { set; get; } // Количество товаров
        public string Unit { get; } // Eдиница измерения
        public string Name { get; } // Название 
        public int MarketPrice { get; } // Розничная цена
        public int WholesalePrice { get; } // Цена закупки

        public Product(string Name, int MarketPrice, int WholesalePrice, string Category, int Quantity,
            string Unit)
        {
            this.Name = Name;
            this.MarketPrice = MarketPrice;
            this.WholesalePrice = WholesalePrice;
            this.Category = Category;
            this.Unit = Unit;
            this.Quantity = Quantity;
            this.id = id; //TODO:: добавить id 
        }
        public Product() { }
    }
}