using System;
using System.Globalization;
using System.Collections.Generic;

namespace t_ejercicio_cuentas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se crea un objeto Cliente y un objeto CuentaCorriente
            Cliente titular = new Cliente("37.193.495", "Lorena Fernandez", "lfernandez@gmail.com", "4826-2473", DateTime.Parse("24/01/1990"));
            CuentaCorriente cuentaCorriente = new CuentaCorriente("cc-0001", 1000, titular);

            //Se realizan operaciones en la cuenta corriente
            cuentaCorriente.IngresarDinero(1000.93m);
            cuentaCorriente.IngresarDinero(5000);
            cuentaCorriente.RetirarDinero(3000);

            //Para agregar un titular mas a la cuenta corriente
            Cliente titular2 = new Cliente("28.093.498", "Gabriel Gutierrez", "ggutierrez@gmail.com", "4785-5992", DateTime.Parse("12/05/1978"));
            cuentaCorriente.AgregarTitular(titular2);

            //Para agregar un titular mas a la cuenta corriente
            titular2 = new Cliente("28.540.959", "Kiara Rodriguez", "krodriguez@yahoo.com", "4019-0985", DateTime.Parse("14/09/1989"));
            cuentaCorriente.AgregarTitular(titular2);

            //Muestra los titulares de la cuenta
            Console.WriteLine("La cuenta corriente: {0}", cuentaCorriente.NumeroCuenta);
            Console.WriteLine("con los Titulares:");
            foreach (Cliente c in cuentaCorriente.Titulares)
            {
                Console.WriteLine("- {0}", c.NombreCompleto);
            }

            //Presenta el saldo de la cuenta
            Console.WriteLine("posee el saldo de: {0:c}", cuentaCorriente.Saldo);

            cuentaCorriente.RetirarDinero(3000);
            cuentaCorriente.IngresarDinero(4000);
            cuentaCorriente.RetirarDinero(8930.58m);

            Console.WriteLine("posee el saldo de: {0:c}", cuentaCorriente.Saldo);

            //Se muestra el historial/log de operaciones de la cuenta
            Console.WriteLine("Las operaciones realizadas y registradas de la cuenta corriente {0} son:", cuentaCorriente.NumeroCuenta);
            foreach (string operacion in cuentaCorriente.RegistroOperaciones)
            {
                Console.WriteLine(operacion);
            }
            Console.WriteLine();
            
            //Prueba de un objeto Caja de ahorro
            CajaAhorro cajaAhorro = new CajaAhorro("ca-0001", 1000, titular, 0.15m);
            cajaAhorro.AgregarTitular(titular2);

            //Operaciones dentro de la caja de ahorro
            cajaAhorro.IngresarDinero(1000.93m);
            cajaAhorro.IngresarDinero(4500);
            cajaAhorro.RetirarDinero(3000);
            cajaAhorro.RetirarDinero(1200);
            cajaAhorro.RetirarDinero(2800);

            //Muestra de todos los titulares de la caja de ahorro
            Console.WriteLine("La caja de ahorro: {0}", cajaAhorro.NumeroCuenta);
            Console.WriteLine("con los Titulares:");
            foreach (Cliente c in cajaAhorro.Titulares)
            {
                Console.WriteLine("- {0}", c.NombreCompleto);
            }

            //Saldo de la cuenta
            Console.WriteLine("posee el saldo de: {0:c}", cajaAhorro.Saldo);

            cajaAhorro.RetirarDinero(3000);
            cajaAhorro.IngresarDinero(4000);
            cajaAhorro.RetirarDinero(8930.58m);

            Console.WriteLine("posee el saldo de: {0:c}", cajaAhorro.Saldo);

            //Registro de todas la operaciones que se quisieron realizar en la caja de ahorro
            Console.WriteLine("Las operaciones realizadas y registradas de la caja de ahorro {0} son:", cajaAhorro.NumeroCuenta);
            foreach (string operacion in cajaAhorro.RegistroOperaciones)
            {
                Console.WriteLine(operacion);
            }

        }
    }
}