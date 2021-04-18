namespace task_8_3
{
    class Product
    {
        public int Id { set; get; } // Уникальный код
        public string Category { set; get; } // Категория
        public int Quantity { set; get; } // Количество товаров
        public string Unit { set; get; } // Eдиница измерения
        public string Name { set; get; } // Название 
        public int MarketPrice { set; get; } // Розничная цена
        public int WholesalePrice { set; get; } // Цена закупки

        public Product(int Id, string Name, int MarketPrice, int WholesalePrice, string Category, int Quantity, string Unit)
        {
            this.Name = Name;
            this.MarketPrice = MarketPrice;
            this.WholesalePrice = WholesalePrice;
            this.Category = Category;
            this.Unit = Unit;
            this.Quantity = Quantity; 
            this.Id = Id; 
        }
        public Product() { }
    }
}
