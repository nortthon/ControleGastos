<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>Painel de Controle</h1>
	<hr />
	<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque posuere fringilla mauris, sed tristique magna ultricies sit amet. Vivamus risus metus, viverra eu auctor sed, posuere quis libero. Aliquam tincidunt bibendum ipsum et tristique. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam commodo iaculis ultricies. In eget nulla at ante sodales suscipit ac vel elit.</p>
	<fieldset>
		<legend>Fieldset</legend>
			<p>Curabitur metus justo, egestas et sagittis in, ornare at nunc. Vivamus nunc sapien, sodales eget lobortis non, accumsan sed diam. Aliquam et nulla id felis suscipit sollicitudin.</p>
	</fieldset>
	<br />
	<form action="#" method="post">
		<label>
			Nome<br />
			<input type="text" />
		</label>
		<br /><br />
		<label>
			<input type="checkbox" />
			É oi?
		</label>
		<br /><br />
		<select>
			<option>Janeiro</option>
			<option>Fevereiro</option>
			<option>Março</option>
			<option>Abril</option>
			<option>Maio</option>
			<option>Junho</option>
			<option>Julho</option>
			<option>Agosto</option>
			<option>Setembro</option>
			<option>Outubro</option>
			<option>Novembro</option>
			<option>Dezembro</option>
		</select>
	</form>
	<hr />
	<table>
		<thead>
		<tr>
			<th>Mês</th>
			<th>Resposável</th>
			<th>Caixa</th>
		</tr>
		</thead>
		<tfoot>
		<tr>
			<td>Total</td>
			<td>- - - -</td>
			<td>R$ 180</td>
		</tr>
		</tfoot>
		<tbody>
		<tr>
			<td>Janeiro</td>
			<td>Fifi</td>
			<td>R$ 100</td>
		</tr>
		<tr>
			<td>Fevereiro</td>
			<td>Suckys</td>
			<td>R$ 80</td>
		</tr>
		</tbody>
	</table>
	<hr />
	<ul>
		<li>Lista</li>
		<ol>
			<li>Green</li>
			<li>Red</li>
			<ol>
				<li>Orange</li>
				<li>Purple</li>
			</ol>
			<li>Blue</li>
		</ol>
		<li>Microsoft</li>
		<li>Apple</li>
		<li>Y7</li>
		<li>Yotta</li>
	</ul>
</asp:Content>
