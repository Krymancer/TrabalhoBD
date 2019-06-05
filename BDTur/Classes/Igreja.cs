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

        //TODO
        //verificar no banco se precisa ter chave estrangeira do pontoturistico e chave primaria de igreja.

        public Igreja(int idPontoTuristico, string tipoPontoTuristico, string nomePontoTuristico, string contatoPontoTuristico, string descricaoPontoTuristico, string endTipoPontoTuristico, string endLogradouroPontoTuristico, string endNumeroPontoTuristico, string endComplementoPontoTuristico, string endBairroPontoTuristico, string endCepPontoTuristico, int cidadeIdCidade)
            : base(idPontoTuristico, tipoPontoTuristico, nomePontoTuristico, contatoPontoTuristico, descricaoPontoTuristico, endTipoPontoTuristico, endLogradouroPontoTuristico, endNumeroPontoTuristico, endComplementoPontoTuristico, endBairroPontoTuristico, endCepPontoTuristico, cidadeIdCidade)
        {

        }
    }
}
