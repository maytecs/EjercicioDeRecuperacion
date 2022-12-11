using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result(); //Instanciar result

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()) )
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;


                        //Agregar los parametros

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("NombreLibro", SqlDbType.VarChar);
                        collection[0].Value = libro.NombreLibro;
                        collection[1] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;
                        collection[2] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;
                        collection[3] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        collection[3].Value = libro.FechaPublicacion;
                        collection[4] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;
                        collection[5] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;
                        collection[6] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection); //Agregar al cmd los parametros de collection

                        cmd.Connection.Open(); //Abrir la conexion

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected>0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }//cierre de sql cmd 
                }//cierre de sql conection
            }//cierre del try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la informacion" + result.Ex;
                throw;
            }
            return result;
        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        DataTable librosTable = new DataTable(); //Instancia de clase de tipo DataTable
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //Adapta la funcion de retorno de sql --cmd envia todos los datos a SqlDataAdapter
                        sqlDataAdapter.Fill(librosTable); //llena la tabla con los datos de BD

                        if(librosTable.Rows.Count > 0)
                        {
                            result.ObjectS = new List<object>();

                            foreach(DataRow row in librosTable.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.NombreLibro = row[1].ToString();
                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString());
                                libro.Autor.NombreAutor = row[3].ToString();
                                libro.NumeroPaginas = int.Parse(row[4].ToString());
                                libro.FechaPublicacion = row[5].ToString();
                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                                libro.Editorial.NombreEditorial = row[7].ToString();
                                libro.Edicion = row[8].ToString();
                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.NombreGenero = row[10].ToString();

                                result.ObjectS.Add(libro);
                            }
                        }

                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la informacion" + result.Ex;
                throw;
            }


            return result;
        }


        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        DataTable librosTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(librosTable);

                        if(librosTable.Rows.Count > 0)
                        {
                            DataRow row = librosTable.Rows[0];
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.NombreLibro = row[1].ToString();
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[2].ToString());
                            libro.Autor.NombreAutor = row[3].ToString();
                            libro.NumeroPaginas = int.Parse(row[4].ToString());
                            libro.FechaPublicacion = row[5].ToString();
                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                            libro.Editorial.NombreEditorial = row[7].ToString();
                            libro.Edicion = row[8].ToString();
                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[9].ToString());
                            libro.Genero.NombreGenero = row[10].ToString();

                            result.Object =libro; //boxing almacenamos los valores en un objeto

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la informacion" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result(); //Instanciar result

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LubroUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;


                        //Agregar los parametros

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.VarChar);
                        collection[0].Value = libro.IdLibro;
                        collection[1] = new SqlParameter("NombreLibro", SqlDbType.VarChar);
                        collection[1].Value = libro.NombreLibro;
                        collection[2] = new SqlParameter("IdAutor", SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;
                        collection[3] = new SqlParameter("NumeroPaginas", SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;
                        collection[4] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        collection[4].Value = libro.FechaPublicacion;
                        collection[5] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;
                        collection[6] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;
                        collection[7] = new SqlParameter("IdGenero", SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection); //Agregar al cmd los parametros de collection

                        cmd.Connection.Open(); //Abrir la conexion

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }//cierre de sql cmd 
                }//cierre de sql conection
            }//cierre del try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la informacion" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result Delete(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DeleteLibro";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 0)
                        {
                            result.Message = "El dato se elimino correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar la informacion" + result.Ex;
            }
            return result;
        }
    }
}
