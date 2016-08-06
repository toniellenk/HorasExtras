using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ControleHorasExtras
{
    public class Colaborador
    {
                public string IdColaborador { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Salario { get; set; }

        public string UrlDiretorio() {
                return ".\\Dados\\Colaboradores.txt";
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
                                                ListaColaboradores.Add(ObjColaborador);
                                            }
                                 }   
            }
                        return ListaColaboradores;

        }

        public static List<string> CarregaColaboradoresSomenteNomes()
        {

            DirectoryInfo DiretorioInicial = new DirectoryInfo(".\\Colaboradores\\");
            DirectoryInfo[] ListaPastasDiretorioAtual = DiretorioInicial.GetDirectories();
            var ListaColaboradores = new List<string>();
            ListaColaboradores.Add("Todos");

            foreach (DirectoryInfo Dir in ListaPastasDiretorioAtual)
            {
                ListaPastasDiretorioAtual = Dir.GetDirectories("Dados");
                foreach (DirectoryInfo Dir2 in ListaPastasDiretorioAtual)
                {
                    FileInfo[] NomesArquivos = Dir2.GetFiles("*.txt*");
                    foreach (FileInfo fi in NomesArquivos)
                    {
                        StreamReader Texto = new StreamReader(".\\Colaboradores\\" + Dir.Name + "\\" + Dir2.Name + "\\" + fi.Name);
                        ListaColaboradores.Add(Texto.ReadLine() +" "+ Texto.ReadLine());
                        Texto.Close();
                    }
                }
            }
            return ListaColaboradores;

        }


    }
}
