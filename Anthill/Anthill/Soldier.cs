using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Anthill
{
    public class Soldier:Ant
    {
        int xx, yy;
        public Soldier(int size, int consumed_food, int lifetime,int x,int y) : base(size, consumed_food, lifetime)
        {
            this.x = x;
            this.y = y;
            Draw();
            Kill();
        }
        public void Kill()
        {
            Form1.T.Elapsed += K;
        }
        public void K(Object o, ElapsedEventArgs e)
        {
            foreach (Pest pest in Form1.Pests)
            {
                if ((Math.Sqrt(Math.Pow(x - pest.x, 2) + Math.Pow(y - pest.y, 2))) <= 40)
                {
                    pest.dead = true;
                }
            }
            Form1.Pests.RemoveAll(Dead_pest);
            if (this.dead) Form1.T.Elapsed -= K;                
        }
        public bool Dead_pest(Pest pest)
        {
            return pest.dead;
        }
        public void Draw()
        {            
            do
            {
                xx = r.Next(-2, 3);
                yy = r.Next(-2, 3);
            }
            while (Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2)) <= 1.3);
            Form1.T.Elapsed += S;                                    
        }
        public void S(Object o, ElapsedEventArgs e)
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
                Form1.g.FillRectangle(new SolidBrush(Color.Black), x, y, size, size);
            }
            else Form1.T.Elapsed -= S;
        }
    }
}
