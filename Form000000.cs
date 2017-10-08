using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WWW
{
    public partial class Form : System.Windows.Forms.Form
    {
        Bitmap bitM;
        Bitmap bitM1;
        public Form()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPG|*.jpg|PNG|.png|Bitmap|.bmp", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color c;
            int r1, g1, b1, r2, g2, b2;
            int W = 75;
            int B = 70;
            bitM = new Bitmap(pictureBox1.Image);
            bitM1 = new Bitmap(pictureBox1.Image);
            for (int y = (pictureBox1.Height / 10) * 9 - 18; y <= (pictureBox1.Height / 10) * 9 + 5; y++)

            {
                for (int x = 2; x < pictureBox1.Width - 2; x++)
                {

                    r1 = 0;
                    g1 = 0;
                    b1 = 0;
                    r2 = 0;
                    g2 = 0;
                    b2 = 0;

                    /* r1 = bitM.GetPixel(x, y).R;
                     g1 = bitM.GetPixel(x, y).G;
                     b1 = bitM.GetPixel(x, y).B;

                     r2 = bitM.GetPixel(x+1, y).R;
                     g2 = bitM.GetPixel(x+1, y).G;
                     b2 = bitM.GetPixel(x+1, y).B;*/

                    for (int x0 = x - 2; x0 <= x + 2; x0++)
                    {
                        for (int y0 = y - 2; y0 <= y + 2; y0++)
                        {
                            r1 += bitM.GetPixel(x0, y0).R;
                            g1 += bitM.GetPixel(x0, y0).G;
                            b1 += bitM.GetPixel(x0, y0).B;
                        }
                    }
                    r1 /= 25;
                    g1 /= 25;
                    b1 /= 25;





                    /* if ((r1>200) && (g1 > 200) && (b1 > 200) && (r1-r2 >W-10) && (g1-g2 >W- 10) && (b1-b2 >W- 10)
                         && (r1 - r2 < W + 10) && (g1 - g2 < W + 10) && (b1 - b2 < W + 10))
                     {*/
                    /*r1 += W;
                    g1 += W;
                    b1 += W;

                    r2 += W;
                    g2 += W;
                    b2 += W;*/

                    if (r1 < 0) r1 = 0;
                    if (g1 < 0) g1 = 0;
                    if (b1 < 0) b1 = 0;
                    if (r2 < 0) r2 = 0;
                    if (g2 < 0) g2 = 0;
                    if (b2 < 0) b2 = 0;

                    if (r1 > 255) r1 = 255;
                    if (g1 > 255) g1 = 255;
                    if (b1 > 255) b1 = 255;
                    if (r2 > 255) r2 = 255;
                    if (g2 > 255) g2 = 255;
                    if (b2 > 255) b2 = 255;

                    c = Color.FromArgb(r1, g1, b1);
                    bitM.SetPixel(x, y, c);
                    /*if ((r1<r2) && (g1<g2) && (b1<b2))
                    {                         
                        c=Color.FromArgb(r1,g1,b1);
                        bitM.SetPixel(x,y,c);

                        c = Color.FromArgb(r2, g2, b2);
                        bitM.SetPixel(x+1, y, c);

                    }*/
                    /*if ((r1 > r2) && (g1 > g2) && (b1 > b2))
                    {
                        c = Color.FromArgb(r2, g2, b2);
                        bitM.SetPixel(x, y, c);

                        c = Color.FromArgb(r1, g1, b1);
                        bitM.SetPixel(x + 1, y, c);

                    }*/

                    // }



                }

            }
            for (int p=0; p < 2; p++) { 
            for (int y = (pictureBox1.Height / 10) * 9 - 18; y <= (pictureBox1.Height / 10) * 9 + 5; y++)

            {
                for (int x = 0; x < pictureBox1.Width; x++)
                {
                    r1 = 0;
                    g1 = 0;
                    b1 = 0;
                    r2 = 0;
                    g2 = 0;
                    b2 = 0;
                    r1 = 2*bitM.GetPixel(x, y).R;
                    g1 = 2*bitM.GetPixel(x, y).G;
                    b1 = 2*bitM.GetPixel(x, y).B;

                    r1 += bitM1.GetPixel(x, y).R;
                    g1 += bitM1.GetPixel(x, y).G;
                    b1 += bitM1.GetPixel(x, y).B;

                    r1 /= 3;
                    g1 /= 3;
                    b1 /= 3;
                     

                    c = Color.FromArgb(r1, g1, b1);
                    bitM.SetPixel(x, y, c);
                }

            }
        }
            pictureBox1.Image = bitM;
        }
    }
}

