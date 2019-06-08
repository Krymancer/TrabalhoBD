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
        public  MySqlDataAdapter igrejaAdapater(string name, string cidade, string nomeFundador, string nacionalidadeFundador, string estilo, int periodo)
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
                                "ON igreja.idIgreja = fundadapor.igrejaIdIgreja " +
                            "INNER JOIN pontoturistico " +
                                "ON igreja.pontoTuristicoIdPontoTuristico = pontoturistico.idPontoTuristico " +
                            "INNER JOIN fundador " +
                                "ON fundador.idFundador = fundadapor.fundadorIdFundador " +
                            $"WHERE `pontoturistico`.`nomePontoTuristico` LIKE '%{name}%' " +
                            $"AND fundador.nomeFundador LIKE '%{nomeFundador}%' " +
                            $"AND fundador.nacionalidadeFundador LIKE '%{nacionalidadeFundador}%' " +
                            $"AND igreja.estiloIgreja LIKE '%{estilo}%' ";
            if (cidade != null && cidade != "0")
            {
                query += $"AND `pontoturistico`.`cidadeIdCidade` = {cidade} ";
            }
            if (periodo > 0) {
                query += $"AND (year(igreja.dataIgreja) > {periodo-1}01 AND year(igreja.dataIgreja) <= {periodo}00 )";
            }
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter casadeShowAdapater(string name, string cidade, string horario, string fechamento, bool[] restaurante)
        {
            string query = "SELECT " +
                                "`pontoturistico`.`idPontoTuristico`," +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`casadeshow`.`diaFechamentoCasadeShow`," +
                                "`casadeshow`.`horaInicioCasadeShow`," +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico` " +
                            "FROM " +
                                "`pontoturistico` " +
                            "INNER JOIN `casadeshow` " +
                            "ON `casadeshow`.`pontoTuristicoIdPontoTuristico` =  `pontoturistico`.`idPontoTuristico` " +
                            $"WHERE `pontoturistico`.`nomePontoTuristico` LIKE '%{name}%' " +
                            $"AND casadeshow.horaInicioCasadeShow LIKE '%{horario}%' ";
            if (cidade != null && cidade != "0")
            {
                query += $"AND `pontoturistico`.`cidadeIdCidade` = {cidade} ";
            }

            if (restaurante[0] && restaurante[1])
            {
                query += "AND (`casadeshow`.`restauranteIdRestaurante` IS NOT NULL OR `casadeshow`.`restauranteIdRestaurante` IS NULL) ";
            }
            else if (restaurante[0])
            {
                query += "AND `casadeshow`.`restauranteIdRestaurante` IS NOT NULL";
            }
            else if (restaurante[1])
            {
                query += "AND `casadeshow`.`restauranteIdRestaurante` IS NULL";
            }
            else
            {
                query += "AND (`casadeshow`.`restauranteIdRestaurante` IS NOT NULL AND `casadeshow`.`restauranteIdRestaurante` IS NULL)";
            }

            if (!fechamento.Equals("Selecione..."))
            {
                query += $"AND casadeshow.diaFechamentoCasadeShow = '{fechamento}' ";
            }            
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter museuAdapater(string name, string cidade, string nomeFundador, string nacionalidadeFundador, string[] fundacao)
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
                            "ON museu.pontoTuristicoIdPontoTuristico = pontoturistico.idPontoTuristico " +
                            "INNER JOIN fundador " +
                            "ON fundador.idFundador = fundadopor.Fundador_idFundador " +                           
                            $"WHERE `pontoturistico`.`nomePontoTuristico` LIKE '%{name}%' " +
                            $"AND fundador.nomeFundador LIKE '%{nomeFundador}%' " +
                            $"AND fundador.nacionalidadeFundador LIKE '%{nacionalidadeFundador}%' " +
                            $"AND museu.dataFundacaoMuseu like '%{fundacao[0]}-{((fundacao[1].Equals("")) ? "%" : fundacao[1])}-{((fundacao[2].Equals("")) ? "%" : fundacao[2])}'";
            if (cidade != null && cidade != "0")
            {
                query += $"AND `pontoturistico`.`cidadeIdCidade` = {cidade} ";
            }
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter fundadorAdapter(string name, string atuacao, string naturalidade)
        {
            string query = "SELECT `fundador`.`idFundador`," +
                                "`fundador`.`nomeFundador`," +
                                "`fundador`.`atividadeProfissionalFundador`," +
                                "`fundador`.`nascimentoFundador`," +
                                "`fundador`.`morteFundador`," +
                                "`fundador`.`nacionalidadeFundador`" +
                            "FROM `equipe431447`.`fundador` " +
                            $"WHERE `fundador`.`nomeFundador` LIKE '%{name}%' " +
                            $"AND `fundador`.`atividadeProfissionalFundador`  LIKE '%{atuacao}%' " +
                            $"AND `fundador`.`nacionalidadeFundador` LIKE '%{naturalidade}%' ";
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
