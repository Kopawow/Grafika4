using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        bool _mousePressed;

        public Form1()
    {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
      GUI();
    }


    public void GUI()
    {

      pasekMenu = new PasekMenu(this);
      pasekStanu = new PasekStanu();
            pasekStanu.SetPasekStanu("");
            panel1.Controls.Add(pasekStanu);

        pasekMenu.wczytajKamere.Click += ActionPerformed;
        pasekMenu.wczytajScene.Click += ActionPerformed;
        pasekMenu.wPersp.Click += ActionPerformed;
        this.MouseMove += OnMouseMove;
        this.MouseWheel += mouseWheelMoved;
        this.MouseDown += OnMouseDown;
        this.MouseUp += OnMouseUp;
    }

    public void zmienKamere(int x, int y, int z)
    {
      ortX1.srodekKamery[0] = x;
      ortX1.srodekKamery[1] = y;
      ortX1.srodekKamery[2] = z;
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
      ortX1.srodekObrazu[0] = x;
      ortX1.srodekObrazu[1] = y;
      ortX1.srodekObrazu[2] = z;
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
      ortX1.maxX = int.MinValue;
      ortX1.minX = int.MaxValue;
      ortX1.maxY = int.MinValue;
      ortX1.minY = int.MaxValue;
      ortX1.maxZ = int.MinValue;
      ortX1.minZ = int.MaxValue;
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
      for (var i = 0; i < ortX1.wierzcholki.GetLength(0); i++)
      {
        if (ortX1.wierzcholki[i, 0] > ortX1.maxX)
        {
          ortX1.maxX = ortX1.wierzcholki[i, 0];
          ortY1.maxX = ortX1.wierzcholki[i, 0];
          ortZ1.maxX = ortX1.wierzcholki[i, 0];
        }
        if (ortX1.wierzcholki[i, 0] < ortX1.minX)
        {
          ortX1.minX = ortX1.wierzcholki[i, 0];
          ortY1.minX = ortX1.wierzcholki[i, 0];
          ortZ1.minX = ortX1.wierzcholki[i, 0];
        }
        if (ortX1.wierzcholki[i, 1] > ortX1.maxY)
        {
          ortX1.maxY = ortX1.wierzcholki[i, 1];
          ortY1.maxY = ortX1.wierzcholki[i, 1];
          ortZ1.maxY = ortX1.wierzcholki[i, 1];
        }
        if (ortX1.wierzcholki[i, 1] < ortX1.minY)
        {
          ortX1.minY = ortX1.wierzcholki[i, 1];
          ortY1.minY = ortX1.wierzcholki[i, 1];
          ortZ1.minY = ortX1.wierzcholki[i, 1];
        }
        if (ortX1.wierzcholki[i, 2] > ortX1.maxZ)
        {
          ortX1.maxZ = ortX1.wierzcholki[i, 2];
          ortY1.maxZ = ortX1.wierzcholki[i, 2];
          ortZ1.maxZ = ortX1.wierzcholki[i, 2];
        }
        if (ortX1.wierzcholki[i, 2] < ortX1.minZ)
        {
          ortX1.minZ = ortX1.wierzcholki[i, 2];
          ortY1.minZ = ortX1.wierzcholki[i, 2];
          ortZ1.minZ = ortX1.wierzcholki[i, 2];
        }
      }
      if (ortX1.srodekKamery[0] > ortX1.maxX)
      {
        ortX1.maxX = ortX1.srodekKamery[0];
        ortY1.maxX = ortX1.srodekKamery[0];
        ortZ1.maxX = ortX1.srodekKamery[0];
      }
      if (ortX1.srodekKamery[0] < ortX1.minX)
      {
        ortX1.minX = ortX1.srodekKamery[0];
        ortY1.minX = ortX1.srodekKamery[0];
        ortZ1.minX = ortX1.srodekKamery[0];
      }
      if (ortX1.srodekKamery[1] > ortX1.maxY)
      {
        ortX1.maxY = ortX1.srodekKamery[1];
        ortY1.maxY = ortX1.srodekKamery[1];
        ortZ1.maxY = ortX1.srodekKamery[1];
      }
      if (ortX1.srodekKamery[1] < ortX1.minY)
      {
        ortX1.minY = ortX1.srodekKamery[1];
        ortY1.minY = ortX1.srodekKamery[1];
        ortZ1.minY = ortX1.srodekKamery[1];
      }
      if (ortX1.srodekKamery[2] > ortX1.maxZ)
      {
        ortX1.maxZ = ortX1.srodekKamery[2];
        ortY1.maxZ = ortX1.srodekKamery[2];
        ortY1.maxZ = ortX1.srodekKamery[2];
      }
      if (ortX1.srodekKamery[2] < ortX1.minZ)
      {
        ortX1.minZ = ortX1.srodekKamery[2];
        ortY1.minZ = ortX1.srodekKamery[2];
        ortZ1.minZ = ortX1.srodekKamery[2];
      }
      if (ortX1.srodekObrazu[0] > ortX1.maxX)
      {
        ortX1.maxX = ortX1.srodekObrazu[0];
        ortY1.maxX = ortX1.srodekObrazu[0];
        ortZ1.maxX = ortX1.srodekObrazu[0];
      }
      if (ortX1.srodekObrazu[0] < ortX1.minX)
      {
        ortX1.minX = ortX1.srodekObrazu[0];
        ortY1.minX = ortX1.srodekObrazu[0];
        ortZ1.minX = ortX1.srodekObrazu[0];
      }
      if (ortX1.srodekObrazu[1] > ortX1.maxY)
      {
        ortX1.maxY = ortX1.srodekObrazu[1];
        ortY1.maxY = ortX1.srodekObrazu[1];
        ortZ1.maxY = ortX1.srodekObrazu[1];
      }
      if (ortX1.srodekObrazu[1] < ortX1.minY)
      {
        ortX1.minY = ortX1.srodekObrazu[1];
        ortY1.minY = ortX1.srodekObrazu[1];
        ortZ1.minY = ortX1.srodekObrazu[1];
      }
      if (ortX1.srodekObrazu[2] > ortX1.maxZ)
      {
        ortX1.maxZ = ortX1.srodekObrazu[2];
        ortY1.maxZ = ortX1.srodekObrazu[2];
        ortZ1.maxZ = ortX1.srodekObrazu[2];
      }
      if (ortX1.srodekObrazu[2] < ortX1.minZ)
      {
        ortX1.minZ = ortX1.srodekObrazu[2];
        ortY1.minZ = ortX1.srodekObrazu[2];
        ortZ1.minZ = ortX1.srodekObrazu[2];
      }
    }
        private void obliczOstroslup()
        {
            if (ortX1.srodekKamery != null && ortX1.srodekObrazu != null)
            {
                //wierzcholki podstawy ostroslupa
                var wierzch = new double[4, 3];
                //
                var punktyPom = new double[2, 3];
                for (var i = 0; i < 3; i++)
                {
                    punktyPom[0, i] = ortX1.srodekKamery[i];
                    //punkt obrazu po przesunieciu
                }
                for (var i = 0; i < 3; i++)
                {
                    punktyPom[1, i] = ortX1.srodekObrazu[i] - ortX1.srodekKamery[i];
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
                double wspPom = Math.Tan(Helper.ConvertToRadians(ortX1.katRozwarcia)) * punktyPom[1, 0];
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
                ortX1.wierzch = wierzch;
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
                        ortX1.wierzcholki = new int[iloscWierzcholkow, 3];
                        ortY1.wierzcholki = new int[iloscWierzcholkow, 3];
                        ortZ1.wierzcholki = new int[iloscWierzcholkow, 3];
                        persp1.wierzcholki = new int[iloscWierzcholkow, 3];
                        for (int i = 0; i < iloscWierzcholkow; i++)
                        {
                            ortX1.wierzcholki[i, 0] = (int)double.Parse(st[j]);
                            ortY1.wierzcholki[i, 0] = (int)double.Parse(st[j]);
                            ortZ1.wierzcholki[i, 0] = (int)double.Parse(st[j]);
                            persp1.wierzcholki[i, 0] = (int)double.Parse(st[j++]);

                            ortX1.wierzcholki[i, 1] = (int)double.Parse(st[j]);
                            ortY1.wierzcholki[i, 1] = (int)double.Parse(st[j]);
                            ortZ1.wierzcholki[i, 1] = (int)double.Parse(st[j]);
                            persp1.wierzcholki[i, 1] = (int)double.Parse(st[j++]);

                            ortX1.wierzcholki[i, 2] = (int)double.Parse(st[j]);
                            ortY1.wierzcholki[i, 2] = (int)double.Parse(st[j]);
                            ortZ1.wierzcholki[i, 2] = (int)double.Parse(st[j]);
                            persp1.wierzcholki[i, 2] = (int)double.Parse(st[j++]);
                        }

                        int iloscTrojkatow = (int)double.Parse(st[j++]);
                        ortX1.trojkaty = new int[iloscTrojkatow, 3];
                        ortY1.trojkaty = new int[iloscTrojkatow, 3];
                        ortZ1.trojkaty = new int[iloscTrojkatow, 3];
                        persp1.trojkaty = new int[iloscTrojkatow, 3];

                        for (int i = 0; i < iloscTrojkatow; i++)
                        {

                            ortX1.trojkaty[i, 0] = int.Parse(st[j]);
                            ortY1.trojkaty[i, 0] = int.Parse(st[j]);
                            ortZ1.trojkaty[i, 0] = int.Parse(st[j]);
                            persp1.trojkaty[i, 0] = int.Parse(st[j++]);

                            ortX1.trojkaty[i, 1] = int.Parse(st[j]);
                            ortY1.trojkaty[i, 1] = int.Parse(st[j]);
                            ortZ1.trojkaty[i, 1] = int.Parse(st[j]);
                            persp1.trojkaty[i, 1] = int.Parse(st[j++]);

                            ortX1.trojkaty[i, 2] = int.Parse(st[j]);
                            ortY1.trojkaty[i, 2] = int.Parse(st[j]);
                            ortZ1.trojkaty[i, 2] = int.Parse(st[j]);
                            persp1.trojkaty[i, 2] = int.Parse(st[j++]);
                        }
                        fileBuff.Close();
                        if (ortX1.srodekKamery == null)
                        {
                            ortX1.srodekKamery = new int[3];
                            ortX1.srodekObrazu = new int[3];
                            ortY1.srodekKamery = new int[3];
                            ortY1.srodekObrazu = new int[3];
                            ortZ1.srodekKamery = new int[3];
                            ortZ1.srodekObrazu = new int[3];
                            persp1.srodekKamery = new int[3];
                            persp1.srodekObrazu = new int[3];
                            ortX1.srodekKamery[0] = 0;
                            ortY1.srodekKamery[0] = 0;
                            ortZ1.srodekKamery[0] = 0;
                            persp1.srodekKamery[0] = 0;
                            ortX1.srodekKamery[1] = 0;
                            ortY1.srodekKamery[1] = 0;
                            ortZ1.srodekKamery[1] = 0;
                            persp1.srodekKamery[1] = 0;
                            ortX1.srodekKamery[2] = 0;
                            ortY1.srodekKamery[2] = 0;
                            ortZ1.srodekKamery[2] = 0;
                            persp1.srodekKamery[2] = 0;
                            ortX1.srodekObrazu[0] = 0;
                            ortY1.srodekObrazu[0] = 0;
                            ortZ1.srodekObrazu[0] = 0;
                            persp1.srodekObrazu[0] = 0;
                            ortX1.srodekObrazu[1] = 0;
                            ortY1.srodekObrazu[1] = 0;
                            ortZ1.srodekObrazu[1] = 0;
                            persp1.srodekObrazu[1] = 0;
                            ortX1.srodekObrazu[2] = 0;
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
                ortX1.srodekKamery = new int[3];
                ortX1.srodekObrazu = new int[3];
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
                        ortX1.srodekKamery[0] = (int)double.Parse(st[j]);
                        ortY1.srodekKamery[0] = (int)double.Parse(st[j]);
                        ortZ1.srodekKamery[0] = (int)double.Parse(st[j]);
                        persp1.srodekKamery[0] = (int)double.Parse(st[j]);
                        pasekStanu.pKameryX.Text = ((int)double.Parse(st[j++])).ToString();

                        ortX1.srodekKamery[1] = (int)double.Parse(st[j]);
                        ortY1.srodekKamery[1] = (int)double.Parse(st[j]);
                        ortZ1.srodekKamery[1] = (int)double.Parse(st[j]);
                        persp1.srodekKamery[1] = (int)double.Parse(st[j]);
                        pasekStanu.pKameryY.Text = ((int)double.Parse(st[j++])).ToString();

                        ortX1.srodekKamery[2] = (int)double.Parse(st[j]);
                        ortY1.srodekKamery[2] = (int)double.Parse(st[j]);
                        ortZ1.srodekKamery[2] = (int)double.Parse(st[j]);
                        persp1.srodekKamery[2] = (int)double.Parse(st[j]);
                        pasekStanu.pKameryZ.Text = ((int)double.Parse(st[j++])).ToString();

                        ortX1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        ortY1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        ortZ1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        persp1.srodekObrazu[0] = (int)double.Parse(st[j]);
                        pasekStanu.pObrazuX.Text = ((int)double.Parse(st[j++])).ToString();

                        ortX1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        ortY1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        ortZ1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        persp1.srodekObrazu[1] = (int)double.Parse(st[j]);
                        pasekStanu.pObrazuY.Text = ((int)double.Parse(st[j++])).ToString();

                        ortX1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        ortY1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        ortZ1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        persp1.srodekObrazu[2] = (int)double.Parse(st[j]);
                        pasekStanu.pObrazuZ.Text = ((int)double.Parse(st[j++])).ToString();

                        ortX1.katRozwarcia = (int)double.Parse(st[j]);
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
                if (ortX1.srodekKamery == null || ortX1.srodekObrazu == null || ortX1.katRozwarcia == 0)
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
                            zapiszWek.Write(ortX1.srodekKamery[0] + " " + ortX1.srodekKamery[1] + " " + ortX1.srodekKamery[2]);
                            zapiszWek.Write(ortX1.srodekObrazu[0] + " " + ortX1.srodekObrazu[1] + " " + ortX1.srodekObrazu[2]);
                            zapiszWek.Write(ortX1.katRozwarcia);
                            zapiszWek.Close();
                        }
                        catch (IOException ex)
                        {
                           // NotificationWindow x = new NotificationWindow("BĹ‚Ä…d I/O", true);
                        }
                    }
                }
            }
            else if (zrodlo == pasekMenu.WkolorKamery)
            {
                //JColorChooser wyb = new JColorChooser(ortX1.kolorKamery);
                //Color c = wyb.showDialog(pasekMenu, "Wybierz kolor kamery", ortX1.kolorKamery);
                //ortX1.kolorKamery = c;
                //ortY1.kolorKamery = c;
                //ortZ1.kolorKamery = c;
                //persp1.kolorKamery = c;
                //Refresh();
            }
            else if (zrodlo == pasekMenu.WkolorTla)
            {
                //JColorChooser wyb = new JColorChooser(ortX1.kolorTla);
                //Color c = wyb.showDialog(pasekMenu, "Wybierz kolor tĹ‚a", ortX1.kolorTla);
                //ortX1.kolorTla = c;
                //ortY1.kolorTla = c;
                //ortZ1.kolorTla = c;
                //persp1.kolorTla = c;
                //Refresh();
            }
            else if (zrodlo == pasekMenu.WkolorSceny)
            {
                //JColorChooser wyb = new JColorChooser(ortX1.kolorSceny);
                //Color c = wyb.showDialog(pasekMenu, "Wybierz kolor sceny", ortX1.kolorSceny);
                //ortX1.kolorSceny = c;
                //ortY1.kolorSceny = c;
                //ortZ1.kolorSceny = c;
                //persp1.kolorSceny = c;
                //Refresh();
            }
            else if (zrodlo == pasekStanu.pow)
            {
                int x = int.Parse(pasekStanu.pow.Text);
                ortX1.pow = (double)x / 100;
                ortY1.pow = (double)x / 100;
                ortZ1.pow = (double)x / 100;
                Refresh();
            }
            else if (zrodlo == pasekStanu.pKameryX)
            {
                int x = int.Parse(pasekStanu.pKameryX.Text);
                ortX1.srodekKamery[0] = x;
                ortY1.srodekKamery[0] = x;
                ortZ1.srodekKamery[0] = x;
                persp1.srodekKamery[0] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pKameryY)
            {
                int x = int.Parse(pasekStanu.pKameryY.Text);
                ortX1.srodekKamery[1] = x;
                ortY1.srodekKamery[1] = x;
                ortZ1.srodekKamery[1] = x;
                persp1.srodekKamery[1] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pKameryZ)
            {
                int x = int.Parse(pasekStanu.pKameryZ.Text);
                ortX1.srodekKamery[2] = x;
                ortY1.srodekKamery[2] = x;
                ortZ1.srodekKamery[2] = x;
                persp1.srodekKamery[2] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pObrazuX)
            {
                int x = int.Parse(pasekStanu.pObrazuX.Text);
                ortX1.srodekObrazu[0] = x;
                ortY1.srodekObrazu[0] = x;
                ortZ1.srodekObrazu[0] = x;
                persp1.srodekObrazu[0] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pObrazuY)
            {
                int x = int.Parse(pasekStanu.pObrazuY.Text);
                ortX1.srodekObrazu[1] = x;
                ortY1.srodekObrazu[1] = x;
                ortZ1.srodekObrazu[1] = x;
                persp1.srodekObrazu[1] = x;
                minMax();
                Refresh();
            }
            else if (zrodlo == pasekStanu.pObrazuZ)
            {
                int x = int.Parse(pasekStanu.pObrazuZ.Text);
                ortX1.srodekObrazu[2] = x;
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
                ortX1.katRozwarcia = (int)(x / 2);
                ortY1.katRozwarcia = (int)(x / 2);
                ortZ1.katRozwarcia = (int)(x / 2);
                persp1.katRozwarcia = (int)(x / 2);
                minMax();
                Refresh();
            }
        }

        public void mouseDragged(object sender, MouseEventArgs mouseEventArgs)
        {
            var location = ((Control) sender).PointToScreen(Point.Empty);
            int x = location.X;
            int y = location.Y;

            var locationOrtX1 = (ortX1).PointToScreen(Point.Empty);
            var locationOrtY1 = (ortY1).PointToScreen(Point.Empty);
            var locationOrtZ1 = (ortZ1).PointToScreen(Point.Empty);
            pasekStanu.changeLabel("");
            if (x >= locationOrtX1.X &&
                    x <locationOrtX1.X + ortX1.Width &&
                    y >=locationOrtX1.Y &&
                    y <locationOrtX1.Y + ortX1.Height)
            {
                if (changeObrazY)
                {
                    ortX1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    ortY1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    ortZ1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    persp1.srodekObrazu[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    pasekStanu.pObrazuY.Text = ((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2).ToString();
                }
                else if (changeEkranY)
                {
                    ortX1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    ortY1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    ortZ1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    persp1.srodekKamery[1] = (int)((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2);
                    pasekStanu.pKameryY.Text = ((double)(x -locationOrtX1.X - (double)ortX1.Width / 2) * ((double)ortX1.prop / ((double)(ortX1.Width * ortX1.pow))) + (ortX1.minY + ortX1.maxY) / 2).ToString();
                }
                if (changeObrazZ)
                {
                    ortX1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    ortY1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    ortZ1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    persp1.srodekObrazu[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    pasekStanu.pObrazuZ.Text = ((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2).ToString();
                }
                else if (changeEkranZ)
                {
                    ortX1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    ortY1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    ortZ1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    persp1.srodekKamery[2] = (int)((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2);
                    pasekStanu.pKameryZ.Text = ((double)(y -locationOrtX1.Y - (double)ortX1.Height / 2) * ((double)ortX1.prop / ((double)(ortX1.Height * ortX1.pow))) + (ortX1.minZ + ortX1.maxZ) / 2).ToString();
                }
            }
            else if (x >=locationOrtY1.X &&
                  x <locationOrtY1.X + ortY1.Width &&
                  y >=locationOrtY1.Y &&
                  y <locationOrtY1.Y + ortY1.Height)
            {
                if (changeObrazX)
                {
                    ortX1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortY1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortZ1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    persp1.srodekObrazu[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    pasekStanu.pObrazuX.Text  = ((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2).ToString();
                }
                else if (changeEkranX)
                {
                    ortX1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortY1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    ortZ1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    persp1.srodekKamery[0] = (int)((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2);
                    pasekStanu.pKameryX.Text = ((double)(x -locationOrtY1.X - (double)ortY1.Width / 2) * ((double)ortY1.prop / ((double)(ortY1.Width * ortX1.pow))) + (ortY1.minX + ortY1.maxX) / 2).ToString();
                }
                if (changeObrazZ)
                {
                    ortX1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    ortY1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    ortZ1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    persp1.srodekObrazu[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    pasekStanu.pObrazuZ.Text = ((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2).ToString();
                }
                else if (changeEkranZ)
                {
                    ortX1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    ortY1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    ortZ1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    persp1.srodekKamery[2] = (int)((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2);
                    pasekStanu.pKameryZ.Text = ((double)(y -locationOrtY1.Y - (double)ortX1.Height / 2) * ((double)ortY1.prop / ((double)(ortY1.Height * ortX1.pow))) + (ortY1.minZ + ortX1.maxZ) / 2).ToString();
                }
            }
            else if (x >=locationOrtZ1.X &&
                  x <locationOrtZ1.X + ortZ1.Width &&
                  y >=locationOrtZ1.Y &&
                  y <locationOrtZ1.Y + ortZ1.Height)
            {
                if (changeObrazX)
                {
                    ortX1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortY1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortZ1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    persp1.srodekObrazu[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    pasekStanu.pObrazuX.Text = ((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2).ToString();
                }
                else if (changeEkranX)
                {
                    ortX1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortY1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    ortZ1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    persp1.srodekKamery[0] = (int)((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2);
                    pasekStanu.pKameryX.Text = ((double)(x -locationOrtZ1.X - (double)ortZ1.Width / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Width * ortX1.pow))) + (ortZ1.minX + ortZ1.maxX) / 2).ToString();
                }
                if (changeObrazY)
                {
                    ortX1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    ortY1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    ortZ1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    persp1.srodekObrazu[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    pasekStanu.pObrazuY.Text = ((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2).ToString();
                }
                else if (changeEkranY)
                {
                    ortX1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    ortY1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    ortZ1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    persp1.srodekKamery[1] = (int)((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2);
                    pasekStanu.pKameryY.Text = ((double)(y -locationOrtZ1.Y - (double)ortX1.Height / 2) * ((double)ortZ1.prop / ((double)(ortZ1.Height * ortX1.pow))) + (ortZ1.minY + ortX1.maxY) / 2).ToString();
                }
            }
            Refresh();
        }

        //public void mouseMoved(object sender, MouseEventArgs mouseEventArgs)
        //{
        //    int x = e.getXOnScreen();
        //    int y = e.getYOnScreen();
        //    pasekStanu.changeLabel("");
        //    if (x >= obszarRoboczy.ortX.getLocationOnScreen().getX() &&
        //            x < obszarRoboczy.ortX.getLocationOnScreen().getX() + obszarRoboczy.ortX.getWidth() &&
        //            y >= obszarRoboczy.ortX.getLocationOnScreen().getY() &&
        //            y < obszarRoboczy.ortX.getLocationOnScreen().getY() + obszarRoboczy.ortX.getHeight())
        //    {
        //        pasekStanu.changeLabel("Y: " + (int)((double)(x - obszarRoboczy.ortX.getLocationOnScreen().getX() - (double)obszarRoboczy.ortX.getWidth() / 2) * ((double)obszarRoboczy.ortX.prop / ((double)(obszarRoboczy.ortX.getWidth() * obszarRoboczy.ortX.pow))) + (obszarRoboczy.ortX.minY + obszarRoboczy.ortX.maxY) / 2) + " Z: " + (int)((double)(y - obszarRoboczy.ortX.getLocationOnScreen().getY() - (double)obszarRoboczy.ortX.getHeight() / 2) * ((double)obszarRoboczy.ortX.prop / ((double)(obszarRoboczy.ortX.getHeight() * obszarRoboczy.ortX.pow))) + (obszarRoboczy.ortX.minZ + obszarRoboczy.ortX.maxZ) / 2));
        //    }
        //    else if (x >= obszarRoboczy.ortY.getLocationOnScreen().getX() &&
        //          x < obszarRoboczy.ortY.getLocationOnScreen().getX() + obszarRoboczy.ortY.getWidth() &&
        //          y >= obszarRoboczy.ortY.getLocationOnScreen().getY() &&
        //          y < obszarRoboczy.ortY.getLocationOnScreen().getY() + obszarRoboczy.ortY.getHeight())
        //    {
        //        pasekStanu.changeLabel("X: " + (int)((double)(x - obszarRoboczy.ortY.getLocationOnScreen().getX() - (double)obszarRoboczy.ortY.getWidth() / 2) * ((double)obszarRoboczy.ortY.prop / ((double)(obszarRoboczy.ortY.getWidth() * obszarRoboczy.ortX.pow))) + (obszarRoboczy.ortY.minX + obszarRoboczy.ortY.maxX) / 2) + " Z: " + (int)((double)(y - obszarRoboczy.ortY.getLocationOnScreen().getY() - (double)obszarRoboczy.ortX.getHeight() / 2) * ((double)obszarRoboczy.ortY.prop / ((double)(obszarRoboczy.ortY.getHeight() * obszarRoboczy.ortX.pow))) + (obszarRoboczy.ortY.minZ + obszarRoboczy.ortX.maxZ) / 2));
        //    }
        //    else if (x >= obszarRoboczy.ortZ.getLocationOnScreen().getX() &&
        //          x < obszarRoboczy.ortZ.getLocationOnScreen().getX() + obszarRoboczy.ortZ.getWidth() &&
        //          y >= obszarRoboczy.ortZ.getLocationOnScreen().getY() &&
        //          y < obszarRoboczy.ortZ.getLocationOnScreen().getY() + obszarRoboczy.ortZ.getHeight())
        //    {
        //        pasekStanu.changeLabel("X: " + (int)((double)(x - obszarRoboczy.ortZ.getLocationOnScreen().getX() - (double)obszarRoboczy.ortZ.getWidth() / 2) * ((double)obszarRoboczy.ortZ.prop / ((double)(obszarRoboczy.ortZ.getWidth() * obszarRoboczy.ortX.pow))) + (obszarRoboczy.ortZ.minX + obszarRoboczy.ortZ.maxX) / 2) + " Y: " + (int)((double)(y - obszarRoboczy.ortZ.getLocationOnScreen().getY() - (double)obszarRoboczy.ortX.getHeight() / 2) * ((double)obszarRoboczy.ortZ.prop / ((double)(obszarRoboczy.ortZ.getHeight() * obszarRoboczy.ortX.pow))) + (obszarRoboczy.ortZ.minY + obszarRoboczy.ortX.maxY) / 2));
        //    }
        //}

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            _mousePressed = true;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_mousePressed)
            {
                mouseDragged(sender, e);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _mousePressed = false;
        }

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
                ortX1.pow = ((double)newPow) / 100;
                ortY1.pow = ((double)newPow) / 100;
                ortZ1.pow = ((double)newPow) / 100;
                Refresh();
            }
        }

    }
}

  

  

  

 

  

  

