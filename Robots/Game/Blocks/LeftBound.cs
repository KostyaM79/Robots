using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots.Game.Blocks
{
    public class LeftBound : BlocksBase
    {
        public LeftBound()
        {
            points = new Point[]
            {
                new Point(1, 0),
                new Point(1, 2),
                new Point(1, 4),
                new Point(1, 6),
                new Point(1, 8),
                new Point(1, 10),
                new Point(1, 12),
                new Point(1, 14)
            };

        }
    }
}
