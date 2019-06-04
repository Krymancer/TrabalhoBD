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

        private MySqlDataAdapter fetchResultFromQuery(string query)
        {
            try
            {
                Classes.Connection connection = new Classes.Connection(Program.databaseUser, Program.databasePassword);
                MySqlConnection con = connection.getConnection();
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

        public  MySqlDataAdapter hotelAdapter()
        {

            string query = "SELECT " +
                                "`hotel`.`idHotel`," +
                                "`hotel`.`nomeHotel`," +
                                "`hotel`.`categoriaHotel`," +
                                "`hotel`.`endTipoHotel`," +
                                "`hotel`.`endLogradouroHotel`," +
                                "`hotel`.`endNumeroHotel`," +
                                "`hotel`.`endComplementoHotel`," +
                                "`hotel`.`endBairroHotel` " +
                            "FROM " +
                                "`equipe431447`.`hotel`;";

            return fetchResultFromQuery(query);

        }
        public  MySqlDataAdapter restauranteAdapter()
        {
            string query = "SELECT " +
                                "`restaurante`.`idRestaurante`," +
                                "`restaurante`.`nomeRestaurante`," +
                                "`restaurante`.`categoriaRestaurante`," +
                                "`restaurante`.`especialidadeRestaurante`," +
                                "`restaurante`.`precoMedioRestaurante`," +
                                "`restaurante`.`endTipoRestaurante`," +
                                "`restaurante`.`endLogradouroRestaurante`," +
                                "`restaurante`.`endNumeroRestaurante`," +
                                "`restaurante`.`endComplementoRestaurante`," +
                                "`restaurante`.`endBairroRestaurante` " +
                            "FROM " +
                                "`equipe431447`.`restaurante`;";

            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter pontoTuristicoAdapter()
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
                                "`equipe431447`.`pontoturistico`;";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter igrejaAdapater()
        {
            string query = "SELECT " +
                                "`pontoturistico`.`idPontoTuristico`," +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`igreja`.`dataIgreja`," +
                                "`igreja`.`estiloIgreja`,  " +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico`" +
                            "FROM" +
                                "`equipe431447`.`pontoturistico` " +
                                "INNER JOIN `equipe431447`.`igreja` " +
                            "ON `equipe431447`.`igreja`.`PontoTuristico_idPontoTuristico` =  `equipe431447`.`pontoturistico`.`idPontoTuristico`;";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter casadeShowAdapater()
        {
            string query = "SELECT " +
                                "`pontoturistico`.`idPontoTuristico`," +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`casa_de_show`.`diaFechamentoCasadeShow`," +
                                "`casa_de_show`.`horaInicioCasadeShow`," +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico` " +
                            "FROM " +
                                "`equipe431447`.`pontoturistico` " +
                            "INNER JOIN `equipe431447`.`casa_de_show` " +
                            "ON `equipe431447`.`casa_de_show`.`PontoTuristico_idPontoTuristico` =  `equipe431447`.`pontoturistico`.`idPontoTuristico`;";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter museuAdapater()
        {
            string query = "SELECT " +
                                "`pontoturistico`.`idPontoTuristico`" +
                                "`pontoturistico`.`nomePontoTuristico`," +
                                "`pontoturistico`.`contatoPontoTuristico`," +
                                "`pontoturistico`.`descricaoPontoTuristico`," +
                                "`museu`.`numeroSalasMuseu`," +
                                "`museu`.`valorEntradaMuseu`," +
                                "`pontoturistico`.`endLogradouroPontoTuristico`," +
                                "`pontoturistico`.`endTipoPontoTuristico`," +
                                "`pontoturistico`.`endNumeroPontoTuristico`," +
                                "`pontoturistico`.`endComplementoPontoTuristico`," +
                                "`pontoturistico`.`endBairroPontoTuristico`" +
                            "FROM" +
                                "`equipe431447`.`pontoturistico` " +
                            "INNER JOIN `equipe431447`.`museu` " +
                            "ON `equipe431447`.`museu`.`PontoTuristico_idPontoTuristico` =  `equipe431447`.`pontoturistico`.`idPontoTuristico`;";
            return fetchResultFromQuery(query);
        }
        public  MySqlDataAdapter fundadorAdapter()
        {
            string query = "SELECT `fundador`.`idFundador`," +
                                "`fundador`.`nomeFundador`," +
                                "`fundador`.`atividadeProfissionalFundador`," +
                                "`fundador`.`nascimentoFundador`," +
                                "`fundador`.`morteFundador`," +
                                "`fundador`.`nacionalidadeFundador`" +
                            "FROM `equipe431447`.`fundador`;";
            return fetchResultFromQuery(query);

        }
    }
}
