using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class PresentacionCuenta
    {

        public void MenuCuentas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* BANCO - MENU CUENTAS********************************");
                Console.WriteLine("*                                                                                  *");
                Console.WriteLine("*        1. Agregar Cuenta                                                         *");
                Console.WriteLine("*        2. Consultar                                                              *");
                Console.WriteLine("*        3. Retirar                                                                *");
                Console.WriteLine("*        4. Consignar                                                              *");
                Console.WriteLine("*        5. Eliminar Cuenta                                                        *");
                Console.WriteLine("*        6. volver ...                                                             *");
                Console.WriteLine("*                                                                                  *");
                Console.WriteLine("************************************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1: //agregar
                        MenuAgregar();
                        break;
                    case 2:
                        MenuConsultar();
                        break;
                    case 3:
                        //  Retirar();
                        break;
                    case 4:
                        //  Consignar();
                        break;
                    case 5:
                        //Environment.Exit(5);
                        MenuEliminar();
                        break;
                    case 6:
                        break;
                }
            } while (opcion != 6);
        }


        public void MenuAgregar()
        {

            Entidad.Cuenta cuenta = new Entidad.Cuenta();
            Logica.ServicioCuentas servico = new Logica.ServicioCuentas();
            Console.Clear();
            Console.Write("Numero cuenta : "); cuenta.NumeroCuenta =Convert.ToDouble( Console.ReadLine());
            Console.Write("saldo : "); cuenta.Saldo = Convert.ToDouble( Console.ReadLine());
            //Console.Write("Cliente: "); Console.Write(cuenta.cliente);
            Console.WriteLine(servico.Guardar(cuenta));
            Console.ReadKey();
        }
        public void MenuEliminar()
        {
            Entidad.Cuenta cuenta;
            double num_cuenta;
            Logica.ServicioCuentas servico = new Logica.ServicioCuentas();
            Console.Clear();

            Console.SetCursorPosition(8, 10); Console.Write("Num Cuenta : ");
            Console.SetCursorPosition(8, 12); Console.Write("Saldo : ");

            Console.SetCursorPosition(21, 10); num_cuenta =double.Parse( Console.ReadLine());

            cuenta = servico.BuscarCuenta(num_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.WriteLine("cuenta no existe");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(28, 12); Console.WriteLine(cuenta.NumeroCuenta);

            string op = string.Empty;
            Console.SetCursorPosition(8, 15); Console.WriteLine("desea eliniminar el cliente s/n ..");
            Console.SetCursorPosition(45, 15); op = Console.ReadLine();
            if (op.ToUpper() == "S")
            {
                Console.Write(servico.Eliminar(num_cuenta));

            }
            else
            {
                return ;
            }
            Console.ReadKey();
        }
        public void MenuConsultar()
        {
            Entidad.Cuenta cuenta = new Entidad.Cuenta();
            Logica.ServicioCuentas servico = new Logica.ServicioCuentas();
            int i = 0;
            Console.Clear();
            Console.SetCursorPosition(20, 8); Console.Write("Numero Cuenta");
            Console.SetCursorPosition(35, 8); Console.Write("Saldo");
            //Console.SetCursorPosition(38, 8); Console.Write("Cliente");

            foreach (var item in servico.Consultar())
            {
                i = i + 2;
                Console.SetCursorPosition(20, 8 + i); Console.Write(item.NumeroCuenta);
                Console.SetCursorPosition(35, 8 + i); Console.Write(item.Saldo);
                //Console.SetCursorPosition(35, 8 + i); Console.Write(item.cliente);
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

