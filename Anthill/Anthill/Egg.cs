using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Anthill
{
    class Egg:Ant
    {
        public Egg(int size, int consumed_food, int lifetime) : base(size, consumed_food, lifetime)
        {
            x = r.Next(202, 350);
            y = r.Next(50, 690);
            Draw();
        }
        public void Draw()
        {
            Form1.T.Elapsed += E;                    
        }
        public void E(Object o, ElapsedEventArgs e)
        {
            if (!this.dead) Form1.g.FillEllipse(new SolidBrush(Color.Brown), x, y, size, size);
            else
            {                
                switch (r.Next(1, 4))
                {
                    case 1:
                        new Soldier(18, 2, r.Next(25000,32000), x, y);                       
                        break;
                    case 2:
                    case 3:
                        new Worker(14, 1, r.Next(25000, 32000), x, y);                        
                        break;
                }                
                Form1.T.Elapsed -= E;
            }
        }
    }
}
