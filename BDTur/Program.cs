using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDTur.Classes;

namespace BDTur
{

    static class Program
    {

        static public string databaseUser, databasePassword;
        static public int AcessLevel;

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.FormLogin());            
        }
    }
}
