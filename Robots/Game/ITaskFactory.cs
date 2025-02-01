using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public interface ITaskFactory
    {
        Directions Direction { get; }

        IRobotTask CreateTask();

        IRobotTask CreateTask(int minLong, int maxLong);
    }
}
