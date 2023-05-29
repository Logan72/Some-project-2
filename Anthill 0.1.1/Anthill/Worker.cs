using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Anthill
{
    class Worker:Ant
    {        
        int xx, yy;
        public Worker(int size, int consumed_food, int lifetime,int x,int y) : base(size, consumed_food, lifetime)
        {
            this.x = x;
            this.y = y;
            Draw();
            Made_food(food);
        }        
        public void Made_food(Food food)
        {           
            t.Elapsed += Increase;                   
        }
        public void Increase(object o,ElapsedEventArgs e)
        {
            food.width += r.Next(4, 7);           
        }
        public void Draw()
        {            
            do
            {
                xx = r.Next(-2, 3);
                yy = r.Next(-2, 3);
            }
            while (Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2)) <= 1.3);
            Form1.T.Elapsed += W;    
        }
        public void W(Object o, ElapsedEventArgs e)
        {
            Form1.g.FillEllipse(new SolidBrush(Color.White), x, y, size, size);
            if (!this.dead)
            {
                x += xx;
                y += yy;
                if ((x < 195) || (x > 1335) || (y < 50) || (y > 675))
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
                Form1.g.FillEllipse(new SolidBrush(Color.Black), x, y, size, size);
            }
            else Form1.T.Elapsed -= W;
        }
    }
}
