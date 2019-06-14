using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Restaurante
    {
        private int idRestaurante;
        private string nomeRestaurante ;
        private int categoriaRestaurante;
        private string especialidadeRestaurante;
        private double precoMedioRestaurante;
        private string contatoRestauranteo;
        private string endTipoRestaurante;
        private string endLogradouroRestaurante;
        private string endNumeroRestaurante;
        private string endComplementoRestaurante;
        private string endBairroRestaurante;
        private string endCepRestaurante;
        private int cidadeIdCidade;

        public Restaurante(int idRestaurante, string nomeRestaurante, int categoriaRestaurante, string especialidadeRestaurante, double precoMedioRestaurante, string contatoRestaurante, string endTipoRestaurante, string endLogradouroRestaurante, string endNumeroRestaurante, string endComplementoRestaurante, string endBairroRestaurante, string endCepRestaurante, int cidadeIdCidade)
        {
            IdRestaurante = idRestaurante;
            NomeRestaurante = nomeRestaurante;
            CategoriaRestaurante = categoriaRestaurante;
            EspecialidadeRestaurante = especialidadeRestaurante;
            PrecoMedioRestaurante = precoMedioRestaurante;
            ContatoRestauranteo = contatoRestaurante;
            EndTipoRestaurante = endTipoRestaurante;
            EndLogradouroRestaurante = endLogradouroRestaurante;
            EndNumeroRestaurante = endNumeroRestaurante;
            EndComplementoRestaurante = endComplementoRestaurante;
            EndBairroRestaurante = endBairroRestaurante;
            EndCepRestaurante = endCepRestaurante;
            CidadeIdCidade = cidadeIdCidade;
        }

        public int IdRestaurante { get; set; }
        public string NomeRestaurante { get; set; }
        public int CategoriaRestaurante { get; set; }
        public string EspecialidadeRestaurante { get; set; }
        public double PrecoMedioRestaurante { get; set; }
        public string ContatoRestauranteo { get; set; }
        public string EndTipoRestaurante { get; set; }
        public string EndLogradouroRestaurante { get; set; }
        public string EndNumeroRestaurante { get; set; }
        public string EndComplementoRestaurante { get; set; }
        public string EndBairroRestaurante { get; set; }
        public string EndCepRestaurante { get; set; }
        public int CidadeIdCidade { get; set; }





        
    }
}
