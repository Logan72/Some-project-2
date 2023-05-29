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
        public static bool B,B1;
        public static List<Pest> Pests;        
        public static Graphics g;
        Potential employee;
        ImmortalAnt immortal;
        int row1,column1,row, column,lifetime,difficulty;
        public static int long_soldier;
        public static System.Timers.Timer T = new System.Timers.Timer(15);
        System.Timers.Timer TimeToAppear = new System.Timers.Timer();
        System.Timers.Timer Employee = new System.Timers.Timer(8000);
        System.Timers.Timer Immortal = new System.Timers.Timer(50000);
        public Random r = new Random();        
        public Form1()
        {
            InitializeComponent();
            F.Text = "500";
            g = CreateGraphics();
            B = false;
            B1 = false;
            Pests = new List<Pest>();
            long_soldier = 0;
        }

        private void Run_Click(object sender, EventArgs e)
        {                     
            label2.Visible = true;
            RC.Visible = true;            
            labelRR.Visible = true;
            labelCC.Visible = true;            
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            F.Enabled = false;
            Run.Enabled = false;            
            if (radioButton1.Checked) { lifetime = 5000; difficulty = 6000; }
            if (radioButton2.Checked) { lifetime = 4000; difficulty = 5000; }
            if (radioButton3.Checked) { lifetime = 3000; difficulty = 5000; }
            try
            {                
                Animal.food = new Food(int.Parse(F.Text));
                if (Animal.food.width<=0) throw new FormatException();                               
                timer1.Interval = 100;                                                       
                T.Elapsed += (o, ev) =>
                {                    
                    g.FillRectangle(new SolidBrush(Color.Gray), 185, 0, 10, 690);
                    g.FillRectangle(new SolidBrush(Color.Gray), 185, 690,1165,10);
                    g.FillRectangle(new SolidBrush(Color.Gray), 1350, 0, 10, 700);
                    g.FillRectangle(new SolidBrush(Color.Gray), 195, 40, 1165, 10);                    
                };
                Queen queen = new Queen(32, 10, 900000);
                T.Elapsed += (o, ev) =>
                {
                    if (Animal.food.width > 0) Animal.food.Draw(g);
                    else
                    {
                        TimeToAppear.Dispose();
                        T.Dispose();
                        var result = MessageBox.Show("Game over:\nno more food left!\nDo you want to retry?","",MessageBoxButtons.RetryCancel);
                        if(result==DialogResult.Retry)
                        {
                            Application.Restart();                             
                        }
                        if (result == DialogResult.Cancel) Application.Exit();
                    }
                    if (queen.dead)
                    {
                        TimeToAppear.Dispose();
                        T.Dispose();                        
                        var result = MessageBox.Show("Congratulations on your victory:\nthe Queen of the ants has lived out the whole life successfully ...\nDo you want to retry?", "", MessageBoxButtons.RetryCancel);
                        if (result == DialogResult.Retry)
                        {
                            Application.Restart();
                        }
                        if (result == DialogResult.Cancel) Application.Exit();
                    }
                };
                Immortal.AutoReset = true;
                Immortal.Elapsed += (o, ev) =>
                {
                    immortal = new ImmortalAnt(18, 0, 3000);
                    Convert(immortal.xc, immortal.yc,ref row1,ref column1);
                };                   
                Employee.AutoReset = true;
                Employee.Elapsed += (o, ev) =>
                {
                    employee = new Potential(15, 0, lifetime);
                    Convert(employee.xc, employee.yc,ref row,ref column);
                };                   
                T.AutoReset = true;
                TimeToAppear.AutoReset = true;
                TimeToAppear.Interval = difficulty;
                TimeToAppear.Elapsed += (o, ev) => Pests.Add(new Pest(20, 3)); ;
                Thread.Sleep(1000);
                TimeToAppear.Start();
                timer1.Start(); 
                T.Start();
                Employee.Start();
                Immortal.Start();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите натуральное число большее 0!");
            }            
        } 
        public void Convert(int x,int y,ref int r,ref int c)
        {
            if ((195 <= x) && (x <= 425)) c = 1;
            if ((426 <= x) && (x <= 656)) c = 2;
            if ((657 <= x) && (x <= 887)) c = 3;
            if ((888 <= x) && (x <= 1118)) c = 4;
            if ((1119 <= x) && (x <= 1350)) c = 5;
            if ((50 <= y) && (y <= 209)) r = 1;
            if ((210 <= y) && (y <= 369)) r = 2;
            if ((370 <= y) && (y <= 529)) r = 3;
            if ((530 <= y) && (y <= 690)) r = 4;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Animal.food.width.ToString();            
        }       
        public void DrawGrid(Color color)
        {
            
                g.DrawLine(new Pen(color, 1), new Point(426, 50), new Point(426, 689));
                g.DrawLine(new Pen(color, 1), new Point(657, 50), new Point(657, 689));
                g.DrawLine(new Pen(color, 1), new Point(888, 50), new Point(888, 689));
                g.DrawLine(new Pen(color, 1), new Point(1119, 50), new Point(1119, 689));

                g.DrawLine(new Pen(color, 1), new Point(195, 210), new Point(1349, 210));
                g.DrawLine(new Pen(color, 1), new Point(195, 370), new Point(1349, 370));
                g.DrawLine(new Pen(color, 1), new Point(195, 530), new Point(1349, 530));
                     
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!checkBox1.Checked)
                {
                    T.Elapsed -= GB;
                    Thread.Sleep(100);
                    T.Elapsed += GW;
                    Thread.Sleep(100);
                    T.Elapsed -= GW;
                }
                else
                {
                    Thread.Sleep(200);
                    T.Elapsed += GB;
                }
            }
            catch (InvalidOperationException) { }           
        }
        void GB(object o,ElapsedEventArgs e)
        {
            DrawGrid(Color.Black);
        }
        void GW(object o, ElapsedEventArgs e)
        {
            DrawGrid(Color.White);
        }

        private void RC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                try
                {
                    if (RC.Text == (row.ToString() + column.ToString())) B = true;
                    if (RC.Text == (row1.ToString() + column1.ToString())) B1 = true;
                    RC.Text = "";
                }
                catch (FormatException) { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 3; i++) new Worker(15, 2, r.Next(25000, 32000), r.Next(195, 1335), r.Next(50, 675));
        }           
    }
}
