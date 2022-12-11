using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public int NumeroPaginas { get; set; }
        public string FechaPublicacion { get; set; }
        public string Edicion { get; set; }
        public List<object> Libros { get; set; }

        //PROPIEDADES DE NAVEGACION
        public ML.Autor Autor { get; set; }
        public ML.Editorial Editorial { get; set; }
        public ML.Genero Genero { get; set; }
    }
}
