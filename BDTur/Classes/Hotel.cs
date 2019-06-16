using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Hotel
    {
        private int idHotel;
        private int cidadeIdCidade;
        private int restauranteIdRestaurante;
        private string nomeHotel;
        private int categoriaHotel;
        private string contatoHotel;
        private int endTipoHotel;
        private string endLogradouroHotel;
        private string endNumeroHotel;
        private string endComplementoHotel;
        private string endBairroHotel;
        private string endCepHotel;

        public Hotel(int idHotel, int cidadeIdCidade, string restauranteIdRestaurante, string nomeHotel, string categoriaHotel, string contatoHotel, string endTipoHotel, string endLogradouroHotel, string endNumeroHotel, string endComplementoHotel, string endBairroHotel, string endCepHotel)
        {
            IdHotel = idHotel;
            CidadeIdCidade = cidadeIdCidade;
            RestauranteIdRestaurante = restauranteIdRestaurante;
            NomeHotel = nomeHotel;
            CategoriaHotel = categoriaHotel;
            ContatoHotel = contatoHotel;
            EndTipoHotel = endTipoHotel;
            EndLogradouroHotel = endLogradouroHotel;
            EndNumeroHotel = endNumeroHotel;
            EndComplementoHotel = endComplementoHotel;
            EndBairroHotel = endBairroHotel;
            EndCepHotel = endCepHotel;
        }

        public int IdHotel { get; set; }
        public int CidadeIdCidade { get; set; }
        public string RestauranteIdRestaurante { get; set; }
        public string NomeHotel { get; set; }
        public string CategoriaHotel { get; set; }
        public string ContatoHotel { get; set; }
        public string EndTipoHotel { get; set; }
        public string EndLogradouroHotel { get; set; }
        public string EndNumeroHotel { get; set; }
        public string EndComplementoHotel { get; set; }
        public string EndBairroHotel { get; set; }
        public string EndCepHotel { get; set; }
    }
}
