using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Reflection;

namespace ControleHorasExtras
{
    class Controles
    {
        public static string UrlDiretorio
        {
            get { return ".\\Dados\\Dados.txt"; }
        }
        public static string ConverteMoeda(string Valor)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            Valor = string.Format("{0:C}", Convert.ToDouble(Valor));
            return Valor;
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

        public static List<List<string>> Dados(string Url)
        {
            var linhas = new List<List<string>>();          
           
                    try {
                        if (File.Exists(Url))
                                using (StreamReader sr = new StreamReader(Url))
                                    {
                                        string line;
                                        while ((line = sr.ReadLine()) != null)
                                        {
                                            List<string> linha = new List<string>();
                                            var valorLinha = line.Split('|');
                                            for (int indice = 0; indice <= valorLinha.Length - 1; indice++)
                                            {
                                                linha.Add(valorLinha[indice]);
                                            }
                                            linhas.Add(linha);                                            
                                        }
                                        return linhas;
                                        
                                    }
                        else
                        {
                            MessageBox.Show("Não existe o arquivo Dados.txt no diretório .\\Dados\\");
                            return null;
                        }    
                                
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return null;
                    }
   
        }


        public static void GravaDados(List<List<string>> Dados)
            {
            var ListaHorasExtras = new List<HorasExtras>();
            StreamWriter Texto = new StreamWriter(Controles.UrlDiretorio, false);            
                    foreach (List<string> DadosColaboradores in Dados)
                        {
                                string Linha = string.Join("|", DadosColaboradores);
                                Texto.WriteLine(Linha);
                        }
            Texto.Close();
            }
     
    }   
}
