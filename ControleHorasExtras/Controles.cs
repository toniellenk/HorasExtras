using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ControleHorasExtras
{
    class Controles
    {
        public static void AlteraArquivo(string UrlArquivo, string Conteudo,bool LimpaTudo)
        {
            if (LimpaTudo)
            {
                StreamWriter Texto = new StreamWriter(UrlArquivo, false);
                Texto.WriteLine(Conteudo);
                Texto.Close();
            }
            else 
            {
                StreamWriter Texto = new StreamWriter(UrlArquivo, true);
                Texto.WriteLine(Conteudo);
                Texto.Close();
            }

        }

        public static Boolean ValidaMensagem(string Mensagem, string Titulo)
        {

            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(Mensagem, Titulo, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public static void LerAquivo(string UrlDiretorio, string NomeArquivo)
        {
            StreamReader Texto;
            string UrlAquivo = UrlDiretorio + NomeArquivo;

            if (File.Exists(UrlAquivo))
            {
                Texto = File.OpenText(UrlAquivo);
                Texto.ReadLine();
                Texto.ReadLine();
                Texto.ReadLine();
                Texto.Close();
            }
            else
            {
                MessageBox.Show("Não existe o arquivo " + NomeArquivo + " no diretório " + UrlDiretorio);
            }
        }

    }
}
