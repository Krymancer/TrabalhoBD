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

        public Fundador(int idFundador, string nomeFundador, string atividadeProfissionalFundador, DateTime nascimentoFundador, DateTime morteFundador, string nacionalidadeFundador, List<PontoTuristico> listPontoTuristicoFundado)
        {
            this.idFundador = idFundador;
            this.nomeFundador = nomeFundador;
            this.atividadeProfissionalFundador = atividadeProfissionalFundador;
            this.nascimentoFundador = nascimentoFundador;
            this.morteFundador = morteFundador;
            this.nacionalidadeFundador = nacionalidadeFundador;
            this.listPontoTuristicoFundado = listPontoTuristicoFundado;
        }

        public int IdFundador { get; set; }
        public string NomeFundador { get; set; }
        public string AtividadeProfissionalFundador { get; set; }
        public DateTime NascimentoFundador { get; set; }
        public DateTime MorteFundador { get; set; }
        public string NacionalidadeFundador { get; set; }
        public List<PontoTuristico> ListPontoTuristicoFundado { get; set; }
    }
}
