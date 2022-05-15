using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cuenta
    {
        public Cuenta(double numeroCuenta, double saldo)
        {
            NumeroCuenta = numeroCuenta;
            //this.cliente = cliente;
            Saldo = saldo;
        }

        public double NumeroCuenta { get; set; }
        //public Cliente cliente { get; set; }
        public double Saldo { get; set; }



        public Cuenta()
        {

        }
        public Cuenta(string linea)
        {
            if (linea != null)
            {
                Mapear(linea);
            }

        }
        public string Linea()
        {
            return  NumeroCuenta + ";" + Saldo;
        }
        private void Mapear(string linea)
        {
            NumeroCuenta = Convert.ToDouble(linea.Split(';')[0]);
            //cliente = new Cliente( linea.Split(';')[1]);
            Saldo = Convert.ToDouble(linea.Split(';')[1]);
        }

        public double getSaldo()
        {
            return Saldo;
        }
        public string Consignar(double valor)
        {
            Saldo += valor;
            return "Consignacion exitosa";
        }
        public string Retirar(double valor)
        {
            if (Saldo < valor)
            {
                return "Fondos insuficiente";
            }
            Saldo -= valor;
            return "Retiro exitoso";
        }
    }
}
