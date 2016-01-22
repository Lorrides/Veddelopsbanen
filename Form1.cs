using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veddeløp
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuysArray = new Guy[3];
        Random MyRandomizer = new Random();



        public Form1()
        {
            InitializeComponent();
            joeRadioButton.Checked = true;
            minimumBetLabel.Text = "Minimun Bet : " + numericUpDown1.Minimum.ToString() + " kroner";

            GreyhoundArray[0] = new Greyhound()
            {
                BildeBox = pictureBox1,
                StartPosition = pictureBox1.Left,
                BaneLengde = racetrackPicturebox.Width - pictureBox1.Width,
                Tilfeldig = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                BildeBox = pictureBox2,
                StartPosition = pictureBox2.Left,
                BaneLengde = racetrackPicturebox.Width - pictureBox3.Width,
                Tilfeldig = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                BildeBox = pictureBox3,
                StartPosition = pictureBox3.Left,
                BaneLengde = racetrackPicturebox.Width - pictureBox3.Width,
                Tilfeldig = MyRandomizer
            };

            GreyhoundArray[3] = new Greyhound()
            {
                BildeBox = pictureBox4,
                StartPosition = pictureBox4.Left,
                BaneLengde = racetrackPicturebox.Width - pictureBox4.Width,
                Tilfeldig = MyRandomizer
            };

            GuysArray[0] = new Guy()
            {
                Name = "Joe",
                MyBet = null,
                Cash = 50,
                MYRadoiButton = joeRadioButton,
                MyLabel = joeBetLabel
            };

            GuysArray[1] = new Guy()
            {
                Name = "Bob",
                MyBet = null,
                Cash = 75,
                MYRadoiButton = bobRadioButton,
                MyLabel = bobBetLabel
            };

            GuysArray[2] = new Guy()
            {
                Name = "AL",
                MyBet = null,
                Cash = 45,
                MYRadoiButton = alRadioButton,
                MyLabel = alBetLabel
            };

            for (int i = 0; i <= 2 ; i++)
            {
                GuysArray[i].UpdateLabels();
                GuysArray[i].MyBet = new Bet();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GreyhoundArray[0].TakeStartingPosition();
            GreyhoundArray[1].TakeStartingPosition();
            GreyhoundArray[2].TakeStartingPosition();
            GreyhoundArray[3].TakeStartingPosition();

            bettingParlor.Enabled = false;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();bettingParlor.Enabled = true;
                    i++;
                    MessageBox.Show("Hund" + i + " vant løpet");
                    for (int j = 0; j <= 2; j++)
                    {
                        GuysArray[j].Collect(i);
                        GuysArray[j].ClearBet();
                    }
                    break;
                }
            }
        }

        private void Bets_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                if (GuysArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    joeBetLabel.Text = GuysArray[0].MyBet.GetDescription();
                }
            }
            else if (bobRadioButton.Checked)
            {
                if (GuysArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    bobBetLabel.Text = GuysArray[1].MyBet.GetDescription();
                }
            }
            else if (alRadioButton.Checked)
            {
                if (GuysArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    alBetLabel.Text = GuysArray[2].MyBet.GetDescription();
                }
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Bob";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Al";
        }

    }
}
