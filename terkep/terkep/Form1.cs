using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace terkep
{

    public partial class Form1 : Form
    {
        /*int[,] colors =
        {
            {0,80,5},
            {0,140,0 },
            { 0,255,0},
            {128,255,0 },
            {255,255,0 },
            {255,128,0 },
            {145,75,0 },
            {100,50,0 }
        };*/

        int[,] colors =
        {
            {0,80,0 },
            {0,100,0 },
            {0,128,0 },
            {0,160,0 },
            {0,200,0 },
            {0, 227,0 },
            {0,255,0 },
            {64,255,0 },
            {128,255,0 },
            {140, 227, 0 },
            {154,205,0 },
            {225, 225, 0 },
            {255,255,0 },
            {255, 230, 0 },
            {255,215,0 },
            {255,165,0 },
            {255,128,0 },
            {200, 90 ,0 },
            {145,75 ,0 },
            {100,50,0 }
        };

        double a0, a1, a2, a3, a4;
        int height, width;
        double[,] xy;
        List<double> sorted;

        private void PictureBox1_Click(object sender, EventArgs e) //kereszt elhelyezése a képen
        {
            Point pos = new Point(pictureBox1.Location.X - MousePosition.X, pictureBox1.Location.Y - MousePosition.Y);
            Color a = bmp.GetPixel(pos.X,pos.Y);

            
        }

        private void Button2_Click(object sender, EventArgs e) //elkezdi a kereszt mozgatását
        {
            Graphics g;
            g = this.CreateGraphics();

        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            // Declares the Graphics object and sets it to the Graphics object  
            // supplied in the PaintEventArgs.  
            Graphics g = pe.Graphics;
            // Insert code to paint the form here.  
        }

        bool succes;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }
        public double MapValue(double a0, double a1, double b0, double b1, double a)
        {
            if ((a1 - a0) != 0)
                return b0 + (b1 - b0) * ((a - a0) / (a1 - a0));
            else
                return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            succes = true;
            try
            {
                width = Convert.ToInt32(textBox6.Text);
                height = Convert.ToInt32(textBox7.Text);
                bmp = new Bitmap(width, height);
                a0 = Convert.ToDouble(textBox1.Text);
                a1 = Convert.ToDouble(textBox2.Text);
                a2 = Convert.ToDouble(textBox3.Text);
                a3 = Convert.ToDouble(textBox4.Text);
                a4 = Convert.ToDouble(textBox5.Text);
            }
            catch(Exception asd)
            {
                succes = false;
            }
            if (succes == true)
            {
                pictureBox1.Width = 500;
                pictureBox1.Height = 500;
                pictureBox1.BackColor = Color.Black;
                xy = new double[width, height];
                sorted = new List<double>();
                for (int i = 0; i < width; i++)
                {
                    double ii = Convert.ToDouble((i + 1) - (width / 2));
                    for (int j = 0; j < height; j++)
                    {

                        double jj = Convert.ToDouble((j + 1) - (height / 2));
                        xy[i, j] = (Math.Pow(ii, 4) * a4) + (Math.Pow(ii, 3) * jj * a3) + (Math.Pow(ii, 2) * Math.Pow(jj, 2) * a2) + (ii * Math.Pow(jj, 3) * a1) + (Math.Pow(jj, 4) * a0);
                        sorted.Add(xy[i, j]);
                    }
                }
                sorted.Sort();
                int curr = Convert.ToInt32(MapValue(sorted.Last(), sorted.First(), 0, colors.GetLength(0)-1, xy[0, 0]));
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        int sor = Convert.ToInt32(MapValue(sorted.Last(), sorted.First(), 0, colors.GetLength(0)-1, xy[i, j]));
                        if (curr == sor)
                            bmp.SetPixel(i, j, Color.FromArgb(colors[sor, 0], colors[sor, 1], colors[sor, 2]));
                        else
                        {
                            bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                            curr = sor;
                        }
                    }
                }
                curr = Convert.ToInt32(MapValue(sorted.Last(), sorted.First(), 0, 7, xy[0, 0]));
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        int sor = Convert.ToInt32(MapValue(sorted.Last(), sorted.First(), 0, colors.GetLength(0)-1, xy[i, j]));
                        if (curr != sor)
                        {
                            bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                            curr = sor;
                        }
                    }
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = bmp;
            }
        }
    }

    public partial class Kereszt : Form
    {
        private Point pos;
        private bool visible = false;
        private Pen pen;
        private Graphics g;

        public Kereszt()
        {
            pen = new Pen(Color.FromArgb(0, 0, 0, 0));
            g = this.CreateGraphics();
        }

        public void DrawCross()
        {
            
        }

        public void RemoveCross()
        {

        }

        public int X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }
        public int Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}
