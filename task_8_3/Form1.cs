using System;
using System.Windows.Forms;


namespace task_8_3
{
    public partial class Shop : Form
    {
        Store store = new Store("store.txt", 2700);

        public Shop()
        {
            InitializeComponent();
        }

        //Магазин закупает товары
        private void button1_Click(object sender, System.EventArgs e)
        {
            var frm = new Form2(store);
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            Hide();
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
                textBox1.Text += "\nКатегория: " + prod.Category + Environment.NewLine;
                textBox1.Text += "\nОбъем товара: " + prod.Quantity + " " + prod.Unit + Environment.NewLine +
                                 Environment.NewLine;
            }
        }

        //Закупить (самомоу магазину)
        private void button2_Click(object sender, EventArgs e)
        {
            string[] strProd = textBox2.Text.Split(' ');
            foreach (var pr in strProd)
            {
                store.SellProducts(pr, textBox6.Text);
            }

            ShowInfo(sender, e);
        }

        // прибыль 
        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = store.Revenue(textBox3.Text, textBox4.Text).ToString();
        }

        // Покупает по штучно
        private void button4_Click(object sender, EventArgs e)
        {
            store.SortByMarketPrice();
            ShowInfo(sender, e);
        }

        // купить партию товара 
        private void button5_Click(object sender, EventArgs e)
        {
            string[] strProd = textBox2.Text.Split(' ');
            for (int i = 0; i < strProd.Length; i += 6)
            {
                store.BuyNewProducts(
                    new Product( strProd[i], int.Parse(strProd[i + 1]),
                        int.Parse(strProd[i + 2]), strProd[i + 3], int.Parse(strProd[i + 4]),
                        strProd[i + 5]),
                    textBox6.Text);
            }

            ShowInfo(sender, e);
        }
    }
}