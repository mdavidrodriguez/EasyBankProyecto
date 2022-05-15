using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.IO; // aqui archivos

namespace Datos
{
    public class RepositorioCuentas
    {
        string ruta = "Cuentas.txt";// ruta donde se guarda el archivo
        public string Guardar(Cuenta cuenta)
        {
            try
            {
                //FileStream archivo = new FileStream(ruta, FileMode.Append);
                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(cuenta.Linea());
                escritor.Close();
                //archivo.Close();
                return "Se guardaron los datos";
            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }

        public string Modificar(List<Entidad.Cuenta> cuentas) //actualiza el contenido del archivo
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);// sobreescribe
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.Linea());
                    //close
                }

                escritor.Close();

                return "Se modificaron los datos los datos";

                //File.Delete(ruta);  // elimina
                //File.Move("tmp", ruta);// renombrar
            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }
        public string Modificar_tmp(List<Entidad.Cuenta> cuentas) //actualiza el contenido del archivo
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp2.txt");// sobreescribe
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.Linea());
                    //close
                }

                escritor.Close();

                File.Delete(ruta);  // elimina

                File.Move("tmp2.txt", ruta);// renombrar

                return "Se modificaron los datos los datos";

                //
                //
            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }
        public Cuenta Buscar(double numCuenta)
        {
            List<Cuenta> cuentas = ConsultarTodos();
            foreach (var item in cuentas)
            {
                if (Encontrado(item.NumeroCuenta,numCuenta))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(double numCuentaRegistrado, double numCuentaBuscado)
        {
            return numCuentaRegistrado == numCuentaBuscado;
        }

        public List<Cuenta> ConsultarTodos()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            // FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea = lector.ReadLine();
                Cuenta cuenta = new Cuenta(linea);
                cuentas.Add(cuenta);
            }
            lector.Close();
            //archivo.Close();
            return cuentas;
        }


        public void Eliminar(double numcuenta)
        {
            List<Cuenta> cuentass = new List<Cuenta>();
            cuentass = ConsultarTodos();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in cuentass)
            {
                if (!Encontrado(item.NumeroCuenta,numcuenta))
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar_old(Cuenta cuentafirst, Cuenta cuentaNew)
        {
            List<Cuenta> cuentas; // = new List<Cliente>();
            cuentas = ConsultarTodos();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in cuentas)
            {
                if (!Encontrado(item.NumeroCuenta, cuentafirst.NumeroCuenta))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(cuentaNew);
                }
            }
        }

        public List<Cuenta> FiltrarIdentificacion(double numcuenta)
        {
            return ConsultarTodos().Where(p => p.NumeroCuenta.Equals(numcuenta)).ToList();
        }

    }
}

