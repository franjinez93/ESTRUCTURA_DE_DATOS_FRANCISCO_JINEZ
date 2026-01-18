using System;

// Clase para representar un nodo de la lista enlazada
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

// Clase para la lista enlazada
public class ListaEnlazada
{
    public Nodo Cabeza { get; set; }

    public ListaEnlazada()
    {
        Cabeza = null;
    }

    // Método para agregar elementos al final de la lista
    public void Agregar(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);
        
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
            return;
        }

        Nodo actual = Cabeza;
        while (actual.Siguiente != null)
        {
            actual = actual.Siguiente;
        }
        actual.Siguiente = nuevoNodo;
    }

    // Método para invertir la lista enlazada
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = Cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            // Guardar el siguiente nodo
            siguiente = actual.Siguiente;
            
            // Invertir el enlace del nodo actual
            actual.Siguiente = anterior;
            
            // Avanzar los punteros
            anterior = actual;
            actual = siguiente;
        }
        
        // Actualizar la cabeza de la lista
        Cabeza = anterior;
    }

    // Método para mostrar la lista
    public void Mostrar()
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía");
            return;
        }

        Nodo actual = Cabeza;
        Console.Write("Lista: ");
        while (actual != null)
        {
            Console.Write(actual.Dato);
            if (actual.Siguiente != null)
                Console.Write(" -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

// Programa principal para probar la implementación
class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregar elementos a la lista
        Console.WriteLine("=== AGREGANDO ELEMENTOS ===");
        lista.Agregar(1);
        lista.Agregar(2);
        lista.Agregar(3);
        lista.Agregar(4);
        lista.Agregar(5);

        // Mostrar lista original
        Console.WriteLine("\nLista original:");
        lista.Mostrar();

        // Invertir la lista
        Console.WriteLine("\n=== INVIRTIENDO LA LISTA ===");
        lista.Invertir();

        // Mostrar lista invertida
        Console.WriteLine("\nLista invertida:");
        lista.Mostrar();

        Console.WriteLine("\n¡Presiona cualquier tecla para salir!");
        Console.ReadKey();
    }
}
