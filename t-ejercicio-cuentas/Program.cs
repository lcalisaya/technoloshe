using System;
using System.Globalization;
using System.Collections.Generic;

namespace t_ejercicio_cuentas
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente titular = new Cliente("37.193.495", "Lorena Fernandez", "lfernandez@gmail.com", "4826-2473", DateTime.Parse("24/01/1990"));
            Cuenta cuenta = new Cuenta("abc-0001", 1000, titular); 
            
            cuenta.IngresarDinero(1000.93m);
            cuenta.IngresarDinero(5000);
            cuenta.RetirarDinero(3000);
            //Console.WriteLine("El saldo de la cuenta: {0}, titular: {1}, es de: {2:C}", cuenta.NumeroCuenta, cuenta.Titular.NombreCompleto, cuenta.Saldo);
                        
            Cliente titular2 = new Cliente("28.093.498", "Gabriel Gutierrez", "ggutierrez@gmail.com", "4785-5992", DateTime.Parse("12/05/1978"));
            cuenta.AgregarTitular(titular2);
            
            titular2 = new Cliente("28.540.959", "Kiara Rodriguez", "krodriguez@yahoo.com", "4019-0985", DateTime.Parse("14/09/1989"));
            cuenta.AgregarTitular(titular2);
            
            Console.WriteLine("La cuenta: {0}", cuenta.NumeroCuenta);
            Console.WriteLine("con los Titulares:");
            foreach(Cliente c in cuenta.Titulares)
            {
                Console.WriteLine("- {0}", c.NombreCompleto);
            }
            
            Console.WriteLine("posee el saldo de: {0:c}", cuenta.Saldo);

            cuenta.RetirarDinero(3000);
            cuenta.IngresarDinero(4000);
            cuenta.RetirarDinero(8930.58m);

            Console.WriteLine("posee el saldo de: {0:c}", cuenta.Saldo);

            Console.WriteLine("Las operaciones realizadas y registradas de la cuenta {0} son:", cuenta.NumeroCuenta);
            foreach(string operacion in cuenta.RegistroOperaciones)
            {
                Console.WriteLine(operacion);
            }
            

            // Console.WriteLine();
            // Console.WriteLine("Un objeto cuenta pasado a string:");
            // Console.WriteLine(cuenta);
            // Console.WriteLine();
            // Console.WriteLine("Un objeto cliente pasado a string:");
            // Console.WriteLine(titular);
        }
    }
}