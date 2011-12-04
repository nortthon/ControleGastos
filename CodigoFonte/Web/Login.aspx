<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" media="screen" type="text/css" href="Content/default.css" />
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
					Se você já é cadastrado basta preencher seu Login e senha e clicar em <strong>Efetuar Login</strong> para continuar.<br />
					Se você ainda não é, <a href="Usuario/Cadastro.aspx" class="bold">registre-se</a>.
				</p>
				<form runat="server" method="post">
                    <asp:ValidationSummary runat="server" ID="summary" />
					<label for="txtLogin">Login:
                        <asp:RequiredFieldValidator runat="server" ID="rfvLogin" ControlToValidate="txtLogin" Text="*" ErrorMessage="O campo Login é obrigatório." />
                    </label><br />
					<asp:TextBox runat="server"  ID="txtLogin" />					
					<br /><br />

                    <label for="txtSenha">Senha:
                        <asp:RequiredFieldValidator runat="server" ID="rfvSenha" ControlToValidate="txtSenha" Text="*" ErrorMessage="O campo Senha é obrigatório." />
                    </label><br />
					<asp:TextBox runat="server" TextMode="Password"  ID="txtSenha" />

					<br />
					<a href="Usuario/RecuperarSenha.aspx">Esqueceu sua senha?</a>
					<br /><br />
                    <asp:Button runat="server" Text="Efetuar login" ID="btnLogin" 
                        onclick="btnLogin_Click" />
				</form>
			</div>
		</div>
    </body>
</html>
