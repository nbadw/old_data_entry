<%@ Page language="c#" Inherits="NBADWDataEntryApplication.ConfirmDelete" CodeFile="ConfirmDelete.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConfirmSave</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>
			<asp:Label id="lblH1" runat="server" Font-Bold="True" Font-Names="Times New Roman"></asp:Label></h1>
		<h2>Delete Confirmation</h2>
		<table align="center" border="0">
			<tr>
				<td align="center">
					<asp:Label id="lblDeleteMessage" Font-Bold="True" runat="server" CssClass="labelText">Record Deleted</asp:Label>
				</td>
			</tr>
			<tr>
				<td align="center"><form id="Form1" method="post" runat="server">
						<asp:Button id="btnReturn" runat="server" Text="Return to List" CssClass="buttonText" onclick="btnReturn_Click"></asp:Button>
					</form>
				</td>
			</tr>
		</table>
	</body>
</HTML>
