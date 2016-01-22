namespace Veddeløp
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {

            return  ("hvem plaserte penger");
        }

        public int PayOut (int Winner)
        {
            return (1 /*hvor mye blei betta */);
        }

    }
}