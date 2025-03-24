//namespace CadenaResponsabilidad;

//class Persona
//{
//    protected Persona Siguiente;

//    public void SetSiguiente(Persona Siguiente)
//    {
//        this.Siguiente = Siguiente;
//    }

//    public virtual void Responder(string pregunta)
//    {
//        if (Siguiente != null)
//        {
//            Siguiente.Responder(pregunta);
//        }
//        else
//        {
//            Console.WriteLine("Lo siento, tu solicitud no puede ser atendida.");
//        }
//    }
//}

//class Juan : Persona
//{
//    public override void Responder(string pregunta)
//    {
//        if (pregunta == "¿Qué día es hoy?")
//        {
//            Console.WriteLine("Juan responde: Hoy es jueves.");
//        }
//        else
//        {
//            base.Responder(pregunta);
//        }
//    }
//}

//class Maria : Persona
//{
//    public override void Responder(string pregunta)
//    {
//        if (pregunta == "¿Cómo está el clima hoy?")
//        {
//            Console.WriteLine("María responde: No tengo respuesta a esa pregunta, pero sé quien te puede ayudar.");
//            base.Responder(pregunta);
//        }
//        else
//        {
//            base.Responder(pregunta);
//        }
//    }
//}

//class Pedro : Persona
//{
//    public override void Responder(string pregunta)
//    {
//        if (pregunta == "¿Cómo está el clima hoy?")
//        {
//            Console.WriteLine("Pedro responde: Hoy el día está soleado");
//        }
//        else
//        {
//            base.Responder(pregunta);
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Persona juan = new Juan();
//        Persona maria = new Maria();
//        Persona pedro = new Pedro();

//        juan.SetSiguiente(maria);
//        maria.SetSiguiente(pedro);

//        juan.Responder("¿Qué día es hoy?");
//        juan.Responder("¿Cómo está el clima hoy?");
//        juan.Responder("¿Qué hora es?");
//    }
//}