using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Logica
{
    public class ServicioCuentas
    {
        //private RepositorioClientes repositorioClientes;
        List<Cuenta> cuentas;
        RepositorioCuentas repositorioCuentas = new RepositorioCuentas();//datos
        public ServicioCuentas()
        {
            cuentas = repositorioCuentas.ConsultarTodos();  // trae a los clientes del archivo
        }

        public string Guardar(Cuenta cuenta)
        {
            string mensaje = string.Empty;
            try
            {

                if (repositorioCuentas.Buscar(cuenta.NumeroCuenta)== null)
                {
                    mensaje = repositorioCuentas.Guardar(cuenta);
                    Actualizar();
                    return mensaje; //"Se guardaron los datos de manera exitosa";
                    // aqui no pasa nada
                }
                return mensaje; //"No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        private void Actualizar()
        {
            cuentas = repositorioCuentas.ConsultarTodos();
        }
        public List<Cuenta> Consultar()
        {
            return cuentas;
        }

        public Cuenta BuscarCuenta(double numCuenta)
        {
            foreach (var item in cuentas)
            {
                if (item.NumeroCuenta == numCuenta)
                {
                    return item;
                }

            }
            return null;

        }

        public string Eliminar(double numCuenta)
        {
            Cuenta cuenta = BuscarCuenta(numCuenta);
            if (cuenta == null)
            {
                return "cuenta no existe";
            }
            else
            {
                cuentas.Remove(cuenta);

                repositorioCuentas.Modificar_tmp(cuentas);
                return "cuenta eliminada";
            }
        }
        public string Modificar(Cuenta cuenta_New)
        {
            Cuenta cuenta_actual = BuscarCuenta(cuenta_New.NumeroCuenta);
            if (cuenta_actual == null)
            {
                return Guardar(cuenta_New);

            }
            else
            {
                cuenta_actual.NumeroCuenta = cuenta_New.NumeroCuenta;
                return repositorioCuentas.Modificar_tmp(cuentas);
            }


        }
        public void ConsultarnumCuentas(double numCuentas)
        {
            //try
            //{
            //    List<Cliente> clientes = repositorioClientes.FiltrarIdentificacion(identificacion);
            //    var response = new ClienteConsultaResponse(clientes);
            //    return response;
            //}
            //catch (Exception e)
            //{
            //    var response = new ClienteConsultaResponse("Error:" + e.Message);
            //    return response;
            //    //}
        }

        public class cuentaConsultaResponse
        {
            public List<Cuenta> Cuenta { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }
            public bool CuentaEncontrada { get; set; }
            public cuentaConsultaResponse(string message)
            {
                Error = true;
                Message = message;
                CuentaEncontrada = false;
            }
            public cuentaConsultaResponse(List<Cuenta> cuentas)
            {
                Cuenta = cuentas;
                Error = false;
                CuentaEncontrada = true;
            }
        }
    }
}
