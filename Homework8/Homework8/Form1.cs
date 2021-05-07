using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework6;

namespace Homework8
{
    public partial class MainForm : Form
    {
        OrderService orderService;
        BindingSource bindingSource = new BindingSource();

        public string keyWords;

        public MainForm()
        {
            InitializeComponent();
            orderService = new OrderService();
            Order order1 = new Order(1, new Customer(1, "Jack"));
            order1.AddDetails(new OrderDetails(new Goods(1,"Apple",10.0),100));
            order1.AddDetails(new OrderDetails(new Goods(2, "Bread", 20.0), 40));
            Order order2 = new Order(2, new Customer(2, "Luke"));
            order2.AddDetails(new OrderDetails(new Goods(3, "Grape", 3.0), 2000));
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderBindingSource.DataSource = orderService.orderList;
            txtSearch.DataBindings.Add("Text",this,"keyWords");

        }
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(new Order(), false, orderService);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
