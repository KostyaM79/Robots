using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Game.Tasks;

namespace Robots.Game
{
    public class TaskGenerator
    {
        Random rnd = new Random();
        ITaskFactory[] factories = new ITaskFactory[] { new MoveDownFactory(), new MoveLeftFactory(), new MoveRightFactory(), new MoveUpFactory() };

        public IRobotTask GetTask()
        {
            int c = rnd.Next(1, 1001);

            if (c >= 1 && c < 251) return new MoveToRightTask();
            if (c >= 251 && c < 500) return new MoveToDownTask();
            if (c >= 501 && c < 750) return new MoveToLeftTask();
            return new MoveToUpTask();
        }

        public IRobotTask GetTask(List<Directions> directions)
        {
            int c = directions.Count;

            if (c > 0)
            {
                int i = rnd.Next(0, c);
                ITaskFactory f = factories.First(e => e.Direction == directions[i]);
                return f.CreateTask();
            }
            else return new NullMoveTask();
        }

        public IRobotTask GetTask(Directions priorityDirection, List<Directions> freeDirections)
        {
            switch (priorityDirection)
            {
                case Directions.Right: return RightPriority(freeDirections);
                case Directions.Down: return DownPriority();
                case Directions.Left: return LeftPriority();
                case Directions.Up: return UpPriority();
                default: return null;
            }
        }

        private IRobotTask RightPriority(List<Directions>directions)
        {
            if (directions.Count > 0)
            {
                int c = rnd.Next(1, 1001);
                List<ITaskFactory> factoryList = GetFactories(directions);
                ITaskFactory actualFactory = null;

                if (c >= 1 && c < 701)
                {
                    actualFactory = factoryList.Find(e => e.Direction == Directions.Right);    //Пытаемся получить сначала фабрику для задачи "Двигаться вправо"
                    //return CreateTask(actualFactory, factoryList);
                    return CreateTask(actualFactory, factoryList, 4, 16);
                }

                if (c >= 701 && c < 801)
                {
                    actualFactory = factoryList.Find(e => e.Direction == Directions.Down);     //Пытаемся получить сначала фабрику для задачи "Двигаться вниз"
                    return CreateTask(actualFactory, factoryList);
                }

                if (c >= 801 && c < 901)
                {
                    actualFactory = factoryList.Find(e => e.Direction == Directions.Left);     //Пытаемся получить сначала фабрику для задачи "Двигаться влево"
                    return CreateTask(actualFactory, factoryList);
                }

                actualFactory = factoryList.Find(e => e.Direction == Directions.Up);           //Пытаемся получить сначала фабрику для задачи "Двигаться вправо"
                return CreateTask(actualFactory, factoryList);
            }

            else return new NullMoveTask();
        }

        private IRobotTask DownPriority()
        {
            int c = rnd.Next(1, 1001);

            if (c >= 1 && c < 101) return new MoveToRightTask();
            if (c >= 101 && c < 801) return new MoveToDownTask();
            if (c >= 801 && c < 901) return new MoveToLeftTask();
            return new MoveToUpTask();
        }

        private IRobotTask LeftPriority()
        {
            int c = rnd.Next(1, 1001);

            if (c >= 1 && c < 101) return new MoveToRightTask();
            if (c >= 101 && c < 201) return new MoveToDownTask();
            if (c >= 201 && c < 901) return new MoveToLeftTask();
            return new MoveToUpTask();
        }

        private IRobotTask UpPriority()
        {
            int c = rnd.Next(1, 1001);

            if (c >= 1 && c < 101) return new MoveToRightTask();
            if (c >= 101 && c < 201) return new MoveToDownTask();
            if (c >= 201 && c < 301) return new MoveToLeftTask();
            return new MoveToUpTask();
        }

        private List<ITaskFactory> GetFactories(List<Directions> freeDirections)
        {
            List<ITaskFactory> fac = new List<ITaskFactory>();                                      //Создаём коллекцию для фабрик
            foreach (Directions d in freeDirections) fac.Add(factories.First(e => e.Direction == d));   //Получаем только фабрики, соответствующие свободным направлениям
            return fac;
        }

        private IRobotTask CreateAnyTask(List<ITaskFactory>fac)
        {
            int i = rnd.Next(0, fac.Count);
            return fac[i].CreateTask();
        }

        private IRobotTask CreateTask(ITaskFactory factory, List<ITaskFactory> factoryList)
        {
            if (factory == null) return CreateAnyTask(factoryList);
            else return factory.CreateTask();
        }

        private IRobotTask CreateTask(ITaskFactory factory, List<ITaskFactory> factoryList, int minLenght, int maxLenght)
        {
            if (factory == null) return CreateAnyTask(factoryList);
            else return factory.CreateTask(minLenght, maxLenght);
        }
    }
}
