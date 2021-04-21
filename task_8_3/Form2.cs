using System;
using System.Windows.Forms;

namespace task_8_3
{
    public partial class Form2 : Form
    {
        private Store _store;
       
        public Form2(Store store)
        {
            _store = store;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Shop {Location = Location, StartPosition = FormStartPosition.Manual};
            frm.FormClosing += delegate { Show(); };
            frm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _store.SortByMarketPrice();
            ShowInfo(sender, e);
        }
        
        private void ShowInfo(object sender, System.EventArgs e)
        {
            groupBox1.Text = String.Empty;

            foreach (var prod in _store.GetProducts())
            {
                groupBox1.Text += "\nНаименование: " + prod.Name + Environment.NewLine;
                groupBox1.Text += "\nРыночная цена: " + prod.MarketPrice + Environment.NewLine;
                groupBox1.Text += "\nОптовая цена: " + prod.WholesalePrice + Environment.NewLine;
                groupBox1.Text += "\nКатегория: " + prod.Category + Environment.NewLine;
                groupBox1.Text += "\nОбъем товара: " + prod.Quantity + " " + prod.Unit + Environment.NewLine +
                                 Environment.NewLine;
            }
        }


        private void Form2_Load_1(object sender, EventArgs e)
        {
            ShowInfo(sender, e);
        }
    }
}