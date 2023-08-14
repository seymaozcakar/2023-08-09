using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static SqlConnection GetConnection()
    {
        var conStr = "Data Source=SEYMA-BASNAK\\SQLEXPRESS;Initial Catalog=KrakerHR2;Integrated Security=True; ";
        SqlConnection con = new SqlConnection(conStr);
        //con.ConnectionString = conStr;
        return con;
    }
    static void Main(string[] args)
    {
        var con = GetConnection();
        SqlCommand cmd = new SqlCommand("select * from Departman", con);

        try
        {
            Console.WriteLine("DB Connection open");
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["Adi"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("hata oldu");
        }
        finally
        {
            con.Close();
            Console.WriteLine("DB Connection close");
        }


    }
}
