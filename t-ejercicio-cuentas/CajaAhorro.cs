using System;
using System.Collections.Generic;

namespace t_ejercicio_cuentas
{
    /// <summary>
    /// La clase CajaAhorro hereda de la clase Cuenta y agrega la propiedad de intereses pagados
    /// </summary>
    public class CajaAhorro : Cuenta
    {
        public decimal InteresQueSePaga { get; set; }
        //Constructor de CajaAhorro, heredado de Cuenta y se inicializa la propiedad InteresQueSePaga
        public CajaAhorro(string numeroCuenta, decimal saldo, Cliente titular, decimal interes) : base(numeroCuenta, saldo, titular)
        {
            this.InteresQueSePaga = interes;
        }
        //Se modifica el comportamiento del método RetirarDinero para que no se acepten retiros de dinero mayores al saldo existente
        public override void RetirarDinero(decimal monto)
        {
            if (this.Saldo >= monto)
            {
                this.Saldo = this.Saldo - monto;
                RegistrarOperaciones(string.Format("- Se retira dinero. Monto = {0}", monto.ToString("C2")));
            }
            else
            {
                RegistrarOperaciones(string.Format("x Operación denegada por solicitar un Monto = {0:c} mayor al Saldo = {1}", monto, this.Saldo.ToString("C2")));
            }
        }
    }
}