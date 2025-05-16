using System.Runtime.CompilerServices;

namespace Clase_Persona
{
  class Persona
  {

    private string nombre;
    private string apellido;
    private int edad;
    private string direccion;
    private string telefono;

    public string Nombre
    {
      get { return nombre; }
      set { nombre = value; }
    }
    public string Apellido
    {
      get { return apellido; }
      set { apellido = value; }
    }
    public int Edad
    {
      get { return edad; }
      set { edad = value; }
    }
    public string Direccion
    {
      get { return direccion; }
      set { direccion = value; }
    }
    public string Telefono
    {
      get { return telefono; }
      set { telefono = value; }
    }

    public Persona()
    {
      nombre = "Sin nombre";
      apellido = "Sin apellido";
      edad = 0;
      telefono = "Sin teléfono";
      direccion = "Sin dirección";

    }

    public Persona(string nombre, string apellido, int edad, string direccion, string telefono)
    {
      this.nombre = nombre;
      this.apellido = apellido;
      this.edad = edad;
      this.direccion = direccion;
      this.telefono = telefono;
    }
    public void MostrarPersona()
    {
      Console.WriteLine($"Nombre: {nombre}, Apellido: {apellido}, Edad: { edad}");
      Console.WriteLine($"Dirección: {direccion}, Teléfono: {telefono}.");

    }
  }

  class Animal
  {
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Animal(string nombre, int edad)
    {
      Nombre = nombre;
      Edad = edad;
    }

    public void MostrarAnimal()
    {
      Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}");
    }

    public virtual void PedirComida()
    {
      Console.WriteLine($"{Nombre}, pide comida.");
    }

  }

  class Perro : Animal
  {
    public Perro(string nombre, int edad, string raza) : base(nombre, edad)
    {
      Raza = raza;
    }
    public string Raza { get; set; }

    public void Ladrar()
    {
      Console.WriteLine($"{Nombre}, está ladrando");
    }

    public override void PedirComida()
    {
      Console.WriteLine($"{Nombre}, el perro quiere comida");
    }
  }

  class Gato : Animal
  {
    public bool EsDomestico { get; set; }

    public Gato(string nombre, int edad, bool esDomestico) : base(nombre, edad)
    {
      EsDomestico = esDomestico;
    }

    public void Maullar()
    {
      Console.WriteLine($"{Nombre}, está maullando.");
    }

    public override void PedirComida()
    {
      Console.WriteLine($"{Nombre}, el gato quiere comida, maullando.");

    }
  }

  class Pajaro : Animal
  {
    public bool Canta { get; set; }

    public Pajaro(string nombre, int edad, bool canta) : base(nombre, edad)
    {
      Canta = canta;
    }

   
  }

  internal class Program
  {
    static void Main(string[] args)
    {
      //Persona objPersona = new Persona();
      //Persona objPersona2 = new Persona("Maria", "Tovar", 18 , "123" , "456");


      //objPersona.Nombre = "Isa";

      //objPersona.MostrarPersona();
      //objPersona2.MostrarPersona();

      Perro miPerro = new Perro("Perro", 2, "no se");
      Gato miGato = new Gato("gato", 5, true);
      Pajaro miPajaro = new Pajaro("loro", 1, true);


      miPerro.MostrarAnimal();
      miGato.MostrarAnimal();
      //miGato.Maullar();

     //miPerro.PedirComida();
     // miGato.PedirComida();

      Animal[] animales = { miPerro, miGato , miPajaro};
      foreach (Animal animal in animales)
      {
        animal.PedirComida();
      }
    }
  }
}
