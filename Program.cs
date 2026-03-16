using System;
using System.Collections.Generic;

enum PaaRaakaAine
{
    nautaa,
    kanaa,
    kasviksia
}

enum Lisuke
{
    perunaa,
    riisiä,
    pastaa
}

enum Kastike
{
    curry,
    hapanimelä,
    pippuri,
    chili
}

class Ateria
{
    public PaaRaakaAine PaaRaakaAine { get; set; }
    public Lisuke Lisuke { get; set; }
    public Kastike Kastike { get; set; }

    public void Tulosta()
    {
        Console.WriteLine($"{PaaRaakaAine} ja {Lisuke} {Kastike}-kastikkeella");
    }
}

class Program
{
    static void Main()
    {
        List<Ateria> ateriat = new List<Ateria>();

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"\nLuo ateria {i}");

            PaaRaakaAine paaRaakaAine = KysyEnum<PaaRaakaAine>("Valitse pääraaka-aine");
            Lisuke lisuke = KysyEnum<Lisuke>("Valitse lisuke");
            Kastike kastike = KysyEnum<Kastike>("Valitse kastike");

            Ateria ateria = new Ateria
            {
                PaaRaakaAine = paaRaakaAine,
                Lisuke = lisuke,
                Kastike = kastike
            };

            ateriat.Add(ateria);
        }

        Console.WriteLine("\nValitsemasi ateriat:");
        foreach (Ateria ateria in ateriat)
        {
            ateria.Tulosta();
        }
    }

    static T KysyEnum<T>(string otsikko) where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine(otsikko + ":");
            foreach (var arvo in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"- {arvo}");
            }

            Console.Write("> ");
            string syote = Console.ReadLine();

            if (Enum.TryParse<T>(syote, true, out T tulos))
            {
                return tulos;
            }

            Console.WriteLine("Virheellinen valinta, yritä uudelleen.\n");
        }
    }
}
