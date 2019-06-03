using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Usuario
    {

        Classes.Connection userCon =  new Classes.Connection(Program.databaseUser,Program.databasePassword); 

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
            MySqlConnection con = userCon.getConnection();
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
            if (reader.HasRows)
            {
                Console.WriteLine(reader);
                //con.Close();
                return true;
            }
            else
            {
                Console.WriteLine(reader);
                //con.Close();
                return false;
            }
        }

    }
}
