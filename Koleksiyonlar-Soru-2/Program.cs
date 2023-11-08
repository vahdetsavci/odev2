using System;

namespace Koleksiyonlar_Soru_2;

class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new();
        int[] sayilar = myClass.SayiIste();
        int[] enBuyukler = sayilar.EnBuyuk();
        int[] enKucukler = sayilar.EnKucuk();

        Console.WriteLine("***************************");
        Console.WriteLine("En büyük sayıların artalaması: {0}", enBuyukler.Ortalama());
        Console.WriteLine("En küçük sayıların ortalaması: {0}", enKucukler.Ortalama());
        Console.WriteLine("Ortalama toplamları: {0}", enBuyukler.Ortalama() + enKucukler.Ortalama());
    }
}

class MyClass
{
    internal int[] SayiIste()
    {
        string[] str;
        int[] ints = null;

        bool kontrol = false;
        while (!kontrol)
        {
            try
            {
                Console.Write("Aralarda boşluk olacak şekilde 20 sayı giriniz: ");
                str = Console.ReadLine().Split(' ');
                if (str.Length != 20)
                    throw new Exception();

                ints = new int[str.Length];
                
                for (int i = 0; i < str.Length; i++)
                ints[i] = int.Parse(str[i]);

                kontrol = true;
            }
            catch (Exception)
            {
                Console.WriteLine(new Exception("HATA: Verilen girdi arada boşluk olacak şekilde 20 adet sayıdan oluşmalı. Lütfen tekrar deneyin!").Message);
            }
        }
        return ints;
    }
}

static class ExtensionClass
{
    internal static int[] EnKucuk(this int[] param)
    {
        int[] ints = new int[3];
        Array.Sort(param);
        for (int i = 0; i < ints.Length; i++)
            ints[i] = param[i];
        
        return ints;
    }

    internal static int[] EnBuyuk(this int[] param)
    {
        int[] ints = new int[3];
        Array.Sort(param); Array.Reverse(param);

        for (int i = 0; i < ints.Length; i++)
            ints[i] = param[i];

        return ints;
    }

    internal static int Ortalama(this int[] param)
    {
        int sum = 0;
        foreach (int item in param)
            sum += item;

        return sum / param.Length;
    }
}