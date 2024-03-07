namespace Ct1450_Evidence.Models
{
    public class Evidence
    {
        public List<Polozka> Polozky {  get; set; } = new List<Polozka>();
        public Polozka Polozka { get; set; } = new Polozka();
        public string Vypis { get; set; } = "";
        public void Pridat()
        {
            //Polozky.Add(Polozka);
            //Polozka = new Polozka();
            Polozky.Add(new Polozka(datum: Polozka.Datum, Polozka.Naklady, Polozka.Vynosy));
        }

        public void PocetZaznamu() 
        {
            Vypis = $"Počet záznamů je {Polozky.Count}";
        }

        public void ZobrazVse()
        {
            Vypis = $"Jednotlivé záznamy jsou:<br> {string.Join("<br>", Polozky)}";
        }

    }
}
