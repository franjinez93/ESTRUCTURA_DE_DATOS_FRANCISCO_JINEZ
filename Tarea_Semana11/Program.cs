using System;
using System.Collections.Generic;

class Traductor
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"tiempo", "time"},
        {"persona", "person"},
        {"año", "year"},
        {"camino", "way"},
        {"forma", "way"},
        {"día", "day"},
        {"cosa", "thing"},
        {"hombre", "man"},
        {"mundo", "world"},
        {"vida", "life"},
        {"mano", "hand"},
        {"parte", "part"},
        {"niño", "child"},
        {"a", "to"},
        {"ojo", "eye"},
        {"mujer", "woman"},
        {"lugar", "place"},
        {"trabajo", "work"},
        {"semana", "week"},
        {"caso", "case"},
        {"punto", "point"},
        {"tema", "point"},
        {"gobierno", "government"},
        {"empresa", "company"},
        {"compañía", "company"}
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("================== MENÚ ==================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Intenta de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.WriteLine();
        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese una frase en español: ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(new[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> traduccion = new List<string>();

        foreach (var palabra in palabras)
        {
            if (diccionario.ContainsKey(palabra.ToLower()))
            {
                traduccion.Add(diccionario[palabra.ToLower()]);
            }
            else
            {
                traduccion.Add(palabra);
            }
        }

        Console.WriteLine("Traducción parcial:");
        Console.WriteLine(string.Join(" ", traduccion));
    }

    static void AgregarPalabra()
    {
        Console.Write("Palabra en español: ");
        string espanol = Console.ReadLine()?.Trim().ToLower();

        Console.Write("Equivalente en inglés: ");
        string ingles = Console.ReadLine()?.Trim().ToLower();

        if (!string.IsNullOrEmpty(espanol) && !string.IsNullOrEmpty(ingles))
        {
            if (!diccionario.ContainsKey(espanol))
            {
                diccionario.Add(espanol, ingles);
                Console.WriteLine("Palabra agregada correctamente.");
            }
            else
            {
                Console.WriteLine("La palabra ya existe en el diccionario.");
            }
        }
        else
        {
            Console.WriteLine("Datos incompletos. No se agregó la palabra.");
        }
    }
}