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
		<div id="pageWrap">
			<div class="boxShadow p10 mAuto" style="width:250px;">
				<p>
					Por favor <strong>entre com seu usuário e senha</strong> nos campos abaixo.<br />
					Se você ainda não é registrado, <a href="Usuario/Cadastro.aspx">registre-se</a>.
				</p>
				<form action="Login.aspx" method="post">
					<label>
						Username<br />
						<input name="username" type="text" />
					</label>
					<br /><br />
					<label>
						Password<br />
						<input name="password" type="password" />
					</label>
					<br />
					<a href="Usuario/RecuperarSenha.aspx">Esqueceu sua senha?</a>
					<br /><br />
					<input type="submit" value="Efetuar login" />
				</form>
			</div>
		</div>
    </body>
</html>
