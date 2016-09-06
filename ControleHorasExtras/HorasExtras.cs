using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ControleHorasExtras
{
    public class HorasExtras
    {
        public string IdHoraExtra { get; set; }
        public string IdColaborador { get; set; }
        public string NomeColaborador { get; set; }
        public string DataInicial { get; set; }
        public string HoraInicial { get; set; }

        public string DataFinal { get; set; }
        public string HoraFinal { get; set; }

        public static List<HorasExtras> CarregaHorasExtras(List<List<string>> Listas)
        {
            var ListaHorasExtras = new List<HorasExtras>();
            foreach (List<string> DadosColaboradores in Listas)
                        {
                            if (DadosColaboradores[0] == "A")
                            {
                                foreach (List<string> DadosHorasExtrasColaboradores in Listas)
                                        {
                                            if ((DadosHorasExtrasColaboradores[0] == "B") && (DadosHorasExtrasColaboradores[1] == DadosColaboradores[1]))
                                            {
                                                HorasExtras ObjHorasExtras = new HorasExtras();
                                                ObjHorasExtras.IdColaborador = DadosColaboradores[1];
                                                ObjHorasExtras.NomeColaborador = DadosColaboradores[2] + " " + DadosColaboradores[3];
                                                ObjHorasExtras.IdHoraExtra = DadosHorasExtrasColaboradores[2];
                                                ObjHorasExtras.DataInicial = DadosHorasExtrasColaboradores[3].Substring(0, 10);
                                                ObjHorasExtras.HoraInicial = DadosHorasExtrasColaboradores[3].Substring(11, 5);
                                                ObjHorasExtras.DataFinal = DadosHorasExtrasColaboradores[4].Substring(0, 10);
                                                ObjHorasExtras.HoraFinal = DadosHorasExtrasColaboradores[4].Substring(11, 5);
                                                ListaHorasExtras.Add(ObjHorasExtras);
                                            }
                                        }
                            }
                        }
           return ListaHorasExtras;
        }
        public static List<HorasExtras> CarregaHorasExtras(List<List<string>> Listas, string IdColaborador)
        {

            var ListaHorasExtras = new List<HorasExtras>();
            foreach (List<string> DadosColaboradores in Listas)
            {
                if (DadosColaboradores[0] == "A" && DadosColaboradores[1] == IdColaborador)
                {
                    foreach (List<string> DadosHorasExtrasColaboradores in Listas)
                    {
                        if ((DadosHorasExtrasColaboradores[0] == "B") && (DadosHorasExtrasColaboradores[1] == IdColaborador))
                        {
                            HorasExtras ObjHorasExtras = new HorasExtras();
                            ObjHorasExtras.IdColaborador = DadosColaboradores[1];
                            ObjHorasExtras.NomeColaborador = DadosColaboradores[2] + " " + DadosColaboradores[3];
                            ObjHorasExtras.IdHoraExtra = DadosHorasExtrasColaboradores[2];
                            ObjHorasExtras.DataInicial = DadosHorasExtrasColaboradores[3].Substring(0, 10);
                            ObjHorasExtras.HoraInicial = DadosHorasExtrasColaboradores[3].Substring(11, 5);
                            ObjHorasExtras.DataFinal = DadosHorasExtrasColaboradores[4].Substring(0, 10);
                            ObjHorasExtras.HoraFinal = DadosHorasExtrasColaboradores[4].Substring(11, 5);
                            ListaHorasExtras.Add(ObjHorasExtras);
                        }
                    }
                }
            }
            return ListaHorasExtras;
        }
        public static List<string> CarregaUnicaHoraExtra(List<List<string>> Listas, string ID)
        {
            var ListHorasExtras = new List<string>();
            foreach (List<string> DadosHoraExtra in Listas)
            {
                if (DadosHoraExtra[0] == "B" && DadosHoraExtra[2] == ID)
                {
                    ListHorasExtras.Add(DadosHoraExtra[1]);
                    ListHorasExtras.Add(DadosHoraExtra[2]);
                    ListHorasExtras.Add(DadosHoraExtra[3]);
                    ListHorasExtras.Add(DadosHoraExtra[4]);
                }
            }
            return ListHorasExtras;
        }
        public static void ExcluiHoraExtra(List<List<string>> Listas, string ID)
        {
            int Indice = 0;
            foreach (List<string> DadosHoraExtra in Listas)
            {
                if (DadosHoraExtra[0] == "B" && DadosHoraExtra[2] == ID)
                {
                    Indice = Listas.IndexOf(DadosHoraExtra);
                }
            }
            Listas.RemoveAt(Indice);
        }
        public static int RetornaNovoID(List<List<string>> Listas)
        {
            int Valor = 1;
            var ListHorasExtras = new List<int>();
            foreach (List<string> DadosHoraExtra in Listas)
            {
                if (DadosHoraExtra[0] == "B")
                {
                    ListHorasExtras.Add(Convert.ToInt32(DadosHoraExtra[2]));
                }
            }
            if (ListHorasExtras.Count > 0)
            {
                Valor = ListHorasExtras.Max() + 1;
            }
            return Valor;
        }

        public static void AdicionaAlteraHoraExtra(List<List<string>> Listas, HorasExtras ObjHoraExtra)
        {
            int Indice = 0;

            var ListaQueSeraAdicionada = new List<string>();            
                foreach (List<string> ListaGeral in Listas)
                        {
                                if (ListaGeral[0] == "A" && ListaGeral[1] == ObjHoraExtra.IdColaborador)
                                {
                                        Indice = Listas.IndexOf(ListaGeral);
                                }
                        }
                        ListaQueSeraAdicionada.Add("B");
                        ListaQueSeraAdicionada.Add(ObjHoraExtra.IdColaborador);
                        ListaQueSeraAdicionada.Add(ObjHoraExtra.IdHoraExtra);
                        ListaQueSeraAdicionada.Add(ObjHoraExtra.DataInicial);
                        ListaQueSeraAdicionada.Add(ObjHoraExtra.DataFinal);
                        Listas.Insert(Indice + 1, ListaQueSeraAdicionada);         
        }
    }
}
