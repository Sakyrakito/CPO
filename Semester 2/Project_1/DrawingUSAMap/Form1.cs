using Project_1;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace DrawingUSAMap
{
    public partial class Map : Form
    {
        private readonly MapDataManager _mapDataManager;

        public Map()
        {
            InitializeComponent();

            _mapDataManager = new MapDataManager(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawUSA(g, e);
        }

        private void DrawUSA(Graphics g, PaintEventArgs e)
        {
            Pen myDrawingPen = new(Color.Black, 1);

            foreach (var (code, shapes) in _mapDataManager.GetShapes())
            {
                Brush myDrawingBrush = new SolidBrush(Color.Red);
                GraphicsPath path = new();

                foreach (var shape in shapes)
                {
                    Point[] poly = new Point[shape.Count];

                    for (int i = 0; i < shape.Count; i++)
                    {
                        poly[i] = new Point(shape[i].x, shape[i].y);
                    }

                    path.AddPolygon(poly);
                }

                e.Graphics.FillPath(myDrawingBrush, path);
                e.Graphics.DrawPath(myDrawingPen, path);
            }

            foreach (var (code, center) in _mapDataManager.GetCenterOfStates)
            {
                int x = (int)center.Longtitude;
                int y = (int)center.Latitude;

                Rectangle rectangle = new Rectangle(x, y, 5, 5);
                g.DrawEllipse(myDrawingPen, rectangle);
            }
        }
    }
}
