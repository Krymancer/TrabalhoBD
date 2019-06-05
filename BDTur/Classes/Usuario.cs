using MySql.Data.MySqlClient;
using System;

namespace BDTur.Classes
{
    class Usuario
    {

        Connection userCon =  new Connection(Program.databaseUser,Program.databasePassword); 

        int idUser   { get; set; }
        string username { get; set; }
        string password { get; set; }
        int acessLevel  { get; set; }

        public Usuario(int idUser, string username, string password, int acessLevel)
        {
            this.idUser = idUser;
            this.username = username;
            this.password = password;
            this.acessLevel = acessLevel;
        }


        public bool autenticate()
        {
            MySqlConnection con = userCon.GetConnection();
            con.Open();
            string query = "SELECT `usuario`.`idUsuario`," +
                           "`usuario`.`username`," +
                           "`usuario`.`password`," +
                           "`usuario`.`tipoUsuario`" +
                           "FROM `equipe431447`.`usuario` where username=?username and password=?password ;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.Add(new MySqlParameter("username", this.username));
            cmd.Parameters.Add(new MySqlParameter("password", this.password));

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                Console.WriteLine(reader);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
