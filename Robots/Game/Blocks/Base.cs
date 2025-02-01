using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots.Game.Blocks
{
    public class Base : BlocksBase
    {
        public Base()
        {
            points = new Point[]
            {
                new Point(2, 0), new Point(3, 0), new Point(6, 0), new Point(7, 0),
                new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(3, 1), new Point(4, 1), new Point(5, 1), new Point(6, 1), new Point(7, 1), new Point(8, 1), new Point(9, 1),
                new Point(0, 2), new Point(1, 2), new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(5, 2), new Point(6, 2), new Point(7, 2), new Point(8, 2), new Point(9, 2),
                new Point(0, 3), new Point(1, 3), new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(5, 3), new Point(6, 3), new Point(7, 3), new Point(8, 3), new Point(9, 3),
                new Point(0, 4), new Point(1, 4), new Point(2, 4), new Point(3, 4), new Point(4, 4), new Point(5, 4), new Point(6, 4), new Point(7, 4), new Point(8, 4), new Point(9, 4),
                new Point(2, 5), new Point(3, 5), new Point(4, 5), new Point(5, 5), new Point(6, 5), new Point(7, 5),
                new Point(2, 6), new Point(3, 6), new Point(4, 6), new Point(5, 6), new Point(6, 6), new Point(7, 6),
                new Point(2, 7), new Point(3, 7), new Point(6, 7), new Point(7, 7)
            };
        }
    }
}
