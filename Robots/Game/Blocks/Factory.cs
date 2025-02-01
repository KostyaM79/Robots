using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots.Game.Blocks
{
    public class Factory : BlocksBase
    {
        public Factory()
        {
            points = new Point[]
            {
                new Point(0,0), new Point(1,0), new Point(2,0), new Point(3,0), new Point(4,0), new Point(5,0),
                new Point(0,1), new Point(1,1), new Point(2,1), new Point(3,1), new Point(4,1), new Point(5,1),
                new Point(0,2), new Point(1,2), new Point(4,2), new Point(5,2),
                new Point(0,3), new Point(1,3), new Point(4,3), new Point(5,3)
            };
        }
    }
}
