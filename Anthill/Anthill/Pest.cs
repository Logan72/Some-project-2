using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Anthill
{
    public class Pest:Animal
    {
        int xx, yy;
        public Pest(int size, int consumed_food) : base(size, consumed_food) 
        {
            x = r.Next(202, 1360);
            y = r.Next(50, 760);
            Draw();
        }
        public void Draw()
        {
            do
            {
                xx = r.Next(-2, 3);
                yy = r.Next(-2, 3);
            }
            while (Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2)) <= 1.3);
            Form1.T.Elapsed += P;
        }
        public void P(Object o, ElapsedEventArgs e)
        {
            if (!this.dead)
            {
                x += xx;
                y += yy;
                while ((x <= 202) || (x >= 1350) || (y <= 50) || (y >= 690))
                {
                    do
                    {
                        xx = r.Next(-2, 3);
                        yy = r.Next(-2, 3);
                    }
                    while (Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2)) <= 1.3);
                    x += xx;
                    y += yy;
                }
                Form1.g.FillEllipse(new SolidBrush(Color.Red), x, y, size, size);
            }
            else Form1.T.Elapsed -= P;
        }
    }
}
