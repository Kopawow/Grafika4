using System.Drawing;
using System.Windows.Forms;

namespace zad4
{
    public class PasekStanu : Panel
    {
        public TextBox katKamery;
        private readonly Label katKameryL;
        private readonly Label pKameryL;
        public TextBox pKameryX;
        public TextBox pKameryY;
        public TextBox pKameryZ;
        private readonly Label pObrazuL;
        public TextBox pObrazuX;
        public TextBox pObrazuY;
        public TextBox pObrazuZ;
        public TextBox pow;
        private readonly Label powL;

        private readonly Label status;

        public PasekStanu()
        {
            status = new Label();
            powL = new Label();
            pow = new TextBox
            {
                Text = "90"
            };
            pKameryL = new Label
            {
                Name = "P.kamery [X,Y,Z]"
            };
            pObrazuL = new Label
            {
                Name = "P.obrazu [X,Y,Z]"
            };
            pKameryX = new TextBox
            {
                Text = "0"
            };
            pKameryY = new TextBox
            {
                Text = "0"
            };
            pKameryZ = new TextBox
            {
                Text = "0"
            };
            pObrazuX = new TextBox
            {
                Text = "0"
            };
            pObrazuY = new TextBox
            {
                Text = "0"
            };
            pObrazuZ = new TextBox
            {
                Text = "0"
            };
            katKameryL = new Label
            {
                Name = "Kąt kamery"
            };
            katKamery = new TextBox
            {
                Text = "0"
            };
            Controls.Add(status);
            Controls.Add(pow);
            Controls.Add(powL);
            Controls.Add(pKameryL);
            Controls.Add(pObrazuL);
            Controls.Add(pKameryX);
            Controls.Add(pKameryY);
            Controls.Add(pKameryZ);
            Controls.Add(pObrazuX);
            Controls.Add(pObrazuY);
            Controls.Add(pObrazuZ);
            Controls.Add(katKamery);
            Controls.Add(katKameryL);
        }

        public void  SetPasekStanu(string startString)
        {
            status.Text = startString;
        }

        public void paintComponent(Graphics g)
        {
            paintComponent(g);
            powL.SetBounds(0, 0, 100, 20);
            pow.SetBounds(100, 1, 33, 20);
            pKameryL.SetBounds(165, 0, 120, 20);
            pKameryX.SetBounds(270, 1, 33, 20);
            pKameryY.SetBounds(303, 1, 33, 20);
            pKameryZ.SetBounds(336, 1, 33, 20);
            pObrazuL.SetBounds(400, 0, 120, 20);
            pObrazuX.SetBounds(500, 1, 33, 20);
            pObrazuY.SetBounds(533, 1, 33, 20);
            pObrazuZ.SetBounds(566, 1, 33, 20);
            katKameryL.SetBounds(635, 0, 80, 20);
            katKamery.SetBounds(705, 1, 33, 20);
            status.SetBounds(750, 0, 200, 20);
        }

        public void changeLabel(string text)
        {
            status.Text = text;
            Refresh();
        }
    }
}