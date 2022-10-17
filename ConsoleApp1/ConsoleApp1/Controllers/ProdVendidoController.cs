using master.Models;
using System.Data;
using System.Data.SqlClient;

namespace master.Controllers
{
    public class ProdVendidoController
    {
        public static List<Producto> ProdutoVendido(string nomDeUsuario)
        {
            var listaProductoVendido = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-97998SI";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT pr.* FROM Producto pr INNER JOIN ProductoVendido pv ON pr.Id = pv.IdProducto INNER JOIN Venta vnt ON vnt.Id = pv.IdVenta INNER JOIN Usuario us ON Us.Id = vnt.IdUsuario WHERE Us.NombreUsuario = @param;";

                var param = new SqlParameter();
                param.ParameterName = "param";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = nomDeUsuario;
                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pr = new Producto();

                    pr.Id = Convert.ToInt32(reader.GetValue(0));
                    pr.Descripciones = reader.GetValue(1).ToString();
                    pr.Costo = Convert.ToDouble(reader.GetValue(2));
                    pr.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    pr.Stock = Convert.ToInt32(reader.GetValue(4));
                    pr.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProductoVendido.Add(pr);

                }
                Console.WriteLine("Productos Vendidos por el usuario: {0}", nomDeUsuario);

                reader.Close();
             }
        return listaProductoVendido;
        }
    }
}
