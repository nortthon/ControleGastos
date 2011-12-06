<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Web.Usuario.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link rel="stylesheet" media="screen" type="text/css" href="~/Content/default.css" />
</head>
    <body>
        <div id="header" class="boxShadow">
            <div id="bar" class="boxShadow p5 radiusBottomLeft radiusBottomRight">
				<h1 class="left branco">Controle de Gastos</h1>
				<div class="cBoth"></div>
            </div>
        </div>
		<div id="pageWrap"><br /><br />
			<div class="boxShadow p10 mAuto" style="width:350px;">
				<p style="text-align:center">
					Erro ao executar a operação.<br />
				</p>
				<form id="Form1" runat="server" style="text-align:center">
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" PostBackUrl="javascript:history.back();" />
				</form>
			</div>
		</div>
    </body>
</html>