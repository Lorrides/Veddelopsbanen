using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veddeløp
{
    public class Greyhound
    {
        public int StartPosition;
        public int BaneLengde;
        public PictureBox BildeBox = null;
        public int Location = 0;
        public Random Tilfeldig;

       public bool Run()
        {
            Location += Tilfeldig.Next(1, 5);
            BildeBox.Left = Location;
            if (BildeBox.Left >= BaneLengde) { return true; }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            BildeBox.Left = StartPosition;
        }
    }
}
