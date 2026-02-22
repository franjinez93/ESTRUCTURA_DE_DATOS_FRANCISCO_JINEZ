using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        const int totalCiudadanos = 500;
        Random random = new Random();

        // 1) Universo U
        var universo = new HashSet<string>(
            Enumerable.Range(1, totalCiudadanos).Select(i => $"Ciudadano {i}")
        );

        // 2) Distribuir ciudadanos correctamente
        var indicesDisponibles = Enumerable.Range(1, totalCiudadanos).ToList();
        Shuffle(indicesDisponibles, random);

        var pfizer = new HashSet<string>();
        var astrazeneca = new HashSet<string>();
        var noVacunados = new HashSet<string>();
        var ambasDosis = new HashSet<string>();

        int indice = 0;

        // 80 ciudadanos con ambas dosis
        for (int i = 0; i < 80; i++)
        {
            var ciudadano = $"Ciudadano {indicesDisponibles[indice++]}";
            ambasDosis.Add(ciudadano);
            pfizer.Add(ciudadano);
            astrazeneca.Add(ciudadano);
        }

        // 40 ciudadanos solo con Pfizer (120 - 80 = 40)
        for (int i = 0; i < 40; i++)
        {
            pfizer.Add($"Ciudadano {indicesDisponibles[indice++]}");
        }

        // 120 ciudadanos solo con AstraZeneca (200 - 80 = 120)
        for (int i = 0; i < 120; i++)
        {
            astrazeneca.Add($"Ciudadano {indicesDisponibles[indice++]}");
        }

        // 260 no vacunados (500 - 80 - 40 - 120 = 260)
        for (int i = 0; i < 260; i++)
        {
            noVacunados.Add($"Ciudadano {indicesDisponibles[indice++]}");
        }

        // 3) Operaciones de conjuntos
        var vacunados = new HashSet<string>(pfizer);
        vacunados.UnionWith(astrazeneca);

        var soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        var soloAstraZeneca = new HashSet<string>(astrazeneca);
        soloAstraZeneca.ExceptWith(pfizer);

        var diferenciaSimetrica = new HashSet<string>(soloPfizer);
        diferenciaSimetrica.UnionWith(soloAstraZeneca);

        // 4) Salida
        Imprimir("1) Ciudadanos que NO se han vacunado", noVacunados);
        Imprimir("2) Ciudadanos que SOLO han recibido Pfizer", soloPfizer);
        Imprimir("3) Ciudadanos que SOLO han recibido AstraZeneca", soloAstraZeneca);
        Imprimir("4) Ciudadanos que han recibido AMBAS dosis", ambasDosis);
        Imprimir("5) Diferencia simétrica: Solo una dosis", diferenciaSimetrica);

        // Estadísticas
        Console.WriteLine("\n              ESTADÍSTICAS DE VACUNACIÓN            ");
        Console.WriteLine("       ");
        Console.WriteLine($"Total Universo: {universo.Count}");
        Console.WriteLine($"Pfizer: {pfizer.Count}");
        Console.WriteLine($"AstraZeneca: {astrazeneca.Count}");
        Console.WriteLine($"Vacunados: {vacunados.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count}");
        Console.WriteLine($"Diferencia simétrica: {diferenciaSimetrica.Count}");
    }

    static void Imprimir(string titulo, HashSet<string> conjunto)
    {
        Console.WriteLine($"\n{titulo}");
        Console.WriteLine($"Total: {conjunto.Count}");
        Console.WriteLine($"Elementos:");
        
        foreach (var c in conjunto.OrderBy(x => ExtraerNumero(x)))
            Console.WriteLine($"   • {c}");
    }

    static int ExtraerNumero(string ciudadano)
    {
        var partes = ciudadano.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return int.Parse(partes[^1]);
    }

    // Método Shuffle compatible con .NET Framework
    static void Shuffle<T>(List<T> list, Random random)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int k = random.Next(i + 1);
            (list[i], list[k]) = (list[k], list[i]);
        }
    }
}