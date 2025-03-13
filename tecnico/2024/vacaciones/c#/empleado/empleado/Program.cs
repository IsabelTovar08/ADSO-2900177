namespace empleado
{
    public abstract class Empleado
    {
        protected string Nombre;
        protected int Edad;

        public Empleado(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        public abstract double CalcularSalario();

        public void MostrarDetalle()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}.");
        }

    }

    public interface IEmpleadoBeneficios
    {
        double CalcularBeneficio();
    }

    public class EmpleadoTimpoCompleto : Empleado, IEmpleadoBeneficios
    {
        private double SalarioMensual;
        private double Beneficio;

        public EmpleadoTimpoCompleto(string nombre, int edad, double salario, double beneficio): base( nombre, edad)
        {
            SalarioMensual = salario;
            this.Beneficio = beneficio;
        }

        public override double CalcularSalario()
        {
            return SalarioMensual;
        }
        public double CalcularBeneficio()
        {
            return Beneficio;
        }
    }

    public class EmpleadoMedioTiempo : Empleado
    {
        private double TarifaPorHora;
        private int HorasTrabajadas;

        public EmpleadoMedioTiempo(string nombre, int edad, double tarifa, int horas) : base (nombre, edad)
        {
            TarifaPorHora = tarifa;
            HorasTrabajadas = horas;
        }
        public override double CalcularSalario() {
            return HorasTrabajadas * TarifaPorHora ; 
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            EmpleadoTimpoCompleto empleado = new EmpleadoTimpoCompleto("ISa", 18, 13000, 50000);
            empleado.MostrarDetalle();

            Console.WriteLine($"Salario: {empleado.CalcularSalario():C}");
            Console.WriteLine($"Beneficios: {empleado.CalcularBeneficio():C}");

            Empleado empleadoDos = new EmpleadoMedioTiempo("Maria", 18, 20, 40);
            empleadoDos.MostrarDetalle();
            Console.WriteLine($"Su salario es: {empleadoDos.CalcularSalario():C}");

        }
    }
}
