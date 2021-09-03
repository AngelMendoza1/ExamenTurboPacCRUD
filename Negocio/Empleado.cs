using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Negocio
{
    public class Empleado
    {
        public static Entidad.Result Agregar(Entidad.Empleado empleado)
        {
            Entidad.Result result = new Entidad.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand commands = new SqlCommand())
                    {
                       
                        commands.CommandText = "EmpleadoAgregar";
                        commands.Connection = context;
                        commands.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[5];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = empleado.Nombre;

                        collection[1] = new SqlParameter("APellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = empleado.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = empleado.ApellidoMaterno;

                        collection[3] = new SqlParameter("Activo", SqlDbType.Bit);
                        collection[3].Value = true;

                        collection[4] = new SqlParameter("Salario", SqlDbType.Decimal);
                        collection[4].Value = empleado.Salario;

                        commands.Parameters.AddRange(collection);

                      

                        int RowsAffected = commands.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un erro al insertar con sp";
                        
                        }


                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static Entidad.Result Registros()
        {
            Entidad.Result result = new Entidad.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand commands = new SqlCommand())
                    {
                        commands.CommandText = "EmpleadoConsultas";
                        commands.Connection = context;
                        commands.CommandType = CommandType.StoredProcedure;
                        context.Open();

                        SqlDataAdapter da = new SqlDataAdapter(commands); 
                        DataTable tEmpleados = new DataTable();
                        da.Fill(tEmpleados);
                        if (tEmpleados.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tEmpleados.Rows)
                            {
                                Entidad.Empleado empleado = new Entidad.Empleado();
                                empleado.idEmpleado = int.Parse(row[0].ToString());
                                empleado.Nombre = row[1].ToString();
                                empleado.ApellidoPaterno = row[2].ToString();
                                empleado.ApellidoMaterno = row[3].ToString();
                                empleado.Activo = bool.Parse(row[4].ToString());
                                empleado.Salario = decimal.Parse(row[5].ToString());
                                result.Objects.Add(empleado);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No Hay Empleados";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Entidad.Result Actualizar(Entidad.Empleado empleado)
        {
            Entidad.Result result = new Entidad.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand commands = new SqlCommand())
                    {

                        commands.CommandText = "EmpleadoActualizar";
                        commands.Connection = context;
                        commands.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("IdEmpleado", SqlDbType.Int);
                        collection[0].Value = empleado.idEmpleado;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = empleado.Nombre;

                        collection[2] = new SqlParameter("APellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = empleado.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = empleado.ApellidoMaterno;

                        collection[4] = new SqlParameter("Activo", SqlDbType.Bit);
                        collection[4].Value = empleado.Activo;

                        collection[5] = new SqlParameter("Salario", SqlDbType.Decimal);
                        collection[5].Value = empleado.Salario;

                        commands.Parameters.AddRange(collection);



                        int RowsAffected = commands.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un erro al insertar con sp";

                        }


                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Entidad.Result Registro(int IdEmpleado)
        {
            Entidad.Result result = new Entidad.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand commands = new SqlCommand())
                    {
                        commands.CommandText = "EmpleadoConsulta";
                        commands.Connection = context;
                        commands.CommandType = CommandType.StoredProcedure;
                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdEmpleado", SqlDbType.Int);
                        collection[0].Value = IdEmpleado;
                        commands.Parameters.AddRange(collection);

                        SqlDataAdapter da = new SqlDataAdapter(commands);
                        DataTable TablaEmpleado = new DataTable();
                        da.Fill(TablaEmpleado);
                        if (TablaEmpleado.Rows.Count > 0)
                        {
                            DataRow row = TablaEmpleado.Rows[0];

                            Entidad.Empleado empleado = new Entidad.Empleado();
                            empleado.idEmpleado = int.Parse(row[0].ToString());
                            empleado.Nombre = row[1].ToString();
                            empleado.ApellidoPaterno = row[2].ToString();
                            empleado.ApellidoMaterno = row[3].ToString();
                            empleado.Activo = bool.Parse(row[4].ToString());
                            empleado.Salario = decimal.Parse(row[5].ToString());

                            result.Object = empleado; 
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se encontro el Empleado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }


        public static Entidad.Result ActualizarEstatus(Entidad.Empleado empleado)
        {
            
            Entidad.Result result = new Entidad.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand commands = new SqlCommand())
                    {

                        commands.CommandText = "ActivarDesactivar";
                        commands.Connection = context;
                        commands.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdEmpleado", SqlDbType.Int);
                        collection[0].Value = empleado.idEmpleado;

                       
                  
                        collection[1] = new SqlParameter("Activo", SqlDbType.Bit);
                        collection[1].Value = empleado.Activo;

          
                        commands.Parameters.AddRange(collection);



                        int RowsAffected = commands.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un erro al insertar con sp";

                        }


                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


    }
}
