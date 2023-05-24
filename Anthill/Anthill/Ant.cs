using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Anthill
{
    public abstract class Ant : Animal
    {
        Timer t1 = new Timer();
        public int lifetime;
        public Ant(int size, int consumed_food, int lifetime)
            : base(size, consumed_food)
        {
            this.lifetime = lifetime;
            t1.Interval = this.lifetime;
            t1.AutoReset = false;
            t1.Elapsed += Die;
            t1.Start();
        }
        public void Die(object o, ElapsedEventArgs e)
        {
            this.dead = true;
            t1.Dispose();
        }
    }
}
