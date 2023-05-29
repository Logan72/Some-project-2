using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Anthill
{
    public class Potential:Ant
    {
        public int xc, yc;
        public Potential(int size, int consumed_food, int lifetime):base(size,consumed_food,lifetime)
        {            
            this.x = r.Next(195, 1335);
            this.y = r.Next(50, 675);
            xc = this.x + 8;
            yc = this.y + 8;
            Draw();
        }
        public void Draw()
        {
            Form1.T.Elapsed+=P;
        }
        public void P(object o, ElapsedEventArgs e)
        {
            if (Form1.B)
            {
                Form1.B = false;
                Form1.long_soldier++;
                new Worker(15, 1, r.Next(25000, 32000), x, y);
                if (Form1.long_soldier == 5)
                {
                    Form1.long_soldier = 0;
                    new Soldier(18, 3,60000, r.Next(195,1332), r.Next(50,672),Color.LimeGreen);
                }
                this.dead = true;
            }
            if (!this.dead) Form1.g.FillEllipse(new SolidBrush(Color.Blue), x, y, size, size);
            else
            {
                Form1.g.FillEllipse(new SolidBrush(Color.White), x, y, size, size);
                Form1.T.Elapsed -= P;
            }
        }
    }
}
