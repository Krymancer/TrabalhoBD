using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class CasaDeShow : PontoTuristico
    {
        private int idCasadeShow;
        private string diaFechamentoCasadeShow;
        private string horaInicioCasadeShow;
        private int pontoTuristicoIdPontoTuristico;
        private int restauranteIdRestaurante;

        public CasaDeShow(int idCasadeShow, string diaFechamentoCasadeShow, string horaInicioCasadeShow, int pontoTuristicoIdPontoTuristico, int restauranteIdRestaurante, int idPontoTuristico, string tipoPontoTuristico, string nomePontoTuristico, string contatoPontoTuristico, string descricaoPontoTuristico, string endTipoPontoTuristico, string endLogradouroPontoTuristico, string endNumeroPontoTuristico, string endComplementoPontoTuristico, string endBairroPontoTuristico, string endCepPontoTuristico, int cidadeIdCidade)
            : base(idPontoTuristico, tipoPontoTuristico, nomePontoTuristico, contatoPontoTuristico, descricaoPontoTuristico, endTipoPontoTuristico, endLogradouroPontoTuristico, endNumeroPontoTuristico, endComplementoPontoTuristico, endBairroPontoTuristico, endCepPontoTuristico, cidadeIdCidade)
        {
            this.idCasadeShow = idCasadeShow;
            this.diaFechamentoCasadeShow = diaFechamentoCasadeShow;
            this.horaInicioCasadeShow = horaInicioCasadeShow;
            this.pontoTuristicoIdPontoTuristico = pontoTuristicoIdPontoTuristico;
            this.restauranteIdRestaurante = restauranteIdRestaurante;
        }

        public int IdCasadeShow { get; set; }
        public string DiaFechamentoCasadeShow { get; set; }
        public string HoraInicioCasadeShow { get; set; }
        public int PontoTuristicoIdPontoTuristico { get; set; }
        public int RestauranteIdRestaurante { get; set; }
    }
}
