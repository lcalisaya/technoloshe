using System;

namespace t_ejercicio_cuentas
{
    public class Cuenta
    {
        public string NumeroCuenta { get; set; }
        public Cliente Titular { get; set; }
        public decimal Saldo { get; set; }
        public Cuenta(string numeroCuenta, decimal saldo, Cliente titular)
        {
            this.NumeroCuenta = numeroCuenta;
            this.Saldo = saldo;
            this.Titular = titular;
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
            return this.NumeroCuenta + " " + this.Titular + " " + this.Saldo;
        }
    }
}