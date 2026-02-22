namespace Project_1.Models
{
    public class Polygon
    {
        public List<Point> Points { get; set; } = new();

        public void AddPoint(Point point)
        {
            Points.Add(point);
        }
    }
}
