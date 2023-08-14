using System.Data.SqlClient;

class Program
{
    static SqlConnection GetConnection()
    {
        var conStr = "Data Source=SEYMA-BASNAK\\SQLEXPRESS;Initial Catalog=KrakerHR2;Integrated Security=True;";
        return new SqlConnection(conStr);
    }
    static SqlCommand GetCommand(string cmdText)
    {
        var con = GetConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = cmdText;
        return cmd;
    }
    static void Main(string[] args)
    {
        Ekle();
        var cmd = GetCommand("select count(*) from Calisan");

        cmd.Connection.Open();
        var kacKisi = cmd.ExecuteScalar();
        cmd.Connection.Close();

        Console.WriteLine("--------------------");
        Console.WriteLine(kacKisi + " var tabloda");
        Listele();
    }

    private static void Ekle()
    {
        var adi = "Lizge";
        var soyadi = "Diri";

        //Console.Write("Adi      = ");
        //adi=Console.ReadLine();

        //Console.Write("Soyadi	= ");
        //soyadi=Console.ReadLine();

        var cmdText = $"insert into Calisan(Adi,Soyadi,DepartmanId) values ('{adi}','{soyadi}',1)";
        Console.WriteLine(cmdText);
        var cmd1 = GetCommand(cmdText);
        cmd1.Connection.Open();
        cmd1.ExecuteNonQuery();
        cmd1.Connection.Close();
    }

    private static void Listele()
    {
        var cmd = GetCommand("select * from calisan");

        cmd.Connection.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Console.WriteLine(dr["Adi"]);
        }
        cmd.Connection.Close();
    }

    private static void CmdConnectionSample()
    {
        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = GetConnection();
        cmd1.Connection.Open();

        var con = GetConnection();
        SqlCommand cmd2 = new SqlCommand();
        cmd2.Connection = con;
        con.Open();
        cmd2.Connection.Open();
    }
}
