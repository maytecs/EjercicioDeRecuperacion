using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc;

            Console.WriteLine("Ingrese la opcion que desea realizar");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Mostrar todos los registros");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Actualizar");
            Console.WriteLine("5. Eliminar");
            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    Libro.Add();
                    break;
                case 2:
                    Libro.GetAll();
                    Console.ReadKey();
                    break;
                case 3:
                    Libro.GetById();
                    Console.ReadKey();
                    break;
                case 4:
                    Libro.Update();
                    Console.ReadKey();
                    break;
                case 5:
                    Libro.Delete();
                    Console.ReadKey();
                    break;
                case 6:
                    Console.WriteLine("Opcion no valida");
                    break;

            }
        }
    }
}
