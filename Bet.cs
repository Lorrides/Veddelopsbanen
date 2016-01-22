namespace Veddeløp
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            string description = "";
            description = this.Bettor.Name + " bets " + this.Amount + " kroner på hund #" + Dog;
            return  description;
        }

        public int PayOut (int winner)
        {
            if (Dog == winner)
            {
                return this.Amount;
            }
            else
            {
                return -this.Amount;
            } 
        }
    }
}