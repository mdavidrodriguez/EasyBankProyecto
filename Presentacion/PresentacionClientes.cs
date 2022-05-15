using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class PresentacionClientes
    {
        public void MenuClientes()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* BANCO - MENU CLIENTES********************************");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("*        1. Agregar Cliente                                                  *");
                Console.WriteLine("*        2. Consultar Cliente                                                 *");
                Console.WriteLine("*        3. Modificar                                                   *");
                Console.WriteLine("*        4. Eliminar                                                 *");
                Console.WriteLine("*        5. volver ...                                                     *");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("***********************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1: // agregar
                        MenuAgregar();
                        break;
                    case 2:
                       MenuConsultar();
                        break;
                    case 3:
                          
                        break;
                    case 4:
                        MenuEliminar(); 
                        break;
                    case 5:
                        //Environment.Exit(5);
                        break;
                }
            } while (opcion != 5);

        }

        public void MenuAgregar()
        {

            Entidad.Cliente cliente = new Entidad.Cliente();  
            Logica.ServicioClientes servico = new Logica.ServicioClientes();    
            Console.Clear();
            Console.Write("id Cliente : "); cliente.IdCliente = Console.ReadLine();
            Console.Write("nombre cliente : "); cliente.Nombre = Console.ReadLine();   
            Console.WriteLine(servico.Guardar(cliente));
            Console.ReadKey();
        }
        public void MenuEliminar()
        {
            Entidad.Cliente cliente;
            string id_cliente;
            Logica.ServicioClientes servico = new Logica.ServicioClientes();
            Console.Clear();
            
            Console.SetCursorPosition(8,10); Console.Write("id Cliente : ");
            Console.SetCursorPosition(8, 12); Console.Write("nombre cliente : ");

            Console.SetCursorPosition(21, 10); id_cliente = Console.ReadLine();

            cliente = servico.BuscarID(id_cliente);
            if (cliente == null)
            {
                Console.Clear();
                Console.WriteLine("cliente no existe");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(28, 12); Console.WriteLine(cliente.Nombre);

            string op= string.Empty;
            Console.SetCursorPosition(8, 15); Console.WriteLine("desea eliniminar el cliente s/n ..");
            Console.SetCursorPosition(45, 15); op= Console.ReadLine();
            if (op.ToUpper()=="S")
            {
               Console.Write(servico.Eliminar(id_cliente));

            }
            else  {
                return;
            }
            Console.ReadKey();
        }
        public void MenuConsultar()
        {
            Entidad.Cliente cliente = new Entidad.Cliente();
            Logica.ServicioClientes servico = new Logica.ServicioClientes();
            int i=0;
            Console.Clear();
            Console.SetCursorPosition(20, 8); Console.Write("IdCliente");
            Console.SetCursorPosition(35, 8); Console.Write("Nombre");
            foreach (var item in servico.Consultar())
            {
                i = i + 2;
                Console.SetCursorPosition(20,8+i); Console.Write(item.IdCliente);
                Console.SetCursorPosition(35,8+i); Console.Write(item.Nombre);
            }
            
            Console.ReadKey();
        }
        public void MenuModificar()
        {
            
        }
        public void prueba(string valor)
        {
            // saldo = saldo + valor;

            //crear
            //    1. buscar cliente (buscarid(id) --> servicio de cliente)
            //    2. calculamos el numerode cuenta --> digitamos --> servicio cuenta
            //    3. guardar --> servico de cuenta
            //Console.WriteLine(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + valor);

        }
    }
}
