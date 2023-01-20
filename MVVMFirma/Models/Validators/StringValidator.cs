using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MVVMFirma.Models.Validator
{
    public class StringValidator : Validator
    {

        //funkcja zwraca komunikat z bledem jezeli jest blad
        //lub funkcja zwraca nulla jezeli takiego bledu nie ma
        //funkcja sprawdza czy string wartosc podana jako parametr rozpoczyna sie duza litera
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))//jeżeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "Pozpocznij dużą literą";
                }
            }
            catch (Exception) { };
            return null;
        }

        //public static string SprawdzCzyMaWiecejNizDwaZnaki(string wartosc)
        //{
        //    try
        //    {
        //        if (wartosc.Length<3)
        //        {
        //            return "Imie powinno mieć więcej niż 2 znaki";
        //        }
        //    }
        //    catch (Exception) { };
        //    return null;
        //}

        public static bool IsValidNrTel(string input)
        {
            string str = "0123456789-+";
            int pomocnicza = 0;
            for (int i=0; i<input.Length; i++)
            {
                if (str.Contains(input[i]))
                { }
                else
                    pomocnicza++;
            }
            if (pomocnicza == 0)
                return true;
            else
                return false;
        }
          
        public static string SprawdzCzyNumerTelMaPoprawneZnaki(string wartosc)
        {

            try
            {
                if (IsValidNrTel(wartosc) != true)
                {
                    return "Numer telefonu zawiera niepoprawne znaki!";
                }
            }
            catch (Exception) { };
            return null;
        }

        public static string SprawdzCzyKodPocztowyJestPoprawnyRegEx(string wartosc)
        {
            try
            {
                if ((Char.IsNumber(wartosc, 0)) && (Char.IsNumber(wartosc, 1)) && (wartosc[2] == '-') && (Char.IsNumber(wartosc, 3)) &&
                    (Char.IsNumber(wartosc, 4)) && (Char.IsNumber(wartosc, 5)) && (wartosc.Length == 6)) { }
                else
                {
                    return "Wpisz kod poczgtowy w formacie, np. 33-300";
                }
            }
            catch (Exception) { };
            return null;
        }
        public static int CalculateControlSum(string pesel, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < pesel.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(pesel[i].ToString());
            }
            return controlSum;
        }
        public static bool IsValidPESEL(string input)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool result = false;
            if (input.Length == 11)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }
        public static string SprawdzCzyPeselJestPoprawny(string wartoscPesel)
        {
            try
            {
                if (IsValidPESEL(wartoscPesel) != true)//jeżeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "Pesel jest niepoprawny";
                }
            }
            catch (Exception) { };
            return null;
        }
        public static bool IsValidNIP(string input)
        {
            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            bool result = false;
            if (input.Length != 10)
            {
                return result;
            }
            int controlSum = CalculateControlSum(input, weights);
            int controlNum = controlSum % 11;
            if (controlNum == 10)
            {
                return result;
            }
            int lastDigit = int.Parse(input[input.Length - 1].ToString());
            result = controlNum == lastDigit;
            return result;
        }

        public static bool IsValidREGON(string input)
        {
            int controlSum;
            if (input.Length == 7 || input.Length == 9)
            {
                int[] weights = { 8, 9, 2, 3, 4, 5, 6, 7 };
                int offset = 9 - input.Length;
                controlSum = CalculateControlSum(input, weights, offset);
            }
            else if (input.Length == 14)
            {
                int[] weights = { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
                controlSum = CalculateControlSum(input, weights);
            }
            else
            {
                return false;
            }

            int controlNum = controlSum % 11;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(input[input.Length - 1].ToString());

            return controlNum == lastDigit;
        }
        public static string SprawdzCzyNIPJestPoprawny(string wartoscNIP)
        {
            try
            {
                if (IsValidNIP(wartoscNIP) != true)
                {
                    return "NIP jest niepoprawny";
                }
            }
            catch (Exception) { };
            return null;
        }
        public static string SprawdzCzyREGONJestPoprawny(string wartoscREGON)
        {
            try
            {
                if (IsValidREGON(wartoscREGON) != true)//jeżeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "REGON jest niepoprawny";
                }
            }
            catch (Exception) { };
            return null;
        }
        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static string SprawdzCzyEMAILJestPoprawny(string wartoscAdresEmail)
        {
            try
            {
                if (EmailIsValid(wartoscAdresEmail) != true)//jeżeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "Email jest niepoprawny";
                }
            }
            catch (Exception) { };
            return null;
        }
        public static string SprawdzCzyFormatGodzinyJestPoprawny(string wartosc)
        {
            try
            {
                if ((Char.IsNumber(wartosc, 0)) && (Char.IsNumber(wartosc, 1)) && (wartosc[2] == ':') && (Char.IsNumber(wartosc, 3)) &&
                    (Char.IsNumber(wartosc, 4)) && (wartosc.Length == 5)) { }
                else
                {
                    return "Wpisz godzinę w formacie, np. 12:00";
                }
            }
            catch (Exception) { };
            return null;
        }
        public static string SprawdzDateWizyty(DateTime? wartosc)
        {
            try
            {
                if (wartosc<DateTime.Now)//jeżeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "Data wizyty powinna mieć co najmniej bieżącą datę";
                }
            }
            catch (Exception) { };
            return null;
        }

        public static bool IsIntNr(string input)
        {
            string str = "0123456789";
            int pomocnicza = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (str.Contains(input[i]))
                { }
                else
                    pomocnicza++;
            }
            if (pomocnicza == 0)
                return true;
            else
                return false;
        }

        public static string SprawdzCzyNrToInt(string wartosc)
        {
            try
            {
                if (IsIntNr(wartosc)!= true)//jeżeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "Nr faktury posiada niewłaściwe znaki.";
                }
            }
            catch (Exception) { };
            return null;
        }

    }
}