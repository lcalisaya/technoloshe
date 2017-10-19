using System;

namespace project1_saturday
{
    class Program
    {
        static void Main(string[] argumentos)
        {
            Console.WriteLine("Hola mundo! Cómo estás?");
            Console.WriteLine(argumentos.Length);
            
            Console.WriteLine("Conversiones explícitas: con (tipo de dato de destino)");
            double miDoble = 4567.89;
            int miInt;
            miInt = (int)miDoble; //Se guarda '4567'
            Console.WriteLine(miInt);

            Console.WriteLine("Conversiones explícitas: con los métodos de .NET");
            double segundoDoble = 4567.89;
            int segundoInt;
            segundoInt = Convert.ToInt32(segundoDoble); // Se guarda '4568' haciendo un redondeo
            Console.WriteLine(segundoInt);

            Console.WriteLine("Conversiones explícitas: con TryParse() y Parse()");
            int number = Int32.Parse("4567"); //Lo pasa de una string a un int
            Console.WriteLine(number);

            int numeroConvertido;
            string numeroEnCadena = "7593";
            bool result = Int32.TryParse(numeroEnCadena, out numeroConvertido); //Si pudo hacer la conversión devuelve un true
            Console.WriteLine(result);
            Console.WriteLine("Convertido de '{0}' a {1}.", numeroEnCadena, numeroConvertido);

            //(crtl + k + c) atajo para comentar líneas
            //(alt + shift + f) para indentar
        }
    }
}
