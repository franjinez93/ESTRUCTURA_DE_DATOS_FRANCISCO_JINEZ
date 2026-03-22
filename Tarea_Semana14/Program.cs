using System;
using System.Collections.Generic;

public class ArbolBinarioBusqueda
{
    public class Node
    {
        public int Valor;
        public Node Izquierda;
        public Node Derecha;

        public Node(int valor)
        {
            Valor = valor;
            Izquierda = null;
            Derecha = null;
        }
    }

    private Node raiz;

    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    public void Insertar(int valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private Node InsertarRecursivo(Node nodo, int valor)
    {
        if (nodo == null)
        {
            return new Node(valor);
        }
        if (valor < nodo.Valor)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
        }
        return nodo;
    }

    public void Preorden()
    {
        PreordenRecursivo(raiz);
    }

    private void PreordenRecursivo(Node nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreordenRecursivo(nodo.Izquierda);
            PreordenRecursivo(nodo.Derecha);
        }
    }

    public void Inorden()
    {
        InordenRecursivo(raiz);
    }

    private void InordenRecursivo(Node nodo)
    {
        if (nodo != null)
        {
            InordenRecursivo(nodo.Izquierda);
            Console.Write(nodo.Valor + " ");
            InordenRecursivo(nodo.Derecha);
        }
    }

    public void Postorden()
    {
        PostordenRecursivo(raiz);
    }

    private void PostordenRecursivo(Node nodo)
    {
        if (nodo != null)
        {
            PostordenRecursivo(nodo.Izquierda);
            PostordenRecursivo(nodo.Derecha);
            Console.Write(nodo.Valor + " ");
        }
    }

    public int Minimo()
    {
        if (raiz == null)
            throw new InvalidOperationException("El árbol está vacío.");
        return MinimoRecursivo(raiz);
    }

    private int MinimoRecursivo(Node nodo)
    {
        return nodo.Izquierda == null ? nodo.Valor : MinimoRecursivo(nodo.Izquierda);
    }

    public int Maximo()
    {
        if (raiz == null)
            throw new InvalidOperationException("El árbol está vacío.");
        return MaximoRecursivo(raiz);
    }

    private int MaximoRecursivo(Node nodo)
    {
        return nodo.Derecha == null ? nodo.Valor : MaximoRecursivo(nodo.Derecha);
    }

    public int Altura()
    {
        return AlturaRecursiva(raiz);
    }

    private int AlturaRecursiva(Node nodo)
    {
        if (nodo == null) return -1;
        return Math.Max(AlturaRecursiva(nodo.Izquierda), AlturaRecursiva(nodo.Derecha)) + 1;
    }

    public void Borrar()
    {
        raiz = null;
    }

    public void Menu()
    {
        int opcion;
        do
        {
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Preorden");
            Console.WriteLine("3. Inorden");
            Console.WriteLine("4. Postorden");
            Console.WriteLine("5. Mínimo");
            Console.WriteLine("6. Máximo");
            Console.WriteLine("7. Altura");
            Console.WriteLine("8. Borrar");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un valor: ");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    Insertar(valor);
                    break;
                case 2:
                    Console.WriteLine("Recorrido Preorden:");
                    Preorden();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Recorrido Inorden:");
                    Inorden();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Recorrido Postorden:");
                    Postorden();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Mínimo: " + Minimo());
                    break;
                case 6:
                    Console.WriteLine("Máximo: " + Maximo());
                    break;
                case 7:
                    Console.WriteLine("Altura: " + Altura());
                    break;
                case 8:
                    Borrar();
                    Console.WriteLine("Árbol borrado.");
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 0);
    }
}

// Ejemplo de uso
class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
        arbol.Menu();
    }
}