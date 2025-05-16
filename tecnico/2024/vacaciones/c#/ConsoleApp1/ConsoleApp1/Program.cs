namespace ConsoleApp1
{

    class CuentaBancaria
    {
        private string numeroCuenta;
        private double saldo;

        public string NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            }
        }
        public double Saldo
        {
            get
            {
                return saldo;
            }
            private set
            {
                if(value >= 0)
                {
                    saldo = value;
                }
                else
                {
                    Console.WriteLine("El saldo no puede ser negativo.");
                }
            }
        }

        public CuentaBancaria(string numeroC, double saldoC)
        {
            this.numeroCuenta = numeroC;
            this.saldo = saldoC;
        }
        public void Depositar(double monto)
        {
            if (monto > 0)
            {
                this.saldo += monto;
                Console.WriteLine($"Se ha depositado {monto:C}. Saldo actual: {saldo:C}");
            }
            else
            {
                Console.WriteLine($"El monto a deposititar debe ser mayor a o");
            }
        }
        public void Retirar(double monto)
        {
            if (monto > 0 && saldo >= monto)
            {
                this.saldo -= monto;
                Console.WriteLine($"Se ha retirado {monto:C}. Saldo actual: {saldo:C}");
            }
            else
            {
                Console.WriteLine($"No se puede realizar la transacción, saldo insuficiente o monto inválido."); 
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cuenta = new CuentaBancaria("123", 1000000);

            cuenta.Depositar(100000);
            cuenta.Retirar(2000000);

            Console.WriteLine($"Numero de cuenta: {cuenta.NumeroCuenta}");
            Console.WriteLine($"Saldo Inicial: {cuenta.Saldo:C}");



        }
    }
}
