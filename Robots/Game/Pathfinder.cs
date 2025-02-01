using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public class Pathfinder
    {
        private readonly Robot currentRobot;

        public Pathfinder(Robot robot) => currentRobot = robot;

        public bool LeftSideClear(IField field, List<Robot> robots)
        {
            return ((currentRobot.X > 0) && !RobotOnTheLeft(robots) && !ObstacleOnTheLeft(field));
        }

        /// <summary>
        /// Возвращает если слева на пути стоит другой робот, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        private bool RobotOnTheLeft(List<Robot> robots)
        {
            if (robots.Count < 2) return false;                  //Если в игре всего один робот, то сразу возвращаем false. Дальнейшие действия бессмыслены
            if (currentRobot.X < 2) return false;                //Если расстояние до левой границы игрового поля менее ширины робота, то сразу возвращаем false, т.к. там не может быть робота

            // Создаём очередь из роботов, в которую включены все роботы, кроме текущего
            Queue<Robot> robotsQueue = new Queue<Robot>();
            foreach (Robot r in robots) 
                if (!r.Equals(currentRobot)) robotsQueue.Enqueue(r);

            while (robotsQueue.Count > 0)
            {
                Robot robot = robotsQueue.Dequeue();                                                //Берём робота из очереди
                if (((robot.Y <= currentRobot.Y + 1) && (robot.Y >= currentRobot.Y + 1) && robot.X == currentRobot.X - 2)) return true;    //Если очередной робот стоит у нас на пути, то возвращаем true
            }

            //Если робот, стоящий у нас на пути, не найден, возвращаем false
            return false;
        }

        /// <summary>
        /// Возвращает true, если слева на пути стоит препятствие, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool ObstacleOnTheLeft(IField field)
        {
            return (field[currentRobot.X - 1, currentRobot.Y] || field[currentRobot.X - 1, currentRobot.Y + 1]);
        }



        /// <summary>
        /// Возвращает true, если путь справа свободен
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        public bool RightSideClear(IField field, List<Robot> robots)
        {
            return ((currentRobot.X < field.Width - 2) && !RobotOnTheRight(field, robots) && !ObstacleOnTheRight(field));
        }

        /// <summary>
        /// Возвращает если слева на пути стоит другой робот, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        private bool RobotOnTheRight(IField field, List<Robot> robots)
        {
            if (robots.Count < 2) return false;                     //Если в игре всего один робот, то сразу возвращаем false. Дальнейшие действия бессмыслены
            if (currentRobot.X > field.Width - 4) return false;     //Если расстояние до правой границы игрового поля менее ширины робота, то сразу возвращаем false, т.к. там не может быть робота

            // Создаём очередь из роботов, в которую включены все роботы, кроме текущего
            Queue<Robot> robotsQueue = new Queue<Robot>();
            foreach (Robot r in robots) if (!r.Equals(this)) robotsQueue.Append(r);

            while (robotsQueue.Count > 0)
            {
                Robot robot = robotsQueue.Dequeue();                                                            //Берём робота из очереди
                if (((robot.Y <= currentRobot.Y + 1) && (robot.Y >= currentRobot.Y + 1) && robot.X == currentRobot.X + 2)) return true;   //Если очередной робот стоит у нас на пути, то возвращаем true
            }

            //Если робот, стоящий у нас на пути, не найден, возвращаем false
            return false;
        }

        /// <summary>
        /// Возвращает true, если слева на пути стоит препятствие, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool ObstacleOnTheRight(IField field)
        {
            return (field[currentRobot.X + 2, currentRobot.Y] || field[currentRobot.X + 2, currentRobot.Y + 1]);
        }



        /// <summary>
        /// Возвращает true, если путь вверх свободен
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        public bool UpSideClear(IField field, List<Robot> robots)
        {
            return ((currentRobot.Y > 0) && !RobotOnTheUp(robots) && !ObstacleOnTheUp(field));
        }

        /// <summary>
        /// Возвращает true, если сыерху на пути стоит другой робот, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        private bool RobotOnTheUp(List<Robot> robots)
        {
            if (robots.Count < 2) return false;         //Если в игре всего один робот, то сразу возвращаем false. Дальнейшие действия бессмыслены
            if (currentRobot.Y < 2) return false;                    //Если расстояние до верхней границы игрового поля менее высоты робота, то сразу возвращаем false, т.к. там не может быть робота

            // Создаём очередь из роботов, в которую включены все роботы, кроме текущего
            Queue<Robot> robotsQueue = new Queue<Robot>();
            foreach (Robot r in robots) if (!r.Equals(this)) robotsQueue.Append(r);

            while (robotsQueue.Count > 0)
            {
                Robot robot = robotsQueue.Dequeue();                                        //Берём робота из очереди

                if (robot.Y != currentRobot.Y - 2) continue;                                //Если другой робот по оси Y выше или ниже нашего робота более чем на 1 шаг,
                                                                                            //то переходим к следдующему роботу

                if ((robot.X >= currentRobot.X - 1) && (robot.X <= currentRobot.X + 1)) return true;     //Если очередной робот стоит у нас на пути, то возвращаем true
            }

            //Если робот, стоящий у нас на пути, не найден, возвращаем false
            return false;
        }

        /// <summary>
        /// Возвращает true, если сверху на пути стоит препятствие, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool ObstacleOnTheUp(IField field)
        {
            return (field[currentRobot.X, currentRobot.Y - 1] || field[currentRobot.X + 1, currentRobot.Y - 1]);
        }



        /// <summary>
        /// Возвращает true, если путь вниз свободен
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        public bool DownSideClear(IField field, List<Robot> robots)
        {
            return ((currentRobot.Y < field.Height - 2) && !RobotOnTheDown(field, robots) && !ObstacleOnTheDown(field));
        }

        /// <summary>
        /// Возвращает true, если внизу на пути стоит другой робот, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        private bool RobotOnTheDown(IField field, List<Robot> robots)
        {
            if (robots.Count < 2) return false;                     //Если в игре всего один робот, то сразу возвращаем false. Дальнейшие действия бессмыслены
            if (currentRobot.Y > field.Height - 4) return false;    //Если расстояние до нижней границы игрового поля менее высоты робота, то сразу возвращаем false, т.к. там не может быть робота

            // Создаём очередь из роботов, в которую включены все роботы, кроме текущего
            Queue<Robot> robotsQueue = new Queue<Robot>();
            foreach (Robot r in robots) if (!r.Equals(this)) robotsQueue.Append(r);

            while (robotsQueue.Count > 0)
            {
                Robot robot = robotsQueue.Dequeue();                                    //Берём робота из очереди

                if (robot.Y != currentRobot.Y + 2) continue;                                         //Если другой робот по оси Y выше или ниже нашего робота более чем на 1 шаг,
                                                                                        //то переходим к следдующему роботу

                if ((robot.X >= currentRobot.X - 1) && (robot.X <= currentRobot.X + 1)) return true; //Если очередной робот стоит у нас на пути, то возвращаем true
            }

            //Если робот, стоящий у нас на пути, не найден, возвращаем false
            return false;
        }

        /// <summary>
        /// Возвращает true, если сверху на пути стоит препятствие, иначе - false
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool ObstacleOnTheDown(IField field)
        {
            return (field[currentRobot.X, currentRobot.Y + 2] || field[currentRobot.X + 1, currentRobot.Y + 2]);
        }
    }
}
