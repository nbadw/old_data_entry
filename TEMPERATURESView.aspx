<%@ Page language="c#" Inherits="NBADWDataEntryApplication.TEMPView" CodeFile="TEMPERATURESView.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TEMPView</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h1>WATER TEMPERATURES</h1>
			<h2><asp:label id="lblh2" runat="server" Font-Names="Times New Roman" Font-Bold="True">VIEW Temperature Data</asp:label></h2>
			<fieldset class="standardText"><legend>Instructions</legend>
				<ul>
					<li>
						Click on <u>Date</u>
					column heading to sort by date.
					<li>
						Click <b>Close</b> button when finished.</li>
				</ul>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Site and Logger Info</legend>
				<table width="100%" border="0">
					<tr>
						<td><asp:label id="Label1" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label>
						<td><asp:textbox id="txtdwsiteid" tabIndex="1" runat="server" BackColor="WhiteSmoke" Enabled="False"
								Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label2" runat="server" CssClass="labelText">Agency Code:</asp:label>
						<td><asp:textbox id="txtagencycd" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox></td>
					</tr>
					<TR>
						<td><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label>
						<td><asp:textbox id="txtwaterbodyname" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"
								Rows="2"></asp:textbox>
						</td>
					</TR>
					<tr>
						<td><asp:label id="Label8" runat="server" CssClass="labelText">Logger ID:</asp:label>
						<td><asp:textbox id="txtloggerid" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="520px"></asp:textbox></td>
					</tr>
				</table>
			</fieldset>
			<br>
			<input type="button" value="Close" onclick="window.close()">
			<br>
			<br>
			<asp:datagrid id="dgTemperatures" runat="server" CssClass="gridItem" BackColor="White" AutoGenerateColumns="False"
				BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ShowFooter="True" DataSource="<%# dvDE_Temperature2 %>" AllowSorting="True">
				<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Bottom" BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="AquaticActivityStartDate" SortExpression="AquaticActivityStartDate" HeaderText="Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="84" SortExpression="84" HeaderText="Average Water Temperature"></asp:BoundColumn>
					<asp:BoundColumn DataField="85" SortExpression="85" HeaderText="Minimum Water Temperature"></asp:BoundColumn>
					<asp:BoundColumn DataField="86" SortExpression="86" HeaderText="Maximum Water Temperature"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<br>
		</form>
	</body>
</HTML>
