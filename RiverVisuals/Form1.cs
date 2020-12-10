using ForestSim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiverVisuals
{
    public partial class Form1 : Form
    {
        River river;
        Point[] riverPoints;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            river = new River();

            river.GenerateRiver();

            riverPoints = new Point[river.RiverPositions.Count];

            for (int i = 0; i < river.RiverPositions.Count; i++)
            {

                riverPoints[i].X = (int) river.RiverPositions.ToArray()[i].x * 10;
                riverPoints[i].Y = (int) river.RiverPositions.ToArray()[i].y * 10;

                if (i > 1)
                {
                    this.CreateGraphics().DrawLine(new Pen(Brushes.Black, 4), riverPoints[i-1], riverPoints[i]);
                }
                
            }

            
        }
    }
}
