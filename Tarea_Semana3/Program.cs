using System;

namespace GestionEstudiantes
{
    // Definición de la Clase Estudiante
    public class Estudiante
    {
        // Propiedades básicas
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Definición del Arreglo (Array) para los teléfonos
        // Se define un array de strings de tamaño fijo (3)
        public string[] Telefonos { get; set; } = new string[3];
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar la clase (Crear el objeto estudiante)
            Estudiante nuevoEstudiante = new Estudiante();

            Console.WriteLine("   SISTEMA DE REGISTRO DE ESTUDIANTE    ");
            
            try
            {
                // Captura de datos simples
                Console.Write("Ingrese el ID del estudiante (numérico): ");
                nuevoEstudiante.ID = int.Parse(Console.ReadLine());

                Console.Write("Ingrese los Nombres: ");
                nuevoEstudiante.Nombres = Console.ReadLine();

                Console.Write("Ingrese los Apellidos: ");
                nuevoEstudiante.Apellidos = Console.ReadLine();

                Console.Write("Ingrese la Dirección: ");
                nuevoEstudiante.Direccion = Console.ReadLine();

                Console.WriteLine("\n--- Registro de Números Telefónicos ---");
                Console.WriteLine("(Debe registrar 3 números obligatoriamente)");

                // Uso de Bucle para llenar el Array
                for (int i = 0; i < nuevoEstudiante.Telefonos.Length; i++)
                {
                    Console.Write($"Ingrese el número de teléfono #{i + 1}: ");
                    nuevoEstudiante.Telefonos[i] = Console.ReadLine();
                }

                // Limpiar consola para mostrar reporte
                Console.Clear();

                // Mostrar los datos almacenados
                Console.WriteLine("   ");
                Console.WriteLine("      DATOS DEL ESTUDIANTE REGISTRADO   ");
                Console.WriteLine("   ");
                Console.WriteLine($"ID:        {nuevoEstudiante.ID}");
                Console.WriteLine($"Nombre:    {nuevoEstudiante.Nombres} {nuevoEstudiante.Apellidos}");
                Console.WriteLine($"Dirección: {nuevoEstudiante.Direccion}");
                
                Console.WriteLine("Teléfonos de contacto:");
                // Recorrer el arreglo para mostrar los datos
                for (int i = 0; i < nuevoEstudiante.Telefonos.Length; i++)
                {
                    Console.WriteLine($"  -> Teléfono {i + 1}: {nuevoEstudiante.Telefonos[i]}");
                }
                Console.WriteLine("========================================");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: El ID debe ser un número entero válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcurrió un error inesperado: {ex.Message}");
            }

            // Pausa para que no se cierre la ventana inmediatamente
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}