using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Cidade
    {
        private int idCidade;
        private string nome;
        private string estado;
        private int populacao;

        public Cidade(int idCidade, string nome, string estado, string populacao)
        {
            IdCidade = idCidade;
            Nome = nome;
            Estado = estado;
            Populacao = populacao;
        }

        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Populacao { get; set; }

    }
}
