using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista para almacenar los números ganadores
        List<int> numerosGanadores = new List<int>();

        Console.WriteLine("LOTERÍA PRIMITIVA");
        Console.WriteLine("Ingrese los 6 números ganadores:\n");

        // Pedir al usuario los 6 números ganadores
        for (int i = 1; i <= 6; i++)
        {
            Console.Write($"Número {i}: ");
            int numero = int.Parse(Console.ReadLine());
            numerosGanadores.Add(numero);
        }

        // Ordenar los números de menor a mayor
        numerosGanadores.Sort();

        // Mostrar los números ordenados
        Console.WriteLine("\nNÚMEROS GANADORES ORDENADOS DE MENOR A MAYOR:");
        foreach (var numero in numerosGanadores)
        {
            Console.WriteLine(numero);
        }
    }
}