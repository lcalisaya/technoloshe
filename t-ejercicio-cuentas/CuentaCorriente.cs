using System;
using System.Collections.Generic;

namespace t_ejercicio_cuentas
{
    /// <summary>
    /// La clase CuentaCorriente permite extracciones de dinero mayores al saldo de la cuenta
    /// </summary>
    public class CuentaCorriente : Cuenta
    {
        //Constructor de CuentaCorriente
        public CuentaCorriente(string numeroCuenta, decimal saldo, Cliente titular) : base(numeroCuenta, saldo, titular)
        {

        }
    }
}