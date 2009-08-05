<%@ Page language="c#" Inherits="NBADWDataEntryApplication.TLDList" CodeFile="TLDList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TLDList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/NBADWDataEntryApplication/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1>WATER TEMPERATURES</h1>
		<h2>LOGGER LIST</h2>
		<form id="Form1" method="post" runat="server">
			<fieldset class="standardText"><legend>Instructions</legend>
				<ul>
					<li>
					Listed below are the loggers that have been installed at this site.
					<li>
						You may view (or edit if you have permission) the details of a particular 
						logger by pressing <b><u>View</u></b>
					in the row containing the logger of interest.
					<li>
						Data Entry Users: Press <b>Add New Logger</b> to add a new logger installation 
						to this site.</li></ul>
			</fieldset>
			<br>
			<fieldset class="standardText"><legend>Site Info</legend>
				<table width="100%" border="0">
					<tr>
						<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="labelText">Aquatic Site ID:</asp:label><br>
							<asp:textbox id="txtdwsiteid" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
						<td vAlign="top"><asp:label id="Label6" runat="server" CssClass="labelText">Site Name:</asp:label><br>
							<asp:textbox id="txtsitename" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"></td>
						<td vAlign="top"><asp:label id="Label7" runat="server" CssClass="labelText">Site Description:</asp:label><br>
							<asp:textbox id="txtsitedescription" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:label id="Label9" runat="server" CssClass="labelText">Agency Code:</asp:label><br>
							<asp:textbox id="txtagencycd" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
						<td vAlign="top"><asp:label id="Label2" runat="server" CssClass="labelText">Agency Site ID:</asp:label><br>
							<asp:textbox id="txtgroupsiteid" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
					</tr>
					<TR>
						<TD vAlign="top"><asp:label id="Label3" runat="server" CssClass="labelText">Water Body ID:</asp:label><br>
							<asp:textbox id="txtwaterbodyid" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></TD>
						<td vAlign="top"><asp:label id="Label4" runat="server" CssClass="labelText">Water Body Name:</asp:label><br>
							<asp:textbox id="txtwaterbodyname" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><br>
						</td>
					</TR>
					<tr>
						<td vAlign="top"><asp:label id="Label8" runat="server" CssClass="labelText">Watershed Code:</asp:label><br>
							<asp:textbox id="txtwatershedcode" runat="server" Enabled="False" BackColor="WhiteSmoke"></asp:textbox></td>
						<TD vAlign="top"><asp:label id="Label5" runat="server" CssClass="labelText">Watershed:</asp:label><br>
							<asp:textbox id="txtwatershed" runat="server" Enabled="False" BackColor="WhiteSmoke" Width="520px"></asp:textbox><br>
						</TD>
					</tr>
				</table>
			</fieldset>
			<br>
			<asp:button id="btnAdd" runat="server" Visible="False" Text="Add New Logger" ToolTip="Adds a new logger to current site" onclick="btnAdd_Click"></asp:button><asp:button id="Button2" runat="server" CssClass="buttonText" Text="Return to Site List" onclick="Button2_Click"></asp:button><br>
			<br>
			<fieldset class="standardText"><legend>Data Loggers</legend><asp:datagrid id=dgLoggers runat="server" CssClass="enclosedgridItem" BackColor="White" AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSource="<%# dvDE_Loggers %>" ShowFooter="True" DataKeyField="TemperatureLoggerID">
					<FooterStyle ForeColor="#000066" BackColor="LightSteelBlue"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
					<ItemStyle HorizontalAlign="Center" ForeColor="#000066"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom"
						BackColor="LightSteelBlue"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="View"></asp:EditCommandColumn>
						<asp:BoundColumn DataField="LoggerNo" HeaderText="Logger No"></asp:BoundColumn>
						<asp:BoundColumn DataField="AgencyCd" SortExpression="AgencyCd" HeaderText="Agency"></asp:BoundColumn>
						<asp:BoundColumn DataField="DataFileName" HeaderText="Data File Name"></asp:BoundColumn>
						<asp:BoundColumn DataField="SampleInterval_min" HeaderText="Sample&lt;br&gt;Interval"></asp:BoundColumn>
						<asp:BoundColumn DataField="RecordingStartDate" SortExpression="RecordingStartDate" HeaderText="Data Begins"></asp:BoundColumn>
						<asp:BoundColumn DataField="RecordingEndDate" HeaderText="Data Ends"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></fieldset>
		</form>
	</body>
</HTML>
