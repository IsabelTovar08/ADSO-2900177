using System;

namespace CadenaResponsabilidad
{

    interface ISoporteManejador
    {
        void SetSiguiente(ISoporteManejador siguiente);
        void Responder(string pregunta);
    }

    class ManejadorSoporteBase : ISoporteManejador
    {
        protected ISoporteManejador Siguiente;

        public void SetSiguiente(ISoporteManejador siguiente)
        {
            Siguiente = siguiente;
        }

        public virtual void Responder(string pregunta)
        {
            if (Siguiente != null)
            {
                Siguiente.Responder(pregunta);
            }
            else
            {
                Console.WriteLine("Lo siento, no podemos atender su solicitud.");
            }
        }

    }

    class Operador : ManejadorSoporteBase
    {
        public override void Responder(string pregunta)
        {
            if (pregunta == "¿Cómo restablezco mi contraseña?")
            {
                Console.WriteLine("Operador: Puedes restablecer tu contraseña desde la opción 'Olvidé mi contraseña'.");
            }
            else
            {
                Console.WriteLine("Operador: No puedo resolver esto, pasando al Técnico...");
                base.Responder(pregunta);
            }
        }
    }

    class Tecnico : ManejadorSoporteBase
    {
        public override void Responder(string pregunta)
        {
            if (pregunta == "Mi computadora no enciende")
            {
                Console.WriteLine("Técnico: Intenta revisar el cable de alimentación.");
            }
            else
            {
                Console.WriteLine("Técnico: No puedo resolver esto, pasando al Gerente...");
                base.Responder(pregunta);
            }
        }
    }

    class Gerente : ManejadorSoporteBase
    {
        public override void Responder(string pregunta)
        {
            if (pregunta == "Quiero presentar una queja")
            {
                Console.WriteLine("Gerente: Por favor, envía tu queja al correo de atención al cliente.");
            }
            else
            {
                base.Responder(pregunta);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISoporteManejador operador = new Operador();
            ISoporteManejador tecnico = new Tecnico();
            ISoporteManejador gerente = new Gerente();

            operador.SetSiguiente(tecnico);
            tecnico.SetSiguiente(gerente);

            operador.Responder("¿Cómo restablezco mi contraseña?");
            operador.Responder("Mi computadora no enciende");
            operador.Responder("Quiero presentar una queja");
            operador.Responder("¿Pueden cambiar mi plan?");
        }
    }

}