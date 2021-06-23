using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Homework9
{
    public partial class Form1 : Form
    {
        SimpleCrawler simpleCrawler = new SimpleCrawler();
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            btn_Start.Enabled = false;
            simpleCrawler.startUrl = textBox1.Text;
            simpleCrawler.Start();
            dataGridView1.DataSource = new BindingList<Page>(simpleCrawler.donloadPages);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            simpleCrawler.startUrl = "http://www.cnblogs.com/dstang2000/";
            textBox1.DataBindings.Add("Text",simpleCrawler, "startUrl");
            
            
        }
    }
}
