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
    public partial class Drawing : Form
    {
        //private PublicData kozos;

        public int[,] colors =
        {
            {0,80,0 },
            {0,100,0 },
            {0,128,0 },
            {0,150,0 },
            {0,160,0 },
            {0,180,0 },
            {0,200,0 },
            {0, 227,0 },
            {0, 240,0 },
            {0,255,0 },
            {32, 255, 0 },
            {64,255,0 },
            {90, 255 ,0 },
            {128,255,0 },
            {140, 227, 0 },
            {154,205,0 },
            {180,210,0 },
            {225, 225, 0 },
            {255,255,0 },
            {255, 230, 0 },
            {255,215,0 },
            {255,165,0 },
            {255,128,0 },
            {225, 110, 0 },
            {200, 90 ,0 },
            {170, 85, 0 },
            {145,75 ,0 },
            {100,50,0 }
        };

        public Bitmap bmp, bmp2;

        public Drawing()
        {

        }

        public PublicData kozos
        {
            get; set;
        }

        public double MapValue(double a0, double a1, double b0, double b1, double a)
        {
            if ((a1 - a0) != 0)
                return b0 + (b1 - b0) * ((a - a0) / (a1 - a0));
            else
                return 0;
        }

        public void CreateTerrain()
        {


            int curr = Convert.ToInt32(MapValue(kozos.sorted.Last(), kozos.sorted.First(), 0, colors.GetLength(0) - 1, kozos.xy[0, 0]));
            for (int i = 0; i < kozos.width; i++)
            {
                for (int j = 0; j < kozos.height; j++)
                {
                    int sor = Convert.ToInt32(MapValue(kozos.sorted.Last(), kozos.sorted.First(), 0, colors.GetLength(0) - 1, kozos.xy[i, j]));
                    if (curr == sor)
                        bmp.SetPixel(i, j, Color.FromArgb(colors[sor, 0], colors[sor, 1], colors[sor, 2]));
                    else
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        curr = sor;
                    }
                    //int sor = Convert.ToInt32(MapValue(kozos.sorted.Last(), kozos.sorted.First(), 0, colors.GetLength(0) - 1, kozos.xy[i, j]));
                    bmp2.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(MapValue(kozos.sorted.Last(), kozos.sorted.First(), 0, 255, kozos.xy[i, j])), 0, 0));
                }
            }
            curr = Convert.ToInt32(MapValue(kozos.sorted.Last(), kozos.sorted.First(), 0, 7, kozos.xy[0, 0]));
            for (int j = 0; j < kozos.height; j++)
            {
                for (int i = 0; i < kozos.width; i++)
                {
                    int sor = Convert.ToInt32(MapValue(kozos.sorted.Last(), kozos.sorted.First(), 0, colors.GetLength(0) - 1, kozos.xy[i, j]));
                    if (curr != sor)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        curr = sor;
                    }
                }
            }

            bmp2 = this.ResizeBitmap(bmp2, kozos.width, kozos.height);
            bmp = this.ResizeBitmap(bmp, kozos.width, kozos.height);

            //bmp2 = bmp;

        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics a = Graphics.FromImage(result))
            {
                a.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
    }
}
