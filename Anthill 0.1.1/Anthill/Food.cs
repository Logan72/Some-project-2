using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Anthill
{
    public class Food
    {
        public int width_before;
        public int width;
        public int height = 15;
        public Food(int width)
        {
            this.width = width;            
        }
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 200, 0, width_before, height);
            g.FillRectangle(new SolidBrush(Color.Green), 200, 0, width, height);
            width_before = width;
        }
    }
}
