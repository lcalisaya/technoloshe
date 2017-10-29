using System;
using System.Collections.Generic;

namespace t_ejercicio_cuentas
{
    public class Cuenta
    {
        public string NumeroCuenta { get; set; }
        public List<Cliente> Titulares { get; set; }
        public decimal Saldo { get; set; }
        //Constructor de la clase Cuenta
        public Cuenta(string numeroCuenta, decimal saldo, Cliente titular)
        {
            this.NumeroCuenta = numeroCuenta;
            this.Saldo = saldo;
            this.Titulares = new List<Cliente>();
            this.Titulares.Add(titular);
        }
        public void IngresarDinero(decimal monto)
        {
            this.Saldo = this.Saldo + monto;
        }

        public void RetirarDinero(decimal monto)
        {
            this.Saldo = this.Saldo - monto;
        }

        public override string ToString()
        {
            return this.NumeroCuenta + " " + this.Titulares + " " + this.Saldo;
        }

        public void AgregarTitular(Cliente otroTitular)
        {
            this.Titulares.Add(otroTitular);
        }
    }
}