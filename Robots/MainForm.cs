using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robots.Game;

namespace Robots
{
    public partial class MainForm : Form, IView
    {
        private Timer timer = new Timer();

        private IGame game = new NetherEarth();

        private Graphics graphics;
        private Brush robotBrush = Brushes.BlueViolet;

        public MainForm()
        {
            InitializeComponent();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e) => game.MoveRobots(this);

        public void UpdateScreen(IField field, List<Robot> robots, int resolution)
        {
            if (game.SelectedRobot != null)
            {
                label1.Text = $"X = {game.SelectedRobot.X}";
                label2.Text = $"Y = {game.SelectedRobot.Y}";
            }

            graphics.Clear(Color.Black);

            //Рисуем прямоугольник, окаймляющий игровое поле
            graphics.DrawRectangle(new Pen(Brushes.White), 0, game.PaintAreaY - 1, game.PaintAreaWidth - 1, game.PaintAreaHeight + 1);

            //Отображаем игровое поле
            for (int y = 0; y < field.Height; y++)
            {
                for (int x = 0; x < field.Width; x++)
                {
                    if (field[x, y]) graphics.FillRectangle(
                        Brushes.Red,
                        (x * resolution + game.PaintAreaX) - game.Offset,
                        (y * resolution + game.PaintAreaY),
                        resolution,
                        resolution);
                }
            }

            //Отображаем роботов
            foreach (Robot r in robots)
            {
                graphics.FillRectangle(robotBrush,
                    (r.X * resolution + game.PaintAreaX) - game.Offset,
                    (r.Y * resolution) + game.PaintAreaY,
                    (r.Width * resolution),
                    (r.Height * resolution));

                if (r.X > field.Width - 2)
                    graphics.FillRectangle(robotBrush,
                    -((field.Width - r.X) * resolution) + game.PaintAreaX,
                    (r.Y * resolution) + game.PaintAreaY,
                    r.Width * resolution,
                    r.Height * resolution);

                if (r.Y > field.Height - 2)
                    graphics.FillRectangle(robotBrush,
                    (r.X * resolution) + game.PaintAreaX,
                    -((field.Height - r.Y) * resolution) + game.PaintAreaY,
                    r.Width * resolution,
                    r.Height * resolution);
            }

            // Обводим выбранного робота, если он есть.
            if (game.SelectedRobot != null)
                graphics.DrawRectangle(
                    new Pen(Brushes.Yellow),
                    (game.SelectedRobot.X * resolution - game.Offset) - 1,
                    (game.SelectedRobot.Y * resolution - 1) + game.PaintAreaY,
                    (game.SelectedRobot.Width * resolution) + 1,
                    (game.SelectedRobot.Height * resolution) + 1);

            pictureBox1.Refresh();
        }

        private void MainForm_Shown(object sender, EventArgs e) => StartGame();

        private void StartGame()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);                  //Получаем полотно для рисования
            graphics = Graphics.FromImage(pictureBox1.Image);                                       //Создаём объект Graphics
            game.Start(pictureBox1.Width, pictureBox1.Height);                                      //Запускаем игру
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (game.Offset > 0) game.Offset -= 1068;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (game.Offset < 2136) game.Offset += 1068;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.CreateRobot();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            game.SelectRobot(this, e.X, e.Y);
        }
    }
}
