namespace task_8_3
{
    public class Product
    {
        private static int gen_id;
        private int id; // Уникальный код
        public string Category { get; } // Категория
        public int Quantity { get; } // Количество товаров
        public string Unit { get; } // Eдиница измерения
        public string Name { get; } // Название 
        public int MarketPrice { get; } // Розничная цена
        public int WholesalePrice { get; } // Цена закупки

        public int GetId()
        {
            return id;
        }

        public Product(string Name, int MarketPrice, int WholesalePrice, string Category, int Quantity,
            string Unit)
        {
            this.Name = Name;
            this.MarketPrice = MarketPrice;
            this.WholesalePrice = WholesalePrice;
            this.Category = Category;
            this.Unit = Unit;
            this.Quantity = Quantity;
            id = gen_id++;
        }
    }
}