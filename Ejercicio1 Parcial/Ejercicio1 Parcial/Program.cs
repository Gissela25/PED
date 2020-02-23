using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Parcial
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Lista list = new Lista();
            bool flag = true;
            
            while(flag)
            {
                Console.Clear();
                Console.WriteLine("Elige una opcion");
                Console.WriteLine("\n");
                Console.WriteLine("1) Insertar al incio");
                Console.WriteLine("2) Eliminar segun nombre");
                Console.WriteLine("3) Mostrar lista");
                Console.WriteLine("4) Longitud de lista");
                Console.WriteLine("5) Salir");

                switch(Console.ReadLine())
                {
                    case "1":
                        bool v1 = false;
                        string n1 = null;
                        while(!(v1))
                        {
                            try
                            {
                                Console.WriteLine("Ingresar el elemento");
                                n1 = Console.ReadLine();
                                v1 = true;
                               
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Ingrese un valor correcto");
                            }
                        }
                        list.InsertarI(n1);
                        break;

                    case "2":
                        bool v2 = false;
                        string n2 = null;
                        while(!(v2))
                        {
                            try
                            {
                                Console.WriteLine("Ingresar el elemento que desea eliminar");
                                n2 = Console.ReadLine();
                                v2 = true;
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Ingresar un valor correcto");
                            }
                        }
                        list.Eliminar(n2);
                        break;

                    case "3":
                        list.mostrar();
                        break;

                    case "4":
                        Console.WriteLine("Longutud de la lista:" + list.Size());
                        break;

                    case "5":
                        Console.Clear();
                        flag = false;
                        break;
                }
                Console.ReadKey();

            }
        }
    }
}
