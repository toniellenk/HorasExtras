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
        public string IdHoraExtra { get; set; }
        public string IdColaborador { get; set; }
        public string NomeColaborador { get; set; }
        public string DataInicial { get; set; }
        public string HoraInicial { get; set; }

        public string DataFinal { get; set; }
        public string HoraFinal { get; set; }

        public static string UrlDiretorio()
        {
            return ".\\Colaboradores\\"; 
        }

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


    }
}
