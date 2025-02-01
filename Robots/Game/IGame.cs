using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public interface IGame
    {
        int PaintAreaX { get; }
        int PaintAreaY { get; }
        int PaintAreaWidth { get; }
        int PaintAreaHeight { get; }

        int Offset { get; set; }

        Robot SelectedRobot { get; }

        void Start(int width, int height);

        void MoveRobots(IView view);

        void CreateRobot();

        void SelectRobot(IView view, int x, int y);
    }
}
