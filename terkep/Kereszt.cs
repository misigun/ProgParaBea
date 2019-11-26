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
    public class Kereszt : Form
    {
        public Point pos;
        private bool visible = false;

        Color currColor;


        public Bitmap keresztBitmap;
        public Bitmap pottyBitmap;

        public Kereszt(string a, string b)
        {
            keresztBitmap = (Bitmap)Image.FromFile(a);
            pottyBitmap = (Bitmap)Image.FromFile(b);
        }

        public Color SetColor
        {
            get { return currColor; }
            set { currColor = value; }
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
