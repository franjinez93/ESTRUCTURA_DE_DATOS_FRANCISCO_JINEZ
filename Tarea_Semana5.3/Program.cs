using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista de asignaturas del curso
        List<string> asignaturas = new List<string> 
        { 
            "Matemáticas", 
            "Física", 
            "Química", 
            "Historia", 
            "Lengua" 
        };

        // Crear una lista para almacenar las notas
        List<double> notas = new List<double>();

        Console.WriteLine("REGISTRO DE NOTAS\n");

        // Pedir al usuario la nota de cada asignatura
        foreach (var asignatura in asignaturas)
        {
            Console.Write($"¿Qué nota sacaste en {asignatura}? ");
            double nota = double.Parse(Console.ReadLine());
            notas.Add(nota);
        }

        // Mostrar las asignaturas con sus notas
        Console.WriteLine("\nRESULTADOS:\n");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine($"En {asignaturas[i]} sacaste {notas[i]}");
        }
    }
}