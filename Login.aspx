<%@ Page language="c#" Inherits="NBADWDataEntryApplication.Login" CodeFile="Login.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload = "javascript:document.Form1.txtUserName.focus();">
		<h1>NB AQUATIC DATA WAREHOUSE</h1>
		<h2>LOGIN</h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Enter Your Login Information</legend>
				<table border="0">
					<tr>
						<td colspan="2"><asp:Label id="lblMessage" runat="server" CssClass="labelText" ForeColor="Red"></asp:Label>
						</td>
					</tr>
					<tr>
						<td><asp:Label id="Label1" runat="server" CssClass="labelText">User Name:</asp:Label>
						</td>
						<td><asp:TextBox id="txtUserName" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td><asp:Label id="Label2" runat="server" CssClass="labelText">Password:</asp:Label>
						</td>
						<td><asp:TextBox id="txtPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
						</td>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:Button id="btnSubmit" runat="server" Text="Submit" CssClass="buttonText" onclick="btnSubmit_Click"></asp:Button>
		</form>
	</body>
</HTML>
