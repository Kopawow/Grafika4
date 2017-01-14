using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;

namespace zad4
{
  public partial class Form1 : Form
  {

    PasekMenu pasekMenu;
    PasekStanu pasekStanu;
    private bool changeEkranX = false;
    private bool changeEkranY = false;
    private bool changeEkranZ = false;
    private bool changeObrazX = false;
    private bool changeObrazY = false;
    private bool changeObrazZ = false;
      private bool _isDragging = false;


        public Form1()
    {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            
            GUI();
            AllowDrop = true;
    }

        
        public void GUI()
    {
      panel1 = new Panel()
      {
          Dock = DockStyle.Fill
      };
      pasekMenu = new PasekMenu(this);
      pasekStanu = new PasekStanu(panel1);
            pasekStanu.paintComponent();
            pasekStanu._panel.Refresh();
            pasekMenu.wczytajKamere.Click += ActionPerformed;
        pasekMenu.wczytajScene.Click += ActionPerformed;
        pasekMenu.wPersp.Click += ActionPerformed;
            pasekMenu.settings.Click += NewAction;
            pasekStanu.pKameryX.TextChanged += ActionPerformed;
            pasekStanu.pKameryY.TextChanged += ActionPerformed;
            pasekStanu.pKameryZ.TextChanged += ActionPerformed;
            pasekStanu.pObrazuX.TextChanged += ActionPerformed;
            pasekStanu.pObrazuY.TextChanged += ActionPerformed;
            pasekStanu.pObrazuZ.TextChanged += ActionPerformed;
            pasekStanu.pow.TextChanged += ActionPerformed;

            //this.MouseMove += mouseMoved;
            this.MouseWheel += mouseWheelMoved;

        //OrtX1.pb.DragDrop += mouseDragged;
        //ortY1.pb.DragDrop += mouseDragged;
        //ortZ1.pb.DragDrop += mouseDragged;
        //persp1.pb.DragDrop += mouseDragged;

            OrtX1.pb.MouseDown += new MouseEventHandler(c_MouseDown);
            ortY1.pb.MouseDown += new MouseEventHandler(c_MouseDown);
            ortZ1.pb.MouseDown += new MouseEventHandler(c_MouseDown);
             OrtX1.pb.MouseMove += new MouseEventHandler(c_MouseMove);
             ortY1.pb.MouseMove += new MouseEventHandler(c_MouseMove);
            ortZ1.pb.MouseMove += new MouseEventHandler(c_MouseMove);
            OrtX1.pb.MouseUp += new MouseEventHandler(c_MouseUp);
            ortY1.pb.MouseUp += new MouseEventHandler(c_MouseUp);
            ortZ1.pb.MouseUp += new MouseEventHandler(c_MouseUp);
        }

      private void NewAction(object sender, EventArgs e)
      {
          var form = new Form();
          form.Controls.Add(pasekStanu._panel);
          pasekStanu.paintComponent();
            pasekStanu._panel.Refresh();
          form.Show();
      }

      void c_MouseDown(object sender, MouseEventArgs e)
        {
            
            _isDragging = true;
            if (OrtX1.srodekKamery != null)
            {

                var location = ((Control)sender).PointToScreen(Point.Empty);
                int x = location.X;
                int y = location.Y;

                var locationOrtX1 = (OrtX1).PointToScreen(Point.Empty);
                var locationOrtY1 = (ortY1).PointToScreen(Point.Empty);
                var locationOrtZ1 = (ortZ1).PointToScreen(Point.Empty);
                if     (x >= locationOrtX1.X + OrtX1.srodekKameryE[1] - 3 &&
                        x <= locationOrtX1.X + OrtX1.srodekKameryE[1] + 2 &&
                        y >= locationOrtX1.Y + OrtX1.srodekKameryE[2] - 3 &&
                        y <= locationOrtX1.Y + OrtX1.srodekKameryE[2] + 2)
                {
                    changeEkranY = true;
                    changeEkranZ = true;
                }
                else if (x >= locationOrtY1.X + ortY1.srodekKameryE[0] - 3 &&
                      x <= locationOrtY1.X + ortY1.srodekKameryE[0] + 2 &&
                      y >= locationOrtY1.Y + ortY1.srodekKameryE[2] - 3 &&
                      y <= locationOrtY1.Y + ortY1.srodekKameryE[2] + 2)
                {
                    changeEkranX = true;
                    changeEkranZ = true;
                }
                else if (x >= locationOrtZ1.X + ortZ1.srodekKameryE[0] - 3 &&
                      x <= locationOrtZ1.X + ortZ1.srodekKameryE[0] + 2 &&
                      y >= locationOrtZ1.Y + ortZ1.srodekKameryE[1] - 3 &&
                      y <= locationOrtZ1.Y + ortZ1.srodekKameryE[1] + 2)
                {
                    changeEkranX = true;
                    changeEkranY = true;
                }
                else if (x >= locationOrtX1.X + OrtX1.srodekObrazuE[1] - 3 &&
                         x <= locationOrtX1.X + OrtX1.srodekObrazuE[1] + 2 &&
                         y >= locationOrtX1.Y + OrtX1.srodekObrazuE[2] - 3 &&
                         y <= locationOrtX1.Y + OrtX1.srodekObrazuE[2] + 2)
                {
                    changeObrazY = true;
                    changeObrazZ = true;
                }
                else if (x >= locationOrtY1.X + ortY1.srodekObrazuE[0] - 3 &&
                      x <= locationOrtY1.X + ortY1.srodekObrazuE[0] + 2 &&
                      y >= locationOrtY1.Y + ortY1.srodekObrazuE[2] - 3 &&
                      y <= locationOrtY1.Y + ortY1.srodekObrazuE[2] + 2)
                {
                    changeObrazX = true;
                    changeObrazZ = true;
                }
                else if (x >= locationOrtZ1.X + ortZ1.srodekObrazuE[0] - 3 &&
                      x <= locationOrtZ1.X  + ortZ1.srodekObrazuE[0] + 2 &&
                      y >= locationOrtZ1.Y  + ortZ1.srodekObrazuE[1] - 3 &&
                      y <= locationOrtZ1.Y + ortZ1.srodekObrazuE[1] + 2)
                {
                    changeObrazX = true;
                    changeObrazY = true;
                }
            }

        }

