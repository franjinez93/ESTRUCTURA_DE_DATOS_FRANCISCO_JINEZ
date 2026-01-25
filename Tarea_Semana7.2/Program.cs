using System;
using System.Collections.Generic;

class TorresHanoiPilas
{
    // Clase para representar un movimiento para mostrar en consola
    class Movimiento
    {
        public int Disco;
        public char Origen;
        public char Destino;
    }

    public static void ResolverHanoiIterativo(int n)
    {
        // Representamos las torres como Pilas
        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        char s = 'A', a = 'B', d = 'C';

        // Si n es par, intercambiamos destino y auxiliar para el algoritmo iterativo
        if (n % 2 == 0)
        {
            char temp = d;
            d = a;
            a = temp;
        }

        // Llenamos la torre origen (Discos grandes primero para que queden al fondo)
        for (int i = n; i >= 1; i--)
        {
            origen.Push(i);
        }

        int totalMovimientos = (int)Math.Pow(2, n) - 1;

        Console.WriteLine($"Resolviendo para {n} discos...\n");

        for (int i = 1; i <= totalMovimientos; i++)
        {
            if (i % 3 == 1)
                MoverDisco(origen, destino, s, d);
            else if (i % 3 == 2)
                MoverDisco(origen, auxiliar, s, a);
            else if (i % 3 == 0)
                MoverDisco(auxiliar, destino, a, d);
        }
    }

    // Función auxiliar para mover legalmente entre dos postes
    public static void MoverDisco(Stack<int> origen, Stack<int> destino, char nombreOrigen, char nombreDestino)
    {
        // Caso 1: La torre destino está vacía, movemos origen -> destino
        if (origen.Count > 0 && destino.Count == 0)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            ImprimirMovimiento(disco, nombreOrigen, nombreDestino);
        }
        // Caso 2: La torre origen está vacía, movemos destino -> origen
        else if (origen.Count == 0 && destino.Count > 0)
        {
            int disco = destino.Pop();
            origen.Push(disco);
            ImprimirMovimiento(disco, nombreDestino, nombreOrigen);
        }
        // Caso 3: Ambas tienen discos, movemos el más pequeño sobre el más grande
        else if (origen.Count > 0 && destino.Count > 0)
        {
            int topOrigen = origen.Peek();
            int topDestino = destino.Peek();

            if (topOrigen < topDestino)
            {
                origen.Pop();
                destino.Push(topOrigen);
                ImprimirMovimiento(topOrigen, nombreOrigen, nombreDestino);
            }
            else
            {
                destino.Pop();
                origen.Push(topDestino);
                ImprimirMovimiento(topDestino, nombreDestino, nombreOrigen);
            }
        }
    }

    public static void ImprimirMovimiento(int disco, char desde, char hacia)
    {
        Console.WriteLine($"Mover disco {disco} de {desde} a {hacia}");
    }

    public static void Main(string[] args)
    {
        // Puedes cambiar el número de discos aquí
        int numeroDiscos = 3; 
        ResolverHanoiIterativo(numeroDiscos);
    }
}