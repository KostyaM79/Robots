using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots.Game.Blocks
{
    public class VerticalWall : BlocksBase
    {
        public VerticalWall()
        {
            points = new Point[]
            {
                new Point(0,0), new Point(1,0), new Point(0,1), new Point(1,1), new Point(0,2), new Point(1,2), new Point(0,3), new Point(1,3),
                new Point(0,4), new Point(1,4), new Point(0,5), new Point(1,5), new Point(0,6), new Point(1,6), new Point(0,7), new Point(1,7)
            };
        }
    }
}
