using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush myDrawingBrush = new SolidBrush(Color.Blue);
            Pen myDrawingPen = new Pen(myDrawingBrush);
            g.DrawLine(myDrawingPen, 50, 50, 94, 500);
            
        }
    }
}
