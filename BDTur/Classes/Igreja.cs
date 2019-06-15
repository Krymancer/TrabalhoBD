using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Igreja : PontoTuristico
    {
        private int idIgreja;
        private DateTime dataIgreja;
        private string estiloIgreja;
        private int pontoTuristicoIdPontoTuristico;
        private List<Fundador> listFundadorIgreja = new List<Fundador>();


        public Igreja(int idIgreja, DateTime dataIgreja, string estiloIgreja, List<Fundador> listFundadorIgreja,  int idPontoTuristico, string tipoPontoTuristico, string nomePontoTuristico, string contatoPontoTuristico, string descricaoPontoTuristico, string endTipoPontoTuristico, string endLogradouroPontoTuristico, string endNumeroPontoTuristico, string endComplementoPontoTuristico, string endBairroPontoTuristico, string endCepPontoTuristico, int cidadeIdCidade)
            : base(idPontoTuristico, tipoPontoTuristico, nomePontoTuristico, contatoPontoTuristico, descricaoPontoTuristico, endTipoPontoTuristico, endLogradouroPontoTuristico, endNumeroPontoTuristico, endComplementoPontoTuristico, endBairroPontoTuristico, endCepPontoTuristico, cidadeIdCidade)
        {
            IdIgreja = idIgreja;
            DataIgreja = dataIgreja;
            EstiloIgreja = estiloIgreja;
            PontoTuristicoIdPontoTuristico = idPontoTuristico;
            ListFundadorIgreja = listFundadorIgreja;
            TipoPontoTuristico = "Igreja";
        }

        public int IdIgreja { get; set; }
        public DateTime DataIgreja { get; set; }
        public string EstiloIgreja { get; set; }
        public int PontoTuristicoIdPontoTuristico { get; set; }
        public List<Fundador> ListFundadorIgreja { set; get; }
    }
}
