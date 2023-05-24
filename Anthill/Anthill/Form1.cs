using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace Anthill
{
    public partial class Form1 : Form
    {
        public static List<Pest> Pests = new List<Pest>();        
        public static Graphics g;
        public static System.Timers.Timer T = new System.Timers.Timer(50);
        System.Timers.Timer TimeToClean = new System.Timers.Timer(5000);
        public Random r = new Random();        
        public Form1()
        {
            InitializeComponent();
            F.Text = "300";
        }

        private void Run_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            try
            {                
                Animal.food = new Food(int.Parse(F.Text));
                if (Animal.food.width<=0) throw new FormatException();
                F.Enabled = false;
                Run.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                timer1.Interval = 100;                            
                timer1.Start();                
                T.Elapsed += (o, ev) =>
                {
                    g.Clear(Color.LightGray);
                    g.FillRectangle(new SolidBrush(Color.Gray), 185, 0, 10, 768);
                };
                Queen queen = new Queen(30, 10, 1200000);                              
                T.Elapsed += (o, ev) =>
                {
                    if (Animal.food.width > 0) Animal.food.Draw(g);
                    else
                    {
                        TimeToClean.Dispose();
                        T.Dispose();
                        MessageBox.Show("No more food left! See you soon ...");
                        Application.Exit();
                    }
                    if (queen.dead)
                    {
                        TimeToClean.Dispose();
                        T.Dispose();
                        MessageBox.Show("The Queen of the ants is gone ...");
                        Application.Exit();
                    }
                };
                T.AutoReset = true;
                TimeToClean.AutoReset = true;
                TimeToClean.Elapsed += (o, ev) => GC.Collect();
                Thread.Sleep(500);
                TimeToClean.Start();
                T.Start();                
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите натуральное число большее 0!");
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            for (int i = 1; i <= 5; ++i) 
            {
                Pests.Add(new Pest(20,3));                
            }            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Animal.food.width.ToString();
        }            
        private void button2_Click(object sender, EventArgs e)
        {
            Animal.food.width += 100;
        }
    }
}
