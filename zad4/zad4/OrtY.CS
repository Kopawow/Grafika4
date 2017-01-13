using System;
using System.Drawing;
using System.Windows.Forms;

namespace zad4
{
    public class OrtY : Panel
    {
        Color kolorTla = Color.Black;
        Color kolorKamery = Color.LightGray;
        Color kolorSceny = Color.White;

        public int[,] wierzcholki;

        public int[,] trojkaty;

        public int[] srodekKamery;

        public int[] srodekObrazu;

        public int katRozwarcia;
        public int maxX;
        public int minX;
        public int maxY;
        public int minY;
        public int maxZ;
        public int minZ;
        double prop;
        public double pow = 0.9;

        int[] srodekKameryE;

        int[] srodekObrazuE;
        public double[,] wierzch = new double[4, 3];

        public PictureBox pb;
        Pen pen = new Pen(Color.Gray);

        public OrtY()
        {
            pb = new PictureBox()
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pb);
            pb.Paint += paint;
        }

        public void paint(object sender, PaintEventArgs paintEventArgs)
        {
            Image bmp = new Bitmap(pb.Width, pb.Height);
            pb.BackColor = kolorTla;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(pen.Brush, 0, 0, this.Width, this.Height);
                if (trojkaty != null &&
                    wierzcholki != null &&
                    srodekKamery != null &&
                    srodekObrazu != null)
                {
                    prop = Math.Max(maxX - minX, Math.Max(maxY - minY, maxZ - minZ));
                    srodekKameryE = new int[3];
                    srodekObrazuE = new int[3];
                    srodekKameryE[0] = wspX(srodekKamery[0]);
                    srodekKameryE[2] = wspZ(srodekKamery[2]);
                    srodekObrazuE[0] = wspX(srodekObrazu[0]);
                    srodekObrazuE[2] = wspZ(srodekObrazu[2]);
                    pen.Color = Color.Gray;
                    g
                        .DrawLine(pen, wspX((int) wierzch[0, 0]), wspZ((int) wierzch[0, 2]), wspX((int) wierzch[1, 0]),
                            wspZ((int) wierzch[1, 2]));
                    g
                        .DrawLine(pen, wspX((int) wierzch[1, 0]), wspZ((int) wierzch[1, 2]), wspX((int) wierzch[2, 0]),
                            wspZ((int) wierzch[2, 2]));
                    g
                        .DrawLine(pen, wspX((int) wierzch[2, 0]), wspZ((int) wierzch[2, 2]), wspX((int) wierzch[3, 0]),
                            wspZ((int) wierzch[3, 2]));
                    g
                        .DrawLine(pen, wspX((int) wierzch[3, 0]), wspZ((int) wierzch[3, 2]), wspX((int) wierzch[0, 0]),
                            wspZ((int) wierzch[0, 2]));
                    g
                        .DrawLine(pen, wspX((int) srodekKamery[0]), wspZ((int) srodekKamery[2]),
                            wspX((int) wierzch[1, 0]),
                            wspZ((int) wierzch[1, 2]));
                    g
                        .DrawLine(pen, wspX((int) srodekKamery[0]), wspZ((int) srodekKamery[2]),
                            wspX((int) wierzch[2, 0]),
                            wspZ((int) wierzch[2, 2]));
                    g
                        .DrawLine(pen, wspX((int) srodekKamery[0]), wspZ((int) srodekKamery[2]),
                            wspX((int) wierzch[3, 0]),
                            wspZ((int) wierzch[3, 2]));
                    g
                        .DrawLine(pen, wspX((int) srodekKamery[0]), wspZ((int) srodekKamery[2]),
                            wspX((int) wierzch[0, 0]),
                            wspZ((int) wierzch[0, 2]));
                    pen.Color = Color.Green;
                    g.DrawRectangle(pen, srodekObrazuE[0] - 3, srodekObrazuE[2] - 3, 5, 5);
                    pen.Color = Color.Red;
                    g.DrawRectangle(pen, srodekKameryE[0] - 3, srodekKameryE[2] - 3, 5, 5);
                    pen.Color = kolorSceny;
                    for (int i = 0; i < trojkaty.GetLength(0); i++)
                    {
                        g.DrawLine(pen, wspX(wierzcholki[trojkaty[i, 0], 0]),
                            wspZ(wierzcholki[trojkaty[i, 0], 2]),
                            wspX(wierzcholki[trojkaty[i, 1], 0]),
                            wspZ(wierzcholki[trojkaty[i, 1], 2]));
                        g.DrawLine(pen, wspX(wierzcholki[trojkaty[i, 2], 0]),
                            wspZ(wierzcholki[trojkaty[i, 2], 2]),
                            wspX(wierzcholki[trojkaty[i, 1], 0]),
                            wspZ(wierzcholki[trojkaty[i, 1], 2]));
                        g.DrawLine(pen, wspX(wierzcholki[trojkaty[i, 0], 0]),
                            wspZ(wierzcholki[trojkaty[i, 0], 2]),
                            wspX(wierzcholki[trojkaty[i, 2], 0]),
                            wspZ(wierzcholki[trojkaty[i, 2], 2]));
                    }
                }
                pen.Color = Color.Gray;

                g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
            pb.Image = bmp;
        }

        int wspX(int wsp)
        {
            double a = (double) (wsp*pow - (minX + maxX)/2*pow);
            double b = (double) this.Width;
            int x = (int) (this.Width/2 + (a*(b/(prop))));
            return x;
        }

        int wspZ(int wsp)
        {
            int x =
                (int) (this.Height/2 + (double) (wsp*pow - (minZ + maxZ)/2*pow)*((double) (this.Height)/(prop)));
            return x;
        }
    }
}