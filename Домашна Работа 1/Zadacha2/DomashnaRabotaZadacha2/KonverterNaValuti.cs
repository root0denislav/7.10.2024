using System;

class CurrencyConverter
{
    static void Main()
    {
        double suma = double.Parse(Console.ReadLine());
        string vkarano = Console.ReadLine();
        string izkarano = Console.ReadLine();

        double usd = 1.79549;
        double eur = 1.95583;
        double gbr = 2.53405;
        double resultat = 0;

        if (vkarano == "BGN")
        {
            if (izkarano == "USD") resultat = suma / usd;
            else if (izkarano == "EUR") resultat = suma / eur;
            else if (izkarano == "GBP") resultat = suma / gbr;
        }
        else if (vkarano == "USD")
        {
            if (izkarano == "BGN") resultat = suma * usd;
        }
        else if (vkarano == "EUR")
        {
            if (izkarano == "BGN") resultat = suma * eur;
        }
        else if (vkarano == "GBP")
        {
            if (izkarano == "BGN") resultat = suma * gbr;
        }

        Console.WriteLine($"{resultat:F2} {izkarano}");
    }
}
