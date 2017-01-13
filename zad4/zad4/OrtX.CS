using System;
using System.Drawing;
using System.Windows.Forms;

namespace zad4
{
    public class OrtX : Panel
    {
        public PictureBox pb;
        Pen pen = new Pen(Color.Gray);
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

        public OrtX()
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


                g.DrawRectangle(pen, 0, 0, this.Width, this.Height);
                if (trojkaty != null &&
                    wierzcholki != null &&
                    srodekKamery != null &&
                    srodekObrazu != null)
                {
                    prop = Math.Max(maxX - minX, Math.Max(maxY - minY, maxZ - minZ));
                    srodekKameryE = new int[3];
                    srodekObrazuE = new int[3];
                    srodekKameryE[1] = wspY(srodekKamery[1]);
                    srodekKameryE[2] = wspZ(srodekKamery[2]);
                    srodekObrazuE[1] = wspY(srodekObrazu[1]);
                    srodekObrazuE[2] = wspZ(srodekObrazu[2]);
                    pb.ForeColor = Color.Gray;
                    g
                        .DrawLine(pen, wspY((int) wierzch[0, 1]), wspZ((int) wierzch[0, 2]), wspY((int) wierzch[1, 1]),
                            wspZ((int) wierzch[1, 2]));
                    g
                        .DrawLine(pen, wspY((int) wierzch[1, 1]), wspZ((int) wierzch[1, 2]), wspY((int) wierzch[2, 1]),
                            wspZ((int) wierzch[2, 2]));
                    g
                        .DrawLine(pen, wspY((int) wierzch[2, 1]), wspZ((int) wierzch[2, 2]), wspY((int) wierzch[3, 1]),
                            wspZ((int) wierzch[3, 2]));
                    g
                        .DrawLine(pen, wspY((int) wierzch[3, 1]), wspZ((int) wierzch[3, 2]), wspY((int) wierzch[0, 1]),
                            wspZ((int) wierzch[0, 2]));
                    g
                        .DrawLine(pen, wspY((int) srodekKamery[1]), wspZ((int) srodekKamery[2]),
                            wspY((int) wierzch[1, 1]),
                            wspZ((int) wierzch[1, 2]));
                    g
                        .DrawLine(pen, wspY((int) srodekKamery[1]), wspZ((int) srodekKamery[2]),
                            wspY((int) wierzch[2, 1]),
                            wspZ((int) wierzch[2, 2]));
                    g
                        .DrawLine(pen, wspY((int) srodekKamery[1]), wspZ((int) srodekKamery[2]),
                            wspY((int) wierzch[3, 1]),
                            wspZ((int) wierzch[3, 2]));
                    g
                        .DrawLine(pen, wspY((int) srodekKamery[1]), wspZ((int) srodekKamery[2]),
                            wspY((int) wierzch[0, 1]),
                            wspZ((int) wierzch[0, 2]));
                    pen.Color = Color.Green;
                    g.DrawRectangle(pen, srodekObrazuE[1] - 3, srodekObrazuE[2] - 3, 5, 5);
                    pen.Color = Color.Red;
                    g.DrawRectangle(pen, srodekKameryE[1] - 3, srodekKameryE[2] - 3, 5, 5);
                    pen.Color = kolorSceny;
                    for (int i = 0; i < trojkaty.GetLength(0); i++)
                    {
                        g.DrawLine(pen, wspY(wierzcholki[trojkaty[i, 0], 1]),
                            wspZ(wierzcholki[trojkaty[i, 0], 2]),
                            wspY(wierzcholki[trojkaty[i, 1], 1]),
                            wspZ(wierzcholki[trojkaty[i, 1], 2]));
                        g.DrawLine(pen, wspY(wierzcholki[trojkaty[i, 2], 1]),
                            wspZ(wierzcholki[trojkaty[i, 2], 2]),
                            wspY(wierzcholki[trojkaty[i, 1], 1]),
                            wspZ(wierzcholki[trojkaty[i, 1], 2]));
                        g.DrawLine(pen, wspY(wierzcholki[trojkaty[i, 0], 1]),
                            wspZ(wierzcholki[trojkaty[i, 0], 2]),
                            wspY(wierzcholki[trojkaty[i, 2], 1]),
                            wspZ(wierzcholki[trojkaty[i, 2], 2]));
                    }
                }
                pen.Color = Color.Gray;
                g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
            pb.Image = bmp;
        }

        int wspY(int wsp)
        {
            return (int) (this.Width/2 + (double) (wsp*pow - (minY + maxY)/2*pow)*((double) (this.Width)/(prop)));
        }

        int wspZ(int wsp)
        {
            return
                (int) (this.Width/2 + (double) (wsp*pow - (minZ + maxZ)/2*pow)*((double) (this.Width)/(prop)));
        }
    }
}