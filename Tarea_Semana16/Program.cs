using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

public class ArbolBinarioBusqueda
{
    public class Node
    {
        public int Valor;
        public Node Izquierda;
        public Node Derecha;
        public Node(int valor) { Valor = valor; }
    }

    private Node raiz;

    // ─────────────────────────────────────────────
    //  LEER DESDE BLOQUE DE NOTAS (.txt)
    // ─────────────────────────────────────────────
    /// <summary>
    /// Lee un archivo .txt con valores separados por comas
    /// e inserta cada valor en el árbol.
    /// Líneas que empiezan con '#' se ignoran (comentarios).
    /// </summary>
    public void CargarDesdeArchivo(string ruta)
    {
        if (!File.Exists(ruta))
        {
            Console.WriteLine($"Archivo no encontrado: {ruta}");
            return;
        }

        int insertados = 0;
        foreach (string linea in File.ReadLines(ruta))
        {
            string l = linea.Trim();
            if (l.StartsWith("#") || string.IsNullOrWhiteSpace(l)) continue;

            foreach (string parte in l.Split(','))
            {
                if (int.TryParse(parte.Trim(), out int val))
                {
                    Insertar(val);
                    insertados++;
                }
            }
        }
        Console.WriteLine($"Se insertaron {insertados} valores desde '{ruta}'.");
    }

    // ─────────────────────────────────────────────
    //  INSERTAR
    // ─────────────────────────────────────────────
    public void Insertar(int valor) => raiz = InsertarRecursivo(raiz, valor);

    private Node InsertarRecursivo(Node nodo, int valor)
    {
        if (nodo == null) return new Node(valor);
        if (valor < nodo.Valor) nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
        else if (valor > nodo.Valor) nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
        return nodo;
    }

    // ─────────────────────────────────────────────
    //  ELIMINAR
    // ─────────────────────────────────────────────
    public void Eliminar(int valor) => raiz = EliminarRecursivo(raiz, valor);

