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
using AngouriMath;


namespace Diffequa
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
        public void GetFormula(string formula, double xStart, double xEnd, double yStart, double h)
        {
            this.Text = formula;
            Chart myChart = new Chart();
            myChart.Parent = this;
            myChart.Dock = DockStyle.Fill;
            myChart.ChartAreas.Add(new ChartArea("Math functions"));

            Series mySeriesOfPoint = new Series("Sinus");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";

            for (; xEnd > xStart; xStart += h)
            {
                Entity expr1 = Replace(new StringBuilder(formula), xStart, yStart);
                yStart = yStart + h * ((double)expr1.EvalNumerical());
                mySeriesOfPoint.Points.AddXY(xStart, yStart);
            }
            myChart.Series.Add(mySeriesOfPoint);

        }
        string Replace(StringBuilder formula, double x, double y)
        {
            formula.Replace("x", x.ToString());
            formula.Replace("y", y.ToString());
            formula.Replace(',', '.');
            return formula.ToString();
        }
    }
}