using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ControleHorasExtras
{
    class HorasExtras
    {
        public string NomeColaborador { get; set; }
        public string DataInicial { get; set; }
        public string HoraInicial { get; set; }

        public string DataFinal { get; set; }
        public string HoraFinal { get; set; }

        public static string UrlDiretorio()
        {
            return ".\\Colaboradores\\"; 
        }

        public static List<HorasExtras> CarregaHorasExtras()
        {

            DirectoryInfo DiretorioInicial = new DirectoryInfo(".\\Colaboradores\\");
            DirectoryInfo[] ListaPastasDiretorioAtual = DiretorioInicial.GetDirectories();
            string DataHoraInicial;
            string DataHoraFinal;
            var ListaHorasExtras = new List<HorasExtras>();


            foreach (DirectoryInfo Dir in ListaPastasDiretorioAtual)
            {
                ListaPastasDiretorioAtual = Dir.GetDirectories("Horas Extras");
                foreach (DirectoryInfo Dir2 in ListaPastasDiretorioAtual)
                {
                    FileInfo[] NomesArquivos = Dir2.GetFiles("*.txt*");
                    foreach (FileInfo fi in NomesArquivos)
                    {
                        HorasExtras ObjHorasExtras = new HorasExtras();
                        StreamReader Texto = new StreamReader(".\\Colaboradores\\" + Dir.Name + "\\" + Dir2.Name + "\\" + fi.Name);
                        ObjHorasExtras.NomeColaborador = Texto.ReadLine();
                        DataHoraInicial = Texto.ReadLine();
                        DataHoraFinal = Texto.ReadLine();
                        ObjHorasExtras.DataInicial = DataHoraInicial.Trim().Substring(0, 10);
                        ObjHorasExtras.HoraInicial = DataHoraInicial.Trim().Substring(11, 5);
                        ObjHorasExtras.DataFinal = DataHoraFinal.Trim().Substring(0, 10);
                        ObjHorasExtras.HoraFinal = DataHoraFinal.Trim().Substring(11, 5);
                        Texto.Close();
                        ListaHorasExtras.Add(ObjHorasExtras);

                    }
                }
            }
            return ListaHorasExtras;

        }
        public static List<HorasExtras> CarregaHorasExtras(string NomeColaborador)
        {

            DirectoryInfo DiretorioInicial = new DirectoryInfo(".\\Colaboradores\\"+ NomeColaborador +"\\Horas Extras\\");
            DirectoryInfo[] ListaPastasDiretorioAtual = DiretorioInicial.GetDirectories();
            string DataHoraInicial;
            string DataHoraFinal;
            var ListaHorasExtras = new List<HorasExtras>();


            FileInfo[] NomesArquivos = DiretorioInicial.GetFiles("*.txt*");
                    foreach (FileInfo fi in NomesArquivos)
                    {
                        HorasExtras ObjHorasExtras = new HorasExtras();
                        StreamReader Texto = new StreamReader(".\\Colaboradores\\"+ NomeColaborador +"\\Horas Extras\\" + fi.Name);
                        ObjHorasExtras.NomeColaborador = Texto.ReadLine();
                        DataHoraInicial = Texto.ReadLine();
                        DataHoraFinal = Texto.ReadLine();
                        ObjHorasExtras.DataInicial = DataHoraInicial.Trim().Substring(0, 10);
                        ObjHorasExtras.HoraInicial = DataHoraInicial.Trim().Substring(11, 5);
                        ObjHorasExtras.DataFinal = DataHoraFinal.Trim().Substring(0, 10);
                        ObjHorasExtras.HoraFinal = DataHoraFinal.Trim().Substring(11, 5);
                        Texto.Close();
                        ListaHorasExtras.Add(ObjHorasExtras);

                    }
            return ListaHorasExtras;

        }


    }
}
