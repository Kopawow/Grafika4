using System.Drawing;
using System.Windows.Forms;

namespace zad4
{
    public class PasekStanu 
    {
        public TextBox katKamery;
        public Label katKameryL;
        public Label pKameryL;
        public TextBox pKameryX;
        public TextBox pKameryY;
        public TextBox pKameryZ;
        public Label pObrazuL;
        public TextBox pObrazuX;
        public TextBox pObrazuY;
        public TextBox pObrazuZ;
        public TextBox pow;
 
        public Panel _panel;

        public PasekStanu(Panel panel)
        {
            _panel = panel;

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
            _panel.Controls.Add(pow);
            _panel.Controls.Add(pKameryL);
            _panel.Controls.Add(pObrazuL);
            _panel.Controls.Add(pKameryX);
            _panel.Controls.Add(pKameryY);
            _panel.Controls.Add(pKameryZ);
            _panel.Controls.Add(pObrazuX);
            _panel.Controls.Add(pObrazuY);
            _panel.Controls.Add(pObrazuZ);
            _panel.Controls.Add(katKamery);
            _panel.Controls.Add(katKameryL);
        }
        
        public void paintComponent()
        {
           
            pow.SetBounds(100, 1, 33, 20);
            pKameryL.SetBounds(165, 0, 33, 20);
            pKameryX.SetBounds(270, 1, 33, 20);
            pKameryY.SetBounds(303, 1, 33, 20);
            pKameryZ.SetBounds(336, 1, 33, 20);
            pObrazuL.SetBounds(400, 0, 33, 20);
            pObrazuX.SetBounds(500, 1, 33, 20);
            pObrazuY.SetBounds(533, 1, 33, 20);
            pObrazuZ.SetBounds(566, 1, 33, 20);
            katKameryL.SetBounds(635, 0, 80, 20);
            katKamery.SetBounds(705, 1, 33, 20);
            
        }

        //public void changeLabel(string text)
        //{
        //    status.Text = text;
        //    Refresh();
        //}
    }
}