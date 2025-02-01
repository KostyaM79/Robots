using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public interface IView
    {
        void UpdateScreen(IField field, List<Robot> robots, int resolution);
    }
}
