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
        private string tipoPontoTuristico;
        private string endTipoPontoTuristico;
        private string endLogradouroPontoTuristico;
        private string endNumeroPontoTuristico;
        private string endComplementoPontoTuristico;
        private string endBairroPontoTuristico;
        private string endCepPontoTuristico;
        private int cidade_idCidade;

        public PontoTuristico(int idPontoTuristico, string tipoPontoTuristico, string endTipoPontoTuristico, string endLogradouroPontoTuristico, string endNumeroPontoTuristico, string endComplementoPontoTuristico, string endBairroPontoTuristico, string endCepPontoTuristico, int cidade_idCidade)
        {
            this.idPontoTuristico = idPontoTuristico;
            this.tipoPontoTuristico = tipoPontoTuristico;
            this.endTipoPontoTuristico = endTipoPontoTuristico;
            this.endLogradouroPontoTuristico = endLogradouroPontoTuristico;
            this.endNumeroPontoTuristico = endNumeroPontoTuristico;
            this.endComplementoPontoTuristico = endComplementoPontoTuristico;
            this.endBairroPontoTuristico = endBairroPontoTuristico;
            this.endCepPontoTuristico = endCepPontoTuristico;
            this.cidade_idCidade = cidade_idCidade;
        }

        public int IdPontoTuristico { get; set; }
        public string TipoPontoTuristico { get; set; }
        public string EndTipoPontoTuristico { get; set; }
        public string EndLogradouroPontoTuristico { get; set; }
        public string EndNumeroPontoTuristico { get; set; }
        public string EndComplementoPontoTuristico { get; set; }
        public string EndBairroPontoTuristico { get; set; }
        public string EndCepPontoTuristico { get; set; }
        public int Cidade_idCidade { get; set; }
    }
}
