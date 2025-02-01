using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game.Tasks
{
    public class MoveToRightTask : IRobotTask
    {
        private Directions direction;
        private int steps;
        private Random rnd = new Random();

        public MoveToRightTask()
        {
            direction = Directions.Right;
            steps = rnd.Next(1, 11);
        }

        public MoveToRightTask(int minLenght, int maxLenght)
        {
            direction = Directions.Right;
            steps = rnd.Next(minLenght, maxLenght + 1);
        }

        public Directions Direction => direction;
        public int Steps => steps;

        /// <summary>
        /// Возвращает true, если справа от робота нет препятствия и остались шаги, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robot"></param>
        /// <param name="calc"></param>
        /// <returns></returns>
        public bool CanMove(IField field, Robot robot, IPositionCalculator calc, List<Robot> robots)
        {
            bool canMoveRight = calc.CanMoveToRight(field, robot, robots);
            return canMoveRight && steps > 0;
        }

        public void Move(Robot robot, IField field)
        {
            if (steps > 0)
            {
                robot.SetPosition(field.NormalizeX(robot.X + 1), robot.Y);
                steps--;
            }
        }
    }
}
