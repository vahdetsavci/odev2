using System;
using System.Collections;

namespace Koleksiyonlar_Soru_1;

class Program
{
    static void Main(string[] args)
    {
        AsalSayi asalSayi = new();
        asalSayi.Iste();
        asalSayi.ListeYazdir();
    }
}

class AsalSayi
{
    ArrayList asal = new(), asalDegil = new();
    internal void Iste()
    {
        int sayi = 0;
        Console.WriteLine("20 adet pozitif sayı giriniz!");
        for (int i = 1; i <= 20; i++)
        {
            bool kontrol = false;
            while (!kontrol)
            {
                Console.Write(i + ".sayı: ");
                int.TryParse(Console.ReadLine(), out sayi);
                if (sayi < 1)
                    Console.WriteLine("HATA: Girdiğiniz değer bir pozitif sayı değil lütfen bir pozitif sayı girip tekrar deneyin!");
                else
                    kontrol = true;
            }
            ListeyeEkle(sayi);
        }
    }

    void ListeyeEkle(int sayi)
    {
        if (sayi.AsalMi())
            asal.Add(sayi);
        else
            asalDegil.Add(sayi);
    }

    internal void ListeYazdir()
    {
        asal.Sort(); asal.Reverse();
        asalDegil.Sort(); asalDegil.Reverse();

        Console.WriteLine("***** Asal Sayılar *****");
        foreach (var item in asal)
            Console.WriteLine(item);

        Console.WriteLine("Toplam {0} asal sayı var. Asal sayıların ortalaması {1} eder.", asal.Count, asal.Ortalama());
        Console.WriteLine("******************");

        Console.WriteLine("***** Asal Olmayan Sayılar *****");
        foreach (var item in asalDegil)
            Console.WriteLine(item);

        Console.WriteLine("Toplam {0} asal olmayan sayı var. Asal olmayan sayıların ortalaması {1} eder.", asalDegil.Count, asalDegil.Ortalama());
        Console.WriteLine("******************");
    }
}

static class ExtensionClass
{
    internal static bool AsalMi(this int param)
    {
        bool kontrol = true;
        if (param > 2)
        {
            for (int i = 2; i < param; i++)
            {
                if (param % i == 0)
                {
                    kontrol = false;
                    break;
                }
            }
        }
        else if (param == 2)
            kontrol = true;
        else
            kontrol = false;

        return kontrol;
    }

    internal static int Ortalama(this ArrayList liste)
    {
        int listeToplam = 0;
        foreach (int item in liste)
            listeToplam += item;
        return listeToplam / liste.Count;
    }
}