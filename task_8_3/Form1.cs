using System;
using System.Windows.Forms;
using StoreDll;


namespace task_8_3
{
    public partial class Shop : Form
    {
        Store store = new Store("store.txt");
        
        public Shop(Store store)
        {
            this.store = store;
        }

        public Shop()
        {
            InitializeComponent();
        }

        //Магазин закупает товары
        private void button1_Click(object sender, System.EventArgs e)
        {
            string [] strProd = textBox2.Text.Split(' ');
            for (int i = 0; i < strProd.Length; i += 3)
            {
                store.BuyNewProducts(new Product(strProd[i], int.Parse(strProd[i + 1]), int.Parse(strProd[i + 2])), textBox6.Text);  
            }
            ShowInfo(sender, e);
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            ShowInfo(sender, e);
        }

        private void ShowInfo(object sender, System.EventArgs e)
        {
            textBox1.Text = String.Empty; 

            foreach (var prod in store.GetProducts())
            {
                textBox1.Text += "\nНаименование: " + prod.Name + Environment.NewLine;
                textBox1.Text += "\nРыночная цена: " + prod.MarketPrice + Environment.NewLine;
                textBox1.Text += "\nОптовая цена: " + prod.WholesalePrice + Environment.NewLine;
            }
        }

        //Покупатель покупает у магазина
        private void button2_Click(object sender, EventArgs e)
        {
            string[] strProd = textBox2.Text.Split(' ');
            for (int i = 0; i < strProd.Length; i++)
            {
                store.SellProducts(strProd[i], textBox6.Text);
            }
            ShowInfo(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = store.Revenue(textBox3.Text, textBox4.Text).ToString();
        }
    }
}
