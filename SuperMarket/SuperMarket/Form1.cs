using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace SuperMarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {


            InitializeComponent();
            var today = DateTime.Now;
            label11.Text = today.Date.ToString("d");

        }


        class MasterDetail
        {
            public string contactName { get; set; }
            public string companyName { get; set; }
            public string city;
            public string cityp  // property
            {
                get { return city; }   // get method
                set { city = value; }  // set method
            }
            public string country { get; set; }
            public MasterDetail(string contactN, string companyN, string CityN, string countryN)
            {
                contactName = contactN;
                companyName = companyN;
                country = countryN;
                city = CityN;
            }
        }
        public static int count = 0;
        List<MasterDetail> masterItem = new List<MasterDetail>();
        private void button1_Click(object sender, EventArgs e)
        {
            MasterDetail master = new MasterDetail(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            masterItem.Add(master);
            //Console.WriteLine(masterItem[0].contactName);
            dataGridView1.Rows.Clear();
            List<MasterDetail> SortedList = masterItem.OrderBy(o => o.companyName).ToList();
            for (int i = 0; i < SortedList.Count; i++)
            {
                dataGridView1.Rows.Add(SortedList[i].contactName, SortedList[i].companyName, SortedList[i].city, SortedList[i].country);
            }

            comboBox1.Items.Add(masterItem[count].companyName);
            count++;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            MessageBox.Show("New entry added");



        }
        public static int id = 100;

        class OrderDetail
        {
            public int orderId { get; set; }

            public DateTime date;
            public string productName { get; set; }
            public string company;
            public int quantity { get; set; }
            public double price { get; set; }
            public string total { get; set; }

            public OrderDetail(string productN, string companyN, int quantityO, double unitP)
            {
                orderId = id++;
                date = DateTime.Now;
                company = companyN;
                productName = productN;
                quantity = quantityO;
                price = unitP;
                total = "Rs. " + quantity * price + "/-";
            }
        }
        List<OrderDetail> orderItem = new List<OrderDetail>();
        public static int orderCount = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            OrderDetail order = new OrderDetail(textBox5.Text, comboBox1.SelectedItem + "", int.Parse(textBox7.Text), double.Parse(textBox8.Text));

            orderItem.Add(order);
            /*List<OrderDetail> SortedList = orderItem.OrderBy(o => o.company).ToList();
            for (int i = 0; i < SortedList.Count; i++)
            {
                dataGridView2.Rows.Add(SortedList[i].orderId, SortedList[i].date, SortedList[i].productName, SortedList[i].quantity, SortedList[i].price, SortedList[i].total);
            }*/
            label10.Text = id + "";
            label11.Text = DateTime.Now.Date.ToString("d") + "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox5.Text = "";

            MessageBox.Show($"New entry added\nTotal={orderItem[orderCount].total}");
            orderCount++;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Visible == true)
                dataGridView2.Visible = false;
            else
            {
                dataGridView2.Visible = true;
                List<OrderDetail> SortedList = orderItem.OrderBy(o => o.company).ToList();
                dataGridView2.Rows.Clear();
                var com = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Column4"].Value.ToString();

                foreach (var p in SortedList)
                {
                    Console.WriteLine("Company " + p.company + "name " + com);
                    if (p.company.Equals(com))
                    {
                        //Console.WriteLine("true");
                        dataGridView2.Rows.Add(p.orderId, p.date, p.company,p.productName, p.quantity, p.price, p.total);
                        
                    }
                    else continue;
                }
            }
        }
    }
}
