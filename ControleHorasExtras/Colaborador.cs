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
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Salario { get; set; }


        public static string UrlDiretorio {
            get { return ".\\Dados\\Dados.txt"; }
        }

        public static List<Colaborador> CarregaColaboradores(List<List<string>> Listas)
        {
           var ListaColaboradores = new List<Colaborador>();
                        foreach (List<string> DadosColaboradores in Listas)
                        {
                            if (DadosColaboradores[0] == "A")
                            {
                                Colaborador ObjColaborador = new Colaborador();
                                ObjColaborador.Id = DadosColaboradores[1];
                                ObjColaborador.Nome = DadosColaboradores[2];
                                ObjColaborador.Sobrenome = DadosColaboradores[3];
                                ObjColaborador.Salario = Controles.ConverteMoeda(DadosColaboradores[4]);
                                ListaColaboradores.Add(ObjColaborador);
                            }
                        }
            return ListaColaboradores;

        }

        public static List<string> CarregaColaboradoresSomenteIDeNomes(List<List<string>> Listas)
        {
            var ListaColaboradores = new List<string>();
            foreach (List<string> DadosColaboradores in Listas)
            {
                if (DadosColaboradores[0] == "A")
                {
                    ListaColaboradores.Add(DadosColaboradores[1] + " - " + DadosColaboradores[2] + " " + DadosColaboradores[3]);
                }
            }
            return ListaColaboradores;
        }

        public static void AdicionaColaborador(List<List<string>> Listas, Colaborador ObjColaborador)
        {
            var ListaQueSeraAdicionada = new List<string>();
                ListaQueSeraAdicionada.Add("A");
                ListaQueSeraAdicionada.Add(ObjColaborador.Id);
                ListaQueSeraAdicionada.Add(ObjColaborador.Nome);
                ListaQueSeraAdicionada.Add(ObjColaborador.Sobrenome);
                ListaQueSeraAdicionada.Add(ObjColaborador.Salario);
            Listas.Add(ListaQueSeraAdicionada);
        }
        public static decimal SalarioTotal(List<List<string>> Listas)
        {
            decimal SalarioTotal = 0;
            var ListaColaboradores = new List<string>();
            foreach (List<string> DadosColaboradores in Listas)
            {
                if (DadosColaboradores[0] == "A")
                {
                    SalarioTotal += Convert.ToDecimal(DadosColaboradores[4]);
                }
            }
            return SalarioTotal;
        }

    }
}
