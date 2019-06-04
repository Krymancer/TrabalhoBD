using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace BDTur.Classes
{
    class Connection
    {

        private string user;
        private string password;

        /// <summary>
        /// Construtor da calsse Connection.
        /// </summary>
        /// <param name="user"> Usuario do Banco de dados</param>
        /// <param name="password"> Senha do Banco de dados</param>
        public Connection(string user, string password)
        {
            this.user = user;
            this.password = password;
        }

        /// <summary>
        /// Retorna uma conexão MySQL
        /// </summary>
        public MySqlConnection GetConnection()
        {
            string myConnection = "datasource=localhost;port=3306;username=" + this.user + ";password=" + this.password;
            return new MySqlConnection(myConnection);
        }

        public MySqlDataAdapter cidadesAdapter()
        {
            try
            {
                MySqlConnection con = GetConnection();
                con.Open();
                MySqlCommand cmd = 
                    new MySqlCommand(
                        "SELECT `cidade`.`idCidade`," +
                        "`cidade`.`nome`,`cidade`.`estado`," +
                        "`cidade`.`populacao` FROM `equipe431447`.`cidade` ORDER BY `nome`;", con);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                con.Close();
                return adapter;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }
    }
}
