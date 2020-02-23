using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Parcial
{
    class Lista
    {
        public Nodo inicio;
        public int size = 0;
        public Lista()
        {
            inicio = null;
        }

        public void InsertarI(string item)
        {
            Nodo auxiliar = new Nodo();
            auxiliar.datos = item;
            auxiliar.siguiente = null;

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                Nodo puntero;
                puntero = inicio;
                inicio = auxiliar;
                auxiliar.siguiente = puntero;
            }
            size++;
        }
        public void mostrar()
        {
            if (inicio == null)
            {

                Console.WriteLine("La lista esta vacia");

            }
            else
            {
                Nodo puntero;
                puntero = inicio;
                Console.Write("{0}->\t", puntero.datos);
                while (puntero.siguiente != null)
                {
                    puntero = puntero.siguiente;
                    Console.Write("{0} -> \t", puntero.datos);
                }

            }
            Console.WriteLine();
        }
        public void Eliminar(string n)
        {
            if(inicio == null)
            {
                Console.WriteLine("La lista esta vacia");

            }
            else
            {
                Nodo puntero = inicio;
                Nodo punteroant, punteropost;
                punteroant = inicio;
                punteropost = inicio;
                Console.WriteLine("Ingresar el valor que desea eliminar");
                n = Console.ReadLine();
                if(n == Convert.ToString(puntero.datos))
                {
                    inicio = inicio.siguiente;
                    
                }
            }
        }
        public int Size()
        {
            return size;
        }
    }
}
