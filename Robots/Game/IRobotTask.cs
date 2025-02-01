using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public interface IRobotTask
    {
        Directions Direction { get; }

        int Steps { get; }

        void Move(Robot robot, IField field);

        bool CanMove(IField field, Robot robot, IPositionCalculator calc, List<Robot> robots);
    }
}
