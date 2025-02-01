using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Game
{
    public interface IPositionCalculator
    {
        void CalculateStartPosition(IField field, Robot robot);

        bool CanMoveToRight(IField field, Robot robot, List<Robot> robots);

        bool CanMoveToLeft(IField field, Robot robot, List<Robot> robots);

        bool CanMoveToUp(IField field, Robot robot, List<Robot> robots);

        bool CanMoveToDown(IField field, Robot robot, List<Robot> robots);
    }
}
