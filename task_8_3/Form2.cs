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
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _store.SortByMarketPrice(); 
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}