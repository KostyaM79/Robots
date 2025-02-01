using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots.Game
{
    public abstract class BlocksBase
    {
        protected Point[] points;

        public Point[] Points => points;

        public int minX => points[0].X;

        public int minY => points[0].Y;

        public int maxX => points[points.Length - 1].X;

        public int maxY => points[points.Length - 1].Y;

        public void CreateBlock(IField field, int x, int y)
        {
            foreach (Point p in points) field[p.X + x, p.Y + y] = true;
        }
    }
}
