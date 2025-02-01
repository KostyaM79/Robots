using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public interface IField
    {
        bool this[int x, int y] { get; set; }

        int Width { get; }

        int Height { get; }

        int NormalizeX(int x);

        int NormalizeY(int y);
    }
}
