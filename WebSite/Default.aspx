<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" type="text/css" href="StyleSite.css" title="Home" />
    <script type="text/javascript" src="jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="JavaScript.js"></script>

</head>
<body runat="server">
    <form id="form1" runat="server">
        <div class="TabControl">
	                <div id="PaiAbas">
		                <ul class="abas">
			                <li>
				                <div id="aba1" class="ClassAba1" runat="server">
                                    <span>Colaborador</span>
			                    </div>
			                </li>
			                <li>
				                <div  id="aba2" class="ClassAba2" runat="server" >
					                <span>Horas Extras</span>
				                </div>
			                </li>
		                </ul>
	                </div>
	                <div id="content">
		                    <div class="conteudo">
                                <br/>    
                                    <asp:Label ID="NomeModulo" class="Titulo" runat="server"></asp:Label>
                                <br/>		
                                <br/>	      
                                <%--      <iframe id="FrameGrade" src="Colaborador/Colaborador.aspx" width="800" height="500" ></iframe>--%>
                                     <asp:GridView runat="server" 
                                         ID="GridPrincipal" 
                                         onrowdatabound="gvSetor_RowDataBound" 
                                         AlternatingRowStyle-BackColor="#EFEFEF" 
                                         Height="100%" Width="100%" 
                                         BackColor="White" 
                                         BorderColor="#D5EDFF" 
                                           AutoGenerateSelectButton="True"
                                         onselectedindexchanged="CustomersGridView_SelectedIndexChanged"
                                         onselectedindexchanging="CustomersGridView_SelectedIndexChanging"                                                                                                                        
                                         
                                         SelectedRowStyle-Wrap="False" SelectedRowStyle-BackColor="#33CCFF"></asp:GridView>
                                <br/>	     
                                <asp:Button runat="server" Text="Novo" ID="BtnNovo" class="Botoes"/> <asp:Button runat="server" Text="Alterar" ID="BtnAlterar"  class="Botoes"/> <asp:Button runat="server" Text="Remover" ID="BtnRemover"  class="Botoes"/>
                           
		                     </div>
	                </div>
        </div>
    </form>
    
</body>
</html>
