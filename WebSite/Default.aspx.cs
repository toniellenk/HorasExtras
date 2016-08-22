using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleHorasExtras;
using System.Windows;

public partial class _Default : System.Web.UI.Page
    {


    public List<List<string>> ListagemDeDados;
    protected void Page_Load(object sender, EventArgs e)
        {
                ListagemDeDados = Controles.Dados(Controles.UrlDiretorio);
                GridPrincipal.DataSource = Colaborador.CarregaColaboradores(ListagemDeDados);
                GridPrincipal.DataBind();
        }
    }
