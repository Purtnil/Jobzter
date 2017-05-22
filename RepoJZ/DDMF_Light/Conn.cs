using System;
using System.Data.SqlClient;

namespace RepoJZ
{
    public static class Conn
    {
        
        public static SqlConnection GetCon()
        {
            SqlConnection con = new SqlConnection("server=194.255.108.50;database=dbJobzter;uid=Jobzter;pwd=eGSeDQL3;MultipleActiveResultSets=True");
            return con;
        }

        public static SqlConnection CreateConnection()
        {
            var cn = GetCon();
            cn.Open();
            return cn;
        }
        /// <summary>
        /// Bruges til at tjekke om der er forbindelse til databasen
        /// C#: var t = RepoAM.Conn.Check();
        /// Razor: @RepoAM.Conn.Check()
        /// </summary>
        /// <returns>Retunere true eller false</returns>
        public static bool Check()
        {
            bool t = true;
            var cn = GetCon();

            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                t = false;
            }

            return t;
        }
    }

}
