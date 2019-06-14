using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Museu : PontoTuristico
    {
        private int idMuseu;
        private DateTime dataFundacaoMuseu;
        private float valorEntradaMuseu;
        private string numeroSalasMuseu;
        private int pontoTuristicoIdPontoTuristico;
        private List<Fundador> listFundadorMuseu = new List<Fundador>();
    

        public Museu(int idMuseu, DateTime dataFundacaoMuseu, float valorEntradaMuseu, string numeroSalasMuseu, List<Fundador> listFundadorMuseu, int idPontoTuristico, string tipoPontoTuristico, string nomePontoTuristico, string contatoPontoTuristico, string descricaoPontoTuristico, string endTipoPontoTuristico, string endLogradouroPontoTuristico, string endNumeroPontoTuristico, string endComplementoPontoTuristico, string endBairroPontoTuristico, string endCepPontoTuristico, int cidadeIdCidade) 
            : base (idPontoTuristico, tipoPontoTuristico, nomePontoTuristico, contatoPontoTuristico, descricaoPontoTuristico, endTipoPontoTuristico, endLogradouroPontoTuristico, endNumeroPontoTuristico, endComplementoPontoTuristico, endBairroPontoTuristico, endCepPontoTuristico, cidadeIdCidade)
        {
            IdMuseu = idMuseu;
            DataFundacaoMuseu = dataFundacaoMuseu;
            ValorEntradaMuseu = valorEntradaMuseu;
            NumeroSalasMuseu = numeroSalasMuseu;
            PontoTuristicoIdPontoTuristico = idPontoTuristico;
            ListFundadorMuseu = listFundadorMuseu;
        }

        public int IdMuseu { get; set; }
        public DateTime DataFundacaoMuseu { get; set; }
        public float ValorEntradaMuseu { get; set; }
        public string NumeroSalasMuseu { get; set; }
        public int PontoTuristicoIdPontoTuristico { set;  get; }
        public List<Fundador> ListFundadorMuseu { set; get; }
    }
}
