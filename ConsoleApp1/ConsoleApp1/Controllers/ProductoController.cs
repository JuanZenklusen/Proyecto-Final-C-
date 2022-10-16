using System.Data;
using System.Data.SqlClient;
using master.Models;

namespace master.Controllers
{
    public static class ProductoController
    {
        public static List<Producto> TraerProducto(int idUsuario)
        {
            var listaProducto = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-97998SI";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @idUs;";

                var param = new SqlParameter();
                param.ParameterName = "idUs";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = idUsuario;
                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prod = new Producto();

                    prod.Id = Convert.ToInt32(reader.GetValue(0));
                    prod.Descripciones = reader.GetValue(1).ToString();
                    prod.Costo = Convert.ToDouble(reader.GetValue(2));
                    prod.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    prod.Stock = Convert.ToInt32(reader.GetValue(4));
                    prod.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProducto.Add(prod);
                }

                Console.WriteLine("Productos cargados por el usuario: ");
                

                reader.Close();

            }
            return listaProducto;
        }

    }
}
