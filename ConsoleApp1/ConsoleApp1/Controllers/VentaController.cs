using master.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace master.Controllers
{
    public static class VentaController
    {
        public static List<Venta> TraerVentas(int idUsuario2)
        {
            var ventas = new List<Venta>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-97998SI";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Venta vt INNER JOIN Usuario us ON us.Id = vt.IdUsuario WHERE us.Id = @idUsuario;";

                var param = new SqlParameter();
                param.ParameterName = "idUsuario";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = idUsuario2;
                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var vt = new Venta();

                    vt.Id = Convert.ToInt32(reader.GetValue(0));
                    vt.Comentarios = reader.GetValue(1).ToString();
                    vt.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    ventas.Add(vt);
                }
                Console.WriteLine("El usuario realizó las siguientes ventas: ");
                reader.Close();
            }

            return ventas;
        }
    }
}
