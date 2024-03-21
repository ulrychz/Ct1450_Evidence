using Microsoft.JSInterop;
using System.Globalization;

namespace Ct1450_Evidence.Models
{
    public class Evidence
    {
        public Evidence(IJSRuntime jSRuntime) 
        { 
            JS = jSRuntime;
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("cs-CZ");
        }
        private IJSRuntime JS;
        public List<Polozka> Polozky {  get; set; } = new List<Polozka>();
        public Polozka Polozka { get; set; } = new Polozka();
        public string Vypis { get; set; } = "";

        public bool IsEditace { get; set; } = false;

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

        public void Statistiky()
        {
            Vypis = "";
            Vypis += $"Minimum: {Minimum()} <br>";
            Vypis += $"Maximum: {Maximum()} <br>";
            Vypis += $"Průměr: {Prumer()}";

        }
        private double Minimum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            else
            {
                return Polozky.Min(x=>x.Zisk);
            }
        }

        private double Maximum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            else
            {
                return Polozky.Max(x => x.Zisk);
            }
        }

        private double Prumer()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            else
            {
                return Polozky.Average(x => x.Zisk);
            }
        }


        public async Task SmazPolozku(Polozka pol)
        {
            var zprava = $"Chcete smazat {pol.Datum} - Zisk {pol.Zisk} z vašeho seznamu?";
            //JS.InvokeVoidAsync("alert", zprava);
            if (await JS.InvokeAsync<bool>("confirm", zprava))
            {
                Polozky.Remove(pol);
            }
        }

        public void Edituj(Polozka pol)
        {
            Polozka = pol;
            IsEditace = true;
        }
        public void UkonciEditaci()
        {
            IsEditace = false;
            Polozka = new Polozka();
        }
    }
}
