using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using master.Models;

namespace master.UsuarioController
{
    public static class UsuarioController
    {
        public static List<Usuario> TraerUsuario(string NombreUsuario)
        {
            var listaUsuario = new List<Usuario>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-97998SI";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nomUsu";

                var param = new SqlParameter();
                param.ParameterName = "nomUsu";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = NombreUsuario;
                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var us = new Usuario();

                    us.Id = Convert.ToInt32(reader.GetValue(0));
                    us.Nombre = reader.GetValue(1).ToString();
                    us.Apellido = reader.GetValue(2).ToString();
                    us.NombreUsuario = reader.GetValue(3).ToString();
                    us.Contraseña = reader.GetValue(4).ToString();
                    us.Mail = reader.GetValue(5).ToString();

                    listaUsuario.Add(us);
                }
                reader.Close();
                
            }
            return listaUsuario;
        }


    }
}
