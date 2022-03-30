using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_prospecto.Models
{
    public class GestorProspectos
    {
        public List<Prospectos> GetProspectos()
        {
            List<Prospectos> lista = new List<Prospectos>();
            string strConn = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Prospectos_All";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string primer_apellido = dr.GetString(2).Trim();
                    string segundo_apellido = dr.GetString(3).Trim();
                    string calle = dr.GetString(4).Trim();
                    string numero = dr.GetString(5).Trim();
                    string colonia = dr.GetString(6).Trim();
                    string cp = dr.GetString(7).Trim();
                    string telefono = dr.GetString(8).Trim();
                    string rfc = dr.GetString(9).Trim();
                    string observaciones = dr.GetString(10).Trim();
                    int status = dr.GetInt32(11);

                    Prospectos prospecto = new Prospectos(id, nombre, primer_apellido, segundo_apellido, calle, numero, colonia, cp, telefono, rfc, status, observaciones);
                    lista.Add(prospecto);

                }
                dr.Close();
                conn.Close();
            }
            return lista;
        }
        public bool addProspecto(Prospectos prospecto)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Prospectos_Add";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", prospecto.nombre);
                cmd.Parameters.AddWithValue("@primer_apellido", prospecto.primer_apellido);
                cmd.Parameters.AddWithValue("@segundo_apellido", prospecto.segundo_apellido);
                cmd.Parameters.AddWithValue("@calle", prospecto.calle);
                cmd.Parameters.AddWithValue("@numero", prospecto.numero);
                cmd.Parameters.AddWithValue("@colonia", prospecto.colonia);
                cmd.Parameters.AddWithValue("@cp", prospecto.cp);
                cmd.Parameters.AddWithValue("@telefono", prospecto.telefono);
                cmd.Parameters.AddWithValue("@rfc", prospecto.rfc);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }

        public bool AceptarProspecto(int id, string observaciones)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Prospectos_Aceptar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@observaciones", observaciones);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }

        public bool RechazarProspecto(int id, string observaciones)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Prospectos_Rechazar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@observaciones", observaciones);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }

    }
}