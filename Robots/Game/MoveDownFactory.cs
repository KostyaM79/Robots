using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Game.Tasks;

namespace Robots.Game
{
    public class MoveDownFactory : ITaskFactory
    {
        public Directions Direction => Directions.Down;

        public IRobotTask CreateTask() => new MoveToDownTask();

        public IRobotTask CreateTask(int minLong, int maxLong)
        {
            throw new NotImplementedException();
        }
    }
}
