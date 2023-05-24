using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Anthill
{
    public abstract class Animal
    {
        public Timer t = new Timer(r.Next(2000, 3000));
        public int x, y;
        public static Random r = new Random();
        public static Food food;
        public bool dead = false;
        public int size;
        public int consumed_food;        
        public Animal (int size,int consumed_food)
        {
            this.size = size;
            this.consumed_food = consumed_food;
            Eat(food);
        }       
        public void Eat(Food food)
        {            
            t.AutoReset = true;
            t.Elapsed += E;            
            t.Start();            
        }
        public void E(object o, ElapsedEventArgs e)
        {            
            if ((this.dead) || (!Form1.T.Enabled))
            {
                t.Dispose();
                GC.Collect();
            }
            else food.width -= consumed_food;    
        }
    }
}
