using System.Reflection.Metadata;

namespace productos
{

    abstract class Producto
    {
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public string Codigo { get; set; }
        public decimal Impuesto { get; set; }

        public Producto(string nombre, decimal precio, string categoria, string codigo, decimal impuesto)
        {
            this.Nombre = nombre;
            this.Valor = precio;
            this.Categoria = categoria;
            this.Codigo = codigo;
            this.Impuesto = impuesto;
        }
        public abstract decimal CalcularPRecioFinal();

        public virtual void MostrarDetaller()
        {
            Console.WriteLine($"Producto: {Nombre}, valor: {Valor:C}, categoría: {Categoria}, código: {Codigo}, impuesto: {Impuesto:C}.");
        } 
    }

    class Libro : Producto
    {
        public string Autor { get; set; }
        public int NumeroPaginas { get; set; }

        public Libro(string nombre, decimal precio, string categoria, string codigo, decimal impuesto, string auntor, int numeropaginas) : base(nombre, precio, categoria, codigo, impuesto)
        {
            this.Autor = auntor;
            this.NumeroPaginas = numeropaginas;
        }

        public override decimal CalcularPRecioFinal()
        {
            decimal descuento = 0.1m;
            decimal PrecioConDescuento = this.Valor - (this.Valor * descuento);
            return PrecioConDescuento + (PrecioConDescuento * this.Impuesto);
        }

        public override void MostrarDetaller()
        {
            base.MostrarDetaller();
            Console.WriteLine($"Auntor: {Autor}, número de páginas: {NumeroPaginas}, precio final: {CalcularPRecioFinal():C}");
        }
    }

    class Computadora : Producto
    {
        public string Marca { get; set; }
        public string Procesador { get; set; }
        public int RAM { get; set; }

        public Computadora(string nombre, decimal precio, string categoria, string codigo, decimal impuesto, string marca, string procesador, int ram) : base(nombre, precio, categoria, codigo, impuesto)
        {
            this.Marca = marca;
            this.RAM = ram;
            this.Procesador = procesador;
        }
        public override decimal CalcularPRecioFinal()
        {
            return this.Valor + (this.Valor * this.Impuesto);
        }
        public override void MostrarDetaller()
        {
            base.MostrarDetaller();
            Console.WriteLine($"Marca: {Marca}, Procesador: {Procesador }, RAM: {RAM}");
        }

    }

    class Factura
    {
        private List<Producto> productos = new List<Producto>();

        public void agregarProducto(Producto producto)
        {
            productos.Add(producto);
        }
        public void MostrarProductos()
        {
            decimal total = 0;
            Console.WriteLine($"Lista de productos:");
            foreach (Producto producto in productos)
            {
                producto.MostrarDetaller();
                total += producto.CalcularPRecioFinal();
            }
            Console.WriteLine($"\nTotal: {total}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Factura fac= new Factura();
            Producto libro = new Libro ("Libro C#", 50m, "Programacion", "L123", 0.05m, "Yooo", 400);
            Producto compu = new Computadora("Compu C#", 50000m, "Tecnologia", "COMPU456", 0.08m, "ASUS", "intel core i7", 16);
            fac.agregarProducto(libro);
            fac.agregarProducto(compu);
            fac.MostrarProductos();
        }
    }
}
