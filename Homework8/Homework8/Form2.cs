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
    public partial class AddForm : Form
    {
        OrderService orderService;

        public Order CurrentOrder;
        public AddForm(Order order, bool model, OrderService orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
            this.CurrentOrder = order;
            OrderBindingSource.DataSource = CurrentOrder;

        }
    }
}
