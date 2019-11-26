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

        Mathematics MathProblems;
        Drawing TerrainPlotter;
        Kereszt kereszt;
        Point coordinates;
        Graphics g;

        bool succes;
        
        Timer Idozito;

        Color prevColor;

        private void Form1_Load(object sender, EventArgs e)
        {
            Idozito = new Timer();
            Idozito.Interval = (100); // 0.1 s
            Idozito.Tick += new EventHandler(Idozito_Tick);
        }

        private void Idozito_Tick(object sender, EventArgs e)
        {
            int searchScale = 1;
            int minimumIndex = 0;
            int[] minimums = {
                TerrainPlotter.bmp2.GetPixel(coordinates.X + searchScale, coordinates.Y + searchScale).R,
                TerrainPlotter.bmp2.GetPixel(coordinates.X + searchScale, coordinates.Y - searchScale).R,
                TerrainPlotter.bmp2.GetPixel(coordinates.X - searchScale, coordinates.Y + searchScale).R,
                TerrainPlotter.bmp2.GetPixel(coordinates.X - searchScale, coordinates.Y - searchScale).R,
                TerrainPlotter.bmp2.GetPixel(coordinates.X - searchScale, coordinates.Y).R,
                TerrainPlotter.bmp2.GetPixel(coordinates.X + searchScale, coordinates.Y).R,
                TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y - searchScale).R,
                TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y + searchScale).R
            };

            for (int i = 0; i < minimums.Length; i++)
            {
                if (minimums[i] < minimums[minimumIndex]) minimumIndex = i;
            }

            //atlos iranyban

            try
            {

                if (minimumIndex == 0 && minimums[0] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.X += searchScale;
                    coordinates.Y += searchScale;
                    kereszt.X += searchScale;
                    kereszt.Y += searchScale;
                    pictureBox2.Location = kereszt.pos;
                }
                else if (minimumIndex == 1 && minimums[1] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.X += searchScale;
                    coordinates.Y -= searchScale;
                    kereszt.X += searchScale;
                    kereszt.Y -= searchScale;
                    pictureBox2.Location = kereszt.pos;
                }
                else if (minimumIndex == 2 && minimums[2] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.X -= searchScale;
                    coordinates.Y += searchScale;
                    kereszt.X -= searchScale;
                    kereszt.Y += searchScale;
                    pictureBox2.Location = kereszt.pos;
                }
                else if (minimumIndex == 3 && minimums[3] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.X -= searchScale;
                    coordinates.Y -= searchScale;
                    kereszt.X -= searchScale;
                    kereszt.Y -= searchScale;
                    pictureBox2.Location = kereszt.pos;
                }

                //csak vizszintes es fuggoleges

                else if (minimumIndex == 4 && minimums[4] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.X -= searchScale;
                    kereszt.X -= searchScale;
                    pictureBox2.Location = kereszt.pos;
                }
                else if (minimumIndex == 5 && minimums[5] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.X += searchScale;
                    kereszt.X += searchScale;
                    pictureBox2.Location = kereszt.pos;
                }
                else if (minimumIndex == 6 && minimums[6] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.Y -= searchScale;
                    kereszt.Y -= searchScale;
                    pictureBox2.Location = kereszt.pos;
                }
                else if (minimumIndex == 7 && minimums[7] < TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y).R)
                {
                    coordinates.Y += searchScale;
                    kereszt.Y += searchScale;
                    pictureBox2.Location = kereszt.pos;
                }

                else
                {
                    g = Graphics.FromImage(TerrainPlotter.bmp);
                    g.DrawImage(kereszt.pottyBitmap, new Point(kereszt.X + (kereszt.keresztBitmap.Width / 2) - 10, kereszt.Y + (kereszt.keresztBitmap.Width / 2) - 10));
                    pictureBox1.Image = TerrainPlotter.bmp;
                    pictureBox2.Visible = false;
                    Idozito.Stop();
                    button2.Enabled = false;
                }
            }
            catch (Exception asds)
            {
                pictureBox2.Visible = false;
                Idozito.Stop();
                button2.Enabled = false;
            }
        }

            public Form1() //ide kell beleírni a keresztet meg a pöttyöt
        {
            InitializeComponent();

            MathProblems = new Mathematics();
            TerrainPlotter = new Drawing();
            kereszt = new Kereszt("kereszt.png","potty.png");

            pictureBox1.Controls.Add(pictureBox2);  //picture box2-ben lesz a kereszt
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = kereszt.keresztBitmap;

            
        }

        private void PictureBox1_Click(object sender, EventArgs e) //kereszt elhelyezése a képen
        {
            if (TerrainPlotter.bmp != null)
            {
                //clickable = true;
                MouseEventArgs me = (MouseEventArgs)e;
                coordinates = me.Location; //picture boxon belüli pozíció 

                kereszt.X = coordinates.X - (kereszt.keresztBitmap.Width / 2);
                kereszt.Y = coordinates.Y - (kereszt.keresztBitmap.Width / 2);

                pictureBox2.Location = kereszt.pos;
                pictureBox2.Visible = true;
                button2.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e) //elkezdi a kereszt mozgatását
        {
            Idozito.Start();
            prevColor = TerrainPlotter.bmp2.GetPixel(coordinates.X, coordinates.Y);
            button2.Enabled = false;
        }


        private void getValuesForMathematics()
        {
            MathProblems.kozos.width = Convert.ToInt32(textBox6.Text);
            MathProblems.kozos.width = 500;
            MathProblems.kozos.height = Convert.ToInt32(textBox7.Text);
            MathProblems.kozos.height = 500;
            TerrainPlotter.bmp = new Bitmap(MathProblems.kozos.width, MathProblems.kozos.height);
            TerrainPlotter.bmp2 = new Bitmap(MathProblems.kozos.width, MathProblems.kozos.height);
            MathProblems.kozos.a0 = Convert.ToDouble(textBox1.Text);
            MathProblems.kozos.a1 = Convert.ToDouble(textBox2.Text);
            MathProblems.kozos.a2 = Convert.ToDouble(textBox3.Text);
            MathProblems.kozos.a3 = Convert.ToDouble(textBox4.Text);
            MathProblems.kozos.a4 = Convert.ToDouble(textBox5.Text);
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            succes = true;
            try
            {
                getValuesForMathematics();
            }
            catch(Exception asd)
            {
                succes = false;
            }
            if (succes == true)
            {
                MathProblems.Calculate();

                pictureBox1.Width = 500;
                pictureBox1.Height = 500;
                pictureBox1.BackColor = Color.Black;

                TerrainPlotter.kozos = MathProblems.kozos;
                TerrainPlotter.CreateTerrain();

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = TerrainPlotter.bmp;
            }
        }
    }
}
