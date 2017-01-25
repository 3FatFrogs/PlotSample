using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Point[] points = new Point[6];

            Random random = new Random();

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(random.Next(100, 300), random.Next(100, 300));
            }
            
            for (int i = 0; i < points.Length; i++)
            {
                if(i!=0)
                    g.DrawLine(new Pen(Brushes.Black,4), points[i-1], points[i]);
                else
                    g.DrawLine(new Pen(Brushes.Black, 4), points[i], points[i]);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
