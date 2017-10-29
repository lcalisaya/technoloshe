using System;

namespace t_ejercicio_cuentas
{
    public class Cliente
    {
        public string DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

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