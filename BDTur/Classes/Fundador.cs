using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Fundador
    {
        private int idFundador;
        private string nomeFundador;
        private string atividadeProfissionalFundador;
        private DateTime nascimentoFundador;
        private DateTime morteFundador;
        private string nacionalidadeFundador;
        private List<PontoTuristico> listPontoTuristicoFundado = new List<PontoTuristico>();

        public Fundador(int idFundador, string nomeFundador, string atividadeProfissionalFundador, DateTime nascimentoFundador, bool morto, DateTime morteFundador, string nacionalidadeFundador, List<PontoTuristico> listPontoTuristicoFundado)
        {
            IdFundador = idFundador;
            NomeFundador = nomeFundador;
            AtividadeProfissionalFundador = atividadeProfissionalFundador;
            NascimentoFundador = nascimentoFundador;
            Morto = morto;
            MorteFundador = morteFundador;
            NacionalidadeFundador = nacionalidadeFundador;
            ListPontoTuristicoFundado = listPontoTuristicoFundado;
        }

        public int IdFundador { get; set; }
        public string NomeFundador { get; set; }
        public string AtividadeProfissionalFundador { get; set; }
        public DateTime NascimentoFundador { get; set; }
        public bool Morto { get; set; }
        public DateTime MorteFundador { get; set; }
        public string NacionalidadeFundador { get; set; }
        public List<PontoTuristico> ListPontoTuristicoFundado { get; set; }
    }
}