        void c_MouseMove(object sender, MouseEventArgs e)
        {

            if (_isDragging == true)
            {
               mouseDragged(sender,e);
            }
        }

        void c_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
            changeEkranX = false;
            changeEkranY = false;
            changeEkranZ = false;
            changeObrazX = false;
            changeObrazY = false;
            changeObrazZ = false;
        }
        public void zmienKamere(int x, int y, int z)
    {
      OrtX1.srodekKamery[0] = x;
      OrtX1.srodekKamery[1] = y;
      OrtX1.srodekKamery[2] = z;
      ortY1.srodekKamery[0] = x;
      ortY1.srodekKamery[1] = y;
      ortY1.srodekKamery[2] = z;
      ortZ1.srodekKamery[0] = x;
      ortZ1.srodekKamery[1] = y;
      ortZ1.srodekKamery[2] = z;
      persp1.srodekKamery[0] = x;
      persp1.srodekKamery[1] = y;
      persp1.srodekKamery[2] = z;
    }

    public void zmienObraz(int x, int y, int z)
    {
      OrtX1.srodekObrazu[0] = x;
      OrtX1.srodekObrazu[1] = y;
      OrtX1.srodekObrazu[2] = z;
      ortY1.srodekObrazu[0] = x;
      ortY1.srodekObrazu[1] = y;
      ortY1.srodekObrazu[2] = z;
      ortZ1.srodekObrazu[0] = x;
      ortZ1.srodekObrazu[1] = y;
      ortZ1.srodekObrazu[2] = z;
      persp1.srodekObrazu[0] = x;
      persp1.srodekObrazu[1] = y;
      persp1.srodekObrazu[2] = z;
    }

