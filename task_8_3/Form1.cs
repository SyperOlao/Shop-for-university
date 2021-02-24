using System;
using System.Windows.Forms;

/* Коллекция Store(OnlineStore) – набор объектов класса Product, экземпляры которого
описывают товары, предлагаемые к продаже. Предусмотреть возможность
выполнения следующих операций: реализация товара(партии товаров) с указанием
даты совершения операции, подсчета выручки за указанный период времени,
поступления повой партии товара. List*/


namespace task_8_3
{
    public partial class Form1 : Form
    {
        Store store = new Store("store.txt");

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            foreach (var prod in store.GetProducts())
            {
                textBox1.Text += "\nНаименование: " + prod.Name + Environment.NewLine;
                textBox1.Text += "\nРыночная цена: " + prod.MarketPrice + Environment.NewLine;
                textBox1.Text += "\nОптовая цена: " + prod.WholesalePrice + Environment.NewLine;
            }
        }
    }
}
