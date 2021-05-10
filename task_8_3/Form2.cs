using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using task_8_3.Classes;

namespace task_8_3
{
    public partial class Form2 : Form
    {
        private Store _store;

        public delegate List<Product> InfoOfPurchase(Dictionary<Date, Product> purchase);

        private InfoOfPurchase infoOfPurchase;
        public Form2(Store store)
        {
            _store = store;
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ShowInfo(_store.SortByMarketPrice());
        }
        
        private void ShowInfo(List<Product> products, bool clean=true)
        {
            if(clean)
                dataGridView1.Rows.Clear();

            int i = 0;
            foreach (var prod in products)
            {
                dataGridView1.Rows.Add("Id");
                dataGridView1.Rows[i].Cells["Column2"].Value = prod.id;

                dataGridView1.Rows.Add("Наименование:");
                dataGridView1.Rows[i+1].Cells["Column2"].Value = prod.Name;
                dataGridView1.Rows[i].Cells["Column2"].Style.BackColor = Color.Aqua;
                
                dataGridView1.Rows.Add("Рыночная цена:");
                dataGridView1.Rows[i+2].Cells["Column2"].Value = prod.MarketPrice;

                dataGridView1.Rows.Add("Оптовая цена:");
                dataGridView1.Rows[i+3].Cells["Column2"].Value = prod.WholesalePrice;
                
                dataGridView1.Rows.Add("Категория:");
                dataGridView1.Rows[i+4].Cells["Column2"].Value = prod.Category;
                
                dataGridView1.Rows.Add("Объём товара:");
                dataGridView1.Rows[i+5].Cells["Column2"].Value = prod.Quantity;
               
                dataGridView1.Rows.Add("Единица измерения");
                dataGridView1.Rows[i+6].Cells["Column2"].Value = prod.Unit;
                i += 7; 
            }
        }

        private void ShowInfo(IOrderedEnumerable<Product> query)
        {
            dataGridView1.Rows.Clear();

            int i = 0;
            foreach (var prod in query)
            {
                dataGridView1.Rows.Add("Id");
                dataGridView1.Rows[i].Cells["Column2"].Value = prod.id;

                dataGridView1.Rows.Add("Наименование:");
                dataGridView1.Rows[i+1].Cells["Column2"].Value = prod.Name;
                dataGridView1.Rows[i].Cells["Column2"].Style.BackColor = Color.Aqua;
                
                dataGridView1.Rows.Add("Рыночная цена:");
                dataGridView1.Rows[i+2].Cells["Column2"].Value = prod.MarketPrice;

                dataGridView1.Rows.Add("Оптовая цена:");
                dataGridView1.Rows[i+3].Cells["Column2"].Value = prod.WholesalePrice;
                
                dataGridView1.Rows.Add("Категория:");
                dataGridView1.Rows[i+4].Cells["Column2"].Value = prod.Category;
                
                dataGridView1.Rows.Add("Объем товара:");
                dataGridView1.Rows[i+5].Cells["Column2"].Value = prod.Quantity;
               
                dataGridView1.Rows.Add("Единица измерения");
                dataGridView1.Rows[i+6].Cells["Column2"].Value = prod.Unit;
                i += 7; 
            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            ShowInfo(_store.GetProductsList());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowInfo(_store.SortByAlphabet());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowInfo(_store.SortByCategory());
        }
        //Корзина покупок
        private void button1_Click(object sender, EventArgs e)
        {
            infoOfPurchase = ShowInfoForPurchase;
            ShowInfo(infoOfPurchase(_store.GetPurchase()));
        }
        //Корзина продаж
        private void button5_Click(object sender, EventArgs e)
        {
            infoOfPurchase = ShowInfoForSelling;
            ShowInfo(infoOfPurchase(_store.GetPurchase()));
        }
        // Корзина общих продаж
 
        public static List<Product> ShowInfoForPurchase(Dictionary<Date, Product> purchase)
        {
            return (from pr in purchase where pr.Key.Money > 0 select pr.Value).ToList();
        }

        public static List<Product> ShowInfoForSelling(Dictionary<Date, Product> purchase)
        {
            return (from pr in purchase where pr.Key.Money < 0 select pr.Value).ToList();
        }
    }
}