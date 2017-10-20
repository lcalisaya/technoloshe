using System;
using System.Collections.Generic;

namespace t_ejercicio_sorteo
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ejercicio hecho con un array
            string[] participantes = new string[12];
            Console.WriteLine("Vamos a hacer un sorteo. Deben participar hasta 12 personas");

            //Llenar el array con los participantes
            for (int i = 0; i < participantes.Length; i++)
            {
                string entrada;
                Console.WriteLine("Ingrese el nombre de 1 participante o 'listo' para salir:");
                entrada = Console.ReadLine();
                while (entrada == "")
                {
                    Console.WriteLine("El nombre no puede estar vacío. Ingrese un nombre o 'listo' para salir:");
                    entrada = Console.ReadLine();
                }

                if (entrada == "listo")
                {
                    break;
                }
                else
                {
                    participantes[i] = entrada;
                }
            }

            //Mostrar los participantes ingresados
            Console.WriteLine("Los participantes son:");
            int j = 0;
            if (participantes[j] == null)
            {
                Console.WriteLine("No se ingresaron participantes");
            }
            else
            {
                foreach(string participante in participantes)
                {
                    Console.WriteLine(participante);
                }
                
                //Seleccionar aleatoriamente una participante
                Random random = new Random();
                int randomPerson = random.Next(0, 12);  // randomPerson: >= 0 y < 13 
                while (participantes[randomPerson] == null)
                {
                    randomPerson = random.Next(0, 12);  
                }

                //Mostrar el participante que ganó el sorteo
                Console.WriteLine("El ganador/a del sorteo es: {0}!", participantes[randomPerson]);

            }
        */

            List<string> participantes = new List<string>();
            Console.WriteLine("Vamos a hacer un sorteo con cualquier número de participantes");

            //Pedir un nombre y llenar la lista con los participantes
            string entrada = "";
            Console.WriteLine("Ingrese el nombre de 1 participante o 'listo' para salir:");
            entrada = Console.ReadLine();

            while (entrada != "listo")
            {
                if (entrada == "")
                {
                    Console.WriteLine("El nombre no puede estar vacío. Ingrese un nombre o 'listo' para salir:");
                    entrada = Console.ReadLine();
                }
                else
                {
                    participantes.Add(entrada);
                    Console.WriteLine("Ingrese el nombre de 1 participante o 'listo' para salir:");
                    entrada = Console.ReadLine();

                }

            }

            //Mostrar los participantes ingresados
            Console.WriteLine("Los participantes son:");

            if (participantes.Count == 0)
            {
                Console.WriteLine("No se ingresaron participantes");
            }
            else
            {
                foreach (string participante in participantes)
                {
                    Console.WriteLine(participante);
                }

                //Seleccionar aleatoriamente un participante
                Random random = new Random();
                int randomPerson = random.Next(0, (participantes.Count));

                //Mostrar el participante que ganó el sorteo
                Console.WriteLine("El ganador/a del sorteo es: {0}!", participantes[randomPerson]);

            }
        }
    }
}
