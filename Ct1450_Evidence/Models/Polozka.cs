namespace Ct1450_Evidence.Models
{
    public class Polozka
    {
        public DateOnly Datum { get; set; }
        private double naklady;

        public double Naklady
        {
            get { return naklady; }
            set { naklady = Math.Abs(value); }
        }

        private double vynosy;

        public double Vynosy
        {
            get { return vynosy; }
            set { vynosy = Math.Abs(value); }
        }
        public double Zisk => Vynosy - Naklady;
    }
}
