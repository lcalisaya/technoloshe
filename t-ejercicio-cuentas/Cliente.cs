using System;
using System.Collections.Generic;

namespace t_ejercicio_cuentas
{
    /// <summary>
    /// La clase Cliente define los datos que se guardarán del cliente y operaciones que podrá realizar
    /// </summary>
    public class Cliente
    {
        public string DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        //Constructor de la clase Cliente
        public Cliente(string dni, string nombre, string mail, string telefono, DateTime fechaNacimiento)
        {
            this.DNI = dni;
            this.NombreCompleto = nombre;
            this.Mail = mail;
            this.Telefono = telefono;
            this.FechaDeNacimiento = fechaNacimiento;
        }

        public override string ToString()
        {
            return this.DNI + " " + this.NombreCompleto + " " + this.Mail + " "+ this.Telefono + " " + this.FechaDeNacimiento;
        }
    }
}