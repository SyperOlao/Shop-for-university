using System;
using System.Drawing;
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
            dataGridView1.Rows.Clear();

            int i = 0;
            foreach (var prod in _store.GetProducts())
            {
                dataGridView1.Rows.Add("Id");
                dataGridView1.Rows[i].Cells["Column2"].Value = prod.id;
                dataGridView1.Rows[i].Cells["Column2"].Style.BackColor = Color.Aqua;
                
                dataGridView1.Rows.Add("Наименование:");
                dataGridView1.Rows[i+1].Cells["Column2"].Value = prod.Name;
                
                dataGridView1.Rows.Add("Рыночная цена:");
                dataGridView1.Rows[i+2].Cells["Column2"].Value = prod.MarketPrice;
                dataGridView1.Rows[i+2].Cells["Column2"].Style.BackColor = Color.Aquamarine;
                
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
            ShowInfo(sender, e);
        }
    }
}