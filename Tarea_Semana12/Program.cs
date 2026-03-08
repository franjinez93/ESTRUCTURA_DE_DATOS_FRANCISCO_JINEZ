using System;
using System.Collections.Generic;

namespace BibliotecaApp
{
    class Program
    {
        // Diccionario: Clave (ID del libro) -> Valor (Nombre del libro)
        // Basado en la teoría de asociaciones clave-valor
        static Dictionary<string, string> registroLibros = new Dictionary<string, string>();
        
        // HashSet: Para almacenar géneros únicos
        static HashSet<string> generosDisponibles = new HashSet<string>();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("\n--- SISTEMA DE GESTIÓN DE BIBLIOTECA (ID) ---");
                Console.WriteLine("1. Registrar nuevo libro");
                Console.WriteLine("2. Visualizar inventario completo");
                Console.WriteLine("3. Consultar libro por ID");
                Console.WriteLine("4. Ver géneros disponibles (Sin duplicados)");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: 
                            RegistrarLibro(); 
                            break;
                        case 2: 
                            VisualizarLibros(); 
                            break;
                        case 3: 
                            ConsultarLibro(); 
                            break;
                        case 4: 
                            VisualizarGeneros(); 
                            break;
                        case 5:
                            Console.WriteLine("¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            } while (opcion != 5);
        }

        static void RegistrarLibro()
        {
            Console.Write("Ingrese el ID del libro (Clave única): ");
            string id = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Error: El ID no puede estar vacío.");
                return;
            }
            
            Console.Write("Ingrese el título: ");
            string titulo = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Error: El título no puede estar vacío.");
                return;
            }
            
            Console.Write("Ingrese el género: ");
            string genero = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(genero))
            {
                Console.WriteLine("Error: El género no puede estar vacío.");
                return;
            }

            // Verificación de unicidad de la clave
            if (!registroLibros.ContainsKey(id))
            {
                registroLibros.Add(id, titulo); // Inserción en el mapa
                generosDisponibles.Add(genero); // Adición al conjunto (ignora si ya existe)
                Console.WriteLine("Libro registrado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El ID ya se encuentra registrado.");
            }
        }

        static void VisualizarLibros()
        {
            Console.WriteLine("\n--- Visualización de Datos ---");
            if (registroLibros.Count == 0) 
            {
                Console.WriteLine("El registro está vacío.");
                return;
            }
            
            // Recorrido de los elementos del diccionario
            foreach (var libro in registroLibros)
            {
                Console.WriteLine($"ID: {libro.Key} | Título: {libro.Value}");
            }
        }

        static void ConsultarLibro()
        {
            Console.Write("Ingrese el ID a consultar: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Error: El ID no puede estar vacío.");
                return;
            }

            // Búsqueda por clave (Acceso rápido)
            if (registroLibros.TryGetValue(id, out string titulo))
            {
                Console.WriteLine($"Libro encontrado: {titulo}");
            }
            else
            {
                Console.WriteLine("No existe un libro con ese ID.");
            }
        }

        static void VisualizarGeneros()
        {
            Console.WriteLine("\n--- Categorías Registradas ---");
            if (generosDisponibles.Count == 0)
            {
                Console.WriteLine("No hay géneros registrados.");
                return;
            }
            
            // Los conjuntos garantizan elementos únicos
            foreach (string g in generosDisponibles)
            {
                Console.WriteLine($"- {g}");
            }
        }
    }
}