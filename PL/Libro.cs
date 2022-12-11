using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingrese los datos del libro\n");
            Console.WriteLine("Ingrese el nombre del lirbro");
            libro.NombreLibro=Console.ReadLine();
            Console.WriteLine("Ingrese el ID del autor");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de publicacion dd-MM-yyyy");
            libro.FechaPublicacion = Console.ReadLine();
            Console.WriteLine("Ingrese el ID de la editorial");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la edición del libro");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del genero del libro");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);

            if(result.Correct)
            {
                Console.WriteLine("El libro se agrego correctamente");
            }

        }

        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                foreach (ML.Libro libro in result.ObjectS)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Id del libro:" + libro.IdLibro);
                    Console.WriteLine("Nombre:" + libro.NombreLibro);
                    Console.WriteLine("Autor" + libro.Autor.IdAutor);
                    Console.WriteLine("Nombre del autor:" + libro.Autor.NombreAutor);
                    Console.WriteLine("Numero de paginas:" + libro.NumeroPaginas);
                    Console.WriteLine("Fecha de publicacion:" + libro.FechaPublicacion);
                    Console.WriteLine("Editorial:" + libro.Editorial.IdEditorial);
                    Console.WriteLine("Nombre de la editorial:" + libro.Editorial.NombreEditorial);
                    Console.WriteLine("Edicion:" + libro.Edicion);
                    Console.WriteLine("Genero:" + libro.Genero.IdGenero);
                    Console.WriteLine("Genero del libro:" + libro.Genero.NombreGenero);
                    Console.WriteLine("--------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Ocirrio un error");
            }
        }

        public static void GetById()
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("Ingrese el ID del libro que desea consultar");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(libro.IdLibro);

                if(result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Id del libro:" + libro.IdLibro);
                    Console.WriteLine("Nombre:" + libro.NombreLibro);
                    Console.WriteLine("Autor" + libro.Autor.IdAutor);
                    Console.WriteLine("Nombre del autor:" + libro.Autor.NombreAutor);
                    Console.WriteLine("Numero de paginas:" + libro.NumeroPaginas);
                    Console.WriteLine("Fecha de publicacion:" + libro.FechaPublicacion);
                    Console.WriteLine("Editorial:" + libro.Editorial.IdEditorial);
                    Console.WriteLine("Nombre de la editorial:" + libro.Editorial.NombreEditorial);
                    Console.WriteLine("Edicion:" + libro.Edicion);
                    Console.WriteLine("Genero:" + libro.Genero.IdGenero);
                    Console.WriteLine("Genero del libro:" + libro.Genero.NombreGenero);
                    Console.WriteLine("--------------------------------");

                }
                else
                {
                Console.WriteLine("Ocurrio un error al cargar la informacion" + result.Ex);
                }
        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingrese los datos del libro a actualizar\n");
            Console.WriteLine("Ingrese el ID del lirbro");
            libro.IdLibro = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del lirbro");
            libro.NombreLibro = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del autor");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de publicacion dd-MM-yyyy");
            libro.FechaPublicacion = Console.ReadLine();
            Console.WriteLine("Ingrese el ID de la editorial");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la edición del libro");
            libro.Edicion = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del genero del libro");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Update(libro);

            if (result.Correct)
            {
                Console.WriteLine("El libro se agrego correctamente");
            }

        }

        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("Ingrese el ID del libro a eliminar");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Delete(libro);
            if (result.Correct)
            {
                Console.WriteLine("El libro se elimino correctamente");
            }
        }
    }
}
