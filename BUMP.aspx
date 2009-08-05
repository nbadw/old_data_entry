<%@ Page language="c#" Inherits="NBADWDataEntryApplication.BUMP" CodeFile="BUMP.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BUMP</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<table>
				<tr>
					<td>Administrator</td>
					<td><asp:radiobuttonlist id="rbAdmin" runat="server">
							<asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
							<asp:ListItem Value="No">No</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td>Site Type</td>
					<td><asp:radiobuttonlist id="rbSType" runat="server">
							<asp:ListItem Value="New Site" Selected="True">New Site</asp:ListItem>
							<asp:ListItem Value="New Use">New Use</asp:ListItem>
							<asp:ListItem Value="Existing">Existing</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td>Selected Site ID
						<asp:checkbox id="chkSite" runat="server" Checked="True"></asp:checkbox></td>
					<td><asp:textbox id="txtSiteID" runat="server">529</asp:textbox></td>
				</tr>
				<tr>
					<td>Selected Site Use ID
						<asp:checkbox id="chkSiteUse" runat="server" Checked="True"></asp:checkbox></td>
					<td><asp:textbox id="txtSiteUseID" runat="server">886</asp:textbox></td>
				</tr>
				<tr>
					<td>Page Mode</td>
					<td><asp:radiobuttonlist id="rbMode" runat="server">
							<asp:ListItem Value="View" Selected="True">View</asp:ListItem>
							<asp:ListItem Value="Add New">Add New</asp:ListItem>
							<asp:ListItem Value="Add Existing">Add Existing</asp:ListItem>
							<asp:ListItem Value="Add">Add</asp:ListItem>
							<asp:ListItem Value="Modify">Modify</asp:ListItem>
							<asp:ListItem Value="ModifySite">ModifySite</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td>Page Version</td>
					<td><asp:radiobuttonlist id="rbVersion" runat="server">
							<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
							<asp:ListItem Value="2">2</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td>User Agency</td>
					<td><asp:textbox id="txtUserAgency" runat="server">ASF</asp:textbox></td>
				</tr>
			</table>
			<asp:button id="Button1" runat="server" Text="TRSView" onclick="Button1_Click"></asp:button><asp:button id="Button2" runat="server" Text="TLDView" Visible="False" onclick="Button2_Click"></asp:button><asp:button id="Button3" runat="server" Text="ESAFSiteObservations" Visible="False" onclick="Button3_Click"></asp:button><asp:button id="Button4" runat="server" Text="Map" Visible="False" onclick="Button4_Click"></asp:button>
			<asp:Button id="Button5" runat="server" Text="WaterbodySearch" Visible="False" onclick="Button5_Click"></asp:Button>
			<asp:Button id="Button6" runat="server" Text="STKView" onclick="Button6_Click"></asp:Button>
			<asp:Button id="Button7" runat="server" Text="STKList" onclick="Button7_Click"></asp:Button>
			<asp:Button id="Button8" runat="server" Text="Confirm Save" onclick="Button8_Click"></asp:Button>
			<asp:Button id="Button9" runat="server" Text="Confirm Delete" onclick="Button9_Click"></asp:Button>
			<asp:Button id="Button10" runat="server" Text="Confirm Delete No" onclick="Button10_Click"></asp:Button></form>
	</body>
</HTML>
