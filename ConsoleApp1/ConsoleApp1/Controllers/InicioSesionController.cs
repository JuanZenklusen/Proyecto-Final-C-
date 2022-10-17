using master.Models;
using System.Data.SqlClient;
using System.Data;

namespace master.Controllers
{
    public class InicioSesionController
    {
        public static Usuario InicioSesion(string nombreDeUsuario, string contraseña)
        {
            var inicioSes = new Usuario();
            
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-97998SI";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @param1 AND Contraseña = @param2;";

                var param1 = new SqlParameter();
                param1.ParameterName = "param1";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = nombreDeUsuario;
                cmd.Parameters.Add(param1);

                var param2 = new SqlParameter();
                param2.ParameterName = "param2";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Value = contraseña;
                cmd.Parameters.Add(param2);

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        inicioSes.Id = Convert.ToInt32(reader.GetValue(0));
                        inicioSes.Nombre = reader.GetValue(1).ToString();
                        inicioSes.Apellido = reader.GetValue(2).ToString();
                        inicioSes.NombreUsuario = reader.GetValue(3).ToString();
                        inicioSes.Contraseña = reader.GetValue(4).ToString();
                        inicioSes.Mail = reader.GetValue(5).ToString();
                    }
                }
                else
                {
                    inicioSes = new Usuario();
                }

                reader.Close();
            }

            return inicioSes;
        }
    }
}
