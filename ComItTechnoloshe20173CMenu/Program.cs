using System;

namespace Calculadora
{
    class Program
    {
        /// <summary>
        /// Muestra el menú de la aplicación. Se lo obtiene llamando a una función.
        /// </summary>
        static void MostrarMenu()
        {
            Console.WriteLine("Qué querés hacer?");
            Console.WriteLine();
            Console.WriteLine("1- Sumar dos números");
            Console.WriteLine("2- Multiplicar dos números");
            Console.WriteLine("3- Restar dos números");
            Console.WriteLine("4- Dividir dos números");
            Console.WriteLine("0- Salir");
        }

        //Función que valida la opción que ingresa el Usuario
        static int ValidarOpcion()
        {
            int opcionValidada;
            string entradaUsuario = Console.ReadLine();
            while (entradaUsuario != "0" && entradaUsuario != "1" && entradaUsuario != "2" && entradaUsuario != "3" && entradaUsuario != "4")
            {
                Console.WriteLine("Opción inválida");
                MostrarMenu();
                entradaUsuario = Console.ReadLine();
            }
            opcionValidada = int.Parse(entradaUsuario);
            return opcionValidada;
        }

        //Función que pide un número válido (para hacer una operación matemática)
        static double pedirNumero(string cartel)
        {
            double numero;
            Console.WriteLine(cartel);
            string cadena = Console.ReadLine();
            while (!Double.TryParse(cadena, out numero))
            {
                Console.WriteLine("");
                Console.WriteLine("Número inválido. Por favor intenté ingresar una cantidad sin '.' y puede ser decimal(Ej. 3,14):");
                cadena = Console.ReadLine();
            }
            numero = Convert.ToDouble(cadena);
            return numero;
        }
        //Función que suma 2 números
        static double SumarDosNumeros(double num1, double num2)
        {
            return num1 + num2;
        }

        //Función que multiplica 2 números
        static double MultiplicarDosNumeros(double num1, double num2)
        {
            return num1 * num2;
        }

        //Función que resta 2 números
        static double RestarDosNumeros(double num1, double num2)
        {
            return num1 - num2;
        }

        //Función que divide 2 números
        static double DividirDosNumeros(double num1, double num2)
        {
            if (num2 == 0)
            {
                return 0;
            }
            else
            {
                return num1 / num2;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la calculadora");
            MostrarMenu();

            int opcion = ValidarOpcion();
            while (opcion != 0)
            {
                double numero1;
                double numero2;
                double total;
                switch (opcion)
                {
                    case 1:
                        //Se piden 2 números y luego se muestra la suma
                        numero1 = pedirNumero("Ingrese una cantidad --Sin puntos y puede ser decimal (Ej: 3,14):");
                        numero2 = pedirNumero("Ingrese otra cantidad --Sin puntos y puede ser decimal (Ej: 3,14):");
                        total = SumarDosNumeros(numero1, numero2);
                        Console.WriteLine("RESPUESTA: {0} + {1} = {2}", numero1, numero2, total);
                        Console.WriteLine("------");
                        break;
                    case 2:
                        //Se piden 2 números y se presenta el resultado de la multiplicación
                        numero1 = pedirNumero("Ingrese una cantidad --Sin puntos y puede ser decimal (Ej: 3,14):");
                        numero2 = pedirNumero("Ingrese otra cantidad --Sin puntos y puede ser decimal (Ej: 3,14):");
                        total = MultiplicarDosNumeros(numero1, numero2);
                        Console.WriteLine("RESPUESTA: {0} * {1} = {2}", numero1, numero2, total);
                        Console.WriteLine("------");
                        break;
                    case 3:
                        //Se piden 2 números y se muestra la resta
                        numero1 = pedirNumero("Ingrese una cantidad --Sin puntos y puede ser decimal (Ej: 3,14):");
                        numero2 = pedirNumero("Ingrese otra cantidad --Sin puntos y puede ser decimal (Ej: 3,14):");
                        total = RestarDosNumeros(numero1, numero2);
                        Console.WriteLine("RESPUESTA: {0} - {1} = {2}", numero1, numero2, total);
                        Console.WriteLine("------");
                        break;
                    case 4:
                        //Se piden 2 números y se muestra la división
                        numero1 = pedirNumero("Ingrese una cantidad --Sin puntos y puede ser decimal (Ej: 3,14):");
                        numero2 = pedirNumero("Ingrese otra cantidad --No '0', No '.' y puede ser decimal (Ej: 3,14):");
                        total = DividirDosNumeros(numero1, numero2);
                        if (total == 0)
                        {
                            Console.WriteLine("RESPUESTA: {0} / {1} = NO SE PUEDE DIVIDIR POR 0", numero1, numero2, total);
                        }
                        else
                        {
                            Console.WriteLine("RESPUESTA: {0} / {1} = {2}", numero1, numero2, total);
                        }
                        Console.WriteLine("------");
                        break;
                }
                //Una vez que se terminó la operación, se le vuelve a preguntar al Usuario que quiere hacer
                MostrarMenu();
                opcion = ValidarOpcion();
            }
            Console.WriteLine("Chau!!!!");
            Console.ReadKey();
        }
    }
}
