 // ==========================================
    // CLASE 2: RECTANGULO
    // ==========================================
    public class Rectangulo
    {
        // Encapsulamiento: Los datos 'base' y 'altura' son privados.
        private double baseRectangulo;
        private double alturaRectangulo;

        // Constructor para inicializar el objeto Rectángulo
        public Rectangulo(double baseInicial, double alturaInicial)
        {
            this.baseRectangulo = baseInicial;
            this.alturaRectangulo = alturaInicial;
        }

        // CalcularArea es una función que devuelve un valor double.
        // Se utiliza para calcular el superficie del rectángulo multiplicando base * altura.
        public double CalcularArea()
        {
            return this.baseRectangulo * this.alturaRectangulo;
        }

        // CalcularPerimetro es una función que devuelve un valor double.
        // Se utiliza para calcular el contorno sumando dos veces la base más dos veces la altura.
        public double CalcularPerimetro()
        {
            return 2 * (this.baseRectangulo + this.alturaRectangulo);
        }
    }