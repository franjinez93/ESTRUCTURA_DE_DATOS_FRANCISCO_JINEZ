using System;
using System.Collections.Generic;

class ParentesisBalanceados
{
    public static bool EsBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            // Si es un signo de apertura, lo empujamos a la pila
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            // Si es un signo de cierre, verificamos
            else if (c == ')' || c == ']' || c == '}')
            {
                // Si la pila está vacía, hay un cierre sin apertura
                if (pila.Count == 0) return false;

                char top = pila.Pop();

                // Verificamos si coinciden las parejas
                if ((c == ')' && top != '(') ||
                    (c == ']' && top != '[') ||
                    (c == '}' && top != '{'))
                {
                    return false;
                }
            }
        }

        // Si la pila queda vacía, todo estaba balanceado. Si queda algo, faltó cerrar.
        return pila.Count == 0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("=== VERIFICADOR DE PARÉNTESIS BALANCEADOS ===");
        Console.WriteLine();
        Console.Write("Ingrese la expresión a verificar: ");
        string entrada = Console.ReadLine();
        
        Console.WriteLine();
        Console.WriteLine($"Entrada: {entrada}");
        
        if (EsBalanceada(entrada))
        {
            Console.WriteLine("Salida: Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Salida: Fórmula NO balanceada.");
        }
        
        Console.WriteLine();
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}