    private Node EliminarRecursivo(Node nodo, int valor)
    {
        if (nodo == null) { Console.WriteLine("Valor no encontrado."); return null; }
        if (valor < nodo.Valor) nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, valor);
        else if (valor > nodo.Valor) nodo.Derecha = EliminarRecursivo(nodo.Derecha, valor);
        else
        {
            if (nodo.Izquierda == null) return nodo.Derecha;
            if (nodo.Derecha   == null) return nodo.Izquierda;
            int sucesor  = MinimoRecursivo(nodo.Derecha);
            nodo.Valor   = sucesor;
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, sucesor);
        }
        return nodo;
    }

    // ─────────────────────────────────────────────
    //  BUSCAR
    // ─────────────────────────────────────────────
    public bool Buscar(int valor) => BuscarRecursivo(raiz, valor);

    private bool BuscarRecursivo(Node nodo, int valor)
    {
        if (nodo == null) return false;
        if (valor == nodo.Valor) return true;
        return valor < nodo.Valor
            ? BuscarRecursivo(nodo.Izquierda, valor)
            : BuscarRecursivo(nodo.Derecha, valor);
    }

    // ─────────────────────────────────────────────
    //  RECORRIDOS
    // ─────────────────────────────────────────────
    public void Preorden()  { PreordenRecursivo(raiz);  Console.WriteLine(); }
    public void Inorden()   { InordenRecursivo(raiz);   Console.WriteLine(); }
    public void Postorden() { PostordenRecursivo(raiz); Console.WriteLine(); }

    private void PreordenRecursivo(Node n)
    { if (n == null) return; Console.Write(n.Valor + " "); PreordenRecursivo(n.Izquierda); PreordenRecursivo(n.Derecha); }
    private void InordenRecursivo(Node n)
    { if (n == null) return; InordenRecursivo(n.Izquierda); Console.Write(n.Valor + " "); InordenRecursivo(n.Derecha); }
    private void PostordenRecursivo(Node n)
    { if (n == null) return; PostordenRecursivo(n.Izquierda); PostordenRecursivo(n.Derecha); Console.Write(n.Valor + " "); }

    // ─────────────────────────────────────────────
    //  MÍNIMO / MÁXIMO / ALTURA
    // ─────────────────────────────────────────────
    public int Minimo() { if (raiz == null) throw new InvalidOperationException("Árbol vacío."); return MinimoRecursivo(raiz); }
    private int MinimoRecursivo(Node n) => n.Izquierda == null ? n.Valor : MinimoRecursivo(n.Izquierda);

    public int Maximo() { if (raiz == null) throw new InvalidOperationException("Árbol vacío."); return MaximoRecursivo(raiz); }
    private int MaximoRecursivo(Node n) => n.Derecha == null ? n.Valor : MaximoRecursivo(n.Derecha);

    public int Altura() => AlturaRecursiva(raiz);
    private int AlturaRecursiva(Node n)
    { if (n == null) return -1; return Math.Max(AlturaRecursiva(n.Izquierda), AlturaRecursiva(n.Derecha)) + 1; }

    // ─────────────────────────────────────────────
    //  LIMPIAR
    // ─────────────────────────────────────────────
    public void Limpiar() { raiz = null; }

    // ─────────────────────────────────────────────
    //  EXPORTAR A PNG
    // ─────────────────────────────────────────────
    public void ExportarPNG(string rutaArchivo = "arbol.png")
    {
        if (raiz == null) { Console.WriteLine("El árbol está vacío."); return; }

        const int anchoImagen = 1400;
        const int altoImagen  = 900;
        const int radio       = 24;
        const int altoNivel   = 90;

        using Bitmap   bmp = new Bitmap(anchoImagen, altoImagen);
        using Graphics g   = Graphics.FromImage(bmp);

        g.Clear(Color.FromArgb(240, 244, 248));
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        var penLinea    = new Pen(Color.FromArgb(91, 141, 184), 2.5f);
        var brochaCirc  = new SolidBrush(Color.FromArgb(44, 123, 182));
        var brochaTexto = new SolidBrush(Color.White);
        var fuente      = new Font("Arial", 11, FontStyle.Bold);
        var fmt         = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        DibujarNodo(g, raiz, anchoImagen / 2, 50, anchoImagen / 4,
                    radio, altoNivel, penLinea, brochaCirc, brochaTexto, fuente, fmt);

        // ─ Pie de página con estadísticas ─
        string stats = $"Nodos: —  |  Mínimo: {Minimo()}  |  Máximo: {Maximo()}  |  Altura: {Altura()}";
        var brochaFondo = new SolidBrush(Color.FromArgb(44, 62, 80));
        g.FillRectangle(brochaFondo, 0, altoImagen - 36, anchoImagen, 36);
        g.DrawString(stats, new Font("Arial", 10), new SolidBrush(Color.FromArgb(168, 209, 240)),
                     new RectangleF(0, altoImagen - 36, anchoImagen, 36), fmt);

        bmp.Save(rutaArchivo, ImageFormat.Png);
        Console.WriteLine($"Árbol exportado como '{rutaArchivo}'.");
    }

    private void DibujarNodo(Graphics g, Node nodo, int x, int y, int desp,
                              int r, int h, Pen pen, Brush brCirc, Brush brTxt,
                              Font fuente, StringFormat fmt)
    {
        if (nodo == null) return;

        if (nodo.Izquierda != null)
        {
            g.DrawLine(pen, x, y, x - desp, y + h);
            DibujarNodo(g, nodo.Izquierda, x - desp, y + h, desp / 2, r, h, pen, brCirc, brTxt, fuente, fmt);
        }
        if (nodo.Derecha != null)
        {
            g.DrawLine(pen, x, y, x + desp, y + h);
            DibujarNodo(g, nodo.Derecha, x + desp, y + h, desp / 2, r, h, pen, brCirc, brTxt, fuente, fmt);
        }

        // Sombra
        g.FillEllipse(new SolidBrush(Color.FromArgb(60, 0, 0, 0)), x - r + 3, y - r + 4, r * 2, r * 2);
        // Nodo
        g.FillEllipse(brCirc, x - r, y - r, r * 2, r * 2);
        g.DrawEllipse(new Pen(Color.FromArgb(168, 209, 240), 2), x - r, y - r, r * 2, r * 2);
        g.DrawString(nodo.Valor.ToString(), fuente, brTxt, new RectangleF(x - r, y - r, r * 2, r * 2), fmt);
    }

    // ─────────────────────────────────────────────
    //  MENÚ PRINCIPAL
    // ─────────────────────────────────────────────
    public void Menu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n=== ÁRBOL BINARIO DE BÚSQUEDA (BST) ===");
            Console.WriteLine(" 1) Insertar");
            Console.WriteLine(" 2) Eliminar");
            Console.WriteLine(" 3) Buscar");
            Console.WriteLine(" 4) Recorrido PREORDEN");
            Console.WriteLine(" 5) Recorrido INORDEN (ordenado)");
            Console.WriteLine(" 6) Recorrido POSTORDEN");
            Console.WriteLine(" 7) Mínimo / Máximo");
            Console.WriteLine(" 8) Altura");
            Console.WriteLine(" 9) Limpiar árbol");
            Console.WriteLine("10) Exportar árbol a PNG");
            Console.WriteLine("11) Cargar datos desde archivo .txt");   // ← NUEVA OPCIÓN
            Console.WriteLine(" 0) Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) { Console.WriteLine("Entrada no válida."); opcion = -1; continue; }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un valor: ");
                    if (int.TryParse(Console.ReadLine(), out int vIns)) Insertar(vIns);
                    else Console.WriteLine("Valor no válido.");
                    break;
                case 2:
                    Console.Write("Valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int vElim)) Eliminar(vElim);
                    else Console.WriteLine("Valor no válido.");
                    break;
                case 3:
                    Console.Write("Valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int vBusc))
                        Console.WriteLine(Buscar(vBusc) ? $"✔ {vBusc} ENCONTRADO." : $"✘ {vBusc} NO encontrado.");
                    else Console.WriteLine("Valor no válido.");
                    break;
                case 4: Console.Write("PREORDEN: "); Preorden(); break;
                case 5: Console.Write("INORDEN:  "); Inorden();  break;
                case 6: Console.Write("POSTORDEN:"); Postorden(); break;
                case 7:
                    try { Console.WriteLine($"Mínimo: {Minimo()}  |  Máximo: {Maximo()}"); }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    break;
                case 8:  Console.WriteLine($"Altura: {Altura()}"); break;
                case 9:  Limpiar(); Console.WriteLine("Árbol limpiado."); break;
                case 10:
                    Console.Write("Nombre del archivo PNG (Enter = 'arbol.png'): ");
                    string ruta = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(ruta)) ruta = "arbol.png";
                    ExportarPNG(ruta);
                    break;
                case 11:                                           // ← CARGAR DESDE TXT
                    Console.Write("Ruta del archivo .txt: ");
                    string rutaTxt = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(rutaTxt)) CargarDesdeArchivo(rutaTxt);
                    break;
                case 0: Console.WriteLine("Saliendo..."); break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        } while (opcion != 0);
    }
}

class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
        arbol.Menu();
    }
}