using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public class NetherEarthPositionCalculator : IPositionCalculator
    {
        private Random rnd = new Random();

        public void CalculateStartPosition(IField field, Robot robot)
        {
            throw new NotImplementedException();
        }

        public bool CanMoveToDown(IField field, Robot robot, List<Robot> robots)
        {
            int bottomY = robot.Y + 2;
            bool isRobot = false;

            foreach (Robot r in robots)
                if (!r.Equals(robot) && ((r.X == robot.X - 1 || r.X == robot.X || r.X == robot.X + 1) && (r.Y == bottomY)))
                {
                    isRobot = true;
                    break;
                }

            if ((robot.Y < field.Height - 2 && !(field[robot.X, robot.Y + 2]) && !field[robot.X + 1, robot.Y + 2]) && !isRobot) return true;
            else return false;
        }

        public bool CanMoveToLeft(IField field, Robot robot, List<Robot> robots)
        {
            int leftX = robot.X - 2;
            bool isRobot = false;

            foreach (Robot r in robots)
                if (!r.Equals(robot) && ((r.Y == robot.Y - 1 || r.Y == robot.Y || r.Y == robot.Y + 1) && (r.X == leftX)))
                {
                    isRobot = true;
                    break;
                }

            if ((robot.X > 0 && !field[robot.X - 1, robot.Y] && !field[robot.X - 1, robot.Y + 1]) && !isRobot) return true;
            else return false;
        }

        public bool CanMoveToRight(IField field, Robot robot, List<Robot> robots)
        {
            int rightX = robot.X + 2;
            bool isRobot = false;

            foreach (Robot r in robots)
                if (!r.Equals(robot) && ((r.Y == robot.Y - 1 || r.Y == robot.Y || r.Y == robot.Y + 1) && (r.X == rightX)))
                {
                    isRobot = true;
                    break;
                }

            if ((robot.X < field.Width-2 && !field[robot.X + 2, robot.Y] && !field[robot.X + 2, robot.Y + 1]) && !isRobot) return true;
            else return false;
        }

        public bool CanMoveToUp(IField field, Robot robot, List<Robot> robots)
        {
            int topY = robot.Y - 2;
            bool isRobot = false;

            foreach (Robot r in robots)
                if (!r.Equals(robot) && ((r.X == robot.X - 1 || r.X == robot.X || r.X == robot.X + 1) && (r.Y == topY)))
                {
                    isRobot = true;
                    break;
                }

            if ((robot.Y > 0 && !field[robot.X, robot.Y - 1] && !field[robot.X + 1, robot.Y - 1]) && !isRobot) return true;
            else return false;
        }


    }
}
