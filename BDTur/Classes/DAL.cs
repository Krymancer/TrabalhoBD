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
        /// <summary>
        /// Retorna uma conexão com o Banco de dados.
        /// </summary>
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

        #region Adapters para os DataGridViews
        public MySqlDataAdapter usuarioAdapter()
        {
            string query = "SELECT  idUsuario, username, password, tipoUsuario " +
                "FROM usuario";

            return fetchResultFromQuery(query);
        }
        public MySqlDataAdapter hotelquartooAdapter()
        {
            string query = "SELECT  * " +
                "FROM hotelQuarto";

            return fetchResultFromQuery(query);
        }
        public MySqlDataAdapter cidadeAdapter()
        {
            string query = "SELECT `cidade`.`idCidade`," +
                             "`cidade`.`nome`,`cidade`.`estado`," +
                             "`cidade`.`populacao` FROM `equipe431447`.`cidade` ORDER BY `nome`;";
            return fetchResultFromQuery(query);
        }
        public MySqlDataAdapter cidadeAdapterParam(string estado, string nome)
        {
            string query = "SELECT `cidade`.`idCidade`," +
                             "`cidade`.`nome`,`cidade`.`estado`," +
                             "`cidade`.`populacao` FROM `equipe431447`.`cidade` " +
                             $"WHERE `cidade`.`nome` LIKE '%{nome}%' AND `cidade`.`estado` LIKE '%{estado}%' ORDER BY `nome`;";
            return fetchResultFromQuery(query);
        }
        public MySqlDataAdapter hotelAdapter(string name, string cidade, int[] categoria, bool[] restaurante)
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
        public MySqlDataAdapter restauranteAdapter(string name, string cidade, int[] categoria, string especialidade)
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
            query += $"AND `restaurante`.`especialidadeRestaurante` LIKE '%{especialidade}%'";

            return fetchResultFromQuery(query);
        }
        public MySqlDataAdapter igrejaAdapater(string name, string cidade, string nomeFundador, string nacionalidadeFundador, string estilo, int periodo)
        {
            string query = "SELECT " +
                                "`igreja`.`idIgreja`," +
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
            if (periodo > 0)
            {
                query += $"AND (year(igreja.dataIgreja) > {periodo - 1}01 AND year(igreja.dataIgreja) <= {periodo}00 )";
            }
            return fetchResultFromQuery(query);
        }
        public MySqlDataAdapter casadeShowAdapater(string name, string cidade, string horario, string fechamento, bool[] restaurante)
        {
            string query = "SELECT " +
                                "`casadeshow`.`idCasadeShow`," +
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
        public MySqlDataAdapter museuAdapater(string name, string cidade, string nomeFundador, string nacionalidadeFundador, string[] fundacao)
        {
            string query = "SELECT " +
                                "`museu`.`idMuseu`," +
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
                            //$"AND museu.dataFundacaoMuseu like '%{fundacao[0]}-{((fundacao[1].Equals("")) ? "%" : fundacao[1])}-{((fundacao[2].Equals("")) ? "%" : fundacao[2])}'";
                            $" AND (year(museu.dataFundacaoMuseu) LIKE '%{fundacao[0]}' AND month(museu.dataFundacaoMuseu) LIKE '%{((fundacao[1].Equals("")) ? "%" : fundacao[1])}' AND day(museu.dataFundacaoMuseu) LIKE '{((fundacao[2].Equals("")) ? "%" : fundacao[2])}') ";
            if (cidade != null && cidade != "0")
            {
                query += $"AND `pontoturistico`.`cidadeIdCidade` = {cidade} ";
            }
            return fetchResultFromQuery(query);
        }
        public MySqlDataAdapter fundadorAdapter(string name, string atuacao, string naturalidade)
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
        public MySqlDataAdapter hotelQuartoAdapter(int id)
        {
            string query = $"SELECT numQuarto,tipoQuarto,diariaQuarto from hotelquarto WHERE hotelIdHotel = {id};";

            return fetchResultFromQuery(query);
        }
        #endregion

        #region DataReaders para consultas especificas
        public MySqlDataReader periodoReader()
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT dataIgreja FROM igreja";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader fundadoresReader()
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT idFundador, nomeFundador FROM fundador";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader restaunrateReader()
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT idRestaurante, nomeRestaurante FROM restaurante";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader hotelDetailsReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT hotel.*, restaurante.idRestaurante, restaurante.nomeRestaurante " +
                "FROM hotel " +
                "INNER JOIN restaurante ON restaurante.idRestaurante = (hotel.restauranteIdRestaurante OR (hotel.restauranteIdRestaurante IS NULL)) " +
                $"WHERE hotel.idHotel = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader restauranteDetailsReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT * " +
                "FROM restaurante " +
                $"WHERE restaurante.idRestaurante = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader igrejaDetailsReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT * " +
                "FROM pontoturistico " +
                "INNER JOIN igreja on igreja.pontoTuristicoIdPontoTuristico = pontoturistico.idPontoTuristico " +
                $"WHERE igreja.idIgreja = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader igrejafundadoresReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT idFundador, nomeFundador FROM fundadapor " +
                            "INNER JOIN fundador ON fundadapor.fundadorIdFundador = fundador.idFundador " +
                            $"WHERE fundadapor.igrejaIdIgreja = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader museuDetailsReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT * " +
                "FROM pontoturistico " +
                "INNER JOIN museu on museu.pontoTuristicoIdPontoTuristico = pontoturistico.idPontoTuristico " +
                $"WHERE museu.idMuseu = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader museufundadoresReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT idFundador, nomeFundador FROM fundadopor " +
                            "INNER JOIN fundador ON fundadopor.Fundador_idFundador = fundador.idFundador " +
                            $"WHERE fundadopor.Museu_idMuseu = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader casadeshowDetailsReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT * " +
                "FROM pontoturistico " +
                "INNER JOIN casadeshow on casadeshow.pontoTuristicoIdPontoTuristico = pontoturistico.idPontoTuristico " +
                $"WHERE casadeshow.idCasadeShow = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader fundadorDetailsReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT nomeFundador, atividadeProfissionalFundador, nacionalidadeFundador, nascimentoFundador, morteFundador " +
                "FROM fundador " +
                $"WHERE idFundador = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader fundadorIgrejaReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "select distinct* from(select pontoturistico.nomePontoTuristico, fundadorIdFundador from pontoturistico " +
                           "inner join igreja on igreja.pontoTuristicoIdPontoTuristico = pontoturistico.idPontoTuristico " +
                           "inner join fundadapor on pontoturistico.idPontoTuristico = fundadapor.Igreja_PontoTuristico_idPontoTuristico) as i " +
                           $"where fundadorIdFundador = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader fundadorMuseuReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "select distinct * from (select  pontoturistico.nomePontoTuristico,Fundador_idFundador from pontoturistico  " +
            "inner join museu on museu.pontoTuristicoIdPontoTuristico = pontoturistico.idPontoTuristico " +
            "inner join fundadopor on pontoturistico.idPontoTuristico = fundadopor.Museu_PontoTuristico_idPontoTuristico) as m " +
            $"where Fundador_idFundador = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader cidadesReader(int id) {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "select * from cidade " +
            $"where idCidade = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader usuarioReader(int id)
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "select * from usuario " +
            $"where idUsuario = {id}";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public MySqlDataReader lastInsertId()
        {
            MySqlConnection con = createConnection();
            con.Open();
            string query = "SELECT LAST_INSERT_ID();";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }        
        #endregion

        #region Inserts
        public bool adicionarRestaurante(Classes.Restaurante restaurante)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `equipe431447`.`restaurante` " +
                                                    "(`idRestaurante`, " +
                                                    "`nomeRestaurante`, " +
                                                    "`categoriaRestaurante`, " +
                                                    "`especialidadeRestaurante`, " +
                                                    "`precoMedioRestaurante`, " +
                                                    "`contatoRestaurante`, " +
                                                    "`endTipoRestaurante`, " +
                                                    "`endLogradouroRestaurante`, " +
                                                    "`endNumeroRestaurante`, " +
                                                    "`endComplementoRestaurante`, " +
                                                    "`endBairroRestaurante`, " +
                                                    "`endCepRestaurante`, " +
                                                    "`cidadeIdCidade`, " +
                                                    "`cidadeNome`, " +
                                                    "`cidadeEstado`) " +
                                                    "VALUES " +
                                                    "(0, " +
                                                    "?nomeRestaurante, " +
                                                    "?categoriaRestaurante, " +
                                                    "?especialidadeRestaurante, " +
                                                    "?precoMedioRestaurante, " +
                                                    "?contatoRestaurante, " +
                                                    "?endTipoRestaurante, " +
                                                    "?endLogradouroRestaurante, " +
                                                    "?endNumeroRestaurante, " +
                                                    "?endComplementoRestaurante, " +
                                                    "?endBairroRestaurante, " +
                                                    "?endCepRestaurante, " +
                                                    "?cidadeIdCidade, " +
                                                    $"(select nome from cidade where idCidade = {restaurante.CidadeIdCidade}), " +
                                                    $"(select estado from cidade where idCidade = {restaurante.CidadeIdCidade}))", con);
                cmd.Parameters.Add(new MySqlParameter("nomeRestaurante", restaurante.NomeRestaurante));
                cmd.Parameters.Add(new MySqlParameter("categoriaRestaurante", restaurante.CategoriaRestaurante));
                cmd.Parameters.Add(new MySqlParameter("especialidadeRestaurante", restaurante.EspecialidadeRestaurante));
                cmd.Parameters.Add(new MySqlParameter("precoMedioRestaurante", restaurante.PrecoMedioRestaurante));
                cmd.Parameters.Add(new MySqlParameter("contatoRestaurante", restaurante.ContatoRestauranteo));
                cmd.Parameters.Add(new MySqlParameter("endTipoRestaurante", restaurante.EndTipoRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroRestaurante", restaurante.EndLogradouroRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endNumeroRestaurante", restaurante.EndNumeroRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endComplementoRestaurante", restaurante.EndComplementoRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endBairroRestaurante", restaurante.EndBairroRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endCepRestaurante", restaurante.EndCepRestaurante));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", restaurante.CidadeIdCidade));

                //Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarCidade(Classes.Cidade cidade)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `equipe431447`.`cidade` " +
                                                    "(`idCidade`, " +
                                                    "`nome`, " +
                                                    "`estado`, " +
                                                    "`populacao`)" +
                                                    "VALUES " +
                                                    "(0, " +
                                                    "?nome, " +
                                                    "?estado, " +
                                                    "?populacao)", con);
                cmd.Parameters.Add(new MySqlParameter("nome", cidade.Nome));
                cmd.Parameters.Add(new MySqlParameter("estado", cidade.Estado));
                cmd.Parameters.Add(new MySqlParameter("populacao", cidade.Populacao));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarHotel(Classes.Hotel hotel)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `equipe431447`.`hotel` " +
                                                    "(`idHotel`, " +
                                                    "`restauranteIdRestaurante`, " +
                                                    "`nomeHotel`, " +
                                                    "`categoriaHotel`, " +
                                                    "`contatoHotel`, " +
                                                    "`endTipoHotel`, " +
                                                    "`endLogradouroHotel`, " +
                                                    "`endNumeroHotel`, " +
                                                    "`endComplementoHotel`, " +
                                                    "`endBairroHotel`, " +
                                                    "`endCepHotel`, " +
                                                    "`cidadeIdCidade`, " +
                                                    "`cidadeNome`, " +
                                                    "`cidadeEstado`)" +
                                                    "VALUES" +
                                                    "(0, " +
                                                    $"{hotel.RestauranteIdRestaurante}, " +
                                                    "?nomeHotel, " +
                                                    "?categoriaHotel, " +
                                                    "?contatoHotel, " +
                                                    "?endTipoHotel, " +
                                                    "?endLogradouroHotel, " +
                                                    "?endNumeroHotel, " +
                                                    "?endComplementoHotel, " +
                                                    "?endBairroHotel, " +
                                                    "?endCepHotel, " +
                                                    "?cidadeIdCidade, " +
                                                    $"(select nome from cidade where idCidade = {hotel.CidadeIdCidade})," +
                                                    $"(select estado from cidade where idCidade = {hotel.CidadeIdCidade}))", con);

                //cmd.Parameters.Add(new MySqlParameter("restauranteIdRestaurante", hotel.RestauranteIdRestaurante));
                cmd.Parameters.Add(new MySqlParameter("nomeHotel", hotel.NomeHotel));
                cmd.Parameters.Add(new MySqlParameter("categoriaHotel", hotel.CategoriaHotel));
                cmd.Parameters.Add(new MySqlParameter("contatoHotel", hotel.ContatoHotel));
                cmd.Parameters.Add(new MySqlParameter("endTipoHotel", hotel.EndTipoHotel));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroHotel", hotel.EndLogradouroHotel));
                cmd.Parameters.Add(new MySqlParameter("endNumeroHotel", hotel.EndNumeroHotel));
                cmd.Parameters.Add(new MySqlParameter("endComplementoHotel", hotel.EndComplementoHotel));
                cmd.Parameters.Add(new MySqlParameter("endBairroHotel", hotel.EndBairroHotel));
                cmd.Parameters.Add(new MySqlParameter("endCepHotel", hotel.EndCepHotel));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", hotel.CidadeIdCidade));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }            
        }
        public bool adicionarUsuario(Classes.Usuario user)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `equipe431447`.`usuario` " +
                                                    "(`idUsuario`, " +
                                                    "`username`, " +
                                                    "`password`, " +
                                                    "`tipoUsuario`) " +
                                                    "VALUES " +
                                                    "(0, " +
                                                    "?username, " +
                                                    "?password, " +
                                                    "?tipoUsuario) ", con);
                cmd.Parameters.Add(new MySqlParameter("username", user.Username));
                cmd.Parameters.Add(new MySqlParameter("password", user.Password));
                cmd.Parameters.Add(new MySqlParameter("tipoUsuario", user.AcessLevel));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarHotelQuarto(Classes.HotelQuarto hq)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "INSERT INTO `equipe431447`.`hotelquarto`" +
                                "(`numQuarto`," +
                                "`hotelIdHotel`," +
                                "`tipoQuarto`," +
                                "`diariaQuarto`)" +
                                "VALUES" +
                                "(?numQuarto," +
                                "?hotelIdHotel," +
                                "?tipoQuarto," +
                                "?diariaQuarto)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("numQuarto", hq.NumQuarto));
                cmd.Parameters.Add(new MySqlParameter("hotelIdHotel", hq.HotelIdHotel));
                cmd.Parameters.Add(new MySqlParameter("tipoQuarto", hq.TipoQuarto));
                cmd.Parameters.Add(new MySqlParameter("diariaQuarto", hq.DiariaQuarto));

                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarIgreja(Classes.Igreja igreja)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                // BuildMyString.com generated code. Please enjoy your string responsibly.

                string query = "BEGIN;" +
                                "INSERT INTO `equipe431447`.`pontoturistico`" +
                                "(`idPontoTuristico`," +
                                "`tipoPontoTuristico`," +
                                "`nomePontoTuristico`," +
                                "`contatoPontoTuristico`," +
                                "`descricaoPontoTuristico`," +
                                "`endLogradouroPontoTuristico`," +
                                "`endTipoPontoTuristico`," +
                                "`endNumeroPontoTuristico`," +
                                "`endComplementoPontoTuristico`," +
                                "`endBairroPontoTuristico`," +
                                "`endCepPontoTuristico`," +
                                "`cidadeIdCidade`," +
                                "`cidadeNome`," +
                                "`cidadeEstado`) " +
                                "VALUES " +
                                "(0," +
                                "?tipoPontoTuristico," +
                                "?nomePontoTuristico," +
                                "?contatoPontoTuristico," +
                                "?descricaoPontoTuristico," +
                                "?endLogradouroPontoTuristico," +
                                "?endTipoPontoTuristico," +
                                "?endNumeroPontoTuristico," +
                                "?endComplementoPontoTuristico," +
                                "?endBairroPontoTuristico," +
                                "?endCepPontoTuristico," +
                                "?cidadeIdCidade," +
                                $"(select nome from cidade where idCidade = {igreja.CidadeIdCidade})," +
                                $"(select estado from cidade where idCidade = {igreja.CidadeIdCidade})); " +
                                "INSERT INTO `equipe431447`.`igreja`" +
                                "(`idIgreja`," +
                                "`dataIgreja`," +
                                "`estiloIgreja`," +
                                "`pontoTuristicoIdPontoTuristico`)" +
                                "VALUES" +
                                "(LAST_INSERT_ID()," +
                                "?dataIgreja," +
                                "?estiloIgreja," +
                                "LAST_INSERT_ID()); " +
                                "COMMIT;";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("tipoPontoTuristico", igreja.TipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("nomePontoTuristico", igreja.NomePontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("contatoPontoTuristico", igreja.ContatoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("descricaoPontoTuristico", igreja.DescricaoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroPontoTuristico", igreja.EndLogradouroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endTipoPontoTuristico", igreja.EndTipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endNumeroPontoTuristico", igreja.EndNumeroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endComplementoPontoTuristico", igreja.EndComplementoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endBairroPontoTuristico", igreja.EndBairroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endCepPontoTuristico", igreja.EndCepPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", igreja.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("dataIgreja", (igreja.DataIgreja)));
                cmd.Parameters.Add(new MySqlParameter("estiloIgreja", igreja.EstiloIgreja));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }

            catch (MySqlException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Data);
                return false;
            }
        }
        public bool adicionarMuseu(Classes.Museu museu)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                // BuildMyString.com generated code. Please enjoy your string responsibly.

                // BuildMyString.com generated code. Please enjoy your string responsibly.

                string query = "BEGIN;" +
                                "INSERT INTO `equipe431447`.`pontoturistico`" +
                                "(`idPontoTuristico`," +
                                "`tipoPontoTuristico`," +
                                "`nomePontoTuristico`," +
                                "`contatoPontoTuristico`," +
                                "`descricaoPontoTuristico`," +
                                "`endLogradouroPontoTuristico`," +
                                "`endTipoPontoTuristico`," +
                                "`endNumeroPontoTuristico`," +
                                "`endComplementoPontoTuristico`," +
                                "`endBairroPontoTuristico`," +
                                "`endCepPontoTuristico`," +
                                "`cidadeIdCidade`," +
                                "`cidadeNome`," +
                                "`cidadeEstado`)" +
                                "VALUES" +
                                "(0," +
                                "?tipoPontoTuristico," +
                                "?nomePontoTuristico," +
                                "?contatoPontoTuristico," +
                                "?descricaoPontoTuristico," +
                                "?endLogradouroPontoTuristico," +
                                "?endTipoPontoTuristico," +
                                "?endNumeroPontoTuristico," +
                                "?endComplementoPontoTuristico," +
                                "?endBairroPontoTuristico," +
                                "?endCepPontoTuristico," +
                                "?cidadeIdCidade," +
                                $"(select nome from cidade where idCidade = {museu.CidadeIdCidade})," +
                                $"(select estado from cidade where idCidade = {museu.CidadeIdCidade})); " +
                                "INSERT INTO `equipe431447`.`museu`" +
                                "(`idMuseu`," +
                                "`dataFundacaoMuseu`," +
                                "`valorEntradaMuseu`," +
                                "`numeroSalasMuseu`," +
                                "`pontoTuristicoIdPontoTuristico`)" +
                                "VALUES" +
                                "(LAST_INSERT_ID()," +
                                "?dataFundacaoMuseu," +
                                "?valorEntradaMuseu," +
                                "?numeroSalasMuseu," +
                                "LAST_INSERT_ID());" +
                                "COMMIT;";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("tipoPontoTuristico", museu.TipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("nomePontoTuristico", museu.NomePontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("contatoPontoTuristico", museu.ContatoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("descricaoPontoTuristico", museu.DescricaoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroPontoTuristico", museu.EndLogradouroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endTipoPontoTuristico", museu.EndTipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endNumeroPontoTuristico", museu.EndNumeroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endComplementoPontoTuristico", museu.EndComplementoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endBairroPontoTuristico", museu.EndBairroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endCepPontoTuristico", museu.EndCepPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", museu.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("dataFundacaoMuseu", museu.DataFundacaoMuseu));
                cmd.Parameters.Add(new MySqlParameter("valorEntradaMuseu", museu.ValorEntradaMuseu));
                cmd.Parameters.Add(new MySqlParameter("numeroSalasMuseu", museu.NumeroSalasMuseu));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarFundador(Classes.Fundador fund)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "INSERT INTO `equipe431447`.`fundador`" +
                                "(`idFundador`," +
                                "`nomeFundador`," +
                                "`atividadeProfissionalFundador`," +
                                "`nascimentoFundador`," +
                                "`morteFundador`," +
                                "`nacionalidadeFundador`)" +
                                "VALUES" +
                                "(0," +
                                "?nomeFundador," +
                                "?atividadeProfissionalFundador," +
                                "?nascimentoFundador," +
                                "?morteFundador," +
                                "?nacionalidadeFundador);";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("nomeFundador", fund.NomeFundador));
                cmd.Parameters.Add(new MySqlParameter("atividadeProfissionalFundador", fund.AtividadeProfissionalFundador));
                cmd.Parameters.Add(new MySqlParameter("nascimentoFundador", fund.NascimentoFundador));
                cmd.Parameters.Add(new MySqlParameter("morteFundador", fund.MorteFundador));
                cmd.Parameters.Add(new MySqlParameter("nacionalidadeFundador" +
                    "", fund.NacionalidadeFundador));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarFundadapor(Classes.Igreja igreja, Classes.Fundador fundador)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "INSERT INTO `equipe431447`.`fundadapor`" +
                                "(`igrejaIdIgreja`," +
                                "`Igreja_PontoTuristico_idPontoTuristico`," +
                                "`fundadorIdFundador`)" +
                                "VALUES" +
                                "(?igrejaIdIgreja," +
                                "?Igreja_PontoTuristico_idPontoTuristico," +
                                "?fundadorIdFundador);";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("igrejaIdIgreja", igreja.IdIgreja));
                cmd.Parameters.Add(new MySqlParameter("Igreja_PontoTuristico_idPontoTuristico", igreja.IdIgreja));
                cmd.Parameters.Add(new MySqlParameter("fundadorIdFundador", fundador.IdFundador));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarFundadopor(Classes.Museu museu, Classes.Fundador fundador)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "INSERT INTO `equipe431447`.`fundadopor`" +
                                "(`Museu_idMuseu`," +
                                "`Museu_PontoTuristico_idPontoTuristico`," +
                                "`Fundador_idFundador`)" +
                                "VALUES" +
                                "(?Museu_idMuseu," +
                                "?Museu_PontoTuristico_idPontoTuristico," +
                                "?Fundador_idFundador);";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("Museu_idMuseu", museu.IdMuseu));
                cmd.Parameters.Add(new MySqlParameter("Museu_PontoTuristico_idPontoTuristico", museu.IdMuseu));
                cmd.Parameters.Add(new MySqlParameter("Fundador_idFundador", fundador.IdFundador));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool adicionarCasadeShow(Classes.CasaDeShow cs)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();

                string query = "BEGIN;" +
                                "INSERT INTO `equipe431447`.`pontoturistico`" +
                                "(`idPontoTuristico`," +
                                "`tipoPontoTuristico`," +
                                "`nomePontoTuristico`," +
                                "`contatoPontoTuristico`," +
                                "`descricaoPontoTuristico`," +
                                "`endLogradouroPontoTuristico`," +
                                "`endTipoPontoTuristico`," +
                                "`endNumeroPontoTuristico`," +
                                "`endComplementoPontoTuristico`," +
                                "`endBairroPontoTuristico`," +
                                "`endCepPontoTuristico`," +
                                "`cidadeIdCidade`," +
                                "`cidadeNome`," +
                                "`cidadeEstado`) " +
                                "VALUES  " +
                                "(0, " +
                                "?tipoPontoTuristico, " +
                                "?nomePontoTuristico, " +
                                "?contatoPontoTuristico, " +
                                "?descricaoPontoTuristico, " +
                                "?endLogradouroPontoTuristico, " +
                                "?endTipoPontoTuristico, " +
                                "?endNumeroPontoTuristico, " +
                                "?endComplementoPontoTuristico, " +
                                "?endBairroPontoTuristico, " +
                                "?endCepPontoTuristico, " +
                                "?cidadeIdCidade, " +
                                $"(select nome from cidade where idCidade = {cs.CidadeIdCidade}), " +
                                $"(select estado from cidade where idCidade = {cs.CidadeIdCidade}));  " +
                                "INSERT INTO `equipe431447`.`casadeshow`" +
                                "(`idCasadeShow`," +
                                "`diaFechamentoCasadeShow`," +
                                "`horaInicioCasadeShow`," +
                                "`pontoTuristicoIdPontoTuristico`," +
                                "`restauranteIdRestaurante`) " +
                                "VALUES  " +
                                "(LAST_INSERT_ID()  ," +
                                "?diaFechamentoCasadeShow, " +
                                "?horaInicioCasadeShow, " +
                                "LAST_INSERT_ID(), " +
                                $"{cs.RestauranteIdRestaurante});" +
                                "COMMIT;";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("tipoPontoTuristico", cs.TipoPontoTuristico);
                cmd.Parameters.Add(new MySqlParameter("nomePontoTuristico", cs.NomePontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("contatoPontoTuristico", cs.ContatoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("descricaoPontoTuristico", cs.DescricaoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroPontoTuristico", cs.EndLogradouroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endTipoPontoTuristico", cs.EndTipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endNumeroPontoTuristico", cs.EndNumeroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endComplementoPontoTuristico", cs.EndComplementoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endCepPontoTuristico", cs.EndCepPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endBairroPontoTuristico", cs.EndBairroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", cs.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("diaFechamentoCasadeShow", cs.DiaFechamentoCasadeShow));
                cmd.Parameters.Add(new MySqlParameter("horaInicioCasadeShow", cs.HoraInicioCasadeShow));
                //cmd.Parameters.Add(new MySqlParameter("restauranteIdRestaurante", cs.RestauranteIdRestaurante));
                //Console.WriteLine(cmd.CommandText);               

                MySqlDataReader reader;                
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion

        #region Deletes
        public bool removerCidade(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `equipe431447`.`cidade` WHERE cidade.idCidade = ?id;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public bool removerRestaurante(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `equipe431447`.`restaurante` WHERE restaurante.idRestaurante = ?id;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public bool removerHotel(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `equipe431447`.`hotel` WHERE hotel.idHotel = ?id;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public bool removerUsuario(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `equipe431447`.`usuario` WHERE usuario.idUsuario = ?id;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public bool removerIgreja(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("BEGIN;" +
                    "DELETE FROM `equipe431447`.`igreja` WHERE igreja.idIgreja = ?id;" +
                    "DELETE FROM `equipe431447`.`pontoturistico` WHERE pontoturistico.idPontoTuristico = ?id;" +
                    "COMMIT;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public bool removerMuseu(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("BEGIN;" +
                    "DELETE FROM `equipe431447`.`museu` WHERE museu.idMuseu = ?id;" +
                    "DELETE FROM `equipe431447`.`pontoturistico` WHERE pontoturistico.idPontoTuristico = ?id;" +
                    "COMMIT;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public bool removerFundador(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `equipe431447`.`fundador` WHERE fundador.idFundador = ?id;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public bool removerCasadeShow(int id)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("BEGIN;" +
                    "DELETE FROM `equipe431447`.`casadeshow` WHERE casadeshow.idCasadeShow = ?id;" +
                    "DELETE FROM `equipe431447`.`pontoturistico` WHERE pontoturistico.idPontoTuristico = ?id;" +
                    "COMMIT;", con);
                cmd.Parameters.Add(new MySqlParameter("id", id));

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        #endregion

        #region Updates            
        public bool atualizarRestaurante(Classes.Restaurante restaurante)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "UPDATE `equipe431447`.`restaurante`" +
                "SET" +
                "`nomeRestaurante` = ?nomeRestaurante," +
                "`categoriaRestaurante` = ?categoriaRestaurante," +
                "`especialidadeRestaurante` = ?especialidadeRestaurante," +
                "`precoMedioRestaurante` = ?precoMedioRestaurante," +
                "`contatoRestaurante` = ?contatoRestaurante," +
                "`endTipoRestaurante` = ?endTipoRestaurante," +
                "`endLogradouroRestaurante` = ?endLogradouroRestaurante," +
                "`endNumeroRestaurante` = ?endNumeroRestaurante," +
                "`endComplementoRestaurante` = ?endComplementoRestaurante," +
                "`endBairroRestaurante` = ?endBairroRestaurante," +
                "`endCepRestaurante` = ?endCepRestaurante," +
                "`cidadeIdCidade` = ?cidadeIdCidade," +
                "`cidadeNome` = (select nome from cidade where idCidade = ?cidadeIdCidade)," +
                "`cidadeEstado` = (select estado from cidade where idCidade = ?cidadeIdCidade)" +
                "WHERE `idRestaurante` = ?id;";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("nomeRestaurante", restaurante.NomeRestaurante));
                cmd.Parameters.Add(new MySqlParameter("categoriaRestaurante", restaurante.CategoriaRestaurante));
                cmd.Parameters.Add(new MySqlParameter("especialidadeRestaurante", restaurante.EspecialidadeRestaurante));
                cmd.Parameters.Add(new MySqlParameter("precoMedioRestaurante", restaurante.PrecoMedioRestaurante));
                cmd.Parameters.Add(new MySqlParameter("contatoRestaurante", restaurante.ContatoRestauranteo));
                cmd.Parameters.Add(new MySqlParameter("endTipoRestaurante", restaurante.EndTipoRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroRestaurante", restaurante.EndLogradouroRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endNumeroRestaurante", restaurante.EndNumeroRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endComplementoRestaurante", restaurante.EndComplementoRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endBairroRestaurante", restaurante.EndBairroRestaurante));
                cmd.Parameters.Add(new MySqlParameter("endCepRestaurante", restaurante.EndCepRestaurante));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", restaurante.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("id", restaurante.IdRestaurante));
                MySqlDataReader reader;
                Console.WriteLine(cmd.CommandText);
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }
        public bool atualizarCidade(Classes.Cidade cidade)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "UPDATE `equipe431447`.`cidade`" +
                                "SET" +
                                "`nome` = ?nome," +
                                "`estado` = ?estado," +
                                "`populacao` = ?populacao " +
                                "WHERE `idCidade` = ?id;";


                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("nome", cidade.Nome));
                cmd.Parameters.Add(new MySqlParameter("estado", cidade.Estado));
                cmd.Parameters.Add(new MySqlParameter("populacao", cidade.Populacao));
                cmd.Parameters.Add(new MySqlParameter("id", cidade.IdCidade));
                MySqlDataReader reader;
                Console.WriteLine(cmd.CommandText);
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }
        public bool atualizarHotel(Classes.Hotel hotel)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();

                string query = " UPDATE `equipe431447`.`hotel`" +
                                "SET" +
                               $"`restauranteIdRestaurante` = {hotel.RestauranteIdRestaurante}," +
                                "`nomeHotel` = ?nomeHotel," +
                                "`categoriaHotel` = ?categoriaHotel," +
                                "`contatoHotel` = ?contatoHotel," +
                                "`endTipoHotel` = ?endTipoHotel," +
                                "`endLogradouroHotel` = ?endLogradouroHotel," +
                                "`endNumeroHotel` = ?endNumeroHotel," +
                                "`endComplementoHotel` = ?endComplementoHotel," +
                                "`endBairroHotel` = ?endBairroHotel," +
                                "`endCepHotel` = ?endCepHotel," +
                                "`cidadeIdCidade` = ?cidadeIdCidade," +
                                $"`cidadeNome` = (select nome from cidade where idCidade = {hotel.CidadeIdCidade})," +
                                $"`cidadeEstado` = (select estado from cidade where idCidade = {hotel.CidadeIdCidade}) " +
                                "WHERE `idHotel` = ?id;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                //cmd.Parameters.Add(new MySqlParameter("restauranteIdRestaurante", hotel.RestauranteIdRestaurante));
                cmd.Parameters.Add(new MySqlParameter("nomeHotel", hotel.NomeHotel));
                cmd.Parameters.Add(new MySqlParameter("categoriaHotel", hotel.CategoriaHotel));
                cmd.Parameters.Add(new MySqlParameter("contatoHotel", hotel.ContatoHotel));
                cmd.Parameters.Add(new MySqlParameter("endTipoHotel", hotel.EndTipoHotel));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroHotel", hotel.EndLogradouroHotel));
                cmd.Parameters.Add(new MySqlParameter("endNumeroHotel", hotel.EndNumeroHotel));
                cmd.Parameters.Add(new MySqlParameter("endComplementoHotel", hotel.EndComplementoHotel));
                cmd.Parameters.Add(new MySqlParameter("endBairroHotel", hotel.EndBairroHotel));
                cmd.Parameters.Add(new MySqlParameter("endCepHotel", hotel.EndCepHotel));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", hotel.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("id", hotel.IdHotel));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool atualizarHotelQuarto(Classes.HotelQuarto hq)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "UPDATE `equipe431447`.`hotelquarto`" +
                                "SET" +
                                "`numQuarto` =   ?numQuarto," +
                                "`tipoQuarto` =   ?tipoQuarto," +
                                "`diariaQuarto` =   ?diariaQuarto " +
                                "WHERE `hotelIdHotel` =   ?hotelIdHotel;";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("numQuarto", hq.NumQuarto));
                cmd.Parameters.Add(new MySqlParameter("hotelIdHotel", hq.HotelIdHotel));
                cmd.Parameters.Add(new MySqlParameter("tipoQuarto", hq.TipoQuarto));
                cmd.Parameters.Add(new MySqlParameter("diariaQuarto", hq.DiariaQuarto));
                MySqlDataReader reader;
                Console.WriteLine(cmd.CommandText);
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }
        public bool atualizarIgreja(Classes.Igreja igreja)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                // BuildMyString.com generated code. Please enjoy your string responsibly.
                string query = "BEGIN;" +
                                "UPDATE `equipe431447`.`pontoturistico`" +
                                "SET" +
                                "`tipoPontoTuristico` =   ?tipoPontoTuristico  ," +
                                "`nomePontoTuristico` =   ?nomePontoTuristico  ," +
                                "`contatoPontoTuristico` =   ?contatoPontoTuristico  ," +
                                "`descricaoPontoTuristico` =   ?descricaoPontoTuristico  ," +
                                "`endLogradouroPontoTuristico` =   ?endLogradouroPontoTuristico  ," +
                                "`endTipoPontoTuristico` =   ?endTipoPontoTuristico  ," +
                                "`endNumeroPontoTuristico` =   ?endNumeroPontoTuristico  ," +
                                "`endComplementoPontoTuristico` =   ?endComplementoPontoTuristico  ," +
                                "`endBairroPontoTuristico` =   ?endBairroPontoTuristico  ," +
                                "`endCepPontoTuristico` =   ?endCepPontoTuristico  ," +
                                "`cidadeIdCidade` =   ?cidadeIdCidade  ," +
                                $"`cidadeNome` =   (select nome from cidade where idCidade = { igreja.CidadeIdCidade})  ," +
                                $"`cidadeEstado` =   (select estado from cidade where idCidade = {igreja.CidadeIdCidade})  " +
                                "WHERE `idPontoTuristico` =   ?idPontoTuristico;" +
                                "UPDATE `equipe431447`.`igreja`" +
                                "SET" +
                                "`dataIgreja` =   ?dataIgreja," +
                                "`estiloIgreja` =   ?estiloIgreja  " +                                
                                "WHERE `idIgreja` =   ?idIgreja;" +
                                "COMMIT;";               

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("tipoPontoTuristico", igreja.TipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("nomePontoTuristico", igreja.NomePontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("contatoPontoTuristico", igreja.ContatoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("descricaoPontoTuristico", igreja.DescricaoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroPontoTuristico", igreja.EndLogradouroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endTipoPontoTuristico", igreja.EndTipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endNumeroPontoTuristico", igreja.EndNumeroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endComplementoPontoTuristico", igreja.EndComplementoPontoTuristico));                                
                cmd.Parameters.Add(new MySqlParameter("endBairroPontoTuristico", igreja.EndBairroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endCepPontoTuristico", igreja.EndCepPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", igreja.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("dataIgreja", igreja.DataIgreja));
                cmd.Parameters.Add(new MySqlParameter("estiloIgreja", igreja.EstiloIgreja));
                cmd.Parameters.Add(new MySqlParameter("idIgreja", igreja.IdIgreja));
                cmd.Parameters.Add(new MySqlParameter("idPontoTuristico", igreja.PontoTuristicoIdPontoTuristico));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool atualizarMuseu(Classes.Museu museu)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();

                string query = "BEGIN;" +
                                "UPDATE `equipe431447`.`pontoturistico`" +
                                "SET" +
                                "`tipoPontoTuristico` =   ?tipoPontoTuristico  ," +
                                "`nomePontoTuristico` =   ?nomePontoTuristico  ," +
                                "`contatoPontoTuristico` =   ?contatoPontoTuristico  ," +
                                "`descricaoPontoTuristico` =   ?descricaoPontoTuristico  ," +
                                "`endLogradouroPontoTuristico` =   ?endLogradouroPontoTuristico  ," +
                                "`endTipoPontoTuristico` =   ?endTipoPontoTuristico  ," +
                                "`endNumeroPontoTuristico` =   ?endNumeroPontoTuristico  ," +
                                "`endComplementoPontoTuristico` =   ?endComplementoPontoTuristico  ," +
                                "`endBairroPontoTuristico` =   ?endBairroPontoTuristico  ," +
                                "`endCepPontoTuristico` =   ?endCepPontoTuristico  ," +
                                "`cidadeIdCidade` =   ?cidadeIdCidade  ," +
                                $"`cidadeNome` =   (select nome from cidade where idCidade = {museu.CidadeIdCidade})  ," +
                                $"`cidadeEstado` =   (select estado from cidade where idCidade = {museu.CidadeIdCidade})  " +
                                "WHERE `idPontoTuristico` =   ?idPontoTuristico;" +
                                "UPDATE `equipe431447`.`museu` " +
                                "SET " +
                                "`dataFundacaoMuseu` =   ?dataFundacaoMuseu," +
                                "`valorEntradaMuseu` =   ?valorEntradaMuseu," +
                                "`numeroSalasMuseu` =   ?numeroSalasMuseu " +                                
                                "WHERE `idMuseu` =   ?idMuseu;" +
                                "COMMIT;";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("tipoPontoTuristico", museu.TipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("nomePontoTuristico", museu.NomePontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("contatoPontoTuristico", museu.ContatoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("descricaoPontoTuristico", museu.DescricaoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroPontoTuristico", museu.EndLogradouroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endTipoPontoTuristico", museu.EndTipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endNumeroPontoTuristico", museu.EndNumeroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endComplementoPontoTuristico", museu.EndComplementoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endBairroPontoTuristico", museu.EndBairroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endCepPontoTuristico", museu.EndCepPontoTuristico));                
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", museu.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("dataFundacaoMuseu", museu.DataFundacaoMuseu));
                cmd.Parameters.Add(new MySqlParameter("valorEntradaMuseu", museu.ValorEntradaMuseu));
                cmd.Parameters.Add(new MySqlParameter("numeroSalasMuseu", museu.NumeroSalasMuseu));
                cmd.Parameters.Add(new MySqlParameter("idMuseu", museu.IdMuseu));
                cmd.Parameters.Add(new MySqlParameter("idPontoTuristico", museu.IdPontoTuristico));
                
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool atualizarFundador(Classes.Fundador fund)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();
                string query = "UPDATE `equipe431447`.`fundador` " +
                                "SET " +
                                "`nomeFundador` = ?nomeFundador, " +
                                "`atividadeProfissionalFundador` = ?atividadeProfissionalFundador, " +
                                "`nascimentoFundador` = ?nascimentoFundador, " +
                                $"`morteFundador` = ?morteFundador, " +
                                "`nacionalidadeFundador` = ?nacionalidadeFundador " +
                                "WHERE `idFundador` = ?idFundador;";

            MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("nomeFundador", fund.NomeFundador));
                cmd.Parameters.Add(new MySqlParameter("atividadeProfissionalFundador", fund.AtividadeProfissionalFundador));
                cmd.Parameters.Add(new MySqlParameter("nascimentoFundador", fund.NascimentoFundador));
                if (fund.Morto)
                {
                    cmd.Parameters.Add(new MySqlParameter("morteFundador", fund.MorteFundador));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("morteFundador", "NULL"));
                }
                cmd.Parameters.Add(new MySqlParameter("nacionalidadeFundador", fund.NacionalidadeFundador));
                cmd.Parameters.Add(new MySqlParameter("idFundador", fund.IdFundador));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool atualizarFundadapor(Classes.Igreja igreja, Classes.Fundador fundador)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();

                string query = "UPDATE `equipe431447`.`fundadapor` " +
                                "SET " +
                                "`igrejaIdIgreja` = ?igrejaIdIgreja, " +
                                "`Igreja_PontoTuristico_idPontoTuristico` = ?Igreja_PontoTuristico_idPontoTuristico, " +
                                "`fundadorIdFundador` = ?fundadorIdFundador " +
                                "WHERE `igrejaIdIgreja` = ?igrejaIdIgreja;";


                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("igrejaIdIgreja", igreja.IdIgreja));
                cmd.Parameters.Add(new MySqlParameter("Igreja_PontoTuristico_idPontoTuristico", igreja.IdIgreja));
                cmd.Parameters.Add(new MySqlParameter("fundadorIdFundador", fundador.IdFundador));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool atualizarFundadopor(Classes.Museu museu, Classes.Fundador fundador)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();

                string query = "UPDATE `equipe431447`.`fundadopor` " +
                                "SET " +
                                "`Museu_idMuseu` = ?Museu_idMuseu, " +
                                "`Museu_PontoTuristico_idPontoTuristico` = ?Museu_PontoTuristico_idPontoTuristico, " +
                                "`Fundador_idFundador` = ?Fundador_idFundador " +
                                "WHERE `Museu_idMuseu` = ?Museu_idMuseu;";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("Museu_idMuseu", museu.IdMuseu));
                cmd.Parameters.Add(new MySqlParameter("Museu_PontoTuristico_idPontoTuristico", museu.IdMuseu));
                cmd.Parameters.Add(new MySqlParameter("Fundador_idFundador", fundador.IdFundador));
                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool atualizarCasadeShow(Classes.CasaDeShow cs)
        {
            try
            {
                MySqlConnection con = createConnection();
                con.Open();

                string query = "BEGIN;" +
                                "UPDATE `equipe431447`.`pontoturistico`" +
                                "SET" +
                                "`tipoPontoTuristico` =   ?tipoPontoTuristico  ," +
                                "`nomePontoTuristico` =   ?nomePontoTuristico  ," +
                                "`contatoPontoTuristico` =   ?contatoPontoTuristico  ," +
                                "`descricaoPontoTuristico` =   ?descricaoPontoTuristico  ," +
                                "`endLogradouroPontoTuristico` =   ?endLogradouroPontoTuristico  ," +
                                "`endTipoPontoTuristico` =   ?endTipoPontoTuristico  ," +
                                "`endNumeroPontoTuristico` =   ?endNumeroPontoTuristico  ," +
                                "`endComplementoPontoTuristico` =   ?endComplementoPontoTuristico  ," +
                                "`endBairroPontoTuristico` =   ?endBairroPontoTuristico  ," +
                                "`endCepPontoTuristico` =   ?endCepPontoTuristico  ," +
                                "`cidadeIdCidade` =   ?cidadeIdCidade  ," +
                                $"`cidadeNome` =   (select nome from cidade where idCidade = {cs.CidadeIdCidade})  ," +
                                $"`cidadeEstado` =   (select estado from cidade where idCidade = {cs.CidadeIdCidade})  " +
                                "WHERE `idPontoTuristico` =   ?idPontoTuristico;" +
                                "UPDATE `equipe431447`.`casadeshow`" +
                                "SET" +
                                "`diaFechamentoCasadeShow` =   ?diaFechamentoCasadeShow  ," +
                                "`horaInicioCasadeShow` =   ?horaInicioCasadeShow, " +
                                $"`restauranteIdRestaurante` = {cs.RestauranteIdRestaurante} " +
                                "WHERE `idCasadeShow` =  ?idCasadeShow;" +
                                "COMMIT;";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add(new MySqlParameter("tipoPontoTuristico", cs.TipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("nomePontoTuristico", cs.NomePontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("contatoPontoTuristico", cs.ContatoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("descricaoPontoTuristico", cs.DescricaoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endLogradouroPontoTuristico", cs.EndLogradouroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endTipoPontoTuristico", cs.EndTipoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endNumeroPontoTuristico", cs.EndNumeroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endComplementoPontoTuristico", cs.EndComplementoPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endBairroPontoTuristico", cs.EndBairroPontoTuristico));
                cmd.Parameters.Add(new MySqlParameter("endCepPontoTuristico", cs.EndCepPontoTuristico));                
                cmd.Parameters.Add(new MySqlParameter("cidadeIdCidade", cs.CidadeIdCidade));
                cmd.Parameters.Add(new MySqlParameter("diaFechamentoCasadeShow", cs.DiaFechamentoCasadeShow));                
                cmd.Parameters.Add(new MySqlParameter("horaInicioCasadeShow", cs.HoraInicioCasadeShow));
                cmd.Parameters.Add(new MySqlParameter("idCasadeShow", cs.IdCasadeShow));
                cmd.Parameters.Add(new MySqlParameter("idPontoTuristico", cs.IdCasadeShow));

                Console.WriteLine(cmd.CommandText);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion

    }
} 