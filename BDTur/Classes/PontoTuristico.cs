using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class PontoTuristico
    {
        private int idPontoTuristico;
        private int cidadeIdCidade;
        private string tipoPontoTuristico;
        private string nomePontoTuristico;
        private string contatoPontoTuristico;
        private string descricaoPontoTuristico;
        private string endLogradouroPontoTuristico;
        private string endTipoPontoTuristico;
        private string endNumeroPontoTuristico;
        private string endComplementoPontoTuristico;
        private string endBairroPontoTuristico;
        private string endCepPontoTuristico;

        

        public PontoTuristico(int idPontoTuristico, string tipoPontoTuristico, string nomePontoTuristico, string contatoPontoTuristico, string descricaoPontoTuristico, string endTipoPontoTuristico, string endLogradouroPontoTuristico, string endNumeroPontoTuristico, string endComplementoPontoTuristico, string endBairroPontoTuristico, string endCepPontoTuristico, int cidadeIdCidade)
        {
            this.idPontoTuristico = idPontoTuristico;
            this.nomePontoTuristico = nomePontoTuristico;
            this.contatoPontoTuristico = contatoPontoTuristico;
            this.descricaoPontoTuristico = descricaoPontoTuristico;
            this.tipoPontoTuristico = tipoPontoTuristico;
            this.endTipoPontoTuristico = endTipoPontoTuristico;
            this.endLogradouroPontoTuristico = endLogradouroPontoTuristico;
            this.endNumeroPontoTuristico = endNumeroPontoTuristico;
            this.endComplementoPontoTuristico = endComplementoPontoTuristico;
            this.endBairroPontoTuristico = endBairroPontoTuristico;
            this.endCepPontoTuristico = endCepPontoTuristico;
            this.cidadeIdCidade = cidadeIdCidade;
        }

        public int IdPontoTuristico { get; set; }
        public string TipoPontoTuristico { get; set; }
        public string NomePontoTuristico { get; set; }
        public string ContatoPontoTuristico { get; set; }
        public string DescricaoPontoTuristico { get; set; }
        public string EndTipoPontoTuristico { get; set; }
        public string EndLogradouroPontoTuristico { get; set; }
        public string EndNumeroPontoTuristico { get; set; }
        public string EndComplementoPontoTuristico { get; set; }
        public string EndBairroPontoTuristico { get; set; }
        public string EndCepPontoTuristico { get; set; }
        public int CidadeIdCidade { get; set; }
    }
}
