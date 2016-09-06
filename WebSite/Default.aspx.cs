using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleHorasExtras;
using System.Windows;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page, IPostBackEventHandler
{


    public List<List<string>> ListagemDeDados;


    protected void Page_Load(object sender, EventArgs e)
        {
                ListagemDeDados = Controles.Dados(Controles.UrlDiretorio);
                Session["ListagemDeDados"] = ListagemDeDados;
                aba1.Attributes["onclick"] = ClientScript.GetPostBackEventReference(this, "ClickDivColaborador");
                aba2.Attributes["onclick"] = ClientScript.GetPostBackEventReference(this, "ClickDivHoraExtra");
                if (GridPrincipal.Rows.Count < 1)
                {
                    BtnNovo.Visible = false;
                    BtnAlterar.Visible = false;
                    BtnRemover.Visible = false;
                }
     //   MessageBox("teste");

    }

    protected void gvSetor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                                        if (e.Row.RowIndex % 2 == 1)
                                        {
                                                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#EFEFEF'");
                                        }
                                        else
                                        {
                                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
                                        }
                                        e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D5EDFF'");
                                        e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridPrincipal, "Select$" + e.Row.RowIndex.ToString()));
                    break;
            }
        }
        catch
        {
            //...throw
        }

    }



    protected void DivColaborador_Click()

    {
        NomeModulo.Text = "Manutenção de Colaboradores";
        GridPrincipal.DataSource = Colaborador.CarregaColaboradores(ListagemDeDados);
        GridPrincipal.DataBind();
        BtnNovo.Visible = true;
        BtnAlterar.Visible = true;
        BtnRemover.Visible = true;
    }

    protected void DivHoraExtra_Click()

    {
        NomeModulo.Text = "Manutenção de Horas Extras";
        GridPrincipal.DataSource = HorasExtras.CarregaHorasExtras(ListagemDeDados);
        GridPrincipal.DataBind();
        BtnNovo.Visible = true;
        BtnAlterar.Visible = true;
        BtnRemover.Visible = true;
    }

    public void CustomersGridView_SelectedIndexChanged(Object sender, EventArgs e)
    {
        GridViewRow row = GridPrincipal.SelectedRow;
        
        row.Cells[GridPrincipal.SelectedRow.RowIndex].Font.Size = 15;
        MessageBox("Você selecionou " + row.Cells[2].Text + ".");
    }

    public void CustomersGridView_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = GridPrincipal.Rows[e.NewSelectedIndex];
        GridPrincipal.Font.Size = 12;

        if (row.Cells[1].Text == "ANATR")
        {
            e.Cancel = true;
            GridPrincipal.SelectedRow.BackColor = System.Drawing.Color.Aqua;
            MessageBox("Você des-selecionou " + row.Cells[2].Text + ".");
        }
    }

    #region IPostBackEventHandler Members

    public void RaisePostBackEvent(string eventArgument)

    {

        if (!string.IsNullOrEmpty(eventArgument))

        {

            if (eventArgument == "ClickDivColaborador")

            {

                DivColaborador_Click();

            }
            if (eventArgument == "ClickDivHoraExtra")

            {

                DivHoraExtra_Click();

            }

        }

    }


    #endregion

    private void MessageBox(string menssagem)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notificação", "alert('"+ menssagem + "');", true);
    }



}
