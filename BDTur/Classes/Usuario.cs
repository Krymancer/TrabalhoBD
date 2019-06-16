using MySql.Data.MySqlClient;
using System;

namespace BDTur.Classes
{
    class Usuario
    {

        Connection userCon =  new Connection(Program.databaseUser,Program.databasePassword); 

        public int IdUser   { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AcessLevel  { get; set; }

        public Usuario(int idUser, string username, string password, int acessLevel)
        {
            this.IdUser = idUser;
            this.Username = username;
            this.Password = password;
            this.AcessLevel = acessLevel;
        }

        /// <summary>
        /// Atentica um usuario
        /// </summary>   
        public bool Autenticate()
        {
            MySqlConnection con = userCon.GetConnection();
            con.Open();
            string query = "SELECT `usuario`.`idUsuario`," +
                           "`usuario`.`username`," +
                           "`usuario`.`password`," +
                           "`usuario`.`tipoUsuario`" +
                           "FROM `equipe431447`.`usuario` where username=?username and password=?password ;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.Add(new MySqlParameter("username", this.Username));
            cmd.Parameters.Add(new MySqlParameter("password", this.Password));

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                reader.Read();
                this.IdUser = reader.GetInt32(0);
                this.AcessLevel = reader.GetInt32(3);
                Program.AcessLevel = this.AcessLevel;
                //Console.WriteLine(reader);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
