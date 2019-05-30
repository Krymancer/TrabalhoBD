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
        
        public Connection(string user, string password)
        {
            this.user = user;
            this.password = password;
        }

        public MySqlConnection getConnection()
        {
            string myConnection = "datasource=localhost;port=3306;username=" + this.user + ";password=" + this.password;
            return new MySqlConnection(myConnection);
        }

    }
}
