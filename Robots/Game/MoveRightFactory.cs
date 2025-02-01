using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Game.Tasks;

namespace Robots.Game
{
    public class MoveRightFactory : ITaskFactory
    {
        public Directions Direction => Directions.Right;

        public IRobotTask CreateTask() => new MoveToRightTask();

        public IRobotTask CreateTask(int minLenght, int maxLenght) => new MoveToRightTask(minLenght, maxLenght);
    }
}
