using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Game.Tasks;

namespace Robots.Game
{
    public class MoveUpFactory : ITaskFactory
    {
        public Directions Direction => Directions.Up;

        public IRobotTask CreateTask() => new MoveToUpTask();

        public IRobotTask CreateTask(int minLong, int maxLong)
        {
            throw new NotImplementedException();
        }
    }
}
