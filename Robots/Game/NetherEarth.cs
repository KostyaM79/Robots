using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Game.Tasks;

namespace Robots.Game
{
    public class NetherEarth : IGame
    {
        private int resolution = 8;
        private List<Robot> robots = new List<Robot>();
        private IField field;
        private int paintAreaX = 0;
        private int paintAreaY = 300;
        private int paintAreaWidth;
        private int paintAreaHeight = 128;
        private int offset = 0;
        private Robot selectedRobot;

        public int PaintAreaX => paintAreaX;
        public int PaintAreaY => paintAreaY;
        public int PaintAreaWidth => paintAreaWidth;
        public int PaintAreaHeight => paintAreaHeight;

        public int Offset
        {
            get => offset;
            set => offset = value;
        }

        public Robot SelectedRobot => selectedRobot;

        public NetherEarth() { }

        public void Start(int width, int height)
        {
            paintAreaWidth = width;
            field = new NetherEarthField(paintAreaWidth / resolution, paintAreaHeight / resolution);

            foreach (Robot r in robots)
            {
                r.SetPosition(10, 8);
                r.CurrentTask = new MoveToDownTask();
            }
        }

        public void MoveRobots(IView view)
        {
            //Random rnd = new Random();
            TaskGenerator taskGenerator = new TaskGenerator();
            IPositionCalculator positionCalculator = new NetherEarthPositionCalculator();

            //Если текущую задачу выполнить невозможно, то случайным образом выбираем новую задачу и снова проверяем на возможность её выполнения.
            //Когда будет получена задача, которую возможно выполнить, продолжим движение робота
            foreach (Robot r in robots)
            {
                //Если направление движения робота свободно, двигаем его на 1 шаг
                if (r.CurrentTask.CanMove(field, r, positionCalculator, robots))
                    r.CurrentTask.Move(r, field);

                //Если на пути препятствие или другой робот, или граница игрового поля, то ищем любое другое свободное напраление
                //else r.CurrentTask = taskGenerator.GetTask(Directions.Right);
                else r.CurrentTask = taskGenerator.GetTask(Directions.Right, r.GetFreeDirections(field, robots));
            }

            view.UpdateScreen(field, robots, resolution);
        }

        public void CreateRobot()
        {
            Robot robot = new Robot(2, 2);
            robot.CurrentTask = new MoveToDownTask();
            robot.SetPosition(10, 8);
            robots.Add(robot);
        }

        public void SelectRobot(IView view, int x, int y)
        {
            RobotSelector selector = new RobotSelector();
            foreach (Robot r in robots)
            {
                if (selector.SelectRobot(r.X * resolution - offset, (r.Y * resolution + paintAreaY), x, y))
                {
                    selectedRobot = r;
                    view.UpdateScreen(field, robots, resolution);
                }
            }
        }
    }
}
