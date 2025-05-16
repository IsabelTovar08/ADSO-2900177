namespace ConsoleApp2
{
  internal class Program
  {
    static void Main(string[] args)
    {
      bool continuar = true;
      do
      {
        decimal precioProducto = 0;
        decimal porcentajeDescuento = 0;
        decimal precioDescuento = 0;
        decimal valorFinalProducto = 0;

        try
        {
          Console.WriteLine("Ingrese el precio inicial del producto: ");
          precioProducto = Convert.ToDecimal(Console.ReadLine());

          Console.WriteLine("Ingrese el descuento del producto: ");
          porcentajeDescuento = Convert.ToDecimal(Console.ReadLine());

          if (precioProducto <= 0 || porcentajeDescuento < 0)
          {
            throw new Exception();
            //Console.WriteLine("Mal");
          }
        }
        catch (Exception)
        {
          Console.WriteLine("Datos no válidos para la operación. Por favor ingrese un número positivo.");
          continue; // Reinicia el ciclo en caso de error
        }

        precioDescuento = (precioProducto * porcentajeDescuento) / 100;
        valorFinalProducto = precioProducto - precioDescuento;

        Console.WriteLine($"El monto de descuento para el producto es: {precioDescuento}");
        Console.WriteLine($"El precio final del producto es: {valorFinalProducto}");

        while (true)
        {
          Console.WriteLine("¿Desea continuar con otro producto? Si/No");
          string respuesta = Console.ReadLine().ToLower();

          switch (respuesta)
          {
            case "si":
              continuar = true;
              break;
            case "no":
              continuar = false;
              break;
            default:
              Console.WriteLine("Error, respuesta no válida. Por favor ingrese 'si' o 'no'.");
              continue; // Repite la pregunta si la respuesta no es válida
          }

          break; // Sale del bucle while si la respuesta es válida
        }

      } while (continuar);
    }
  }
}
