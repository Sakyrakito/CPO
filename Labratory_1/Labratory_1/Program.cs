using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace program;

static class Program
{
    static Dictionary<string, Color> ColorMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "красн", Color.Red },
        { "ал", Color.Crimson },
        { "багр", Color.DarkRed },
        { "зелен", Color.Green },
        { "изумруд", Color.MediumSeaGreen },
        { "малахит", Color.MediumSeaGreen },
        { "син", Color.Blue },
        { "голуб", Color.LightBlue },
        { "лазур", Color.LightSkyBlue },
        { "ультрамарин", Color.Blue },
        { "желт", Color.Yellow },
        { "золот", Color.Gold },
        { "лимон", Color.LemonChiffon },
        { "бел", Color.White },
        { "черн", Color.Black },
        { "сер", Color.Gray },
        { "фиолетов", Color.Purple },
        { "лилов", Color.Purple },
        { "оранжев", Color.Orange },
        { "коричнев", Color.Brown },
        { "розов", Color.Pink },
        { "бирюз", Color.Turquoise },
    };

    static string GetText(string filePath) => File.ReadAllText(filePath);

    static List<Color> GetColorMap(string text)
    {
        var words = Regex.Matches(text, @"\b[\p{IsCyrillic}a-zA-Z]+\b").Select(w => w.ToString()).ToList();
        
        var wordList = words.Where(w => ColorMap.Keys.Any(pref => w.StartsWith(pref, StringComparison.OrdinalIgnoreCase))).ToList();
        var colorList = wordList.Select(w =>
        {
            var key = ColorMap.Keys.FirstOrDefault(k => w.StartsWith(k, StringComparison.OrdinalIgnoreCase));
            return key is null ? Color.Magenta : ColorMap[key];
        }).ToList();

        return colorList;
    }

    static void DrawPicture(List<Color> colorList)
    {
        int numOfRectangles = colorList.Count;
        int rowSize = (int)Math.Sqrt(numOfRectangles);
        int columnSize = numOfRectangles / rowSize;

        const int pixelSize = 30;

        using (Bitmap bmp = new Bitmap(rowSize * pixelSize, columnSize * pixelSize))
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Magenta);

                for (int i = 0; i < rowSize; i++)
                {
                    for (int j = 0; j < columnSize; j++)
                    {
                        using (Brush brush = new SolidBrush(colorList[i * columnSize + j]))
                        {
                            g.FillRectangle(brush, j * pixelSize, i * pixelSize, pixelSize, pixelSize);
                        }
                    }
                }
            }
            bmp.Save("square.png", ImageFormat.Png);
        }
    }

    static void Main()
    {
        var text = GetText("D:\\Учёба\\КПО 2 курс\\Labratory_1\\Podarok.txt");

        var colorList = GetColorMap(text);

        DrawPicture(colorList);
    }
}