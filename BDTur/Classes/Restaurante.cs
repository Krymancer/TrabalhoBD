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
        private float precoMedioRestaurante;
        private string contatoRestauranteo;
        private string endTipoRestaurante;
        private string endLogradouroRestaurante;
        private string endNumeroRestaurante;
        private string endComplementoRestaurante;
        private string endBairroRestaurante;
        private string endCepRestaurante;
        private int cidadeIdCidade;

        public Restaurante(int idRestaurante, string nomeRestaurante, int categoriaRestaurante, string especialidadeRestaurante, float precoMedioRestaurante, string contatoRestauranteo, string endTipoRestaurante, string endLogradouroRestaurante, string endNumeroRestaurante, string endComplementoRestaurante, string endBairroRestaurante, string endCepRestaurante, int cidadeIdCidade)
        {
            this.idRestaurante = idRestaurante;
            this.nomeRestaurante = nomeRestaurante;
            this.categoriaRestaurante = categoriaRestaurante;
            this.especialidadeRestaurante = especialidadeRestaurante;
            this.precoMedioRestaurante = precoMedioRestaurante;
            this.contatoRestauranteo = contatoRestauranteo;
            this.endTipoRestaurante = endTipoRestaurante;
            this.endLogradouroRestaurante = endLogradouroRestaurante;
            this.endNumeroRestaurante = endNumeroRestaurante;
            this.endComplementoRestaurante = endComplementoRestaurante;
            this.endBairroRestaurante = endBairroRestaurante;
            this.endCepRestaurante = endCepRestaurante;
            this.cidadeIdCidade = cidadeIdCidade;
        }

        public int IdRestaurante { get; set; }
        public string NomeRestaurante { get; set; }
        public int CategoriaRestaurante { get; set; }
        public string EspecialidadeRestaurante { get; set; }
        public float PrecoMedioRestaurante { get; set; }
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
