﻿using System;
using System.Collections.Generic;
using System.IO; // aqui archivos
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class RepositorioClientes
    {
        string ruta = "Clientes.txt";// ruta donde se guarda el archivo
        public string Guardar(Cliente cliente)
        {
            try
            {
                //FileStream archivo = new FileStream(ruta, FileMode.Append);
                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(cliente.Linea());
                escritor.Close();
                //archivo.Close();
                return "Se guardaron los datos";
            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }
            
        }

        public string Modificar(List<Entidad.Cliente> clientes) //actualiza el contenido del archivo
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);// sobreescribe
                foreach (var item in clientes)
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
        public string Modificar_tmp(List<Entidad.Cliente> clientes) //actualiza el contenido del archivo
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt");// sobreescribe
                foreach (var item in clientes)
                {
                    escritor.WriteLine(item.Linea());
                    //close
                }

                escritor.Close();
                
                File.Delete(ruta);  // elimina
                
                File.Move("tmp.txt", ruta);// renombrar
                
                return "Se modificaron los datos los datos";

                //
                //
            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }
        public Cliente Buscar(string identificacion)
        {
            List<Cliente> clientes = ConsultarTodos();
            foreach (var item in clientes)
            {
                if (Encontrado(item.IdCliente, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string IdClienteRegistrado, string IdClienteBuscado)
        {
            return IdClienteRegistrado == IdClienteBuscado;
        }

        public List<Cliente> ConsultarTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
           // FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea =lector.ReadLine();
                Cliente cliente = new Cliente(linea);       
                clientes.Add(cliente);
            }
            lector.Close();
            //archivo.Close();
            return clientes;
        }
        

        public void Eliminar(String identificacion)
        {
            List<Cliente> clienetes = new List<Cliente>();
            clienetes = ConsultarTodos();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in clienetes)
            {
                if (!Encontrado(item.IdCliente, identificacion))
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar_old(Cliente clientefirst, Cliente clienteNew)
        {
            List<Cliente> clientes; // = new List<Cliente>();
            clientes = ConsultarTodos();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in clientes)
            {
                if (!Encontrado(item.IdCliente, clientefirst.IdCliente))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(clienteNew);
                }
            }
        }

        public List<Cliente> FiltrarIdentificacion(string identificacion)
        {
            return ConsultarTodos().Where(p => p.IdCliente.Equals(identificacion)).ToList();
        }

    }
}

