using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
       
            [HttpGet]
            public ActionResult GetAll()
            {
                ML.Result result = BL.Libro.GetAllEF();
                ML.Libro libro = new ML.Libro();
                if (result.Correct)
                {
                    libro.Libros = result.ObjectS;
                }
                else
                {
                    ViewBag.Message = "Error al cargar la informacion";
                }


                return View(libro);
            }

            [HttpGet]
            public ActionResult Form(int? IdLibro) //se usa el int? para que acepte valores null
            {

            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            ML.Result resultAutor = BL.Autor.GetAll();
            ML.Result resultEditorial = BL.Editorial.GetAll();
            ML.Result resultGenero = BL.Genero.GetAll();

            if (IdLibro == null)
                {

                libro.Autor.Autores = resultAutor.ObjectS;
                libro.Editorial.Editoriales = resultEditorial.ObjectS;
                libro.Genero.Generos = resultGenero.ObjectS;
                
                return View(libro);
            }

                else
                {
                    ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);

                    //ML.Libro libro = new ML.Libro();

                    if (result.Correct)
                    {
                        //Se tiene que hacer un unboxing del objeto que nos trajo el metodo de GEYBYID
                        libro = (ML.Libro)result.Object; //Se usa el object porque solo es 1 objeto 

                        libro.Autor.Autores = resultAutor.ObjectS;
                        libro.Editorial.Editoriales = resultEditorial.ObjectS;
                        libro.Genero.Generos = resultGenero.ObjectS;
                }
                    else
                    {
                        ViewBag.Message = "Error al cargar la informacion";
                    }
                    return View(libro);
                }
            }

            [HttpPost]
            public ActionResult Form(ML.Libro libro) //se usa el int? para que acepte valores null
            {
                //ML.Usuario usuario = new ML.Usuario();

                if (libro.IdLibro == 0)
                {
                    ML.Result result = BL.Libro.AddEF(libro);
                    if (result.Correct)
                    {
                        ViewBag.Message = result.Message;
                    }
                    else
                    {
                        ViewBag.Message = "Error:" + result.Message;
                    }

                }

                else
                {
                    ML.Result result = BL.Libro.UpdateEF(libro);

                    if (result.Correct)
                    {
                        ViewBag.Message = result.Message;
                    }
                    else
                    {
                        ViewBag.Message = "Error: " + result.Message;
                    }
                }

                return PartialView("Modal");
            }

            public ActionResult Delete(ML.Libro libro)
            {
                ML.Result result = BL.Libro.DelateEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error:" + result.Message;
                }
                return PartialView("Modal");
            }


            //return View();
        
    }
}