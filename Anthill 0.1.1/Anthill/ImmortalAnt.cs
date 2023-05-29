using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Anthill
{
    public class ImmortalAnt:Ant
    {
        public int xc, yc;
        public ImmortalAnt(int size, int consumed_food, int lifetime):base(size,consumed_food,lifetime)
        {
            this.x = r.Next(195, 1332);
            this.y = r.Next(50, 672);
            this.xc = x + 9;
            this.yc = y + 9;
            Draw();

        }
        public void Draw()
        {
            Form1.T.Elapsed += IA;
        }
        public void IA(object o,ElapsedEventArgs e)
        {
            if(Form1.B1)
            {
                Form1.B1 = false;
                new Soldier(18, 0, 900000, x,y, Color.LightSlateGray);
                this.dead = true;
            }
            if (!this.dead) Form1.g.FillRectangle(new SolidBrush(Color.SkyBlue), x, y, size, size);
            else
            {
                Form1.g.FillRectangle(new SolidBrush(Color.White), x, y, size, size);
                Form1.T.Elapsed -= IA;
            }
        }
    }
}
