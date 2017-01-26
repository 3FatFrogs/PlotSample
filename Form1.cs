using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            Graphics g;
            Point[] points;

            CreatePoints(out g, out points);

            for (int i = 0; i < points.Length; i++)
            {
                if (i != 0)
                    g.DrawLine(new Pen(Brushes.Black, 4), points[i - 1], points[i]);
                else
                    g.DrawLine(new Pen(Brushes.Black, 4), points[i], points[i]);

            }

        }

        private void CreatePoints(out Graphics g, out Point[] points)
        {
            g = CreateGraphics();
            points = new Point[100];

            Random random = new Random();
            int count = 100;
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(count, random.Next(100, 300));
                count += 10;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //using SERIES
            Random random = new Random();
            chart1.Series.Clear();

            var series = new Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime

            };
            DateTime t = DateTime.Today;
            for (int i = 0; i < 10; i++)
            {
                //series.Points.AddXY(i, Math.Sin(i*2*3.14/90));
                series.Points.AddXY(t.AddDays(i), random.Next(0, 10));
            }

            chart1.Series.Add(series);


            // copy the series and manipulate the copy
            chart1.DataManipulator.CopySeriesValues("Series1", "Series2");
            chart1.DataManipulator.FinancialFormula(
                FinancialFormula.WeightedMovingAverage,
                "Series2"
            );
            chart1.Series["Series2"].ChartType = SeriesChartType.FastLine;

            // draw!
            chart1.Invalidate();

            chart1.SaveImage("chart.png", ChartImageFormat.Png);
        }

    }
}