    public void minMax()
    {
      OrtX1.maxX = int.MinValue;
      OrtX1.minX = int.MaxValue;
      OrtX1.maxY = int.MinValue;
      OrtX1.minY = int.MaxValue;
      OrtX1.maxZ = int.MinValue;
      OrtX1.minZ = int.MaxValue;
      ortY1.maxX = int.MinValue;
      ortY1.minX = int.MaxValue;
      ortY1.maxY = int.MinValue;
      ortY1.minY = int.MaxValue;
      ortY1.maxZ = int.MinValue;
      ortY1.minZ = int.MaxValue;
      ortZ1.maxX = int.MinValue;
      ortZ1.minX = int.MaxValue;
      ortZ1.maxY = int.MinValue;
      ortZ1.minY = int.MaxValue;
      ortZ1.maxZ = int.MinValue;
      ortZ1.minZ = int.MaxValue;
      for (var i = 0; i < OrtX1.wierzcholki.GetLength(0); i++)
      {
        if (OrtX1.wierzcholki[i, 0] > OrtX1.maxX)
        {
          OrtX1.maxX = OrtX1.wierzcholki[i, 0];
          ortY1.maxX = OrtX1.wierzcholki[i, 0];
          ortZ1.maxX = OrtX1.wierzcholki[i, 0];
        }
        if (OrtX1.wierzcholki[i, 0] < OrtX1.minX)
        {
          OrtX1.minX = OrtX1.wierzcholki[i, 0];
          ortY1.minX = OrtX1.wierzcholki[i, 0];
          ortZ1.minX = OrtX1.wierzcholki[i, 0];
        }
        if (OrtX1.wierzcholki[i, 1] > OrtX1.maxY)
        {
          OrtX1.maxY = OrtX1.wierzcholki[i, 1];
          ortY1.maxY = OrtX1.wierzcholki[i, 1];
          ortZ1.maxY = OrtX1.wierzcholki[i, 1];
        }
        if (OrtX1.wierzcholki[i, 1] < OrtX1.minY)
        {
          OrtX1.minY = OrtX1.wierzcholki[i, 1];
          ortY1.minY = OrtX1.wierzcholki[i, 1];
          ortZ1.minY = OrtX1.wierzcholki[i, 1];
        }
        if (OrtX1.wierzcholki[i, 2] > OrtX1.maxZ)
        {
          OrtX1.maxZ = OrtX1.wierzcholki[i, 2];
          ortY1.maxZ = OrtX1.wierzcholki[i, 2];
          ortZ1.maxZ = OrtX1.wierzcholki[i, 2];
        }
        if (OrtX1.wierzcholki[i, 2] < OrtX1.minZ)
        {
          OrtX1.minZ = OrtX1.wierzcholki[i, 2];
          ortY1.minZ = OrtX1.wierzcholki[i, 2];
          ortZ1.minZ = OrtX1.wierzcholki[i, 2];
        }
      }
      if (OrtX1.srodekKamery[0] > OrtX1.maxX)
      {
        OrtX1.maxX = OrtX1.srodekKamery[0];
        ortY1.maxX = OrtX1.srodekKamery[0];
        ortZ1.maxX = OrtX1.srodekKamery[0];
      }
      if (OrtX1.srodekKamery[0] < OrtX1.minX)
      {
        OrtX1.minX = OrtX1.srodekKamery[0];
        ortY1.minX = OrtX1.srodekKamery[0];
        ortZ1.minX = OrtX1.srodekKamery[0];
      }
      if (OrtX1.srodekKamery[1] > OrtX1.maxY)
      {
        OrtX1.maxY = OrtX1.srodekKamery[1];
        ortY1.maxY = OrtX1.srodekKamery[1];
        ortZ1.maxY = OrtX1.srodekKamery[1];
      }
      if (OrtX1.srodekKamery[1] < OrtX1.minY)
      {
        OrtX1.minY = OrtX1.srodekKamery[1];
        ortY1.minY = OrtX1.srodekKamery[1];
        ortZ1.minY = OrtX1.srodekKamery[1];
      }
      if (OrtX1.srodekKamery[2] > OrtX1.maxZ)
      {
        OrtX1.maxZ = OrtX1.srodekKamery[2];
        ortY1.maxZ = OrtX1.srodekKamery[2];
        ortY1.maxZ = OrtX1.srodekKamery[2];
      }
      if (OrtX1.srodekKamery[2] < OrtX1.minZ)
      {
        OrtX1.minZ = OrtX1.srodekKamery[2];
        ortY1.minZ = OrtX1.srodekKamery[2];
        ortZ1.minZ = OrtX1.srodekKamery[2];
      }
      if (OrtX1.srodekObrazu[0] > OrtX1.maxX)
      {
        OrtX1.maxX = OrtX1.srodekObrazu[0];
        ortY1.maxX = OrtX1.srodekObrazu[0];
        ortZ1.maxX = OrtX1.srodekObrazu[0];
      }
      if (OrtX1.srodekObrazu[0] < OrtX1.minX)
      {
        OrtX1.minX = OrtX1.srodekObrazu[0];
        ortY1.minX = OrtX1.srodekObrazu[0];
        ortZ1.minX = OrtX1.srodekObrazu[0];
      }
      if (OrtX1.srodekObrazu[1] > OrtX1.maxY)
      {
        OrtX1.maxY = OrtX1.srodekObrazu[1];
        ortY1.maxY = OrtX1.srodekObrazu[1];
        ortZ1.maxY = OrtX1.srodekObrazu[1];
      }
      if (OrtX1.srodekObrazu[1] < OrtX1.minY)
      {
        OrtX1.minY = OrtX1.srodekObrazu[1];
        ortY1.minY = OrtX1.srodekObrazu[1];
        ortZ1.minY = OrtX1.srodekObrazu[1];
      }
      if (OrtX1.srodekObrazu[2] > OrtX1.maxZ)
      {
        OrtX1.maxZ = OrtX1.srodekObrazu[2];
        ortY1.maxZ = OrtX1.srodekObrazu[2];
        ortZ1.maxZ = OrtX1.srodekObrazu[2];
      }
      if (OrtX1.srodekObrazu[2] < OrtX1.minZ)
      {
        OrtX1.minZ = OrtX1.srodekObrazu[2];
        ortY1.minZ = OrtX1.srodekObrazu[2];
        ortZ1.minZ = OrtX1.srodekObrazu[2];
      }
    }
        private void obliczOstroslup()
        {
            if (OrtX1.srodekKamery != null && OrtX1.srodekObrazu != null)
            {
                //wierzcholki podstawy ostroslupa
                var wierzch = new double[4, 3];
                //
                var punktyPom = new double[2, 3];
                for (var i = 0; i < 3; i++)
                {
                    punktyPom[0, i] = OrtX1.srodekKamery[i];
                    //punkt obrazu po przesunieciu
                }
                for (var i = 0; i < 3; i++)
                {
                    punktyPom[1, i] = OrtX1.srodekObrazu[i] - OrtX1.srodekKamery[i];
                }
                //katy obrotu
                var modPom = new int[3];
                for (var i = 0; i < 3; i++)
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
                /*int spr=-1;
            for(int i=1;i<3;i++)
            {
            if(modPom[i]!=modPom[0]) spr=1;
            }
            System.out.println(spr);*/
                double katZ = -1 * modPom[0] * modPom[1] * Math.Acos((punktyPom[1, 0] * punktyPom[1, 0] + 0 * punktyPom[1, 1]) /
                                                               (Helper.Hypotenuse(punktyPom[1, 0], punktyPom[1, 1]) *
                                                                Helper.Hypotenuse(punktyPom[1, 0], 0)));
                if (double.IsNaN(katZ))
                {
                    katZ = Helper.ConvertToRadians(-1 * modPom[1] * 90);
                    /*double katX = -(Math.acos((punktyPom[1, 1] * punktyPom[1, 1] + punktyPom[1, 2] * 0) /
            (Helper.Hypotenuse(punktyPom[1, 1], punktyPom[1, 2]) * Helper.Hypotenuse(0, punktyPom[1, 2]))));*/
                }
                double pom1 = punktyPom[1, 0] * Math.Cos(katZ) - punktyPom[1, 1] * Math.Sin(katZ);
                punktyPom[1, 1] = punktyPom[1, 0] * Math.Sin(katZ) + punktyPom[1, 1] * Math.Cos(katZ);
                punktyPom[1, 0] = pom1;
                double katY = modPom[0] * modPom[2] * Math.Acos((punktyPom[1, 0] * punktyPom[1, 0] + 0 * punktyPom[1, 2]) /
                                                            (Helper.Hypotenuse(punktyPom[1, 0], punktyPom[1, 2]) *
                                                             Helper.Hypotenuse(punktyPom[1, 0], 0)));
                if (double.IsNaN(katY))
                {
                    katY = Helper.ConvertToRadians(90);
                }
                double pom2 = punktyPom[1, 0] * Math.Cos(katY) + punktyPom[1, 2] * Math.Sin(katY);
                punktyPom[1, 2] = punktyPom[1, 2] * Math.Cos(katY) - punktyPom[1, 0] * Math.Sin(katY);
                punktyPom[1, 0] = pom2;
                double wspPom = Math.Tan(Helper.ConvertToRadians(OrtX1.katRozwarcia)) * punktyPom[1, 0];
                wierzch[0, 1] = -wspPom;
                wierzch[0, 2] = -wspPom;
                wierzch[1, 1] = -wspPom;
                wierzch[1, 2] = wspPom;
                wierzch[2, 1] = wspPom;
                wierzch[2, 2] = wspPom;
                wierzch[3, 1] = wspPom;
                wierzch[3, 2] = -wspPom;
                for (var i = 0; i < 4; i++)
                {
                    wierzch[i, 0] = (int)punktyPom[1, 0];
                    pom2 = wierzch[i, 0] * Math.Cos(-katY) + wierzch[i, 2] * Math.Sin(-katY);
                    wierzch[i, 2] = wierzch[i, 2] * Math.Cos(-katY) - wierzch[i, 0] * Math.Sin(-katY);
                    wierzch[i, 0] = pom2;
                    pom1 = wierzch[i, 0] * Math.Cos(-katZ) - wierzch[i, 1] * Math.Sin(-katZ);
                    wierzch[i, 1] = wierzch[i, 0] * Math.Sin(-katZ) + wierzch[i, 1] * Math.Cos(-katZ);
                    wierzch[i, 0] = pom1;
                    for (var j = 0; j < 3; j++)
                    {
                        wierzch[i, j] += punktyPom[0, j];
                    }
                }
                OrtX1.wierzch = wierzch;
                ortY1.wierzch = wierzch;
                ortZ1.wierzch = wierzch;
            }
        }

