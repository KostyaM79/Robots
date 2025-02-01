using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Game.Tasks;

namespace Robots.Game
{
    public class MoveLeftFactory : ITaskFactory
    {
        public Directions Direction => Directions.Left;

        public IRobotTask CreateTask() => new MoveToLeftTask();

        public IRobotTask CreateTask(int minLong, int maxLong)
        {
            throw new NotImplementedException();
        }
    }
}
