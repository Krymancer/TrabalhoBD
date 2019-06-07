using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class DAL
    {
        private MySqlConnection createConnection()
        {
            Classes.Connection connection = new Classes.Connection(Program.databaseUser, Program.databasePassword);
            MySqlConnection con = connection.GetConnection();
            return con;
        }
        /// <summary>
        /// Retorna o resultado de uma consulta paa o banco de dados em um DataAdapter.
        /// </summary>
        /// <param name="query"> Consulta que sera feita ao Banco de Dados</param>
        private MySqlDataAdapter fetchResultFromQuery(string query)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd =
                    new MySqlCommand(query, con);
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
        /* Adapters para popular os DataGridViews */
        public  MySqlDataAdapter cidadeAdapter()
        {
            string query = "SELECT `cidade`.`idCidade`," +
                             "`cidade`.`nome`,`cidade`.`estado`," +
                             "`cidade`.`populacao` FROM `equipe431447`.`cidade` ORDER BY `nome`;";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter hotelAdapter(string name,string cidade,int[] categoria, bool[] restaurante)
        {

            string query = "SELECT " +
                                "`hotel`.`idHotel`," +
                                "`hotel`.`nomeHotel`," +
                                "`hotel`.`categoriaHotel`," +
                                "`hotel`.`contatoHotel`," +
                                "`hotel`.`endTipoHotel`," +
                                "`hotel`.`endLogradouroHotel`," +
                                "`hotel`.`endNumeroHotel`," +
                                "`hotel`.`endComplementoHotel`," +
                                "`hotel`.`endBairroHotel` " +
                            "FROM " +
                                "`equipe431447`.`hotel` " +
                            $"WHERE `hotel`.`nomeHotel` LIKE '%{name}%'";

            if (cidade != null && cidade != "0")
            {
                query += $"AND `hotel`.`cidadeIdCidade` = {cidade} "; 
            }
            query += $"AND  (`hotel`.`categoriaHotel` = {categoria[0]} OR `hotel`.`categoriaHotel` = {categoria[1]} OR `hotel`.`categoriaHotel` = {categoria[2]} OR `hotel`.`categoriaHotel` = {categoria[3]} OR `hotel`.`categoriaHotel` = {categoria[4]}) ";

            if (restaurante[0] && restaurante[1])
            {
                query += "AND (`hotel`.`restauranteIdRestaurante` IS NOT NULL OR `hotel`.`restauranteIdRestaurante` IS NULL) ";
            }
            else if (restaurante[0])
            {
                query += "AND `hotel`.`restauranteIdRestaurante` IS NOT NULL";
            }
            else if (restaurante[1])
            {
                query += "AND `hotel`.`restauranteIdRestaurante` IS NULL";
            }
            else
            {
                query += "AND (`hotel`.`restauranteIdRestaurante` IS NOT NULL AND `hotel`.`restauranteIdRestaurante` IS NULL)";
            }

            return fetchResultFromQuery(query);

        }
        public  MySqlDataAdapter restauranteAdapter(string name, string cidade, int[] categoria, string especialidade)
        {
            string query = "SELECT " +
                                "`restaurante`.`idRestaurante`," +
                                "`restaurante`.`nomeRestaurante`," +
                                "`restaurante`.`categoriaRestaurante`," +
                                "`restaurante`.`especialidadeRestaurante`," +
                                "`restaurante`.`precoMedioRestaurante`," +
                                "`restaurante`.`contatoRestaurante`," +
                                "`restaurante`.`endTipoRestaurante`," +
                                "`restaurante`.`endLogradouroRestaurante`," +
                                "`restaurante`.`endNumeroRestaurante`," +
                                "`restaurante`.`endComplementoRestaurante`," +
                                "`restaurante`.`endBairroRestaurante` " +
                            "FROM " +
                                "`equipe431447`.`restaurante` " +
                            $"WHERE `restaurante`.`nomeRestaurante` LIKE '%{name}%'";

            if (cidade != null && cidade != "0")
            {
                query += $"AND `restaurante`.`cidadeIdCidade` = {cidade} ";
            }
            query += $"AND  (`restaurante`.`categoriaRestaurante` = {categoria[0]} OR `restaurante`.`categoriaRestaurante` = {categoria[1]} OR `restaurante`.`categoriaRestaurante` = {categoria[2]} OR `restaurante`.`categoriaRestaurante` = {categoria[3]} OR `restaurante`.`categoriaRestaurante` = {categoria[4]}) ";
            query += $"AND `restaurante`.`especialidadeRestaurante` LIKE '%{especialidade}%'";

            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter pontoTuristicoAdapter(string name)
        {
            string query = "SELECT " +
                        "`pontoturistico`.`idPontoTuristico`," +
                                "`pontoturistico`.`tipoPontoTuristico`," +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico` " +
                            "FROM " +
                                "`equipe431447`.`pontoturistico` " +
                                $"WHERE `pontoturistico`.`nomePontoTuristico` LIKE '%{name}%';";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter igrejaAdapater(string name, string nomeFundador, string nacionalidadeFundador, string estiloIgreja)
        {
            string query = "SELECT " +
                                "`pontoturistico`.`idPontoTuristico`," +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +                            
                                "`igreja`.`dataIgreja`," +
                                "`igreja`.`estiloIgreja`,  " +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +                                
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico`" +
                            "FROM" +
                                "`fundadapor` " +
                            "INNER JOIN igreja " +
                                "ON igreja.idIgreja = fundadapor.Igreja_idIgreja " +
                            "INNER JOIN pontoturistico " +
                                "ON igreja.PontoTuristico_idPontoTuristico = pontoturistico.idPontoTuristico " +
                            "INNER JOIN fundador " +
                                "ON fundador.idFundador = fundadapor.Fundador_idFundador " +
                            $"WHERE `pontoturistico`.`nomePontoTuristico` LIKE '%{name}%' " +
                            $"AND fundador.nomeFundador LIKE '%{nomeFundador}%' " +
                            $"AND fundador.nacionalidadeFundador LIKE '%{nacionalidadeFundador}%' " +
                            $"AND igreja.estiloIgreja LIKE '%{estiloIgreja}%'";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter casadeShowAdapater(string name)
        {
            string query = "SELECT " +
                                "`pontoturistico`.`idPontoTuristico`," +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`casa_de_show`.`diaFechamentoCasadeShow`," +
                                "`casa_de_show`.`horaInicioCasadeShow`," +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +                                
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico` " +
                            "FROM " +
                                "`equipe431447`.`pontoturistico` " +
                            "INNER JOIN `equipe431447`.`casa_de_show` " +
                            "ON `equipe431447`.`casa_de_show`.`PontoTuristico_idPontoTuristico` =  `equipe431447`.`pontoturistico`.`idPontoTuristico` " +
                            $"WHERE `pontoturistico`.`nomePontoTuristico` LIKE '%{name}%';";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter museuAdapater(string name, string nomeFundador, string nacionalidadeFundador, string[] fundacao)
        {
            string query = "SELECT " +
                                "`pontoturistico`.`idPontoTuristico`," +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`museu`.`numeroSalasMuseu`," +
                                "`museu`.`valorEntradaMuseu`," +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +                               
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico`" +
                            "FROM" +
                                "`fundadopor` " +
                            "INNER JOIN museu " +
                            "ON museu.idMuseu = fundadopor.Museu_idMuseu " +
                            "INNER JOIN pontoturistico " +
                            "ON museu.PontoTuristico_idPontoTuristico = pontoturistico.idPontoTuristico " +
                            "INNER JOIN fundador " +
                            "ON fundador.idFundador = fundadopor.Fundador_idFundador " +                           
                            $"WHERE `pontoturistico`.`nomePontoTuristico` LIKE '%{name}%' " +
                            $"AND fundador.nomeFundador LIKE '%{nomeFundador}%' " +
                            $"AND fundador.nacionalidadeFundador LIKE '%{nacionalidadeFundador}%' " +
                            $"AND museu.dataFundacaoMuseu like '%{fundacao[0]}-{((fundacao[1].Equals("")) ? "%" : fundacao[1])}-{((fundacao[2].Equals("")) ? "%" : fundacao[2])}'";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter fundadorAdapter(string name)
        {
            string query = "SELECT `fundador`.`idFundador`," +
                                "`fundador`.`nomeFundador`," +
                                "`fundador`.`atividadeProfissionalFundador`," +
                                "`fundador`.`nascimentoFundador`," +
                                "`fundador`.`morteFundador`," +
                                "`fundador`.`nacionalidadeFundador`" +
                            "FROM `equipe431447`.`fundador` " +
                            $"WHERE `fundador`.`nomeFundador` LIKE '%{name}%'; ";
            return fetchResultFromQuery(query);

        }
        /* ------------------------------------- */
        public MySqlDataReader   periodoReader()
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT dataIgreja FROM igreja";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
