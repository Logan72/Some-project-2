using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Anthill
{
    class Queen:Ant
    {
        int xx, yy;
        public Queen(int size, int consumed_food, int lifetime) : base(size, consumed_food, lifetime)
        {
            x = r.Next(202, 350);
            y = r.Next(50, 760);
            Draw();
            Breed();
        }
        public void Breed()
        {                       
            Timer t = new Timer(r.Next(14000, 18000));
            t.AutoReset = true;
            t.Elapsed += (o, e) =>
            {                            
                if ((this.dead) || (!Form1.T.Enabled))
                {
                    t.Dispose();
                }
                else
                    for (int i = 1; i <= r.Next(5, 8); ++i)
                    {
                        GC.Collect();
                        new Egg(6, 1, r.Next(6000, 10000));
                    }
            };
            t.Start();
        }

        public void Draw()
        {
            do
            {
                xx = r.Next(-2, 3);
                yy = r.Next(-2, 3);
            }
            while (Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2)) <= 1.3);
            Form1.T.Elapsed += Q;
        }
        public void Q(Object o, ElapsedEventArgs e)
        {
            if (!this.dead)
            {
                x += xx;
                y += yy;
                while ((x <= 202) || (x >= 350) || (y <= 50) || (y >= 690))
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
                Form1.g.FillEllipse(new SolidBrush(Color.Gold), x, y, size, size);
            }
            else Form1.T.Elapsed -= Q;
        }
    }
}
