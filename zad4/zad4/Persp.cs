using System;
using System.Drawing;
using System.Windows.Forms;

namespace zad4
{
  public class Persp : Panel
  {
    public PictureBox pb;
    Pen pen = new Pen(Color.Gray);
    Color kolorTla = Color.Black;
    Color kolorKamery = Color.LightGray;
    Color kolorSceny = Color.White;


      public int[,] wierzcholki;

    int[,] wierzcholkiP;

      public int[,] trojkaty;

    public int[] srodekKamery;

    public int[] srodekObrazu;

      public int katRozwarcia;
    int maxX;
    int minX;
    int maxY;
    int minY;
    int maxZ;
    int minZ;
    double prop;
    int[,] obraz;

    private bool[] showW;
    double[,] wierzcholkiPom;

    double wspPom;
    int help;
      public bool trybPersp = true;

    public Persp()
    {
            pb = new PictureBox()
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pb);
            pb.Paint += paint;
        }
    void przeliczWsp()
    {
      if (srodekKamery != null && srodekObrazu != null)
      {
        wierzcholkiPom = new double[wierzcholki.Length, 3];
        obraz = new int[wierzcholki.Length, 2];
        var punktyPom = new double[2, 3];

        for (int i = 0; i < 3; i++)
        {
          punktyPom[0, i] = srodekKamery[i];
          //punkt obrazu po przesunieciu
        }
        for (int i = 0; i < 3; i++)
        {
          punktyPom[1, i] = srodekObrazu[i] - srodekKamery[i];
        }
        //katy obrotu
        var modPom = new int[3];
        for (int i = 0; i < 3; i++)
        {
          if (punktyPom[1, i] < 0)
          {
            modPom[i] = -1;
          }
          else
          {
            modPom[i] = 1;
          }
        }
        double katZ = -1 * modPom[0] * modPom[1] * (Math.Acos((punktyPom[1, 0] * punktyPom[1, 0] + 0 * punktyPom[1, 1]) /
                                                        (Helper.Hypotenuse(punktyPom[1, 0], punktyPom[1, 1]) *
                                                         Helper.Hypotenuse(punktyPom[1, 0], 0))));
        if (Double.IsNaN(katZ))
        {
          katZ = Helper.ConvertToRadians(-1 * modPom[1] * 90);
        }
        /*double katX = -(Math.acos((punktyPom[1, 1] * punktyPom[1, 1] + punktyPom[1, 2] * 0) /
        (Helper.Hypotenuse(punktyPom[1, 1], punktyPom[1, 2]) * Helper.Hypotenuse(0, punktyPom[1, 2]))));*/
        double pom1 = punktyPom[1, 0] * Math.Cos(katZ) - punktyPom[1, 1] * Math.Sin(katZ);
        punktyPom[1, 1] = punktyPom[1, 0] * Math.Sin(katZ) + punktyPom[1, 1] * Math.Cos(katZ);
        punktyPom[1, 0] = pom1;
        double katY = modPom[0] * modPom[2] * (Math.Acos((punktyPom[1, 0] * punktyPom[1, 0] + 0 * punktyPom[1, 2]) /
                                                     (Helper.Hypotenuse(punktyPom[1, 0], punktyPom[1, 2]) *
                                                      Helper.Hypotenuse(punktyPom[1, 0], 0))));
        if (Double.IsNaN(katY))
        {
          katY = Helper.ConvertToRadians(90);
        }
        double pom2 = punktyPom[1, 0] * Math.Cos(katY) + punktyPom[1, 2] * Math.Sin(katY);
        punktyPom[1, 2] = punktyPom[1, 2] * Math.Cos(katY) - punktyPom[1, 0] * Math.Sin(katY);
        punktyPom[1, 0] = pom2;
        help = (srodekKamery[0] > srodekObrazu[0]) ? -1 : 1;
        wspPom = Math.Tan(Helper.ConvertToRadians(katRozwarcia));
        showW = new bool[wierzcholki.GetLength(0)];
        for (int i = 0; i < wierzcholki.GetLength(0); i++)
        {
          for (int j = 0; j < 3; j++)
          {
            if ((wierzcholki[i, j] - srodekKamery[j]) < 0)
            {
              modPom[j] = -1;
            }
            else
            {
              modPom[j] = 1;
            }
          }
          //katZ = -1 * modPom[0] * modPom[1] * (Math.abs(katZ));//
          //katY =  modPom[0] * modPom[2] * (Math.abs(katY));//
          //System.out.println("i=" + i);
          //System.out.println("katY:"+Math.toDegrees(katY));
          //System.out.println("katZ:"+Math.toDegrees(katZ));
          //System.out.println(wierzcholki[i, 0] + " " + wierzcholki[i, 1] + " " + wierzcholki[i, 2]);
          //System.out.println((wierzcholki[i, 0] - srodekKamery[0]) + " " + (wierzcholki[i, 1] - srodekKamery[1]) + " " + (wierzcholki[i, 2] - srodekKamery[2]));
          pom1 = (wierzcholki[i, 0] - srodekKamery[0]) * Math.Cos(katZ) -
                 (wierzcholki[i, 1] - srodekKamery[1]) * Math.Sin(katZ);
          wierzcholkiPom[i, 1] = (wierzcholki[i, 0] - srodekKamery[0]) * Math.Sin(katZ) +
                                 (wierzcholki[i, 1] - srodekKamery[1]) * Math.Cos(katZ);
          wierzcholkiPom[i, 0] = pom1;
          //System.out.println(wierzcholkiPom[i, 0] + " " + wierzcholkiPom[i, 1] + " " + wierzcholkiPom[i, 2]);
          pom2 = wierzcholkiPom[i, 0] * Math.Cos(katY) + (wierzcholki[i, 2] - srodekKamery[2]) * Math.Sin(katY);
          wierzcholkiPom[i, 2] = (wierzcholki[i, 2] - srodekKamery[2]) * Math.Cos(katY) -
                                 wierzcholkiPom[i, 0] * Math.Sin(katY);
          wierzcholkiPom[i, 0] = pom2;
          //System.out.println(wierzcholkiPom[i, 0] + " " + wierzcholkiPom[i, 1] + " " + wierzcholkiPom[i, 2]);

          showW[i] = wierzcholkiPom[i, 0] * help >= 0;
          if (trybPersp)
          {
            //System.out.println(wierzcholkiPom[i, 0]);// && wierzcholkiPom[i, 0]<=srodekObrazu[0];
            obraz[i, 0] = (int)(((double)this.Width * ((double)wierzcholkiPom[i, 1] / ((double)wspPom * (double)wierzcholkiPom[i, 0]))) + this.Width) / 2;
            //System.out.println("X=" + obraz[i, 0]);
            obraz[i, 1] = (int)(((double)this.Height * ((double)wierzcholkiPom[i, 2] * help / ((double)wspPom * (double)wierzcholkiPom[i, 0]))) + this.Height) / 2;
            //System.out.println("Y=" + obraz[i, 1]);

          }
        }
        if (!trybPersp)
        {
          int maxYl = int.MinValue;
          int minYl = int.MaxValue;
          int maxZl = int.MinValue;
          int minZl = int.MaxValue;
          int propor;
          for (int k = 0; k < wierzcholkiPom.GetLength(0); k++)
          {
            if (wierzcholkiPom[k, 1] > maxYl)
            {
              maxYl = (int)wierzcholkiPom[k, 1];
            }
            if (wierzcholkiPom[k, 1] < minYl)
            {
              minYl = (int)wierzcholkiPom[k, 1];
            }
            if (wierzcholkiPom[k, 2] > maxZl)
            {
              maxZl = (int)wierzcholkiPom[k, 2];
            }
            if (wierzcholkiPom[k, 2] < minZl)
            {
              minZl = (int)wierzcholkiPom[k, 2];
            }
          }
          //System.out.println(maxYl);
          //System.out.println(minYl);
          //System.out.println(maxZl);
          //System.out.println(minZl);
          propor = Math.Max(maxYl - minYl, maxZl - minZl);
          for (int k = 0; k < wierzcholkiPom.GetLength(0); k++)
          {
            obraz[k, 0] = (int)(this.Width / 2 + (double)(wierzcholkiPom[k, 1] * help * 0.9 - (minYl + maxYl) / 2 * 0.9) * ((double)(this.Width) / (propor)));
            obraz[k, 1] = (this.Height / 4) + (int)(this.Height / 2 + (double)(wierzcholkiPom[k, 2] * 0.9 - (minZl + maxZl) / 2 * 0.9) * ((double)(this.Height) / (propor)));
            //System.out.
            //println(obraz[k]
            //    [0]);
            //System.out.
            //println(obraz[k]
            //    [1]);
          }
        }
        /*double katZ = -1 * modPom[0] * modPom[1] * (Math.acos((punktyPom[1, 0] * punktyPom[1, 0] + 0 * punktyPom[1, 1]) /
    (Helper.Hypotenuse(punktyPom[1, 0], punktyPom[1, 1]) * Helper.Hypotenuse(punktyPom[1, 0], 0))));
    if (Double.IsNaN(katZ)) {
    katZ = Helper.ConvertToRadians(-1 * modPom[1] * 90);
    double katX = -(Math.acos((punktyPom[1, 1] * punktyPom[1, 1] + punktyPom[1, 2] * 0) /
    (Helper.Hypotenuse(punktyPom[1, 1], punktyPom[1, 2]) * Helper.Hypotenuse(0, punktyPom[1, 2]))));
    }
    double pom1 = punktyPom[1, 0] * Math.cos(katZ) - punktyPom[1, 1] * Math.sin(katZ);
    punktyPom[1, 1] = punktyPom[1, 0] * Math.sin(katZ) + punktyPom[1, 1] * Math.cos(katZ);
    punktyPom[1, 0] = pom1;
    double katY = modPom[0] * modPom[2] * (Math.acos((punktyPom[1, 0] * punktyPom[1, 0] + 0 * punktyPom[1, 2]) /
    (Helper.Hypotenuse(punktyPom[1, 0], punktyPom[1, 2]) * Helper.Hypotenuse(punktyPom[1, 0], 0))));
    if (Double.IsNaN(katY)) {
    katY = Helper.ConvertToRadians(90);
    }
    double pom2 = punktyPom[1, 0] * Math.cos(katY) + punktyPom[1, 2] * Math.sin(katY);
    punktyPom[1, 2] = punktyPom[1, 2] * Math.cos(katY) - punktyPom[1, 0] * Math.sin(katY);
    punktyPom[1, 0] = pom2;*/
      }
    }


