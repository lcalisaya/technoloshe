﻿using System;

namespace Technoloshe20173CCuentas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio Cuentas");
            //creamos persona
            Persona morty = new Persona();
            morty.Nombre = "Morty";
            morty.Apellido = "Smith";
            morty.DNI = 38234293;
            morty.Mail = "morty@mail.com";
            morty.FechaDeNacimiento = new DateTime(1990, 5, 1);
            Persona rick = new Persona();
            rick.Nombre = "Rick";
            rick.Apellido = "Sanchez";
            rick.DNI = 12000099;
            rick.Mail = "rick@mail.com";
            rick.FechaDeNacimiento = new DateTime(1960, 5, 1);

            //creamos cuenta
            CuentaCorriente cuenta1 = new CuentaCorriente();
            cuenta1.Numero = 231231;            
            //le damos la cuenta a morty
            cuenta1.Titulares.Add(morty);
            cuenta1.Titulares.Add(rick);
            
            CajaDeAhorro cuenta2 = new CajaDeAhorro(348438);
            cuenta2.Titulares.Add(morty);

            if(cuenta1.DepositarDinero(400))
            {
                Console.WriteLine("Operación OK");
            }
            //Thread.Sleep(2000); //duerme el proceso por 2 segundos
            if(cuenta1.RetirarDinero(200))
            {
                Console.WriteLine("Operación OK");
            }
            if(cuenta1.RetirarDinero(300))
            {
                Console.WriteLine("Operación OK");
            }

            Console.WriteLine("La cuenta1 tiene un saldo: " + cuenta1.Saldo);
            foreach(Persona titular in cuenta1.Titulares)
            {
                Console.WriteLine("La cuenta1 tiene el titular: " + titular.NombreCompleto());
            }
            cuenta1.MostrarOperacionesRealizadas();
            Console.ReadKey();

        }
    }
}
