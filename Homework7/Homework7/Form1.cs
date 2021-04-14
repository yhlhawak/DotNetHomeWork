using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        double th1 = 30;
        double th2 = 20;
        double per1 = 0.6;
        double per2 = 0.7;
        int n = 10;
        double leng = 100;
        double th = -Math.PI / 2;
        Pen pen = Pens.Black;
        void drawCayleyTree(int n , double x0,double y0, double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1) ;

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1 * Math.PI / 180);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2 * Math.PI / 180);

        }

        void drawLine(double x0, double y0 , double x1 , double y1)
        {
            graphics.DrawLine(pen ,(float)x0, (float)y0, (float)x1, (float)y1);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (graphics == null) graphics = splitContainer1.Panel2.CreateGraphics();
            else graphics.Clear(Color.White);
            if(!Int32.TryParse(textBox1.Text, out n)){
                n = 10;
            }
            if(!Double.TryParse(textBox2.Text, out leng))
            {
                leng = 100;
            }
            if(!Double.TryParse(textBox3.Text, out per1))
            {
                per1 = 0.6;
            }
            if(!Double.TryParse(textBox4.Text, out per2))
            {
                per2 = 0.7;
            }
            if(!Double.TryParse(textBox5.Text, out th1))
            {
                th1 = 30;
            }
            if (!Double.TryParse(textBox6.Text, out th2))
            {
                th2 = 20;
            }
            switch (textBox7.Text)
            {
                case "Black":
                    pen = Pens.Black;
                    break;
                case "Blue":
                    pen = Pens.Blue;
                    break;
                case "Red":
                    pen = Pens.Red;
                    break;
                default:
                    pen = Pens.Black;
                    break;

            }

            drawCayleyTree(n, 200, 310, leng, th);
        }
    }
}
