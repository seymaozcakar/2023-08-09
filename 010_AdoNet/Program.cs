
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        var conStr = "Data Source=SEYMA-BASNAK\\SQLEXPRESS;Initial Catalog=KrakerHR2;Integrated Security=True; ";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = conStr;

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select Id,Adi,upper(Adi) as YeniAdi from Departman";
        

        Console.WriteLine(conStr);

        con.Open();
        Console.WriteLine("Bağlantı açıldı");
        Console.WriteLine("--------------------------");

        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read()) 
        {
            Console.WriteLine(dr["ID"]+" - "+dr["Adi"]+" - " + dr["YeniAdi"]);
        }

        con.Close();
        Console.WriteLine("---------------------------");
        Console.WriteLine("Bağlantı kapandı");

    }
}
