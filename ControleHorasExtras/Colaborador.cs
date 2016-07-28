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

        public const string UrlDiretorio = ".\\Colaboradores\\";

        public List<Colaborador> CarregaColaboradores()
        {
            DirectoryInfo InfoDiretorio = new DirectoryInfo(Colaborador.UrlDiretorio);
            FileInfo[] NomesArquivos = InfoDiretorio.GetFiles("*.txt*");
            var ListaColaboradores = new List<Colaborador>();


            foreach (FileInfo fi in NomesArquivos)
                {
                    Colaborador ObjColaborador = new Colaborador();
                    StreamReader Texto = new StreamReader(Colaborador.UrlDiretorio + fi.Name);
                    ObjColaborador.Nome = Texto.ReadLine();
                    ObjColaborador.Sobrenome = Texto.ReadLine();
                    ObjColaborador.Salario = Texto.ReadLine();
                    Texto.Close();
                    ListaColaboradores.Add(ObjColaborador);
                }
            return ListaColaboradores;
        }

    }
}
