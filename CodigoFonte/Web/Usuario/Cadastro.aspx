<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Web.Usuario.Cadastro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Usuário</title>
    <link rel="stylesheet" media="screen" type="text/css" href="~/Content/default.css" />
</head>
    <body>
        <div id="header" class="boxShadow">
            <div id="bar" class="boxShadow p5 radiusBottomLeft radiusBottomRight">
				<h1 class="left branco">Controle de Gastos</h1>
				<div class="cBoth"></div>
            </div>
        </div>
        <br />
		<div id="pageWrap">
			<div class="boxShadow p20 mAuto" style="width:350px;">
				<h1>Registre-se</h1><br />                
				<form runat="server" method="post"> 
                    <asp:ValidationSummary runat="server" ID="summary" />
                    <label for="txtNome">Nome Completo:
                        <asp:RequiredFieldValidator runat="server" ID="rfvNome" ControlToValidate="txtNome" Text="*" ErrorMessage="O campo Nome é obrigatório." />
                    </label>
                    <br /><asp:TextBox runat="server"  ID="txtNome" />					
					<br /><br />

                    <label for="txtEmail">Email:
                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Text="*" ErrorMessage="O campo Email é obrigatório." />
                        <asp:RegularExpressionValidator runat="server" ID="revEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*" 
                            ControlToValidate="txtEmail" ErrorMessage="O Email é inválido." />
                    </label>
                    <br /><asp:TextBox runat="server"  ID="txtEmail" />					
					<br /><br />

                    <label for="txtLogin">Login:
                        <asp:RequiredFieldValidator runat="server" ID="rfvLogin" ControlToValidate="txtLogin" Text="*" ErrorMessage="O campo Login é obrigatório." />
                    </label><br />
					<asp:TextBox runat="server"  ID="txtLogin" />					
					<br /><br />

                    <label for="txtSenha">Senha:
                        <asp:RequiredFieldValidator runat="server" ID="rfvSenha" ControlToValidate="txtSenha" Text="*" ErrorMessage="O campo Senha é obrigatório." />
                    </label><br />
					<asp:TextBox runat="server" TextMode="Password"  ID="txtSenha" />					

					<br /><br />
                    <label for="txtConfirmarSenha">Confirmar Senha:
                        <asp:RequiredFieldValidator runat="server" ID="rfvConfirmarSenha" ControlToValidate="txtConfirmarSenha" Text="*" ErrorMessage="O campo Confirmar Senha é obrigatório." />
                        <asp:CompareValidator runat="server" ID="cpvSenha" ControlToValidate="txtConfirmarSenha" ControlToCompare="txtSenha" Text="*" ErrorMessage="As senhas não estão iguais." /> 
                    </label><br />
					<asp:TextBox runat="server" TextMode="Password"  ID="txtConfirmarSenha" />					
					<br /><br />

					<asp:Button runat="server" Text="Cadastrar" ID="btnEnviar" onclick="btnEnviar_Click" />
                    <asp:Button runat="server" Text="Cancelar" PostBackUrl="~/Login.aspx" CausesValidation="false" />
				</form>
			</div>
		</div>
    </body>
</html>
