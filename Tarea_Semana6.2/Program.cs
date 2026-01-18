using System;

// Clase que representa un nodo de la lista
public class Nodo
{
    public int Dato { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

// Clase que representa la lista enlazada
public class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Método para agregar elementos al final de la lista
    public void Agregar(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);
        
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    // Función que calcula el número de elementos de la lista
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = cabeza;

        // Recorremos la lista hasta el final
        while (actual != null)
        {
            contador++;           // Incrementamos el contador
            actual = actual.Siguiente;  // Saltamos al siguiente nodo
        }

        return contador;
    }

    // Método para mostrar la lista
    public void MostrarLista()
    {
        Nodo actual = cabeza;
        Console.Write("Lista: ");
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}

// Programa principal para probar la función
class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        Console.WriteLine("=== Prueba de contar elementos ===\n");

        // Lista vacía
        Console.WriteLine($"Elementos en lista vacía: {lista.ContarElementos()}");

        // Agregamos elementos
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);
        lista.Agregar(40);
        lista.Agregar(50);

        lista.MostrarLista();
        Console.WriteLine($"Número de elementos: {lista.ContarElementos()}");

        Console.ReadKey();
    }
}