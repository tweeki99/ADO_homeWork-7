using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HwAdo_7
{
    public partial class Form1 : Form
    {
        WarehouseContext db;
        public Form1()
        {
            InitializeComponent();

            db = new WarehouseContext();
            

            dataGridView1.DataSource = db.Products.ToList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            DialogResult result = form2.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Product product = new Product();
            product.Name = form2.textBox1.Text;

            db.Products.Add(product);
            db.SaveChanges();
            dataGridView1.DataSource = db.Products.ToList();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                Guid id;
                bool converted = Guid.TryParse(dataGridView1[1, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Product product = db.Products.Find(id);

                Form2 form2 = new Form2();

                form2.textBox1.Text = product.Name;

                DialogResult result = form2.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                
                product.Name = form2.textBox1.Text;

                db.SaveChanges();
                dataGridView1.DataSource = db.Products.ToList();

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                Guid id;
                bool converted = Guid.TryParse(dataGridView1[1, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                dataGridView1.DataSource = db.Products.ToList();
            }
        }
    }
}
