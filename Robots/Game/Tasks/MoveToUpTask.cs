using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game.Tasks
{
    public class MoveToUpTask : IRobotTask
    {
        private Directions direction;
        private int steps;
        private Random rnd = new Random();

        public MoveToUpTask()
        {
            direction = Directions.Up;
            steps = rnd.Next(1, 11);
        }
        public Directions Direction => direction;

        public int Steps => steps;

        public bool CanMove(IField field, Robot robot, IPositionCalculator calc, List<Robot> robots)
        {
            bool canMoveUp = calc.CanMoveToUp(field, robot, robots);
            return canMoveUp && steps > 0;
        }

        public void Move(Robot robot, IField field)
        {
            if (steps > 0)
            {
                robot.SetPosition(robot.X, field.NormalizeY(robot.Y - 1));
                steps--;
            }
        }
    }
}
