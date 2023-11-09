using System;
using System.Collections.Generic;

namespace Koleksiyonlar_Soru_3;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bir cümle giriniz: ");
        char[] sesliHarfler = Console.ReadLine().ToLower().SesliHarfBul();
        Array.Sort(sesliHarfler);

        Console.Write("Sesli Harfler: ");
        foreach (char harf in sesliHarfler)
            Console.Write(harf + " ");
    }
}

static class MyClass
{
    internal static char[] SesliHarfBul(this string param)
    {
        char[] sesliHarfler = {'a','e','ı','i','o','ö','u','ü'};
        char[] bulunanlar = new char[param.Length];
        int count = 0;

        for (int i = 0; i < sesliHarfler.Length; i++)
        {
            for (int j = 0; j < param.Length; j++)
            {
                if (sesliHarfler[i] == param[j])
                {
                    bulunanlar[count] = param[j];
                    count++;
                }
            }
        }

        Array.Resize<char>(ref bulunanlar, count);
        return bulunanlar;
    }
}