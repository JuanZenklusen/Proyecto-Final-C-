using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {

        SqlConnectionStringBuilder conecctionbuilder = new();
        conecctionbuilder.DataSource = "DESKTOP-97998SI";
        conecctionbuilder.InitialCatalog = "SistemaGestion";
        conecctionbuilder.IntegratedSecurity = true;
        var cs = conecctionbuilder.ConnectionString;

     
    }
}