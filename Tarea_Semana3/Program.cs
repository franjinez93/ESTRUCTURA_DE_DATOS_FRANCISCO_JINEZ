using System;

namespace GestionEstudiantes
{
    class Program
    {
        // MATRICES para almacenar los datos (máximo 50 estudiantes)
        static int[] ids = new int[50];              // Matriz unidimensional para IDs
        static string[] nombres = new string[50];    // Matriz unidimensional para nombres
        static string[] apellidos = new string[50];  // Matriz unidimensional para apellidos
        static string[] direcciones = new string[50];// Matriz unidimensional para direcciones
        
        // ARRAY para almacenar los 3 teléfonos de cada estudiante
        static string[][] telefonos = new string[50][]; // Array de arrays (jagged array)
        
        static int totalEstudiantes = 0;  // Contador de estudiantes registrados
        static int idActual = 1;          // Generador de IDs

        static void Main(string[] args)
        {
            int opcion;
            
            // Bucle principal del programa
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE ESTUDIANTES ===");
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Listar estudiantes");
                Console.WriteLine("3. Salir");
                Console.Write("Opción: ");
                
                opcion = int.Parse(Console.ReadLine());

                // Menú de opciones
                switch (opcion)
                {
                    case 1: 
                        RegistrarEstudiante(); 
                        break;
                    case 2: 
                        ListarEstudiantes(); 
                        break;
                }

                // Pausa para ver los resultados
                if (opcion != 3)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }
                
            } while (opcion != 3); // Repetir hasta que elija salir
        }

        static void RegistrarEstudiante()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR ESTUDIANTE ===\n");

            // Verificar que no se supere el límite
            if (totalEstudiantes >= 50)
            {
                Console.WriteLine("No se pueden registrar más estudiantes.");
                return;
            }

            // Asignar ID automáticamente
            ids[totalEstudiantes] = idActual;
            idActual++;

            // Capturar NOMBRES en la matriz
            Console.Write("Nombres: ");
            nombres[totalEstudiantes] = Console.ReadLine();

            // Capturar APELLIDOS en la matriz
            Console.Write("Apellidos: ");
            apellidos[totalEstudiantes] = Console.ReadLine();

            // Capturar DIRECCIÓN en la matriz
            Console.Write("Dirección: ");
            direcciones[totalEstudiantes] = Console.ReadLine();

            // Inicializar el array de 3 teléfonos para este estudiante
            telefonos[totalEstudiantes] = new string[3];

            // Capturar los 3 TELÉFONOS en el array
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Teléfono {i + 1}: ");
                telefonos[totalEstudiantes][i] = Console.ReadLine();
            }

            // Confirmar registro
            Console.WriteLine($"\n✓ Estudiante registrado con ID: {ids[totalEstudiantes]}");
            
            // Incrementar contador
            totalEstudiantes++;
        }

        static void ListarEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE ESTUDIANTES ===\n");

            // Verificar si hay estudiantes registrados
            if (totalEstudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            // Recorrer todos los estudiantes registrados
            for (int i = 0; i < totalEstudiantes; i++)
            {
                // Mostrar datos desde las MATRICES
                Console.WriteLine($"ID: {ids[i]}");
                Console.WriteLine($"Nombres: {nombres[i]}");
                Console.WriteLine($"Apellidos: {apellidos[i]}");
                Console.WriteLine($"Dirección: {direcciones[i]}");
                
                // Mostrar los 3 teléfonos desde el ARRAY
                Console.WriteLine($"Teléfono 1: {telefonos[i][0]}");
                Console.WriteLine($"Teléfono 2: {telefonos[i][1]}");
                Console.WriteLine($"Teléfono 3: {telefonos[i][2]}");
                
                Console.WriteLine("----------------------------");
            }

            // Mostrar total de estudiantes
            Console.WriteLine($"\nTotal: {totalEstudiantes} estudiante(s)");
        }
    }
}