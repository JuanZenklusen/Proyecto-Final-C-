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

                //string NombreUsuario = String.Empty;

                //Console.WriteLine("Ingrese Nombre de Usuario: ");
                //NombreUsuario = Console.ReadLine();

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

                Console.WriteLine("Los usuarios son: \n");
                /*
                foreach (var us in listaUsuario)
                {
                    Console.WriteLine("Codigo de usuario: {0}", us.Id);
                    Console.WriteLine("Nombre: {0}", us.Nombre);
                    Console.WriteLine("Apellido: {0}", us.Apellido);
                    Console.WriteLine("NombreUsuario: {0}", us.NombreUsuario);
                    Console.WriteLine("Contraseña: {0}", us.Contraseña);
                    Console.WriteLine("Mail: {0}", us.Mail);
                    Console.WriteLine("--------------\n");

                }*/

               
                
                reader.Close();
                
            }
            return listaUsuario;
        }


    }
}
