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

        // Mostrar el mensaje para cada asignatura
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }
    }
}