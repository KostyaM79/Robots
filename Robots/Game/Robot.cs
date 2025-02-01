using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Robots.Game
{
    public class Robot
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Pathfinder pathfinder;

        public Robot(int width, int height)
        {
            this.width = width;
            this.height = height;
            pathfinder = new Pathfinder(this);
        }

        public IRobotTask CurrentTask { get; set; }

        public int Width => width;
        public int Height => height;
        public int X => x;
        public int Y => y;

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Возаращает список свободных направлений
        /// </summary>
        /// <param name="field"></param>
        /// <param name="robots"></param>
        /// <returns></returns>
        public List<Directions> GetFreeDirections(IField field, List<Robot> robots)
        {
            List<Directions> dir = new List<Directions>();

            //Если путь влево свободен, то добавляем Directions.Left в список свободных направлений
            if (pathfinder.LeftSideClear(field, robots)) dir.Add(Directions.Left);
            if (pathfinder.RightSideClear(field, robots)) dir.Add(Directions.Right);
            if (pathfinder.UpSideClear(field, robots)) dir.Add(Directions.Up);
            if (pathfinder.DownSideClear(field, robots)) dir.Add(Directions.Down);

            return dir;     //Возвращаем список свободных направлений текущего робота
        }
    }
}
