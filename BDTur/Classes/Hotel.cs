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
        private string endTipoHotel;
        private string endLogradouroHotel;
        private string endNumeroHotel;
        private string endComplementoHotel;
        private string endBairroHotel;
        private string endCepHotel;

        public Hotel(int idHotel, int cidadeIdCidade, int restauranteIdRestaurante, string nomeHotel, int categoriaHotel, string contatoHotel, string endTipoHotel, string endLogradouroHotel, string endNumeroHotel, string endComplementoHotel, string endBairroHotel, string endCepHotel)
        {
            this.idHotel = idHotel;
            this.cidadeIdCidade = cidadeIdCidade;
            this.restauranteIdRestaurante = restauranteIdRestaurante;
            this.nomeHotel = nomeHotel;
            this.categoriaHotel = categoriaHotel;
            this.contatoHotel = contatoHotel;
            this.endTipoHotel = endTipoHotel;
            this.endLogradouroHotel = endLogradouroHotel;
            this.endNumeroHotel = endNumeroHotel;
            this.endComplementoHotel = endComplementoHotel;
            this.endBairroHotel = endBairroHotel;
            this.endCepHotel = endCepHotel;
        }

        public int IdHotel { get; set; }
        public int CidadeIdCidade { get; set; }
        public int RestauranteIdRestaurante { get; set; }
        public string NomeHotel { get; set; }
        public int CategoriaHotel { get; set; }
        public string ContatoHotel { get; set; }
        public string EndTipoHotel { get; set; }
        public string EndLogradouroHotel { get; set; }
        public string EndNumeroHotel { get; set; }
        public string EndComplementoHotel { get; set; }
        public string EndBairroHotel { get; set; }
        public string EndCepHotel { get; set; }
    }
}
