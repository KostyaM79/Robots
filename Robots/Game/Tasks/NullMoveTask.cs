using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game.Tasks
{
    public class NullMoveTask : IRobotTask
    {
        public Directions Direction => throw new NotImplementedException();

        public int Steps => throw new NotImplementedException();

        public bool CanMove(IField field, Robot robot, IPositionCalculator calc, List<Robot> robots)
        {
            return false;
        }

        public void Move(Robot robot, IField field)
        {
            
        }
    }
}
