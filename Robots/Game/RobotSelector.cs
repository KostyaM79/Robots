using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots.Game
{
    public class RobotSelector
    {
        public bool SelectRobot(int robotX, int robotY, int mouseX, int mouseY)
        {
            Rectangle rect = new Rectangle(robotX, robotY, 16, 16);
            return rect.Contains(mouseX, mouseY);
        }
    }
}
