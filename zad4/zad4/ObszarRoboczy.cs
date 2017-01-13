using System;
using System.Drawing;
using System.Windows.Forms;

namespace zad4
{
    public class ObszarRoboczy : Panel
    {
        public readonly OrtX ortX;
        public readonly OrtY ortY;
        public readonly OrtZ ortZ;
        public readonly Persp persp;
        public Form _form;

        public ObszarRoboczy(Form form)
        {
            _form = form;
            //this.setLayout(null);
            this.BackColor = (Color.Black);
            ortX = new OrtX();
            ortY = new OrtY();
            ortZ = new OrtZ();
            persp = new Persp();
            this.Controls.Add(ortX);
            this.Controls.Add(ortY);
            this.Controls.Add(ortZ);
            this.Controls.Add(persp);
            this.Visible = true;
            _form.Controls.Add(this);
        }


    }
}