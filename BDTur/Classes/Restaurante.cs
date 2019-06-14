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
        private string categoriaRestaurante;
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

        public Restaurante(int idRestaurante, string nomeRestaurante, string categoriaRestaurante, string especialidadeRestaurante, float precoMedioRestaurante, string contatoRestauranteo, string endTipoRestaurante, string endLogradouroRestaurante, string endNumeroRestaurante, string endComplementoRestaurante, string endBairroRestaurante, string endCepRestaurante, int cidadeIdCidade)
        {
            this.IdRestaurante = idRestaurante;
            this.NomeRestaurante = nomeRestaurante;
            this.CategoriaRestaurante = categoriaRestaurante;
            this.EspecialidadeRestaurante = especialidadeRestaurante;
            this.PrecoMedioRestaurante = precoMedioRestaurante;
            this.ContatoRestauranteo = contatoRestauranteo;
            this.EndTipoRestaurante = endTipoRestaurante;
            this.EndLogradouroRestaurante = endLogradouroRestaurante;
            this.EndNumeroRestaurante = endNumeroRestaurante;
            this.EndComplementoRestaurante = endComplementoRestaurante;
            this.EndBairroRestaurante = endBairroRestaurante;
            this.EndCepRestaurante = endCepRestaurante;
            this.CidadeIdCidade = cidadeIdCidade;
        }

        public int IdRestaurante { get; set; }
        public string NomeRestaurante { get; set; }
        public string CategoriaRestaurante { get; set; }
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
