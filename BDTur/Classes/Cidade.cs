using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class Cidade
    {

        Classes.Connection userCon = new Classes.Connection(Program.databaseUser, Program.databasePassword);

        int id        { get; set; }
        string nome   { get; set; }
        string estado { get; set; }
        int populacao { get; set; }

    }
}
