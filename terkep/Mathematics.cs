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
    public class Mathematics
    {

        public PublicData kozos;


        public void Calculate()
        {
            kozos.xy = new double[kozos.width, kozos.height];
            kozos.sorted = new List<double>();
            for (int i = 0; i < kozos.width; i++)
            {
                double ii = Convert.ToDouble((i + 1) - (kozos.width / 2));
                for (int j = 0; j < kozos.height; j++)
                {

                    double jj = Convert.ToDouble((j + 1) - (kozos.height / 2));
                    kozos.xy[i, j] = (Math.Pow(ii, 4) * kozos.a4) + (Math.Pow(ii, 3) * jj * kozos.a3) + (Math.Pow(ii, 2) * Math.Pow(jj, 2) * kozos.a2) + (ii * Math.Pow(jj, 3) * kozos.a1) + (Math.Pow(jj, 4) * kozos.a0);
                    kozos.sorted.Add(kozos.xy[i, j]);
                }
            }
            kozos.sorted.Sort();
        }

    }
}
