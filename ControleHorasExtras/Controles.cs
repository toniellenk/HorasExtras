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
        public static void AlteraArquivo(string UrlArquivo, string Conteudo, bool LimpaTudo)
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

        public static void CriaDiretorio(string UrlDiretorio)
        {
            if (!Directory.Exists(UrlDiretorio))
            {
                Directory.CreateDirectory(UrlDiretorio);
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

        public static Boolean ExisteHorasExtras(string ItemSelecionado)
        {

            if (Directory.Exists(".\\Colaboradores\\" + ItemSelecionado + "\\Horas Extras\\"))
            {
                if (Directory.EnumerateFileSystemEntries(".\\Colaboradores\\" + ItemSelecionado + "\\Horas Extras\\", "*.txt").Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string ConverteMoeda(string Valor)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            Valor = string.Format("{0:C}", Convert.ToDouble(Valor));
            return Valor;
        }

        public static List<List<string>> LerArquivo(string Url)
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

    }


    
}
