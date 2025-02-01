using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Game.Blocks;

namespace Robots.Game
{
    public class NetherEarthField : IField
    {
        private bool[,] field;

        public NetherEarthField(int width, int height)
        {
            field = new bool[487, height];
            FillField(field, 487, height);
        }

        public bool this[int x, int y]
        {
            get => field[x, y];
            set => field[x, y] = value;
        }

        public int Width => field.GetLength(0);

        public int Height => field.GetLength(1);

        public int NormalizeX(int x)
        {
            if (x < 0) return Width + x;
            if (x > Width - 1) return x - Width;
            return x;
        }

        public int NormalizeY(int y)
        {
            if (y < 0) return Height + y;
            if (y > Height - 1) return y - Height;
            return y;
        }

        private void FillField(bool[,] f, int width, int height)
        {
            Block block = new Block();
            Factory factory = new Factory();
            HorisontalWall horisontalWall = new HorisontalWall();
            VerticalWall verticalWall = new VerticalWall();
            Base _base = new Base();
            HorisontalTripleBlock tripleBlock = new HorisontalTripleBlock();
            LeftBound bound = new LeftBound();

            BlocksBase b = new LeftBound();
            b.CreateBlock(this, 0, 0);

            _base.CreateBlock(this, 6, 1);

            block.CreateBlock(this, 4, 13);
            block.CreateBlock(this, 20, 2);

            factory.CreateBlock(this, 25, 3);
            factory.CreateBlock(this, 37, 0);
            factory.CreateBlock(this, 46, 7);

            block.CreateBlock(this, 49, 1);
            block.CreateBlock(this, 51, 1);
            block.CreateBlock(this, 56, 0);
            block.CreateBlock(this, 56, 12);
            block.CreateBlock(this, 58, 12);

            factory.CreateBlock(this, 63, 0);
            factory.CreateBlock(this, 81, 0);

            horisontalWall.CreateBlock(this, 80, 12);
            horisontalWall.CreateBlock(this, 91, 3);
            horisontalWall.CreateBlock(this, 93, 10);

            verticalWall.CreateBlock(this, 106, 8);

            factory.CreateBlock(this, 108, 0);

            block.CreateBlock(this, 112, 11);
            block.CreateBlock(this, 114, 6);

            horisontalWall.CreateBlock(this, 119, 3);

            block.CreateBlock(this, 118, 10);
            block.CreateBlock(this, 118, 12);

            factory.CreateBlock(this, 123, 8);
            factory.CreateBlock(this, 143, 2);
            factory.CreateBlock(this, 163, 0);

            horisontalWall.CreateBlock(this, 176, 2);
            horisontalWall.CreateBlock(this, 176, 7);
            horisontalWall.CreateBlock(this, 176, 12);

            horisontalWall.CreateBlock(this, 184, 2);
            horisontalWall.CreateBlock(this, 184, 7);
            horisontalWall.CreateBlock(this, 184, 12);

            horisontalWall.CreateBlock(this, 192, 2);

            block.CreateBlock(this, 192, 7);
            block.CreateBlock(this, 194, 7);

            horisontalWall.CreateBlock(this, 192, 12);
            horisontalWall.CreateBlock(this, 200, 12);
            horisontalWall.CreateBlock(this, 208, 12);

            block.CreateBlock(this, 214, 10);

            factory.CreateBlock(this, 200, 0);
            factory.CreateBlock(this, 210, 6);

            verticalWall.CreateBlock(this, 218, 6);

            block.CreateBlock(this, 218, 14);

            factory.CreateBlock(this, 224, 0);

            _base.CreateBlock(this, 242, 0);

            factory.CreateBlock(this, 264, 0);
            factory.CreateBlock(this, 270, 10);

            block.CreateBlock(this, 273, 2);

            factory.CreateBlock(this, 278, 0);

            block.CreateBlock(this, 283, 8);

            factory.CreateBlock(this, 292, 4);

            block.CreateBlock(this, 290, 12);

            factory.CreateBlock(this, 301, 0);

            block.CreateBlock(this, 301, 9);
            block.CreateBlock(this, 303, 11);
            block.CreateBlock(this, 305, 13);
            block.CreateBlock(this, 310, 11);

            horisontalWall.CreateBlock(this, 317, 4);
            horisontalWall.CreateBlock(this, 317, 8);

            block.CreateBlock(this, 319, 2);
            block.CreateBlock(this, 319, 12);

            horisontalWall.CreateBlock(this, 325, 4);
            horisontalWall.CreateBlock(this, 325, 8);

            block.CreateBlock(this, 324, 0);
            block.CreateBlock(this, 323, 12);
            block.CreateBlock(this, 323, 14);
            block.CreateBlock(this, 325, 14);
            block.CreateBlock(this, 327, 14);
            block.CreateBlock(this, 327, 10);

            verticalWall.CreateBlock(this, 333, 8);

            block.CreateBlock(this, 331, 0);
            block.CreateBlock(this, 331, 2);
            block.CreateBlock(this, 337, 4);
            block.CreateBlock(this, 339, 4);
            block.CreateBlock(this, 341, 4);

            _base.CreateBlock(this, 346, 0);


            block.CreateBlock(this, 360, 5);

            factory.CreateBlock(this, 365, 0);
            block.CreateBlock(this, 375, 0);

            factory.CreateBlock(this, 380, 4);

            block.CreateBlock(this, 382, 14);
            block.CreateBlock(this, 392, 0);

            factory.CreateBlock(this, 397, 0);
            factory.CreateBlock(this, 417, 2);
            factory.CreateBlock(this, 427, 0);
            factory.CreateBlock(this, 437, 7);

            block.CreateBlock(this, 447, 9);
            block.CreateBlock(this, 450, 12);

            factory.CreateBlock(this, 447, 0);

            tripleBlock.CreateBlock(this, 457, 4);
            tripleBlock.CreateBlock(this, 463, 4);
            tripleBlock.CreateBlock(this, 459, 2);
            tripleBlock.CreateBlock(this, 461, 0);


            tripleBlock.CreateBlock(this, 457, 8);
            tripleBlock.CreateBlock(this, 459, 10);
            tripleBlock.CreateBlock(this, 461, 12);
            tripleBlock.CreateBlock(this, 463, 14);

            _base.CreateBlock(this, 473, 0);

            bound.CreateBlock(this, 485, 0);
        }
    }
}
