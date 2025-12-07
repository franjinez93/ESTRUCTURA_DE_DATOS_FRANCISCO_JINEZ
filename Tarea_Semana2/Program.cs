using System;

namespace GeometriaTarea
{
    // PROGRAMA PRINCIPAL (MAIN)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CÁLCULO DE FIGURAS GEOMÉTRICAS ===");

            // 1. Instancia y uso del Círculo
            double radioUsuario = 5.0;
            Circulo miCirculo = new Circulo(radioUsuario);

            Console.WriteLine("\n--- Resultados para el Círculo (Radio: " + radioUsuario + ") ---");
            Console.WriteLine("Área: " + miCirculo.CalcularArea().ToString("F2"));
            Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro().ToString("F2"));

            // 2. Instancia y uso del Rectángulo
            double baseUsuario = 4.0;
            double alturaUsuario = 3.0;
            Rectangulo miRectangulo = new Rectangulo(baseUsuario, alturaUsuario);

            Console.WriteLine("\n--- Resultados para el Rectángulo (Base: " + baseUsuario + ", Altura: " + alturaUsuario + ") ---");
            Console.WriteLine("Área: " + miRectangulo.CalcularArea().ToString("F2"));
            Console.WriteLine("Perímetro: " + miRectangulo.CalcularPerimetro().ToString("F2"));

            // Esperar a que el usuario presione una tecla para salir
            Console.ReadKey();
        }
    }
}