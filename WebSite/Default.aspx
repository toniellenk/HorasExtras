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
				<div class="aba">
					<span>Colaborador</span>
				</div>
			</li>
			<li>
				<div class="aba">
					<span>Horas Extras</span>
				</div>
			</li>
		</ul>
	</div>
	<div id="content">
		<div class="conteudo">			      
                  <iframe id="FrameGrade" src="Colaborador/Colaborador.aspx" width="800" height="500" ></iframe>
		</div>
        <div class="conteudo">			      
		</div>
	</div>
</div>

    </form>
    
</body>
</html>
