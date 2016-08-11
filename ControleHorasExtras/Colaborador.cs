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
                                if (DadosColaboradores[4] == "") {
                                    DadosColaboradores[4] = "0";
                                }
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

        public static List<string> CarregaUnicoColaborador(List<List<string>> Listas, string ID)
        {
            var ListaColaboradores = new List<string>();
            foreach (List<string> DadosColaboradores in Listas)
            {
                if (DadosColaboradores[0] == "A" && DadosColaboradores[1] == ID)
                {
                    ListaColaboradores.Add(DadosColaboradores[2]);
                    ListaColaboradores.Add(DadosColaboradores[3]);
                    ListaColaboradores.Add(DadosColaboradores[4]);
                }
            }
            return ListaColaboradores;
        }

        public static int RetornaNovoID(List<List<string>> Listas)
        {
            int Valor = 1;
            var ListColaboradores = new List<int>();
            foreach (List<string> DadosHoraExtra in Listas)
            {
                if (DadosHoraExtra[0] == "A")
                {
                    ListColaboradores.Add(Convert.ToInt32(DadosHoraExtra[1]));
                }
            }
            if (ListColaboradores.Count > 0)
            {
                Valor = ListColaboradores.Max() + 1;
            }
            return Valor;
        }
        public static void ExcluiColaborador(List<List<string>> Listas, string ID)
        {
            int Indice = 0;
            foreach (List<string> DadosHoraExtra in Listas)
            {
                if (DadosHoraExtra[0] == "A" && DadosHoraExtra[1] == ID)
                {
                    Indice = Listas.IndexOf(DadosHoraExtra);
                }
            }
            Listas.RemoveAt(Indice);
        }
        public static void AdicionaAlteraColaborador(List<List<string>> Listas, Colaborador ObjColaborador)
        {
            bool AchouAlguem = false;
            foreach (List<string> ListaGeral in Listas)
            {
                if (ListaGeral[0] == "A")
                {
                    if (ListaGeral[1] == ObjColaborador.Id)
                    {
                        ListaGeral[2] = ObjColaborador.Nome;
                        ListaGeral[3] = ObjColaborador.Sobrenome;
                        ListaGeral[4] = ObjColaborador.Salario;
                        AchouAlguem = true;
                    }


                }

            }
            if (!AchouAlguem)
            {
                var ListaQueSeraAdicionada = new List<string>();
                ListaQueSeraAdicionada.Add("A");
                ListaQueSeraAdicionada.Add(ObjColaborador.Id);
                ListaQueSeraAdicionada.Add(ObjColaborador.Nome);
                ListaQueSeraAdicionada.Add(ObjColaborador.Sobrenome);
                ListaQueSeraAdicionada.Add(ObjColaborador.Salario);
                Listas.Add(ListaQueSeraAdicionada);
            }
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
