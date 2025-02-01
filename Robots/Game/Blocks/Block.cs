using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots.Game.Blocks
{
    public class Block : BlocksBase
    {
        public Block()
        {
            points = new Point[]
            {
                new Point(0,0), new Point(1,0),
                new Point(0,1), new Point(1,1)
            };
        }
    }
}