        public void ActionPerformed(object sender, EventArgs eventArgs)
        {
            Object zrodlo = (sender as MenuItem)!=null ?sender: (Control)sender;
            if (zrodlo == pasekMenu.zakoncz)
            {
                this.Close();
            }
            else if (zrodlo == pasekMenu.wPersp)
            {
                persp1.trybPersp = !persp1.trybPersp;
                Refresh();
            }
            else if (zrodlo == pasekMenu.wczytajScene)
            {
                OpenFileDialog wybierz = new OpenFileDialog();

                var opcja = wybierz.ShowDialog();
                if (opcja == DialogResult.OK)
                {
                    try
                    {
                        int j = 0;
                        StreamReader fileBuff = new StreamReader(wybierz.FileName);
                        var file = fileBuff.ReadToEnd();
                        var st = file.Split(' ','\r','\n').Where(x=> !string.IsNullOrEmpty(x)).ToArray();
                        for (int s = 0; s < st.Length; s++)
                        {
                            st[s] = st[s].Replace('.', ',');
                        }
                        int iloscWierzcholkow = int.Parse(st[j++]);
                        OrtX1.wierzcholki = new int[iloscWierzcholkow, 3];
                        ortY1.wierzcholki = new int[iloscWierzcholkow, 3];
                        ortZ1.wierzcholki = new int[iloscWierzcholkow, 3];
                        persp1.wierzcholki = new int[iloscWierzcholkow, 3];
                        for (int i = 0; i < iloscWierzcholkow; i++)
                        {
                            OrtX1.wierzcholki[i, 0] = (int)double.Parse(st[j]);
                            ortY1.wierzcholki[i, 0] = (int)double.Parse(st[j]);
                            ortZ1.wierzcholki[i, 0] = (int)double.Parse(st[j]);
                            persp1.wierzcholki[i, 0] = (int)double.Parse(st[j++]);

                            OrtX1.wierzcholki[i, 1] = (int)double.Parse(st[j]);
                            ortY1.wierzcholki[i, 1] = (int)double.Parse(st[j]);
                            ortZ1.wierzcholki[i, 1] = (int)double.Parse(st[j]);
                            persp1.wierzcholki[i, 1] = (int)double.Parse(st[j++]);

                            OrtX1.wierzcholki[i, 2] = (int)double.Parse(st[j]);
                            ortY1.wierzcholki[i, 2] = (int)double.Parse(st[j]);
                            ortZ1.wierzcholki[i, 2] = (int)double.Parse(st[j]);
                            persp1.wierzcholki[i, 2] = (int)double.Parse(st[j++]);
                        }

                        int iloscTrojkatow = (int)double.Parse(st[j++]);
                        OrtX1.trojkaty = new int[iloscTrojkatow, 3];
                        ortY1.trojkaty = new int[iloscTrojkatow, 3];
                        ortZ1.trojkaty = new int[iloscTrojkatow, 3];
                        persp1.trojkaty = new int[iloscTrojkatow, 3];

                        for (int i = 0; i < iloscTrojkatow; i++)
                        {

                            OrtX1.trojkaty[i, 0] = int.Parse(st[j]);
                            ortY1.trojkaty[i, 0] = int.Parse(st[j]);
                            ortZ1.trojkaty[i, 0] = int.Parse(st[j]);
                            persp1.trojkaty[i, 0] = int.Parse(st[j++]);

                            OrtX1.trojkaty[i, 1] = int.Parse(st[j]);
                            ortY1.trojkaty[i, 1] = int.Parse(st[j]);
                            ortZ1.trojkaty[i, 1] = int.Parse(st[j]);
                            persp1.trojkaty[i, 1] = int.Parse(st[j++]);

                            OrtX1.trojkaty[i, 2] = int.Parse(st[j]);
                            ortY1.trojkaty[i, 2] = int.Parse(st[j]);
                            ortZ1.trojkaty[i, 2] = int.Parse(st[j]);
                            persp1.trojkaty[i, 2] = int.Parse(st[j++]);
                        }
                        fileBuff.Close();
                        if (OrtX1.srodekKamery == null)
                        {
                            OrtX1.srodekKamery = new int[3];
                            OrtX1.srodekObrazu = new int[3];
                            ortY1.srodekKamery = new int[3];
                            ortY1.srodekObrazu = new int[3];
                            ortZ1.srodekKamery = new int[3];
                            ortZ1.srodekObrazu = new int[3];
                            persp1.srodekKamery = new int[3];
                            persp1.srodekObrazu = new int[3];
                            OrtX1.srodekKamery[0] = 0;
                            ortY1.srodekKamery[0] = 0;
                            ortZ1.srodekKamery[0] = 0;
                            persp1.srodekKamery[0] = 0;
                            OrtX1.srodekKamery[1] = 0;
                            ortY1.srodekKamery[1] = 0;
                            ortZ1.srodekKamery[1] = 0;
                            persp1.srodekKamery[1] = 0;
                            OrtX1.srodekKamery[2] = 0;
                            ortY1.srodekKamery[2] = 0;
                            ortZ1.srodekKamery[2] = 0;
                            persp1.srodekKamery[2] = 0;
                            OrtX1.srodekObrazu[0] = 0;
                            ortY1.srodekObrazu[0] = 0;
                            ortZ1.srodekObrazu[0] = 0;
                            persp1.srodekObrazu[0] = 0;
                            OrtX1.srodekObrazu[1] = 0;
                            ortY1.srodekObrazu[1] = 0;
                            ortZ1.srodekObrazu[1] = 0;
                            persp1.srodekObrazu[1] = 0;
                            OrtX1.srodekObrazu[2] = 0;
                            ortY1.srodekObrazu[2] = 0;
                            ortZ1.srodekObrazu[2] = 0;
                            persp1.srodekObrazu[2] = 0;
                        }
                        minMax();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("BĹ‚Ä…d I/O");
                    }
                }
                Refresh();
            }
            else if (zrodlo == pasekMenu.wczytajKamere)
            {
                OrtX1.srodekKamery = new int[3];
                OrtX1.srodekObrazu = new int[3];
                ortY1.srodekKamery = new int[3];
                ortY1.srodekObrazu = new int[3];
                ortZ1.srodekKamery = new int[3];
                ortZ1.srodekObrazu = new int[3];
                persp1.srodekKamery = new int[3];
                persp1.srodekObrazu = new int[3];
                OpenFileDialog wybierz = new OpenFileDialog();

                var opcja = wybierz.ShowDialog();
                if (opcja == DialogResult.OK)
                {
                    try
                    {
                        StreamReader fileBuff = new StreamReader(wybierz.FileName);
                        var file = fileBuff.ReadToEnd();
                        var st = file.Split(' ', '\r', '\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        var j = 0;
                        OrtX1.srodekKamery[0] = (int)double.Parse(st[j]);
                        ortY1.srodekKamery[0] = (int)double.Parse(st[j]);
                        ortZ1.srodekKamery[0] = (int)double.Parse(st[j]);
                        persp1.srodekKamery[0] = (int)double.Parse(st[j]);
                        pasekStanu.pKameryX.Text = ((int)double.Parse(st[j++])).ToString();

                        OrtX1.srodekKamery[1] = (int)double.Parse(st[j]);
                        ortY1.srodekKamery[1] = (int)double.Parse(st[j]);
                        ortZ1.srodekKamery[1] = (int)double.Parse(st[j]);
                        persp1.srodekKamery[1] = (int)double.Parse(st[j]);
                        pasekStanu.pKameryY.Text = ((int)double.Parse(st[j++])).ToString();

                        OrtX1.srodekKamery[2] = (int)double.Parse(st[j]);
                        ortY1.srodekKamery[2] = (int)double.Parse(st[j]);
                        ortZ1.srodekKamery[2] = (int)double.Parse(st[j]);
                        persp1.srodekKamery[2] = (int)double.Parse(st[j]);
                        pasekStanu.pKameryZ.Text = ((int)double.Parse(st[j++])).ToString();

                        OrtX1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        ortY1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        ortZ1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        persp1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        pasekStanu.pObrazuX.Text = ((int)double.Parse(st[j++])).ToString();

                        OrtX1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        ortY1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        ortZ1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        persp1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        pasekStanu.pObrazuY.Text = ((int)double.Parse(st[j++])).ToString();

                        OrtX1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        ortY1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        ortZ1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        persp1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        pasekStanu.pObrazuZ.Text = ((int)double.Parse(st[j++])).ToString();

                        OrtX1.katRozwarcia = (int)double.Parse(st[j]);
                        ortY1.katRozwarcia = (int)double.Parse(st[j]);
                        ortZ1.katRozwarcia = (int)double.Parse(st[j]);
                        persp1.katRozwarcia = (int)double.Parse(st[j]);
                        pasekStanu.katKamery.Text = ((int)double.Parse(st[j++])).ToString();
                        fileBuff.Close();
                        minMax();
                    }
                    catch (IOException ex)
                    {

                    }
                }
            }
            else if (zrodlo == pasekMenu.zapiszKamere)
            {
                if (OrtX1.srodekKamery == null || OrtX1.srodekObrazu == null || OrtX1.katRozwarcia == 0)
                {
                    //NotificationWindow w = new NotificationWindow("Brak pliku do zapisu.", true);
                }
                else
                {
                    OpenFileDialog wybierz = new OpenFileDialog();

                    var opcja = wybierz.ShowDialog();
                    if (opcja == DialogResult.Cancel)
                    {
                       // NotificationWindow w = new NotificationWindow("Nie wybrano Ĺ›cieĹĽki. Zapis nie powiĂłdĹ‚ siÄ™.", true);
                    }
                    else if (opcja == DialogResult.OK)
                    {
                        try
                        { 
                            StreamWriter zapiszWek = new StreamWriter(wybierz.FileName);
                            zapiszWek.Write(OrtX1.srodekKamery[0] + " " + OrtX1.srodekKamery[1] + " " + OrtX1.srodekKamery[2]);
                            zapiszWek.Write(OrtX1.srodekObrazu[0] + " " + OrtX1.srodekObrazu[1] + " " + OrtX1.srodekObrazu[2]);
                            zapiszWek.Write(OrtX1.katRozwarcia);
                            zapiszWek.Close();
                        }
                        catch (IOException ex)
                        {
                           // NotificationWindow x = new NotificationWindow("BĹ‚Ä…d I/O", true);
                        }
                    }
                }
            }
            else if (zrodlo == pasekStanu.pow)
            {
                int x = int.Parse(pasekStanu.pow.Text);
                OrtX1.pow = (double)x / 100;
                ortY1.pow = (double)x / 100;
                ortZ1.pow = (double)x / 100;
                Refresh();
            }
            else if (zrodlo == pasekStanu.pKameryX)
            {
                int x = int.Parse(pasekStanu.pKameryX.Text);
                OrtX1.srodekKamery[0] = x;
                ortY1.srodekKamery[0] = x;
                ortZ1.srodekKamery[0] = x;
                persp1.srodekKamery[0] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pKameryY)
            {
                int x = int.Parse(pasekStanu.pKameryY.Text);
                OrtX1.srodekKamery[1] = x;
                ortY1.srodekKamery[1] = x;
                ortZ1.srodekKamery[1] = x;
                persp1.srodekKamery[1] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pKameryZ)
            {
                int x = int.Parse(pasekStanu.pKameryZ.Text);
                OrtX1.srodekKamery[2] = x;
                ortY1.srodekKamery[2] = x;
                ortZ1.srodekKamery[2] = x;
                persp1.srodekKamery[2] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pObrazuX)
            {
                int x = int.Parse(pasekStanu.pObrazuX.Text);
                OrtX1.srodekObrazu[0] = x;
                ortY1.srodekObrazu[0] = x;
                ortZ1.srodekObrazu[0] = x;
                persp1.srodekObrazu[0] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pObrazuY)
            {
                int x = int.Parse(pasekStanu.pObrazuY.Text);
                OrtX1.srodekObrazu[1] = x;
                ortY1.srodekObrazu[1] = x;
                ortZ1.srodekObrazu[1] = x;
                persp1.srodekObrazu[1] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pObrazuZ)
            {
                int x = int.Parse(pasekStanu.pObrazuZ.Text);
                OrtX1.srodekObrazu[2] = x;
                ortY1.srodekObrazu[2] = x;
                ortZ1.srodekObrazu[2] = x;
                persp1.srodekObrazu[2] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.katKamery)
            {
                double x = (double)int.Parse(pasekStanu.katKamery.Text);
                if (x < 1)
                {
                    x = 1;
                    pasekStanu.katKamery.Text =1.ToString();
                }
                else if (x > 179)
                {
                    x = 179;
                    pasekStanu.katKamery.Text = 179.ToString();
                }
                OrtX1.katRozwarcia = (int)(x / 2);
                ortY1.katRozwarcia = (int)(x / 2);
                ortZ1.katRozwarcia = (int)(x / 2);
                persp1.katRozwarcia = (int)(x / 2);
                minMax();
                Refresh();
            }
        }

        public void mouseDragged(object sender, MouseEventArgs dragEventArgs)
        {
            var location = dragEventArgs.Location;
            int x = location.X;
            int y = location.Y;

            var locationOrtX1 = (OrtX1).PointToScreen(Point.Empty);
            var locationOrtY1 = (ortY1).PointToScreen(Point.Empty);
            var locationOrtZ1 = (ortZ1).PointToScreen(Point.Empty);

            if (x >= locationOrtX1.X &&
                    x <locationOrtX1.X + OrtX1.Width &&
                    y >=locationOrtX1.Y &&
                    y <locationOrtX1.Y + OrtX1.Height)
            {
                if (changeObrazY)
                {
                    OrtX1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    ortY1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    ortZ1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    persp1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    pasekStanu.pObrazuY.Text = ((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2).ToString();
                }
                else if (changeEkranY)
                {
                    OrtX1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    ortY1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    ortZ1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    persp1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2);
                    pasekStanu.pKameryY.Text = ((double)(x -locationOrtX1.X - (double)OrtX1.Width / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Width * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2).ToString();
                }
                if (changeObrazZ)
                {
                    OrtX1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    ortY1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    ortZ1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    persp1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    pasekStanu.pObrazuZ.Text = ((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2).ToString();
                }
                else if (changeEkranZ)
                {
                    OrtX1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    ortY1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    ortZ1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    persp1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2);
                    pasekStanu.pKameryZ.Text = ((double)(y -locationOrtX1.Y - (double)OrtX1.Height / 2) * ((double)OrtX1.prop / ((double)(OrtX1.Height * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2).ToString();
                }
            }
            else if (x >=locationOrtY1.X &&
                  x <locationOrtY1.X + ortY1.Width &&
                  y >=locationOrtY1.Y &&
                  y <locationOrtY1.Y + ortY1.Height)
            {
                if (changeObrazX)
                {
                    OrtX1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortY1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortZ1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    persp1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    pasekStanu.pObrazuX.Text  = ((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2).ToString();
                }
                else if (changeEkranX)
                {
                    OrtX1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortY1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortZ1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    persp1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    pasekStanu.pKameryX.Text = ((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * OrtX1.pow))) + (ortY1.minX + ortY1.maxX) / 2).ToString();
                }
                if (changeObrazZ)
                {
                    OrtX1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    ortY1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    ortZ1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    persp1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    pasekStanu.pObrazuZ.Text = ((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2).ToString();
                }
                else if (changeEkranZ)
                {
                    OrtX1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    ortY1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    ortZ1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    persp1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2);
                    pasekStanu.pKameryZ.Text = ((double)(y -locationOrtY1.Y - (double)OrtX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * OrtX1.pow))) + (ortY1.minZ + OrtX1.maxZ) / 2).ToString();
                }
            }
            else if (x >=locationOrtZ1.X &&
                  x <locationOrtZ1.X + ortZ1.Width &&
                  y >=locationOrtZ1.Y &&
                  y <locationOrtZ1.Y + ortZ1.Height)
            {
                if (changeObrazX)
                {
                    OrtX1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortY1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortZ1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    persp1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    pasekStanu.pObrazuX.Text = ((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2).ToString();
                }
                else if (changeEkranX)
                {
                    OrtX1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortY1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortZ1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    persp1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    pasekStanu.pKameryX.Text = ((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * OrtX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2).ToString();
                }
                if (changeObrazY)
                {
                    OrtX1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    ortY1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    ortZ1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    persp1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    pasekStanu.pObrazuY.Text = ((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2).ToString();
                }
                else if (changeEkranY)
                {
                    OrtX1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    ortY1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    ortZ1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    persp1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2);
                    pasekStanu.pKameryY.Text = ((double)(y -locationOrtZ1.Y - (double)OrtX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * OrtX1.pow))) + (ortZ1.minY + OrtX1.maxY) / 2).ToString();
                }
            }
            Refresh();
        }

        //public void mouseMoved(object sender, MouseEventArgs mouseEventArgs)
        //{
        //    int x = e.getXOnScreen();
        //    int y = e.getYOnScreen();
        //    pasekStanu.changeLabel("");
        //    if (x >= OrtX1.getLocationOnScreen().getX() &&
        //            x < OrtX1.getLocationOnScreen().getX() + OrtX1.getWidth() &&
        //            y >= OrtX1.getLocationOnScreen().getY() &&
        //            y < OrtX1.getLocationOnScreen().getY() + OrtX1.getHeight())
        //    {
        //        pasekStanu.changeLabel("Y: " + (int)((double)(x - OrtX1.getLocationOnScreen().getX() - (double)OrtX1.getWidth() / 2) * ((double)OrtX1.prop / ((double)(OrtX1.getWidth() * OrtX1.pow))) + (OrtX1.minY + OrtX1.maxY) / 2) + " Z: " + (int)((double)(y - OrtX1.getLocationOnScreen().getY() - (double)OrtX1.getHeight() / 2) * ((double)OrtX1.prop / ((double)(OrtX1.getHeight() * OrtX1.pow))) + (OrtX1.minZ + OrtX1.maxZ) / 2));
        //    }
        //    else if (x >= obszarRoboczy.ortY.getLocationOnScreen().getX() &&
        //          x < obszarRoboczy.ortY.getLocationOnScreen().getX() + obszarRoboczy.ortY.getWidth() &&
        //          y >= obszarRoboczy.ortY.getLocationOnScreen().getY() &&
        //          y < obszarRoboczy.ortY.getLocationOnScreen().getY() + obszarRoboczy.ortY.getHeight())
        //    {
        //        pasekStanu.changeLabel("X: " + (int)((double)(x - obszarRoboczy.ortY.getLocationOnScreen().getX() - (double)obszarRoboczy.ortY.getWidth() / 2) * ((double)obszarRoboczy.ortY.prop / ((double)(obszarRoboczy.ortY.getWidth() * OrtX1.pow))) + (obszarRoboczy.ortY.minX + obszarRoboczy.ortY.maxX) / 2) + " Z: " + (int)((double)(y - obszarRoboczy.ortY.getLocationOnScreen().getY() - (double)OrtX1.getHeight() / 2) * ((double)obszarRoboczy.ortY.prop / ((double)(obszarRoboczy.ortY.getHeight() * OrtX1.pow))) + (obszarRoboczy.ortY.minZ + OrtX1.maxZ) / 2));
        //    }
        //    else if (x >= obszarRoboczy.ortZ.getLocationOnScreen().getX() &&
        //          x < obszarRoboczy.ortZ.getLocationOnScreen().getX() + obszarRoboczy.ortZ.getWidth() &&
        //          y >= obszarRoboczy.ortZ.getLocationOnScreen().getY() &&
        //          y < obszarRoboczy.ortZ.getLocationOnScreen().getY() + obszarRoboczy.ortZ.getHeight())
        //    {
        //        pasekStanu.changeLabel("X: " + (int)((double)(x - obszarRoboczy.ortZ.getLocationOnScreen().getX() - (double)obszarRoboczy.ortZ.getWidth() / 2) * ((double)obszarRoboczy.ortZ.prop / ((double)(obszarRoboczy.ortZ.getWidth() * OrtX1.pow))) + (obszarRoboczy.ortZ.minX + obszarRoboczy.ortZ.maxX) / 2) + " Y: " + (int)((double)(y - obszarRoboczy.ortZ.getLocationOnScreen().getY() - (double)OrtX1.getHeight() / 2) * ((double)obszarRoboczy.ortZ.prop / ((double)(obszarRoboczy.ortZ.getHeight() * OrtX1.pow))) + (obszarRoboczy.ortZ.minY + OrtX1.maxY) / 2));
        //    }
        //}

        public void mouseWheelMoved(object sender, MouseEventArgs mouseEventArgs)
        {
            int rot = mouseEventArgs.Delta;
            if (rot != 0)
            {
                int newPow;
                if (rot < 0)
                {
                    newPow = (int)(1.2 * double.Parse(pasekStanu.pow.Text));
                }
                else
                {
                    newPow = (int)(0.8 * double.Parse(pasekStanu.pow.Text));
                }
                if (newPow < 10)
                {
                    newPow = 10;
                }
                pasekStanu.pow.Text = newPow.ToString();
                OrtX1.pow = ((double)newPow) / 100;
                ortY1.pow = ((double)newPow) / 100;
                ortZ1.pow = ((double)newPow) / 100;
                Refresh();
            }
        }
    }
}

  

  

  

 

  

  

