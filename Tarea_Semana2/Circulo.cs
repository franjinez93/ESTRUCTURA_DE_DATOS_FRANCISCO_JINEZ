 // CLASE 1: CIRCULO
    // ==========================================
    public class Circulo
    {
        // Encapsulamiento: El dato 'radio' es privado, solo la clase lo puede modificar directamente.
        private double radio;

        // Constructor para inicializar el objeto Círculo
        public Circulo(double radioInicial)
        {
            this.radio = radioInicial;
        }

        // CalcularArea es una función que devuelve un valor double.
        // Se utiliza para calcular el área de este círculo usando la fórmula Pi * radio^2.
        public double CalcularArea()
        {
            return Math.PI * Math.Pow(this.radio, 2);
        }

        // CalcularPerimetro es una función que devuelve un valor double.
        // Se utiliza para calcular la longitud de la circunferencia usando la fórmula 2 * Pi * radio.
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * this.radio;
        }
    }