using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public class GameLodic
    {
        public static readonly Bitmap Marker = Resource1.marker;
        public static readonly Bitmap Target = Resource1.aim;

        public static int GlobalCounter = 0;
        public static int CountdownCounter = 4;

        public static readonly int FontSize = 64;
        public static readonly Font Font = new Font("Haettenschweiler", FontSize, FontStyle.Regular);
        public static readonly SolidBrush Brush = new SolidBrush(Color.Black);

        public Point[] Coordinates;

        public static Point[] MakeCoords(int mode)
        {
            Point[] Coords;
            int size;
            int z;

            if (mode % 2 == 1)
            {
                Coords = new Point[44];
                size = 540;
                z = 1;
            }
            else
            {
                Coords = new Point[88];
                size = 320;
                z = 2;
            }

            var random = new Random();
            Point number = new Point();
            for (int x = 0; x < 11; x++)
            {
                number.X = random.Next(0, size);
                number.Y = random.Next(100, 1100);

                for (int i = 0; i < (4 * z); i++)
                {
                    Coords[x * (4 * z) + i].X = number.X;
                    Coords[x * (4 * z) + i].Y = number.Y;

                    number.X = random.Next(number.X + 150, number.X + size);
                    number.Y = random.Next(100, 1100);
                }
            }    

            return Coords;
        }
        public static Point[] NextPoint (Point[] main, int c,int mode)
        {
            int x;

            if (mode % 2 == 1)
                x = 1;
            else
                x = 2;

            var a = new Point[4 * x];
            for (int i = 0; i < (x * 4); i++)
            {
                a[i] = main[c * (x * 4) + i];
            }

            return a;
        }
        public static TextBox MakeStat (TextBox stat, int mainscore)
        {
            stat.Text = "your score: " + mainscore.ToString();
            stat.Size = new Size(800, 400);
            stat.BorderStyle = BorderStyle.None;
            stat.TextAlign = HorizontalAlignment.Center;
            stat.Location = new Point(1280 - 400, 720 - 200);
            stat.Font = GameLodic.Font;
            stat.ForeColor = Color.Black;

            return stat;
        }
    }
}
