using Project_1;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace DrawingUSAMap
{
    public partial class Map : Form
    {
        private List<Project_1.Models.State> states;
        private (double minLon, double maxLon, double minLat, double maxLat) bounds;

        public Map()
        {
            states = DeserializeCoordinates.GetStates();
            bounds = Project.FindBounds(states);
            InitializeComponent();
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawUSA(g, e);
        }

        private (int x, int y) ProjectMercator(double lon, double lat, int width, int height)
        {
            double scaleForX = 2.5;
            double latRad = lat * Math.PI / 180.0;
            //double lonRad = lon * Math.PI / 180.0;
            double minLatRad = bounds.minLat * Math.PI / 180.0;
            double maxLatRad = bounds.maxLat * Math.PI / 180.0;

            double mercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2)));

            double minMerc = Math.Log(Math.Tan((Math.PI / 4) + (minLatRad / 2)));
            double maxMerc = Math.Log(Math.Tan((Math.PI / 4) + (maxLatRad / 2)));

            double xPerc = (lon - bounds.minLon) / (bounds.maxLon - bounds.minLon) * scaleForX;
            int x = (int)(xPerc * width);

            double yPerc = (mercN - minMerc) / (maxMerc - minMerc);
            int y = (int)((1.0 - yPerc) * height);

            return (x, y);
        }

        private void DrawUSA(Graphics g, PaintEventArgs e)
        {
            Brush myDrawingBrush = new SolidBrush(Color.Red);
            Pen myDrawingPen = new Pen(Color.Black, 1);

            foreach (var state in states)
            {
                GraphicsPath path = new GraphicsPath();
                foreach (var shape in state.Shapes)
                {
                    foreach (var polygon in shape.Polygons)
                    {
                        Point[] poly = new Point[polygon.Points.Count];
                        for (int i = 0; i < polygon.Points.Count; i++)
                        {
                            var currentPoint = polygon.Points[i];

                            var currentCoord = ProjectMercator(currentPoint.Longtitude,
                                currentPoint.Latitude, this.ClientSize.Width, this.ClientSize.Height);

                            poly[i] = new Point(currentCoord.x, currentCoord.y);
                        }
                        path.AddPolygon(poly);
                    }
                }
                
                e.Graphics.FillPath(myDrawingBrush, path);
                e.Graphics.DrawPath(myDrawingPen, path);
            }
        }
    }
}
