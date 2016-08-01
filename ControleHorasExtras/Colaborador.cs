using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControleHorasExtras
{
    public class Colaborador
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Salario { get; set; }

        public string UrlDiretorio() {
                return ".\\Colaboradores\\" + Nome + " " + Sobrenome + "\\Dados\\";
        }


        public static List<Colaborador> CarregaColaboradores()
        {

                        DirectoryInfo DiretorioInicial = new DirectoryInfo(".\\Colaboradores\\");
                        DirectoryInfo[] ListaPastasDiretorioAtual = DiretorioInicial.GetDirectories();
                        var ListaColaboradores = new List<Colaborador>();


                        foreach (DirectoryInfo Dir in ListaPastasDiretorioAtual)
                        {
                            ListaPastasDiretorioAtual = Dir.GetDirectories("Dados");
                                foreach (DirectoryInfo Dir2 in ListaPastasDiretorioAtual)
                                {
                                        FileInfo[] NomesArquivos = Dir2.GetFiles("*.txt*");
                                        foreach (FileInfo fi in NomesArquivos)
                                            {
                                                Colaborador ObjColaborador = new Colaborador();
                                                StreamReader Texto = new StreamReader(".\\Colaboradores\\"+ Dir.Name + "\\" + Dir2.Name + "\\"+ fi.Name);
                                                ObjColaborador.Nome = Texto.ReadLine();
                                                ObjColaborador.Sobrenome = Texto.ReadLine();
                                                ObjColaborador.Salario = Texto.ReadLine();
                                                Texto.Close();
                                               // ObjColaborador.UrlDiretorio = "";
                                                ListaColaboradores.Add(ObjColaborador);
                                            }
                                 }   
            }
                        return ListaColaboradores;

        }

    }
}
