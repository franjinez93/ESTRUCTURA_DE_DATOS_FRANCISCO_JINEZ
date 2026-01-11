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

        // Mostrar las asignaturas por pantalla
        Console.WriteLine("ASIGNATURAS DEL CURSO:\n");
        
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine(asignatura);
        }
    }
}