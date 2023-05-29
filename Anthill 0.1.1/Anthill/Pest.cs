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
            x = r.Next(195, 1330);
            y = r.Next(50, 670);
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
            Form1.g.FillEllipse(new SolidBrush(Color.White), x, y, size, size);
            if (!this.dead)
            {
                x += xx;
                y += yy;
                if ((x < 195) || (x > 1330) || (y < 50) || (y > 670))
                {
                    x -= xx;
                    y -= yy;
                    do
                    {
                        xx = r.Next(-2, 3);
                        yy = r.Next(-2, 3);
                    }
                    while (Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2)) <= 1.3);                    
                }            
                Form1.g.FillEllipse(new SolidBrush(Color.Red), x, y, size, size);
            }
            else Form1.T.Elapsed -= P;
        }       
    }
}
