using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veddeløp
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MYRadoiButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MYRadoiButton.Text = Name + " has " + Cash + " kroner ";
            MyLabel.Text = Name + " har ikke plasert et veddemål ";

        }

        public void ClearBet() {
            MyBet.Amount = 0;
            MyBet.Dog = 0;
            MyBet.Bettor = this;
        }

        public bool PlaceBet (int BetAmount, int DogToWin)
        {
            if (Cash >= BetAmount)
            {
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                MyBet.Bettor = this;
                return true;
            }
            return false;
        }

        public void Collect (int winner)
        {
            Cash += MyBet.PayOut(winner);
            this.UpdateLabels();
        }


    }
}
