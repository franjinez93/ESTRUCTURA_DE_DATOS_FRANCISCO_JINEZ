using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista con los números del 1 al 10
        List<int> numeros = new List<int> 
        { 
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10 
        };

        // Invertir el orden de la lista
        numeros.Reverse();

        // Mostrar los números en orden inverso separados por comas
        Console.WriteLine("Números en orden inverso:");
        
        for (int i = 0; i < numeros.Count; i++)
        {
            Console.Write(numeros[i]);
            
            // Agregar coma si no es el último número
            if (i < numeros.Count - 1)
            {
                Console.Write(", ");
            }
        }
        
        Console.WriteLine();
    }
}