    public void paint(object sender, PaintEventArgs paintEventArgs)
    {
            Image bmp = new Bitmap(pb.Width, pb.Height);
            pb.BackColor = kolorTla;
        using (Graphics g = Graphics.FromImage(bmp))
        {

            przeliczWsp();
            if (trojkaty != null &&
                wierzcholki != null &&
                srodekKamery != null &&
                srodekObrazu != null)
            {
                for (int i = 0; i < trojkaty.GetLength(0); i++)
                {
                    if ((showW[trojkaty[i, 0]] && showW[trojkaty[i, 1]]) || !trybPersp)
                    {
                        g.DrawLine(pen, obraz[trojkaty[i, 0], 0],
                            obraz[trojkaty[i, 0], 1],
                            obraz[trojkaty[i, 1], 0],
                            obraz[trojkaty[i, 1], 1]);
                    }
                    else if (showW[trojkaty[i, 0]] || showW[trojkaty[i, 1]])
                    {
                        var odl = Math.Abs(wierzcholkiPom[trojkaty[i, 0], 0] - wierzcholkiPom[trojkaty[i, 1], 0]);
                        double[] m = wierzcholkiPom[trojkaty[i, 0], 0] < 0
                            ? new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 0], 0], wierzcholkiPom[trojkaty[i, 0], 1],
                                wierzcholkiPom[trojkaty[i, 0], 2]
                            }
                            : new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 1], 0], wierzcholkiPom[trojkaty[i, 1], 1],
                                wierzcholkiPom[trojkaty[i, 1], 2]
                            };
                        double[] w = wierzcholkiPom[trojkaty[i, 0], 0] < 0
                            ? new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 1], 0], wierzcholkiPom[trojkaty[i, 1], 1],
                                wierzcholkiPom[trojkaty[i, 1], 2]
                            }
                            : new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 0], 0], wierzcholkiPom[trojkaty[i, 0], 1],
                                wierzcholkiPom[trojkaty[i, 0], 2]
                            };
                        double proporcja = Math.Abs(m[0])/odl; //todo
                        var newM = new int[3];
                        newM[0] = 0;
                        newM[1] = (int) (m[1] + ((double) (w[1] - m[1]))*proporcja); //todo
                        newM[2] = (int) (m[2] + ((double) (w[2] - m[2]))*proporcja); //todo
                        int x =
                            (int)
                                (((double) this.Width*((double) newM[1]/((double) wspPom*(double) 0.000001))) +
                                 this.Width)/2;
                        int y =
                            (int)
                                (((double) this.Height*((double) newM[2]/((double) wspPom*(double) 0.000001))) +
                                 this.Height)/2;
                        g.DrawLine(pen, x,
                            y,
                            wierzcholkiPom[trojkaty[i, 0], 0] < 0 ? obraz[trojkaty[i, 1], 0] : obraz[trojkaty[i, 0], 0],
                            wierzcholkiPom[trojkaty[i, 0], 0] < 0 ? obraz[trojkaty[i, 1], 0] : obraz[trojkaty[i, 0], 0]);
                    }
                    if ((showW[trojkaty[i, 1]] && showW[trojkaty[i, 2]]) || !trybPersp)
                    {
                        g.DrawLine(pen, obraz[trojkaty[i, 2], 0],
                            obraz[trojkaty[i, 2], 1],
                            obraz[trojkaty[i, 1], 0],
                            obraz[trojkaty[i, 1], 1]);
                    }
                    else if (showW[trojkaty[i, 2]] || showW[trojkaty[i, 1]])
                    {
                        double odl = Math.Abs(wierzcholkiPom[trojkaty[i, 2], 0] - wierzcholkiPom[trojkaty[i, 1], 0]);
                        var m = wierzcholkiPom[trojkaty[i, 2], 0] < 0
                            ? new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 2], 0], wierzcholkiPom[trojkaty[i, 2], 1],
                                wierzcholkiPom[trojkaty[i, 2], 2]
                            }
                            : new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 1], 0], wierzcholkiPom[trojkaty[i, 1], 1],
                                wierzcholkiPom[trojkaty[i, 1], 2]
                            };
                        var w = wierzcholkiPom[trojkaty[i, 2], 0] < 0
                            ? new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 1], 0], wierzcholkiPom[trojkaty[i, 1], 1],
                                wierzcholkiPom[trojkaty[i, 1], 2]
                            }
                            : new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 2], 0], wierzcholkiPom[trojkaty[i, 2], 1],
                                wierzcholkiPom[trojkaty[i, 2], 2]
                            };
                        double proporcja = Math.Abs(m[0])/odl;
                        var newM = new int[3];
                        newM[0] = 0;
                        newM[1] = (int) (m[1] + ((double) (w[1] - m[1]))*proporcja);
                        newM[2] = (int) (m[2] + ((double) (w[2] - m[2]))*proporcja);
                        int x =
                            (int)
                                (((double) this.Width*((double) newM[1]/((double) wspPom*(double) 0.000001))) +
                                 this.Width)/2;
                        int y =
                            (int)
                                (((double) this.Height*((double) newM[2]/((double) wspPom*(double) 0.000001))) +
                                 this.Height)/2;
                        g.DrawLine(pen, x,
                            y,
                            wierzcholkiPom[trojkaty[i, 2], 0] < 0 ? obraz[trojkaty[i, 1], 0] : obraz[trojkaty[i, 2], 0],
                            wierzcholkiPom[trojkaty[i, 2], 0] < 0 ? obraz[trojkaty[i, 1], 1] : obraz[trojkaty[i, 2], 1]);
                    }
                    if ((showW[trojkaty[i, 0]] && showW[trojkaty[i, 2]]) || !trybPersp)
                    {
                        g.DrawLine(pen, obraz[trojkaty[i, 0], 0],
                            obraz[trojkaty[i, 0], 1],
                            obraz[trojkaty[i, 2], 0],
                            obraz[trojkaty[i, 2], 1]);
                    }
                    else if (showW[trojkaty[i, 0]] || showW[trojkaty[i, 2]])
                    {
                        double odl = Math.Abs(wierzcholkiPom[trojkaty[i, 2], 0] - wierzcholkiPom[trojkaty[i, 0], 0]);
                        var m = wierzcholkiPom[trojkaty[i, 2], 0] < 0
                            ? new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 2], 0], wierzcholkiPom[trojkaty[i, 2], 1],
                                wierzcholkiPom[trojkaty[i, 2], 2]
                            }
                            : new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 0], 0], wierzcholkiPom[trojkaty[i, 0], 1],
                                wierzcholkiPom[trojkaty[i, 0], 2]
                            };
                        var w = wierzcholkiPom[trojkaty[i, 2], 0] < 0
                            ? new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 0], 0], wierzcholkiPom[trojkaty[i, 0], 1],
                                wierzcholkiPom[trojkaty[i, 0], 2]
                            }
                            : new double[3]
                            {
                                wierzcholkiPom[trojkaty[i, 2], 0], wierzcholkiPom[trojkaty[i, 2], 1],
                                wierzcholkiPom[trojkaty[i, 2], 2]
                            };
                        double proporcja = Math.Abs(m[0])/odl; //todo
                        var newM = new int[3];
                        newM[0] = 0;
                        newM[1] = (int) (m[1] + ((double) (w[1] - m[1]))*proporcja); //todo
                        newM[2] = (int) (m[2] + ((double) (w[2] - m[2]))*proporcja); //todo
                        int x =
                            (int)
                                (((double) this.Width*((double) newM[1]/((double) wspPom*(double) 0.000001))) +
                                 this.Width)/2;
                        int y =
                            (int)
                                (((double) this.Height*((double) newM[2]/((double) wspPom*(double) 0.000001))) +
                                 this.Height)/2;
                        g.DrawLine(pen, x,
                            y,
                            wierzcholkiPom[trojkaty[i, 2], 0] < 0 ? obraz[trojkaty[i, 0], 0] : obraz[trojkaty[i, 2], 0],
                            wierzcholkiPom[trojkaty[i, 2], 0] < 0 ? obraz[trojkaty[i, 0], 1] : obraz[trojkaty[i, 2], 1]);
                    }
                }
            }
            pen.Color = Color.Gray;
            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }
        pb.Image = bmp;
    }
  }
}