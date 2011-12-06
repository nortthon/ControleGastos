<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarSenha.aspx.cs" Inherits="Web.RecuperarSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Recuperar Senha</title>
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
				<p>
					Digite seu email no campo abaixo para receber a nova senha em seu email.
				</p>
				<form runat="server" method="post">
                    <asp:ValidationSummary runat="server" ID="summary" />
					<label for="txtEmail">Email:
                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Text="*" ErrorMessage="O campo Email é obrigatório." />
                        <asp:RegularExpressionValidator runat="server" ID="revEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*" 
                            ControlToValidate="txtEmail" ErrorMessage="O Email é inválido." />
                    </label>
                    <br /><asp:TextBox runat="server"  ID="txtEmail" />					
					<br /><br />

                    <asp:Button runat="server" Text="Enviar" ID="btnEnviar" 
                        onclick="btnEnviar_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Cancelar" PostBackUrl="~/Login.aspx" CausesValidation="false" />
				</form>
			</div>
		</div>
    </body>
</html>
