namespace StoreDll
{
    public class Product
    {
        public string Name { set; get; }
        public int MarketPrice { set; get; } // Рыночная цена
        public int WholesalePrice { set; get; } // Цена закупки
        
        public Product(string Name, int MarketPrice, int WholesalePrice)
        {
            this.Name = Name;
            this.MarketPrice = MarketPrice;
            this.WholesalePrice = WholesalePrice; 
        }
        public Product() { }
    }
}
