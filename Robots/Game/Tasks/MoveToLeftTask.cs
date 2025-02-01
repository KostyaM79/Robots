using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game.Tasks
{
    public class MoveToLeftTask : IRobotTask
    {
        private Directions direction;
        private int steps;
        private Random rnd = new Random();

        public MoveToLeftTask()
        {
            direction = Directions.Left;
            steps = rnd.Next(1, 11);
        }

        public Directions Direction => direction;

        public int Steps => steps;

        public bool CanMove(IField field, Robot robot, IPositionCalculator calc, List<Robot> robots)
        {
            bool canMoveLeft = calc.CanMoveToLeft(field, robot, robots);
            return canMoveLeft && steps > 0;
        }

        public void Move(Robot robot, IField field)
        {
            if (steps > 0)
            {
                robot.SetPosition(field.NormalizeX(robot.X - 1), robot.Y);
                steps--;
            }
        }
    }
}
