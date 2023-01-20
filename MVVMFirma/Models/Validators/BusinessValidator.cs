using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.Validator
{
    class BusinessValidator : Validator
    {
        public static string SprawdzRabat(double? rabat)
        {
            if (rabat < 0 || rabat > 100)
                return "Rabat  powinien  być  z  przedziału  od  0  do  100";
            return null;
        }

        public static string CzyDataSprzedazyJestWiekszaOdDatyWystawienia(DateTime? dataSprzedazy, DateTime? dataWystawienia)
        {
            if (dataSprzedazy> dataWystawienia)
                return "Data waystawienia faktury powinna być równa dacie sprzedaży lub mieć późniejszą datę.";
            return null;
        }

        //public static string CzyDataSprzedazyJestWiekszaOdDatyWystawieni(DateTime? dataSprzedazy, DateTime? dataWystawienia)
        //{
        //    TimeSpan? roznica = dataSprzedazy - dataWystawienia;
            
        //    if (roznica>90)
        //        return "Data waystawienia faktury powinna być równa dacie sprzedaży lub mieć późniejszą datę.";
        //    return null;
        //}

        //public static string SprawdzGodzineiMinute(string GodzinaWizyty)
        //{
        //    string[] podzielony = GodzinaWizyty.Split(':');
        //    int godzina = Int32.Parse(podzielony[0]);
        //    int minuta = Int32.Parse(podzielony[1]);
        //    if ((godzina < 7 || godzina > 21) && (minuta <= 0 || minuta >= 60))
        //        return "Godzina  powinien  być  z  przedziału  od  7  do  20, minuty w przedziale od 0 do 60";
        //    return null;
        //}

    }
}
